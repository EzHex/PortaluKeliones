using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Portalai.Models;
using System.Diagnostics;
using static System.Math;
using Route = Portalai.Models.Route;

namespace Portalai.Controllers
{
    public class RouteController : Controller
    {
        private readonly PortalsDbContext context;

        public RouteController(PortalsDbContext context)
        {
            this.context = context;
        }

        public async Task<ActionResult> ShowRoutes()
        {
            var routes = await context.Routes.ToListAsync();

            return View("RoutesAdminList", routes);
        }

        public async Task<ActionResult> ShowCreateForm()
        {
            var route = new Route();

            await route.LoadAvailableDropdowns(context);

            return View("RouteCreate", route);
        }


        [HttpPost]
        public async Task<ActionResult> Create(int? save, int? add, int? remove, Route route)
        {
            if (add != null)
            {
                // var routeVoyage = new RouteVoyage(0, DateTime.MinValue, DateTime.MinValue);
                // routeVoyage.ListId = route.RouteVoyages.Count > 0 ? route.RouteVoyages.Max(it => it.ListId) + 1 : 0;
                //
                // route.RouteVoyages.Add(routeVoyage);
                //
                // ModelState.Clear();
                //
                // await route.LoadAvailableDropdowns(context);
                //
                // return View("RouteCreate", route);
            }

            if (remove != null)
            {
                route.RouteVoyages = route
                    .RouteVoyages
                    .Where(it => it.ListId != remove.Value)
                    .ToList();

                ModelState.Clear();

                await route.LoadAvailableDropdowns(context);

                return View("RouteCreate", route);
            }

            //if (save != null)
            //{
            //    //form field validation passed?
            //    if (ModelState.IsValid)
            //    {
            //        //create new 'Sutartis'
            //        sutartisEvm.Sutartis.Nr = SutartisRepo.Insert(sutartisEvm);

            //        //create new 'UzsakytosPaslaugos' records
            //        foreach (var upVm in sutartisEvm.UzsakytosPaslaugos)
            //            UzsakytaPaslaugaRepo.Insert(sutartisEvm.Sutartis.Nr, upVm);

            //        //save success, go back to the entity list
            //        return RedirectToAction("Index");
            //    }
            //    //form field validation failed, go back to the form
            //    else
            //    {
            //        PopulateLists(sutartisEvm);
            //        return View(sutartisEvm);
            //    }
            //}

            throw new Exception("Should not reach here.");
        }

        public async Task<ActionResult> ShowRoutePlanning()
        {
            var places = await context.Places.ToListAsync();

            return View("RoutePlan", places);
        }

        private static double CalculateDistance(Place place1, Place place2)
        {
            const double p = PI / 180;
            var a = 0.5 - Cos((place2.Latitude - place1.Latitude) * p) / 2 +
                    Cos(place1.Latitude * p) * Cos(place2.Latitude * p) *
                    (1 - Cos((place2.Longitude - place1.Longitude) * p)) / 2;
            return 12742 * Asin(Sqrt(a));
        }

        class Chromosome
        {
            public Place StartPlace { get; private set; }
            public Place EndPlace { get; private set; }
            public List<Place> Places { get; private set; }
            public int TravelersCount { get; private set; }
            public List<int> Travelers { get; private set; }
            public double TimePerLocation { get; private set; }
            public double TimePerKilometer { get; private set; }
            public double TimeBeforeBreak { get; private set; }
            public double BreakTime { get; private set; }

            private static readonly Random random = new Random();

            public Chromosome(Place startPlace, Place endPlace, List<Place> places, int travelersCount,
                              double timePerLocation, double timePerKilometer, double timeBeforeBreak, double breakTime)
            {
                StartPlace = startPlace;
                EndPlace = endPlace;
                Shuffle(places);
                Places = places;
                TravelersCount = travelersCount;
                Travelers = new List<int>();
                for (int i = 0; i < places.Count; i++)
                {
                    Travelers.Add(random.Next(1, travelersCount + 1));
                }
                TimePerLocation = timePerLocation;
                TimePerKilometer = timePerKilometer;
                TimeBeforeBreak = timeBeforeBreak;
                BreakTime = breakTime;
            }

