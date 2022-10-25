FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/central/LiveSync.Central/LiveSync.Central.csproj", "LiveSync.Central/"]
RUN dotnet restore "src/central/LiveSync.Central/LiveSync.Central.csproj"
COPY . .
WORKDIR "/src/LiveSync.Central"
RUN dotnet build "LiveSync.Central.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LiveSync.Central.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LiveSync.Central.dll"]
