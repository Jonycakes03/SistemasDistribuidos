FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["TrainerApi.csproj", "./"]
RUN dotnet restore "TrainerApi.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "TrainerApi.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "TrainerApi.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final 
WORKDIR /app
COPY --from=publish /app/publish . 
ENTRYPOINT ["dotnet", "TrainerApi.dll"]