            public Chromosome(Place startPlace, Place endPlace, List<Place> places, int travelersCount, List<int> travelers,
                              double timePerLocation, double timePerKilometer, double timeBeforeBreak, double breakTime)
            {
                StartPlace = startPlace;
                EndPlace = endPlace;
                Places = places;
                TravelersCount = travelersCount;
                Travelers = travelers;
                TimePerLocation = timePerLocation;
                TimePerKilometer = timePerKilometer;
                TimeBeforeBreak = timeBeforeBreak;
                BreakTime = breakTime;
            }

            public override string ToString()
            {
                string line = "";
                for (int i = 1; i <= TravelersCount; i++)
                {
                    List<Place> travelersPlaces = new List<Place>();
                    travelersPlaces.Add(StartPlace);
                    for (int j = 0; j < Places.Count; j++)
                    {
                        if (Travelers[j] == i)
                        {
                            travelersPlaces.Add(Places[j]);
                        }
                    }
                    travelersPlaces.Add(EndPlace);
                    for (int j = 0; j < travelersPlaces.Count; j++)
                    {
                        line += travelersPlaces[j].Name;
                        if (j != travelersPlaces.Count - 1)
                        {
                            line += "->";
                        }
                    }
                    if (i != TravelersCount)
                    {
                        line += "\n\n";
                    }
                }
                return line;
            }

            public double GetFitnessByTime()
            {
                double maxTripTime = 0;
                for (int i = 1; i <= TravelersCount; i++)
                {
                    double distance = 0;
                    double tripTime = 0;
                    List<Place> travelersPlaces = new List<Place>();
                    travelersPlaces.Add(StartPlace);
                    for (int j = 0; j < Places.Count; j++)
                    {
                        if (Travelers[j] == i)
                        {
                            travelersPlaces.Add(Places[j]);
                        }
                    }
                    travelersPlaces.Add(EndPlace);
                    for (int j = 0; j < travelersPlaces.Count - 1; j++)
                    {
                        distance += CalculateDistance(travelersPlaces[j], travelersPlaces[j + 1]);
                        tripTime += distance / 1000 * TimePerKilometer + TimePerLocation;
                    }
                    int breaksCount = (int)(tripTime / TimeBeforeBreak);
                    tripTime += breaksCount * BreakTime;
                    if (tripTime > maxTripTime)
                    {
                        maxTripTime = tripTime;
                    }
                }
                return maxTripTime;
            }

            public double GetFitnessByPrice()
            {
                double distance = 0;
                List<Place> places = new List<Place>();
                places.Add(StartPlace);
                places.AddRange(Places);
                places.Add(EndPlace);
                for (int i = 0; i < places.Count - 1; i++)
                {
                    distance += CalculateDistance(places[i], places[i + 1]);
                }
                return Cbrt(distance);
            }

            private void Shuffle(List<Place> places)
            {
                int n = places.Count;
                while (n > 1)
                {
                    int k = random.Next(n--);
                    Place temp = places[n];
                    places[n] = places[k];
                    places[k] = temp;
                }
            }
        }

        class Population
        {
            public int Size { get; private set; }
            public List<Chromosome> Chromosomes { get; private set; }

            public Population(int size, Place startPlace, Place endPlace, List<Place> places, int travelersCount,
                              double timePerLocation, double timePerKilometer, double timeBeforeBreak, double breakTime)
            {
                Size = size;
                Chromosomes = new List<Chromosome>();
                for (int i = 0; i < size; i++)
                {
                    Chromosomes.Add(new Chromosome(startPlace, endPlace, places, travelersCount,
                                                   timePerLocation, timePerKilometer, timeBeforeBreak, breakTime));
                }
            }

            public Population(int size)
            {
                Size = size;
                Chromosomes = new List<Chromosome>();
            }

