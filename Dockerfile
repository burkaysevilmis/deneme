FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["MovieApp/MovieApp.csproj", "MovieApp/"]
RUN dotnet restore "MovieApp/MovieApp.csproj"
COPY . .
WORKDIR "/src/MovieApp"
RUN dotnet build "MovieApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MovieApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet MovieApp.dll