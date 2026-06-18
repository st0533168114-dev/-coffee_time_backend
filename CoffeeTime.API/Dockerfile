# כדי לבנות את האפליקציה. משתמש בתמונה הבסיסית של NET SDK.
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# מעתיק את קבצי הפרויקט ומבצע restore (בדיוק לפי השיטה של המורה)
COPY *.sln ./
COPY CoffeeTime.API/*.csproj CoffeeTime.API/
COPY CoffeeTime.Core/*.csproj CoffeeTime.Core/
COPY CoffeeTime.Service/*.csproj CoffeeTime.Service/
COPY CoffeTime.Data/*.csproj CoffeeTime.Data/
RUN dotnet restore

# מעתיק את שאר הקבצים ובונה את האפליקציה
COPY . ./
RUN dotnet publish CoffeeTime.API -c Release -o out

# כדי להריץ את האפליקציה. משתמש בתמונה של NET Runtime.
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

# הגדרה ייעודית עבור Render - מאלצת את האפליקציה להאזין לפורט שרנדר מחפש
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

# מפעיל את האפליקציה
ENTRYPOINT ["dotnet", "CoffeeTime.API.dll"]
