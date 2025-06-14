FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5254

ENV ASPNETCORE_URLS=http://+:5254

FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src

COPY ["Eventary-API/Eventary-API.csproj", "Eventary-API/"]
COPY ["CORE/CORE.csproj", "CORE/"]
COPY ["DAL/DAL.csproj", "DAL/"]

RUN dotnet restore "Eventary-API/Eventary-API.csproj"
COPY . .
WORKDIR "/src/Eventary-API"
RUN dotnet build "Eventary-API.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "Eventary-API.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Eventary-API.dll"]
