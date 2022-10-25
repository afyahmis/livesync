FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/client/LiveSync.Client/LiveSync.Client.csproj", "LiveSync.Client/"]
RUN dotnet restore "src/client/LiveSync.Client/LiveSync.Client.csproj"
COPY . .
WORKDIR "/src/LiveSync.Client"
RUN dotnet build "LiveSync.Client.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LiveSync.Client.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LiveSync.Client.dll"]
