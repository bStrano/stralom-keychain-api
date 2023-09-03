FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

ARG CONNECTION_STRING
ARG KEY
ARG IV
ARG ACCESS_TOKEN_SECRET


ENV DbSettings:CONNECTION_STRING=${CONNECTION_STRING}
ENV EncryptionSettings:KEY=${KEY}
ENV EncryptionSettings:IV=${IV}
ENV JwtSettings:Secret=${ACCESS_TOKEN_SECRET}
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Keychain.API/Keychain.API.csproj", "Keychain.API/"]
COPY ["Keychain.Application/Keychain.Application.csproj", "Keychain.Application/"]
COPY ["Keychain.Contracts/Keychain.Contracts.csproj", "Keychain.Contracts/"]
COPY ["Keychain.Domain/Keychain.Domain.csproj", "Keychain.Domain/"]
COPY ["Keychain.Infrastructure/Keychain.Infrastructure.csproj", "Keychain.Infrastructure/"]
RUN dotnet restore "Keychain.API/Keychain.API.csproj"
COPY . .
WORKDIR "/src/Keychain.API"
RUN dotnet build "Keychain.API.csproj" -c Release -o /app/build
#
FROM build AS publish
RUN dotnet publish "Keychain.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ["dotnet", "Keychain.API.dll"]
