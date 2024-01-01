# Aplikacja Bankowa

## Opis

Repozytorium zawiera kod źródłowy dla aplikacji bankowej. Backend został zaimplementowany w .NET Core 6, a frontend wykorzystuje Angular wraz z biblioteką Angular Material. Aplikacja korzysta z bazy danych PostgreSQL.

## Funkcjonalności

### Backend
- Dodawanie nowych transakcji
- Pobieranie historii transakcji
- Usuwanie transakcji
- Pobieranie podsumowania stanu konta

Backend wykorzystuje architekturę CQRS, implementując ją przez bibliotekę MediatR, co pozwala na oddzielenie logiki komend od zapytań.

### Frontend
- Konsumpcja API dostarczanego przez backend
- Interfejs użytkownika do zarządzania transakcjami
- Wyświetlanie historii oraz podsumowania stanu konta

## Technologie

- Backend: .NET Core 6
- Frontend: Angular z Angular Material
- Baza danych: PostgreSQL

## Uruchomienie projektu

### Wymagania wstępne

Upewnij się, że na swoim komputerze masz zainstalowany Docker oraz Docker Compose. Wszelkie zależności aplikacji, w tym .NET SDK, Node.js, Angular CLI oraz PostgreSQL, zostaną automatycznie zarządzane przez Docker.

### Uruchamianie za pomocą Docker Compose

1. Otwórz terminal i przejdź do głównego katalogu repozytorium, gdzie znajduje się plik `docker-compose.yml`.

2. Uruchom wszystkie serwisy zdefiniowane w `docker-compose.yml` za pomocą poniższej komendy:
   ```bash
   docker-compose up

3. Po uruchomieniu kontenerów interakcja z aplikacją będzie możliwa poprzez frontend dostępny domyślnie pod adresem 'http://localhost:4200'
