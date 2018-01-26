FROM microsoft/aspnetcore-build:2 AS build

# copy project files and restore as distinct layers
WORKDIR /app/LocationAlert.Library
COPY LocationAlert.Library/*.csproj ./
RUN dotnet restore
WORKDIR /app/LocationAlert.Library.Service
COPY LocationAlert.Library.Service/*.csproj ./
RUN dotnet restore

# copy everything else and build
WORKDIR /app
COPY . ./
WORKDIR LocationAlert.Library.Service
RUN dotnet publish -c Release -o ../out

# build runtime image
FROM microsoft/aspnetcore:2
WORKDIR /app
COPY --from=build /app/out ./

ENTRYPOINT ["dotnet", "LocationAlert.Library.Service.dll"]