            public void AddChromosome(Chromosome chromosome)
            {
                Chromosomes.Add(chromosome);
            }

            public Chromosome GetFittest()
            {
                List<Chromosome> sortedList = Chromosomes.OrderBy(x => x.GetFitnessByTime())
                                                         .ThenBy(x => x.GetFitnessByPrice())
                                                         .ToList();
                return sortedList[0];
            }

            public Chromosome GetFittest(int index)
            {
                List<Chromosome> sortedList = Chromosomes.OrderBy(x => x.GetFitnessByTime())
                                                         .ThenBy(x => x.GetFitnessByPrice())
                                                         .ToList();
                return sortedList[index];
            }
        }

        class GeneticAlgorithm
        {
            public double MutationRate { get; private set; }
            public int EliteSize { get; private set; }
            public int TournamentSize { get; private set; }

            private static readonly Random random = new Random();

            public GeneticAlgorithm(double mutationRate, int eliteSize, int tournamentSize)
            {
                MutationRate = mutationRate;
                EliteSize = eliteSize;
                TournamentSize = tournamentSize;
            }

            public Population EvolvePopulation(Population population)
            {
                Population newPopulation = new Population(population.Size);
                for (int i = 0; i < EliteSize; i++)
                {
                    newPopulation.Chromosomes.Add(population.GetFittest(i));
                }
                for (int i = EliteSize; i < population.Size; i++)
                {
                    Chromosome chromosome1 = TournamentSelection(population);
                    Chromosome chromosome2 = TournamentSelection(population);
                    Chromosome newChromosome = CrossoverAndMutate(chromosome1, chromosome2);
                    newPopulation.AddChromosome(newChromosome);
                }
                return newPopulation;
            }

            private Chromosome CrossoverAndMutate(Chromosome chromosome1, Chromosome chromosome2)
            {
                int cutPoint = random.Next(1, chromosome1.Places.Count);
                List<Place> places = chromosome1.Places.GetRange(0, cutPoint);
                List<int> travelers = chromosome1.Travelers.GetRange(0, cutPoint);
                for (int i = 0; i < chromosome2.Places.Count; i++)
                {
                    for (int j = cutPoint; j < chromosome1.Places.Count; j++)
                    {
                        if (chromosome2.Places[i].Id.Equals(chromosome1.Places[j].Id))
                        {
                            places.Add(chromosome2.Places[i]);
                            travelers.Add(chromosome2.Travelers[i]);
                        }
                    }
                }
                for (int i = 0; i < places.Count; i++)
                {
                    if (random.NextDouble() < MutationRate)
                    {
                        int index = random.Next(0, places.Count);
                        Place temp1 = places[i];
                        int temp2 = travelers[i];
                        places[i] = places[index];
                        travelers[i] = travelers[index];
                        places[index] = temp1;
                        travelers[index] = temp2;
                    }
                }
                Place startPlace = chromosome1.StartPlace;
                Place endPlace = chromosome1.EndPlace;
                int travelersCount = chromosome1.TravelersCount;
                double timePerLocation = chromosome1.TimePerLocation;
                double timePerKilometer = chromosome1.TimePerKilometer;
                double timeBeforeBreak = chromosome1.TimeBeforeBreak;
                double breakTime = chromosome1.BreakTime;
                Chromosome newChromosome = new Chromosome(startPlace, endPlace, places, travelersCount, travelers,
                                                          timePerLocation, timePerKilometer, timeBeforeBreak, breakTime);
                return newChromosome;
            }

            private Chromosome TournamentSelection(Population population)
            {
                Population tournament = new Population(TournamentSize);
                for (int i = 0; i < TournamentSize; i++)
                {
                    tournament.AddChromosome(population.Chromosomes[random.Next(1, population.Size)]);
                }
                return tournament.GetFittest();
            }
        }

