#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Proxfield.Google.Ddns.Updater/Proxfield.Google.Ddns.Updater.csproj", "Proxfield.Google.Ddns.Updater/"]
RUN dotnet restore "Proxfield.Google.Ddns.Updater/Proxfield.Google.Ddns.Updater.csproj"
COPY . .
WORKDIR "/src/Proxfield.Google.Ddns.Updater"
RUN dotnet build "Proxfield.Google.Ddns.Updater.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Proxfield.Google.Ddns.Updater.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Proxfield.Google.Ddns.Updater.dll"]