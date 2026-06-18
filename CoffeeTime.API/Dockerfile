# כדי לבנות את האפליקציה. משתמש בתמונה הבסיסית של NET SDK.
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# מעתיק את קבצי הפרויקט מתיקיית האב (שלב אחד למעלה) ומבצע restore
COPY ../*.sln ./
COPY ../CoffeeTime.API/*.csproj CoffeeTime.API/
COPY ../CoffeeTime.Core/*.csproj CoffeeTime.Core/
COPY ../CoffeeTime.Service/*.csproj CoffeeTime.Service/
COPY ../CoffeTime.Data/*.csproj CoffeTime.Data/
RUN dotnet restore "CoffeeTime.API/CoffeeTime.API.csproj"

# מעתיק את שאר הקבצים מתיקיית האב ובונה את האפליקציה
COPY ../ ./
WORKDIR "/src/CoffeeTime.API"
RUN dotnet publish -c Release -o /app/out

# כדי להריץ את האפליקציה. משתמש בתמונה של NET Runtime.
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

# הגדרה ייעודית עבור Render - מאלצת את האפליקציה להאזין לפורט שרנדר מחפש
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

# מפעיל את האפליקציה
ENTRYPOINT ["dotnet", "CoffeeTime.API.dll"]