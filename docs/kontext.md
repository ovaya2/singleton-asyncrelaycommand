# Projektkontext: Singleton--asyncRelayCommands

## Übersicht

WPF-Anwendung (.NET Framework 4.8) mit MVVM-Architektur, die ein Login-Formular mit asynchronen Relay-Commands implementiert.

---

## Projektstruktur

```
Singleton--asyncRelayCommands/
├── Commands/
│   ├── AsyncCommandBase.cs        // Abstrakte Basisklasse für async ICommand
│   ├── AsyncRelayCommand.cs       // Generischer async Command mit Func<Task>-Callback
│   └── LoginCommand.cs            // Konkreter Login-Command (aktuell nicht verwendet)
├── Services/
│   ├── IAuthenticationService.cs  // Interface: Task Login(string username)
│   └── AuthenticationService.cs   // Implementierung: simuliert 5s Login-Delay
├── ViewModels/
│   ├── ViewModelBase.cs           // INotifyPropertyChanged-Basis
│   └── LoginViewModel.cs          // Username, StatusMessage, HasStatusMessage, LoginCommand
├── Views/
│   ├── LoginView.xaml             // UserControl: TextBox, Button, StatusMessage
│   └── LoginView.xaml.cs         // Code-Behind (leer)
├── App.xaml / App.xaml.cs         // Startup: DataContext = new LoginViewModel()
└── MainWindow.xaml                // Enthält <views:LoginView />
```

---

## Kern-Klassen

### `AsyncCommandBase` (abstrakt)
- Implementiert `ICommand`
- Verwaltet `IsExecuting` (bool) → löst `CanExecuteChanged` aus → Button auto-disabled während Ausführung
- `CanExecute()` gibt `!IsExecuting` zurück
- `Execute()` ist `async void` → ruft `ExecuteAsync()` auf, fängt Exceptions via `_onException`-Callback

### `AsyncRelayCommand`
- Erbt von `AsyncCommandBase`
- Nimmt `Func<Task>` Callback + `Action<Exception>` onException
- `ExecuteAsync()` ruft den Callback auf

### `LoginCommand` (vorhanden, aber aktuell nicht eingebunden)
- Erbt von `AsyncCommandBase`
- Hält Referenz auf `LoginViewModel` + `IAuthenticationService`
- Setzt `StatusMessage` direkt auf dem ViewModel

### `LoginViewModel`
- `Username` (string, bindbar)
- `StatusMessage` (string, bindbar)
- `HasStatusMessage` (bool, abgeleitet) → steuert Sichtbarkeit im View
- `LoginCommand` = `AsyncRelayCommand` mit inline `Login()`-Methode
- Erstellt `AuthenticationService` direkt (kein DI → Kopplung!)

---

## Datenfluss beim Login

```
Button Click
  → LoginCommand.Execute()
    → IsExecuting = true  (Button disabled)
    → Login() [async Task]
      → StatusMessage = "Logging in..."
      → AuthenticationService.Login(Username)  [await Task.Delay(5000)]
      → StatusMessage = "Successfully logged in."
    → IsExecuting = false (Button wieder aktiv)
```

---

## Bekannte Besonderheiten / TODOs

| Punkt | Beschreibung |
|---|---|
| `LoginCommand.cs` ungenutzt | `LoginViewModel` verwendet `AsyncRelayCommand` mit Lambda statt `LoginCommand`-Klasse |
| Kein DI | `LoginViewModel` instanziiert `AuthenticationService` direkt → schwer testbar |
| `App.xaml.cs` | `MainWindow.Show()` ist auskommentiert → Fenster erscheint trotzdem (WPF-Standard) |
| `async void Execute` | Nötig für `ICommand`, Exception-Handling über Callback gelöst |
| `HasStatusMessage` | Wird über `OnPropertyChanged` in `StatusMessage`-Setter mitgefeuert |

---

## Technologie-Stack

- **Framework:** .NET Framework 4.8, WPF
- **Pattern:** MVVM (Model-View-ViewModel)
- **Sprache:** C# 7.x
- **Build:** Visual Studio 2017+ (Solution Format 12.00)
- **Namespace:** `Singleton__asyncRelayCommands`
