FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Portalai/Portalai.csproj", "Portalai/"]
RUN dotnet restore "Portalai/Portalai.csproj"
COPY . .
WORKDIR "/src/Portalai"
RUN dotnet build "Portalai.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Portalai.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Portalai.dll"]
