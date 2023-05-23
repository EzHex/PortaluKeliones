using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Portalai.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Portalai.ViewModel;
using static System.Math;
using Route = Portalai.Models.Route;

namespace Portalai.Controllers
{
    public class RouteController : Controller
    {
        private readonly PortalsDbContext _context;

        public RouteController(PortalsDbContext context)
        {
            this._context = context;
        }

        public async Task<ActionResult> ShowRoutes()
        {
            var routes = await _context.Routes.ToListAsync();
            
            if (TempData["status"] != null)
            {
                ViewBag.Status = TempData["status"];
                TempData.Remove("status");
            }
            
            return View("RoutesAdminList", routes);
        }

        public async Task<ActionResult> ShowCreateForm()
        {
            var route = new RouteCreateEditVm();

            route.PlaceSelectList = new List<SelectListItem>((await _context.Places.ToListAsync())
                .Select(x=> new SelectListItem(x.Name, x.Id.ToString())).ToList());

            return View("RouteCreate", route);
        }


        [HttpPost]
        public async Task<ActionResult> Create(int? save, int? add, int? remove, RouteCreateEditVm routeCreateEditVm)
        {
            //add specifies order number of the voyage to add
            if (add != null)
            {
                int nextOrder = routeCreateEditVm.RouteVoyageMs.Count == 0
                    ? 0
                    : routeCreateEditVm.RouteVoyageMs.Max(it => it.Order) + 1;
                
                var routeVoyage = new RouteCreateEditVm.RouteVoyageM(nextOrder, 0,1);
                
                
                routeCreateEditVm.RouteVoyageMs.Add(routeVoyage);
                
                //make sure @Html helper is not reusing old model state containing the old list
                ModelState.Clear();
                
                routeCreateEditVm.PlaceSelectList = new List<SelectListItem>((await _context.Places.ToListAsync())
                    .Select(x=> new SelectListItem(x.Name, x.Id.ToString())).ToList());
                
                return View("RouteCreate", routeCreateEditVm);
            }

            if (remove != null)
            {
                routeCreateEditVm.RouteVoyageMs = routeCreateEditVm
                    .RouteVoyageMs
                    .Where(it => it.Order != remove.Value)
                    .ToList();
                
                ModelState.Clear();
                
                //update order
                for (int i = 0; i < routeCreateEditVm.RouteVoyageMs.Count; i++)
                {
                    routeCreateEditVm.RouteVoyageMs[i].Order = i;
                }
                
                routeCreateEditVm.PlaceSelectList = new List<SelectListItem>((await _context.Places.ToListAsync())
                    .Select(x=> new SelectListItem(x.Name, x.Id.ToString())).ToList());
                
                return View("RouteCreate", routeCreateEditVm);
            }

            if (save != null)
            {
                if (routeCreateEditVm.RouteVoyageMs.Count() < 2)
                {
                    ModelState.AddModelError("", "Maršrutas turi turėti bent 2 vietoves.");
                }

                ModelState.Remove("RouteVoyageMs[0].Duration");
                //form field validation passed?
                if (ModelState.IsValid)
                {
                    // //create new 'Sutartis'
                    EntityEntry<Route> route = await _context.Routes.AddAsync(routeCreateEditVm.Route);
                    
                    //construct RouteVoyages
                    for(int i = 0; i < routeCreateEditVm.RouteVoyageMs.Count-1; i++)
                    {
                        var arrivalId = routeCreateEditVm.RouteVoyageMs[i].PlaceId;
                        var departureId = routeCreateEditVm.RouteVoyageMs[i+1].PlaceId;
                        
                        var arrival = await _context.Places.FindAsync(arrivalId);
                        var departure = await _context.Places.FindAsync(departureId);

                        if (arrival != null)
                        {
                            if (departure != null)
                            {
                                RouteVoyage routeVoyage = new RouteVoyage
                                {
                                    Route = route.Entity,
                                    Order = routeCreateEditVm.RouteVoyageMs[i].Order,
                                    Arrival = arrival,
                                    Departure = departure,
                                    Duration = routeCreateEditVm.RouteVoyageMs[i].Duration
                                };
                        
                                await _context.RouteVoyages.AddAsync(routeVoyage);
                            }
                        }
                    }

                    await _context.SaveChangesAsync();
                    
                    //update viewbag
                    TempData["status"] = "Maršrutas sėkmingai sukurtas.";

                    //save success, go back to the entity list
                    return RedirectToAction("ShowRoutes");
                }
                //form field validation failed, go back to the form
                else
                {
                    routeCreateEditVm.PlaceSelectList = new List<SelectListItem>((await _context.Places.ToListAsync())
                        .Select(x=> new SelectListItem(x.Name, x.Id.ToString())).ToList());
                    
                    return View("RouteCreate", routeCreateEditVm);
                }
            }

            throw new Exception("Should not reach here.");
        }

