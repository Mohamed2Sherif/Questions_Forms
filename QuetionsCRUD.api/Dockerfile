FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["QuetionsCRUD.api/QuetionsCRUD.api.csproj", "QuetionsCRUD.api/"]
RUN dotnet restore "QuetionsCRUD.api/QuetionsCRUD.api.csproj"
COPY . .
WORKDIR "/src/QuetionsCRUD.api"
RUN dotnet build "QuetionsCRUD.api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "QuetionsCRUD.api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .


COPY QuetionsCRUD.api/start /start
RUN sed -i 's/\r$//g' /start
RUN chmod +x /start

ENTRYPOINT ["dotnet", "QuetionsCRUD.api.dll"]
