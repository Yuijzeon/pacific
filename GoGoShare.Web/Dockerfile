FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build-env
WORKDIR /App

COPY . ./
RUN dotnet restore "GoGoShare.Web/GoGoShare.Web.csproj"
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine
ENV ASPNETCORE_ENVIRONMENT=Production
WORKDIR /App
COPY --from=build-env /App/out .
ENTRYPOINT ["dotnet", "GoGoShare.Web.dll"]