        public async Task<ActionResult> ShowRoutePlanning()
        {
            var places = await _context.Places.ToListAsync();

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

            private static readonly Random Random = new Random();

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
                    Travelers.Add(Random.Next(1, travelersCount + 1));
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
                    int k = Random.Next(n--);
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

            private static readonly Random Random = new Random();

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
                int cutPoint = Random.Next(1, chromosome1.Places.Count);
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
                    if (Random.NextDouble() < MutationRate)
                    {
                        int index = Random.Next(0, places.Count);
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
                    tournament.AddChromosome(population.Chromosomes[Random.Next(1, population.Size)]);
                }
                return tournament.GetFittest();
            }
        }

        [HttpPost]
        public async Task<ActionResult> PostRoutePlan(IFormCollection form)
        {
            TempData["StartPlaceId"] = form["StartPlace"].ToString();
            TempData["EndPlaceId"] = form["EndPlace"].ToString();
            TempData["PlaceIds"] = form["Places"].ToArray();
            TempData["TimePerLocation"] = form["TimePerLocation"].ToString();
            TempData["TimePerKilometer"] = form["TimePerKilometer"].ToString();
            TempData["TimeBeforeBreak"] = form["TimeBeforeBreak"].ToString();
            TempData["BreakTime"] = form["BreakTime"].ToString();

            var places = await _context.Places.ToListAsync();

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
            if (placeIds.Contains(form["StartPlace"].ToString()) || placeIds.Contains(form["EndPlace"].ToString()))
            {
                ViewBag.Error4 = "Pradžios arba pabaigos vietovė negali būti įtraukta tarp tarpinių vietovių";
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
            catch (FormatException)
            {
                ViewBag.Error5 = "Netinkamas skaičiaus formatas";
                return View("RoutePlan", places);
            }
            if (timePerPlace <= 0.0 || timePerKilometer <= 0.0 || timeBeforeBreak <= 0.0)
            {
                ViewBag.Error6 = "Laikas vietovei aplankyti, keliavimo greitis, keliavimo laikas iki pertraukos turi būti didesni už 0";
                return View("RoutePlan", places);
            }
            if (breakTime < 0.0)
            {
                ViewBag.Error7 = "Petraukos laikas negali būti neigiamas";
                return View("RoutePlan", places);
            }

            var startPlace = await _context.Places.SingleAsync(p => p.Id == startPlaceId);
            var endPlace = await _context.Places.SingleAsync(p => p.Id == endPlaceId);
            var selectedPlaces = await _context.Places.Where(p => placeIds.Contains(p.Id.ToString())).ToListAsync();
            Population population = new Population(10, startPlace, endPlace, selectedPlaces, 1, timePerPlace, timePerKilometer, timeBeforeBreak, breakTime);
            GeneticAlgorithm geneticAlgorithm = new GeneticAlgorithm(0.05, 5, 3);

            Chromosome fittest = population.GetFittest();
            int generation = 2;
            int sameIterationCount = 1;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            while (sameIterationCount <= 200 && stopwatch.Elapsed.TotalSeconds < 60)
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
            TempData["RoutePlan"] = routePlan;

            var educationalRoutes = await _context.EducationalRoutes
                .Include(r => r.Places)
                .ToListAsync();

            var filteredRoutes = educationalRoutes
                .Where(r =>
                    r.Places.Any(p => p.Id == startPlaceId) &&
                    r.Places.Any(p => p.Id == endPlaceId)
                ).ToList();

            if (filteredRoutes.Count == 0)
            {
                filteredRoutes = educationalRoutes
                    .Where(r =>
                        r.Places.Any(p => p.Id == startPlaceId) ||
                        r.Places.Any(p => p.Id == endPlaceId)
                    ).ToList();
                if (filteredRoutes.Count == 0)
                {
                    filteredRoutes = educationalRoutes;
                }
            }

            var placeNames = selectedPlaces.Select(p => p.Name).ToList();

            var random = new Random();
            var routeMatches = filteredRoutes.Select(r => new
            {
                Route = r,
                MatchCount = r.Places.Count(p => placeNames.Contains(p.Name))
            })
                .OrderByDescending(match => match.MatchCount)
                .ThenBy(_ => random.Next())
                .ToList();

            var suggestedRoute = routeMatches.FirstOrDefault()?.Route;

            var suggestedRouteStr = "";
            if (suggestedRoute != null)
            {
                var startPlaceIndex = suggestedRoute.Places.FindIndex(p => p.Id == startPlaceId);
                var endPlaceIndex = suggestedRoute.Places.FindIndex(p => p.Id == endPlaceId);

                if (startPlaceIndex != -1)
                {
                    var temp = suggestedRoute.Places[0];
                    suggestedRoute.Places[0] = suggestedRoute.Places[startPlaceIndex];
                    suggestedRoute.Places[startPlaceIndex] = temp;
                }
                if (endPlaceIndex != -1)
                {
                    var temp = suggestedRoute.Places[suggestedRoute.Places.Count - 1];
                    suggestedRoute.Places[suggestedRoute.Places.Count - 1] = suggestedRoute.Places[endPlaceIndex];
                    suggestedRoute.Places[endPlaceIndex] = temp;
                }

                for (int i = 0; i < suggestedRoute.Places.Count; i++)
                {
                    if (i <= suggestedRoute.Places.Count - 2)
                    {
                        suggestedRouteStr += suggestedRoute.Places[i].Name + "->";
                    }
                    else
                    {
                        suggestedRouteStr += suggestedRoute.Places[i].Name;
                    }
                }
            }

            TempData["SuggestedRouteId"] = suggestedRoute?.Id;
            TempData["SuggestedRoute"] = suggestedRouteStr;
            if (suggestedRouteStr != "")
            {
                TempData["IsReviewPosted"] = false;
            }

            return View("RoutePlan", places);
        }

        [HttpPost]
        public async Task<ActionResult> PostReview(IFormCollection form)
        {
            TempData["Rating"] = form["Rating"].ToString();

            var places = await _context.Places.ToListAsync();

            var rating = 0.0;
            try
            {
                rating = Convert.ToDouble(form["Rating"]);
            }
            catch (FormatException)
            {
                ViewBag.Error8 = "Netinkamas skaičiaus formatas";
                return View("RoutePlan", places);
            }
            if (rating < 0.0 || rating > 5.0)
            {
                ViewBag.Error9 = "Reitingas turi būti tarp 0 ir 5";
                return View("RoutePlan", places);
            }

            var educationalRouteId = Convert.ToInt32(TempData.Peek("SuggestedRouteId"));

            var educationalRoute = await _context.EducationalRoutes.SingleAsync(r => r.Id == educationalRouteId);

            educationalRoute.Rating = (educationalRoute.RatingCount * educationalRoute.Rating + rating) / (educationalRoute.RatingCount + 1);
            educationalRoute.RatingCount += 1;

            await _context.SaveChangesAsync();

            TempData["IsReviewPosted"] = true;
            TempData.Remove("Rating");

            return View("RoutePlan", places);
        }

        public async Task<ActionResult> ShowRoutesSearch()
        {
            if (TempData["status"] != null)
            {
                ViewBag.Status = TempData["status"];
                TempData.Remove("status");
            }
            
            var route = await _context.Routes.FirstAsync();

            await route.LoadAvailableDropdowns(_context);

            return View("RouteSearch", route);
        }

        [HttpPost]
        public async Task<ActionResult> PostSearch()
        {
            var form = Request.Form;
            var routes = await _context.Routes.ToListAsync();
            
            var filteredRoutes = new System.Collections.Generic.List<Route>();
            
            int departureCityId = 0;
            int arrivalCityId = 0;

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

            if (departureCityId == arrivalCityId)
            {
                ModelState.AddModelError("departureCity", "Išvykimo miestas negali sutapti su atvykimo miestu");
                ModelState.AddModelError("arrivalCity", "Atvykimo miestas negali sutapti su išvykimo miestu");
            }

            if (!ModelState.IsValid)
            {
                await routes[0].LoadAvailableDropdowns(_context);
                return View("RouteSearch", routes[0]);
            }
            
            var departureCity = await _context.Places.SingleAsync(c => c.Id == departureCityId);
            var arrivalCity = await _context.Places.SingleAsync(c => c.Id == arrivalCityId);

            foreach (var route in routes)
            {
                route.RouteVoyages = await _context.RouteVoyages.Where(rv => rv.RouteId == route.Id).ToListAsync();
                
                foreach (var routeVoyage in route.RouteVoyages)
                {
                    if (routeVoyage.DepartureId != departureCity.Id) 
                        continue;
                    foreach (var routeVoyage2 in route.RouteVoyages)
                    {
                        if (routeVoyage2.ArrivalId != arrivalCity.Id) 
                            continue;
                        if (routeVoyage.Order > routeVoyage2.Order) 
                            continue;
                        
                        filteredRoutes.Add(route);
                        break;
                    }
                }
            }
            
            return View("RoutesList", filteredRoutes);
        }

        public async Task<IActionResult> ShowOneRoute(int id)
        {
            Route route = await _context.Routes
                .Include(r=>r.RouteVoyages)
                .ThenInclude(r=>r.Arrival)
                .Include(r=>r.RouteVoyages)
                .ThenInclude(r=>r.Departure)
                .SingleAsync(r => r.Id == id);

            return View("RouteInfo", route);
        }

        public async Task<IActionResult> ShowEditForm(int id)
        {
            RouteCreateEditVm vm = new RouteCreateEditVm();
            vm.Route = await _context.Routes
                .Include(m=>m.RouteVoyages)
                .SingleAsync(r => r.Id == id);
            
            vm.PlaceSelectList = new List<SelectListItem>((await _context.Places.ToListAsync())
                .Select(x=> new SelectListItem(x.Name, x.Id.ToString())).ToList());
            
            vm.RouteVoyageMs = new List<RouteCreateEditVm.RouteVoyageM>();
            foreach (var routeVoyage in vm.Route.RouteVoyages)
            {
                vm.RouteVoyageMs.Add(new RouteCreateEditVm.RouteVoyageM()
                {
                    Order = routeVoyage.Order,
                    PlaceId = routeVoyage.Arrival.Id,
                    Duration = routeVoyage.Duration
                });
            }
            
            //Add last
            vm.RouteVoyageMs.Add(new RouteCreateEditVm.RouteVoyageM()
            {
                Order = vm.Route.RouteVoyages.Last().Order+1,
                PlaceId = vm.Route.RouteVoyages.Last().Departure.Id,
                Duration = vm.Route.RouteVoyages.Last().Duration
            });

            return View("RouteEdit", vm);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(int? save, int? add, int? remove, RouteCreateEditVm routeCreateEditVm)
        {
            //add specifies order number of the voyage to add
            if (add != null)
            {
                var rv = new RouteCreateEditVm.RouteVoyageM
                {
                    Order = routeCreateEditVm.RouteVoyageMs.Count == 0
                        ? 0
                        : routeCreateEditVm.RouteVoyageMs.Max(it => it.Order) + 1,
                    PlaceId = 0,
                    Duration = 0
                };

                routeCreateEditVm.RouteVoyageMs.Add(rv);
                
                //make sure @Html helper is not reusing old model state containing the old list
                ModelState.Clear();
                
                //Reselect PlaceSelectList
                routeCreateEditVm.PlaceSelectList = new List<SelectListItem>((await _context.Places.ToListAsync())
                    .Select(x=> new SelectListItem(x.Name, x.Id.ToString())).ToList());
                
                return View("RouteEdit", routeCreateEditVm);
            }

            if (remove != null)
            {
                //Remove voyage by order number
                routeCreateEditVm.RouteVoyageMs = routeCreateEditVm
                    .RouteVoyageMs
                    .Where(it => it.Order != remove.Value)
                    .ToList();
                
                ModelState.Clear();
                
                //Update order numbers
                for (int i = 0; i < routeCreateEditVm.RouteVoyageMs.Count; i++)
                {
                    routeCreateEditVm.RouteVoyageMs[i].Order = i;
                }
                
                //Reselect PlaceSelectList
                routeCreateEditVm.PlaceSelectList = new List<SelectListItem>((await _context.Places.ToListAsync())
                    .Select(x=> new SelectListItem(x.Name, x.Id.ToString())).ToList());
                
                return View("RouteEdit", routeCreateEditVm);
            }

            if (save != null)
            {
                //Validate RouteVoyageMs
                if (routeCreateEditVm.RouteVoyageMs.Count() < 2)
                {
                    ModelState.AddModelError("", "Maršrutas turi turėti bent 2 vietoves.");
                }
                //Remove validation for first voyage
                ModelState.Remove("RouteVoyageMs[0].Duration");
                
                //form field validation passed?
                if (ModelState.IsValid)
                {

                    //update route from vm
                    _context.Routes.Update(routeCreateEditVm.Route);
                    
                    _context.RouteVoyages.RemoveRange(_context.RouteVoyages.Where(rv => rv.Route.Id == routeCreateEditVm.Route.Id));
                    
                    //construct RouteVoyages
                    for(int i = 0; i < routeCreateEditVm.RouteVoyageMs.Count-1; i++)
                    {
                        var arrivalId = routeCreateEditVm.RouteVoyageMs[i].PlaceId;
                        var departureId = routeCreateEditVm.RouteVoyageMs[i+1].PlaceId;
                        
                        var arrival = await _context.Places.FindAsync(arrivalId);
                        var departure = await _context.Places.FindAsync(departureId);
                    
                        if (arrival != null && departure != null)
                        {
                            RouteVoyage routeVoyage = new RouteVoyage
                                {
                                    Route = routeCreateEditVm.Route,
                                    Order = routeCreateEditVm.RouteVoyageMs[i].Order,
                                    Arrival = arrival,
                                    Departure = departure,
                                    Duration = routeCreateEditVm.RouteVoyageMs[i].Duration
                                };
                        
                                await _context.RouteVoyages.AddAsync(routeVoyage);
                        }
                    }
                    
                    await _context.SaveChangesAsync();
                    
                    //update viewbag
                    TempData["status"] = "Maršrutas sėkmingai redaguotas.";

                    //save success, go back to the entity list
                    return RedirectToAction("ShowRoutes");
                }
                //form field validation failed, go back to the form
                else
                {
                    //Reselect Place List
                    routeCreateEditVm.PlaceSelectList = new List<SelectListItem>((await _context.Places.ToListAsync())
                        .Select(x=> new SelectListItem(x.Name, x.Id.ToString())).ToList());
                    
                    return View("RouteEdit", routeCreateEditVm);
                }
            }

            throw new Exception("Should not reach here.");
        }

        public async Task<IActionResult> ShowDeleteConfirmForm(int id)
        {
            Route route = await _context.Routes
                .SingleAsync(r => r.Id == id);

            return View("RouteDelete", route);
        }

        public IActionResult DeleteRoute(Route item)
        {
            _context.Routes.Remove(item);
            _context.SaveChanges();

            TempData["status"] = "Maršrutas sėkmingai ištrintas.";

            return RedirectToAction("ShowRoutes");
        }
    }
}