        [HttpPost]
        public async Task<ActionResult> PostRoutePlan(IFormCollection form)
        {
            ViewBag.StartPlaceId = form["StartPlace"].ToString();
            ViewBag.EndPlaceId = form["EndPlace"].ToString();
            ViewBag.PlaceIds = form["Places"].ToList();
            ViewBag.TimePerLocation = form["TimePerLocation"].ToString();
            ViewBag.TimePerKilometer = form["TimePerKilometer"].ToString();
            ViewBag.TimeBeforeBreak = form["TimeBeforeBreak"].ToString();
            ViewBag.BreakTime = form["BreakTime"].ToString();

            var places = await context.Places.ToListAsync();

            var startPlaceId = Convert.ToInt32(form["StartPlace"]);
            if (startPlaceId == -1)
            {
                ViewBag.Error1 = "Nepasirinkta pradžios vietovė";
                return View("RoutePlan", places);
            }
            var endPlaceId = Convert.ToInt32(form["EndPlace"]);
            if (endPlaceId == -1)
            {
                ViewBag.Error2 = "Nepasirinkta pabaigos vietovė";
                return View("RoutePlan", places);
            }
            var placeIds = form["Places"].ToList();
            if (placeIds.Count == 0)
            {
                ViewBag.Error3 = "Nepasirinkta nei viena tarpinė vietovė";
                return View("RoutePlan", places);
            }
            var timePerPlace = 0.0;
            var timePerKilometer = 0.0;
            var timeBeforeBreak = 0.0;
            var breakTime = 0.0;
            try
            {
                timePerPlace = Convert.ToDouble(form["TimePerLocation"]);
                timePerKilometer = Convert.ToDouble(form["TimePerKilometer"]);
                timeBeforeBreak = Convert.ToDouble(form["TimeBeforeBreak"]);
                breakTime = Convert.ToDouble(form["BreakTime"]);
            }
            catch (FormatException ex)
            {
                ViewBag.Error4 = "Netinkamas skaičiaus formatas";
                return View("RoutePlan", places);
            }
            if (timePerPlace <= 0.0 || timePerKilometer <= 0.0 || timeBeforeBreak <= 0.0)
            {
                ViewBag.Error5 = "Laikas vietovei aplankyti, keliavimo greitis, keliavimo laikas iki pertraukos turi būti didesni už 0";
                return View("RoutePlan", places);
            }
            if (breakTime < 0.0)
            {
                ViewBag.Error6 = "Petraukos laikas negali būti neigiamas";
                return View("RoutePlan", places);
            }

            var startPlace = await context.Places.SingleAsync(p => p.Id == startPlaceId);
            var endPlace = await context.Places.SingleAsync(p => p.Id == endPlaceId);
            var selectedPlaces = await context.Places.Where(p => placeIds.Contains(p.Id.ToString())).ToListAsync();
            Population population = new Population(10, startPlace, endPlace, selectedPlaces, 1, timePerPlace, timePerKilometer, timeBeforeBreak, breakTime);
            GeneticAlgorithm geneticAlgorithm = new GeneticAlgorithm(0.05, 5, 3);

            Chromosome fittest = population.GetFittest();
            int generation = 2;
            int sameIterationCount = 1;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            while (sameIterationCount <= 1000 && stopwatch.Elapsed.TotalSeconds < 60)
            {
                Chromosome lastFittest = fittest;
                population = geneticAlgorithm.EvolvePopulation(population);
                fittest = population.GetFittest();
                if (lastFittest.GetFitnessByTime() != fittest.GetFitnessByTime() || lastFittest.GetFitnessByPrice() != fittest.GetFitnessByPrice())
                {
                    sameIterationCount = 1;
                }
                sameIterationCount++;
                generation++;
            }
            stopwatch.Stop();

            var routePlan = fittest.ToString();
            ViewBag.RoutePlan = routePlan;

            return View("RoutePlan", places);
        }

