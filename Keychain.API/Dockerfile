FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Keychain-API/Keychain-API.csproj", "Keychain-API/"]
RUN dotnet restore "Keychain-API/Keychain-API.csproj"
COPY . .
WORKDIR "/src/Keychain-API"
RUN dotnet build "Keychain-API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Keychain-API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Keychain-API.dll"]
