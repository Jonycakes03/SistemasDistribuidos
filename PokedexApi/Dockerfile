FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["PokedexApi.csproj", "./"]
RUN dotnet restore "PokedexApi.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "PokedexApi.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "PokedexApi.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final 
WORKDIR /app
COPY --from=publish /app/publish . 
ENTRYPOINT ["dotnet", "PokedexApi.dll"]