        public async Task<ActionResult> ShowRoutesSearch()
        {
            var routes = await context.Routes.ToListAsync();
            foreach (var route in routes)
            {
                //TODO fix this
                // route.RouteVoyages = await context.RouteVoyages.Where(rv => rv.Routes.Id == route.Id).ToListAsync();
                //
                // foreach (var routeVoyage in route.RouteVoyages)
                // {
                //     routeVoyage.Places = await context.Places.Where(p => p.RouteVoyages.Contains(routeVoyage)).ToListAsync();
                //     
                //     routeVoyage.Places.ForEach(p =>
                //     {
                //         if (!route.Places.Contains(p))
                //         {
                //             route.Places.Add(p);   
                //         }
                //     });
                // }
            }

            return View("RouteSearch", routes);
        }

        [HttpPost]
        public async Task<ActionResult> PostSearch()
        {
            var form = Request.Form;
            var routes = await context.Routes.ToListAsync();
            
            var filteredRoutes = new System.Collections.Generic.List<Route>();
            
            int departureCityId = 0;
            int arrivalCityId = 0;
            DateTime departureDate = DateTime.Now;
            DateTime arrivalDate = DateTime.Now;

            if (form.ContainsKey("departureCity"))
            {
                departureCityId = Convert.ToInt32(form["departureCity"]);
            }
            else
            {
                ModelState.AddModelError("departureCity", "Nepasirinktas išvykimo miestas");
            }
            
            if (form.ContainsKey("destinationCity"))
            {
                arrivalCityId = Convert.ToInt32(form["destinationCity"]);
            }
            else
            {
                ModelState.AddModelError("arrivalCity", "Nepasirinktas atvykimo miestas");
            }
            
            if (form.ContainsKey("departureTime"))
            {
                departureDate = Convert.ToDateTime(form["departureTime"]);
            }
            else
            {
                ModelState.AddModelError("departureTime", "Nepasirinkta išvykimo data");
            }
            
            if (form.ContainsKey("arrivalTime"))
            {
                arrivalDate = Convert.ToDateTime(form["arrivalTime"]);
            }
            else
            {
                ModelState.AddModelError("arrivalTime", "Nepasirinkta atvykimo data");
            }
            
            if (departureCityId == arrivalCityId)
            {
                ModelState.AddModelError("departureCity", "Išvykimo miestas negali sutapti su atvykimo miestu");
                ModelState.AddModelError("arrivalCity", "Atvykimo miestas negali sutapti su išvykimo miestu");
            }
            
            if (departureDate > arrivalDate)
            {
                ModelState.AddModelError("departureTime", "Išvykimo data negali būti vėlesnė nei atvykimo data");
                ModelState.AddModelError("arrivalTime", "Atvykimo data negali būti ankstesnė nei išvykimo data");
            }

            if (!ModelState.IsValid)
                return View("RouteSearch", routes);

            var departureCity = await context.Places.SingleAsync(c => c.Id == departureCityId);
            var arrivalCity = await context.Places.SingleAsync(c => c.Id == arrivalCityId);
            
            foreach (var route in routes)
            {
                //TODO fix this
                // route.RouteVoyages = await context.RouteVoyages.Where(rv => rv.Routes.Id == route.Id).ToListAsync();

                //TODO fix this
                // foreach (var routeVoyage in route.RouteVoyages)
                // {
                //     routeVoyage.Places = await context.Places.Where(p => p.RouteVoyages.Contains(routeVoyage)).ToListAsync();
                //     
                //     routeVoyage.Places.ForEach(p =>
                //     {
                //         if (!route.Places.Contains(p))
                //         {
                //             route.Places.Add(p);   
                //         }
                //     });
                // }
            }
            //TODO: filter by needed cities (and maybe dates)
            //cant do it because there is no data in database and no way to add it yet. Waiting for other to do it.
            //too lazy to add manually to database myself cuz there is a lot of table and I am tired :(
            foreach (var route in routes)
            {
                //TODO fix this
                // foreach (var routeVoyage in route.RouteVoyages)
                // {
                //     if (!routeVoyage.Places.Contains(departureCity) || !routeVoyage.Places.Contains(arrivalCity))
                //         continue;
                //
                //     filteredRoutes.Add(route);
                // }
            }
            
            
            return View("RoutesList", filteredRoutes);
        }
    }
}
