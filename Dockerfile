FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0.401 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["StudyPlanner/StudyPlanner.csproj", "StudyPlanner/"]
RUN dotnet restore "StudyPlanner/StudyPlanner.csproj"
COPY . .
WORKDIR "/src/StudyPlanner"
RUN dotnet build "StudyPlanner.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "StudyPlanner.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
# Add this line to include your SQLite database file
COPY StudyPlanner/applicationdatabase.db /app/
ENTRYPOINT ["dotnet", "StudyPlanner.dll"]
