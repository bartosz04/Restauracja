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
- Login: Pracownik; Hasło: Pracownik123.
- Login: Admin123; Hasło: Admin123.

🔐 Metody:

Form1(string? userType) – konstruktor, ustawia interakcje z przyciskami.

buttonRegister_Click() – otwiera formularz rejestracji użytkownika (dla admina).

buttonSearch_Click() – wyszukuje stoliki według kryteriów.

buttonChange_Click() – przełącza do formularza Form2.

SearchTables() – metoda wewnętrzna do wyszukiwania stolików w bazie.

Form2() – konstruktor, przypisuje zdarzenia do przycisków.

changeButton2_Click() – obsługa zmiany statusu stolika (np. „zarezerwowany” lub „wolny”).

UpdateTableStatus() – aktualizuje dane w bazie danych (SQLite), zmieniając status i handler w tabeli tables.


📦 Klasy:


-Form2  = 	Formularz do zmiany statusu stolika.

-LoginForm	 = 	Formularz logowania użytkownika.

-RegisterForm	 = 	Formularz rejestracji nowego użytkownika (dla admina).

-pulpit  = 	główne menu (dashboard) aplikacji.

-RestaurantTable	 = 	Model stolika restauracyjnego (numer, status, itd.).

-Order	 = 	Klasa reprezentująca zamówienie.

-OrderItem	 = 	Element zamówienia (np. danie, ilość).

-MenuItem	 = 	Pozycja w menu restauracji.

-Receipt	 = 	Reprezentuje paragon za zamówienie.

-zamowienia	 = 	formularz lub logika związana z zamówieniami.

-PasswordScript	 = 	Obsługa hash/salt lub walidacja hasła (logowanie).

-PasswordScriptR	 = analogiczna klasa dla rejestracji.

-RegistrationValidator	 = 	Walidacja danych rejestracyjnych.

-Program  = 	Punkt wejścia aplikacji (Main()).



Paradygmaty obiektowe w kodzie:


1. Abstrakcja 

Abstrakcja polega na wydzieleniu istotnych cech obiektu, ignorując detale implementacyjne. 

Klasy   MenuItem, OrderItem i Order abstrahują rzeczywiste pojęcia z restauracji (danie, pozycja zamówienia, całe zamówienie). 

Użytkownik klasy Order nie musi wiedzieć, jak dokładnie są przechowywane i liczone pozycje, tylko korzysta z metod takich jak AddItem() czy GetTotal(). 

2. Enkapsulacja (Hermetyzacja) 

Enkapsulacja to ukrywanie wewnętrznych szczegółów działania klasy i udostępnianie tylko odpowiednich metod do interakcji. 

Prywatne pola (np. private List<OrderItem> items w klasie Order) są ukryte przed użytkownikiem klasy. 

Dostęp do nich odbywa się przez publiczne metody i właściwości, np. AddItem(), Clear(), GetTotal(). 

Dzięki temu zmiana wewnętrznej implementacji nie wymusza zmian na zewnątrz. 

3. Dziedziczenie 

Dziedziczenie pozwala tworzyć nowe klasy na podstawie istniejących, rozszerzając lub modyfikując ich zachowanie. 

OrderItem dziedziczy po MenuItem, więc przejmuje właściwości Name i Price. 

Dodatkowo rozszerza je o Quantity oraz metodę LineTotal, która oblicza koszt pozycji zamówienia.

📞 Kontakt
- reSSBisSupport@gmail.com


Wygląd Aplikacji 


- Logowanie
  
  ![Zrzut ekranu 2025-07-05 142418](https://github.com/user-attachments/assets/d0ec55b7-62d6-41d5-b494-a23d39616c4d)

- Rozkład stolików

  ![Zrzut ekranu 2025-07-05 142453](https://github.com/user-attachments/assets/41f4f7ef-4085-498c-b285-df372f24c55e)

- Tworzenie zamówienia

  ![Zrzut ekranu 2025-07-05 142520](https://github.com/user-attachments/assets/8ec5c254-683f-43a0-bd46-e320a49da3f5)

- Wyświelanie paragonu ze stworzonego paragonu

  ![Zrzut ekranu 2025-07-05 142537](https://github.com/user-attachments/assets/dd286420-3459-4054-afa7-85745e7e758e)

- Przypisanie nowego użytkownika bez roli administratora

  ![Zrzut ekranu 2025-07-05 142617](https://github.com/user-attachments/assets/c504134f-1e18-4e17-8b6c-f8e65d5c94ff)




  
