# Projekt - System Rezerwacji Hoteli

## Opis
Projekt jest aplikacją internetową do rezerwacji hoteli, która umożliwia użytkownikom przeglądanie dostępnych hoteli, rezerwowanie pokoi, zarządzanie rezerwacjami oraz przeglądanie historii zamówień. Administrator ma możliwość dodawania, edytowania i usuwania hoteli, a także zarządzania zamówieniami użytkowników i rozpatrywania próśb o anulowanie rezerwacji.

## Wymagania systemowe
- .NET 6.0 SDK lub nowszy
- Entity Framework Core
- Baza danych SQLite
- Visual Studio 2022 lub nowszy (opcjonalnie)

## Instalacja

1. **Klonowanie repozytorium**

   git clone https://github.com/KamilFKZ/Projekt.git
   cd projekt
   
2.**Przygotowanie środowiska**:
   
   dotnet restore
          
 3.**Utwórz bazę danych i zastosuj migracje**
   
dotnet ef database update

4.**Uruchomienie aplikacji**

dotnet run

5.**Struktura projektu**

Controllers - Zawiera kontrolery obsługujące żądania HTTP
Models - Zawiera modele danych
Views - Zawiera widoki (pliki Razor)
wwwroot - Zawiera statyczne zasoby, takie jak pliki CSS, JS, obrazy
appsettings.json - Plik konfiguracyjny aplikacji

**Użytkowanie**

-Rejestracja-
Przejdź do /Account/Register
Wypełnij formularz rejestracyjny i wyślij

-Logowanie- 
Przejdź do /Account/Login
Wypełnij formularz logowania i wyślij

**Konto Administracyjne**
login: admin@admin.pl
hasło: Admin@123
