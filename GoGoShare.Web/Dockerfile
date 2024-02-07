FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
COPY . ./src
WORKDIR /src/GoGoShare.Web
RUN dotnet restore GoGoShare.Web.csproj
RUN dotnet publish GoGoShare.Web.csproj -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT dotnet GoGoShare.Web.dll
