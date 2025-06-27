**Restauracja_Biss - Aplikacja**

📌 Opis projektu

Aplikacja dla personelu restauracji stworzona w technologii .NET 8, która umożliwia zarządzanie zamówieniami i rezerwacjami klientów. Celem aplikacji jest uproszczenie procesów związanych z obsługą klientów, zwiększenie efektywności pracy personelu oraz poprawa jakości usług w restauracji.


Spis treści

- Funkcjonalności
- Wymagania
- Instalacja
- Użycie
- Struktura projektu
- Przykłady użycia
- Współpraca
- Kontakt

⚙️ Funkcjonalności

- Zarządzanie rezerwacjami: Pracownicy mogą dodawać, edytować i usuwać rezerwacje, a także przeglądać dostępność stolików w czasie rzeczywistym.

- Zarządzanie zamówieniami: Możliwość dodawania, edytowania i śledzenia statusu zamówień klientów.

- Bezpieczny system logowania: Tylko uprawniony personel ma dostęp do aplikacji, co zapewnia bezpieczeństwo danych.

- Interfejs użytkownika: Przyjazny i intuicyjny interfejs, który ułatwia nawigację i obsługę aplikacji.


🛠️ Wymagania

- .NET 8 SDK

- Visual Studio 2022 lub nowszy (opcjonalnie, ale zalecane dla łatwiejszego rozwoju)

- System operacyjny: Windows 10 lub nowszy

⚙️ Instalacja
- git clone <https://github.com/bartosz04/Restauracja>
- Wybierz odpowiedni plik do otwarcia projektu w Visual Studio 2022
- Uruchom plik
  

🔐 Logowanie: 

- Po uruchomieniu aplikacji, wprowadź swoje dane logowania (nazwa użytkownika i hasło).

- Hasła użytkowników są hashowane i saltowane przed zapisaniem w bazie danych, co zapewnia dodatkowy poziom bezpieczeństwa danych logowania.

- Zarządzanie rezerwacjami: W sekcji rezerweacji dodaj nową rezerwację do danego stolika.

- Zarządzanie zamówieniami: W sekcji zamówień możesz dodawać nowe zamówienia, edytować istniejące.

👥 Konta:
- Login: Pracownik; Hasło: Pracownik.
- Login: Admin123; Hasło: Admin123.

🔐 Metody:

Form1(string? userType) – konstruktor, ustawia interakcje z przyciskami.

buttonRegister_Click() – otwiera formularz rejestracji użytkownika (dla admina).

buttonSearch_Click() – wyszukuje stoliki według kryteriów.

buttonChange_Click() – przełącza do formularza Form2.

SearchTables() – metoda wewnętrzna do wyszukiwania stolików w bazie.

DisplayResults() – (nie pokazana jeszcze, ale prawdopodobnie odpowiada za wyświetlanie listy wyników).

Form2() – konstruktor, przypisuje zdarzenia do przycisków.

changeButton2_Click() – obsługa zmiany statusu stolika (np. „zarezerwowany” lub „wolny”).

UpdateTableStatus() – aktualizuje dane w bazie danych (SQLite), zmieniając status i handler w tabeli tables.

📦 Klasy:

-Form1  = 	Główne okno aplikacji (wyszukiwanie i zarządzanie stolikami).

-Form2  = 	Formularz do zmiany statusu stolika.
-LoginForm	 = 	Formularz logowania użytkownika.
-RegisterForm	 = 	Formularz rejestracji nowego użytkownika (dla admina).
-pulpit	Możliwe  = 	główne menu (dashboard) aplikacji.
-RestaurantTable	 = 	Model stolika restauracyjnego (numer, status, itd.).
-Order	 = 	Klasa reprezentująca zamówienie.
-OrderItem	 = 	Element zamówienia (np. danie, ilość).
-MenuItem	 = 	Pozycja w menu restauracji.
-Receipt	 = 	Reprezentuje paragon za zamówienie.
-zamowienia	 = 	Prawdopodobnie formularz lub logika związana z zamówieniami.
-PasswordScript	 = 	Obsługa hash/salt lub walidacja hasła (logowanie).
-PasswordScriptR	 = 	Prawdopodobnie analogiczna klasa dla rejestracji.
-RegistrationValidator	 = 	Walidacja danych rejestracyjnych.
-Program  = 	Punkt wejścia aplikacji (Main()).

📞 Kontakt
- reSSBisSupport@gmail.com
