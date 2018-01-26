FROM microsoft/aspnetcore-build:2 AS build

# copy project files and restore as distinct layers
WORKDIR /app/LocationAlert.Data
COPY LocationAlert.Data/*.csproj ./
RUN dotnet restore
WORKDIR /app/LocationAlert.Data.Service
COPY LocationAlert.Data.Service/*.csproj ./
RUN dotnet restore

# copy everything else and build
WORKDIR /app
COPY . ./
WORKDIR /app/LocationAlert.Data.Service
RUN dotnet publish -c Release -o ../out

# build runtime image
FROM microsoft/aspnetcore:2
WORKDIR /app
COPY --from=build /app/out ./

ENTRYPOINT ["dotnet", "LocationAlert.Data.Service.dll"]
