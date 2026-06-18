# שלב 1: בניית האפליקציה
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# מעתיק את קובץ ה-csproj של ה-API שנמצא ישירות בתיקיית השורש הנוכחית
COPY *.csproj ./
RUN dotnet restore

# מעתיק את שאר הקבצים של ה-API ומבצע בנייה
COPY . ./
RUN dotnet publish -c Release -o /app/out

# שלב 2: הרצת האפליקציה
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "CoffeeTime.API.dll"]