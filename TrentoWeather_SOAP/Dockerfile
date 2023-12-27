#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TrentoWeather_SOAP/TrentoWeather_SOAP.csproj", "TrentoWeather_SOAP/"]
RUN dotnet restore "TrentoWeather_SOAP/TrentoWeather_SOAP.csproj"
COPY . .
WORKDIR "/src/TrentoWeather_SOAP"
RUN dotnet build "TrentoWeather_SOAP.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TrentoWeather_SOAP.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TrentoWeather_SOAP.dll"]