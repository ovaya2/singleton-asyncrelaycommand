# CLAUDE.md

## Projekt
WPF-Anwendung (.NET Framework 4.8) mit MVVM-Architektur und asynchronen Commands.
Namespace: `Singleton__asyncRelayCommands`

## Build & Run
- IDE: Visual Studio 2017+
- Solution: `Singleton--asyncRelayCommands.sln`
- Zielframework: .NET Framework 4.8
- Build: `msbuild` oder über VS (Strg+Shift+B)
- Starten: F5 in Visual Studio

## Architektur-Regeln
- **Strikte MVVM-Trennung**: kein Logik-Code in Code-Behind-Dateien (`.xaml.cs`)
- **Neue async Commands** immer von `AsyncCommandBase` ableiten, nie `ICommand` direkt implementieren
- **Sync Commands** als `AsyncRelayCommand` mit synchronem Lambda wrappen (`async () => { ... }`)
- **Services** nur über ihr Interface ansprechen (`IAuthenticationService`, nicht `AuthenticationService`)
- ViewModels erben von `ViewModelBase`, nie direkt `INotifyPropertyChanged` implementieren

## Coding-Konventionen
- Private Felder mit `_camelCase` Prefix
- Bindbare Properties immer mit `OnPropertyChanged(nameof(...))` im Setter
- Abgeleitete Properties (z. B. `HasStatusMessage`) im Setter der Quell-Property mitfeuern
- Exception-Handling in Commands **ausschließlich** über den `onException`-Callback, kein try/catch im ViewModel
- `async void` nur in `AsyncCommandBase.Execute()` — nirgendwo sonst

## Bekannte TODOs / offene Baustellen
- `LoginCommand.cs` ist ungenutzt → entweder einbinden oder löschen
- `LoginViewModel` instanziiert `AuthenticationService` direkt → durch Constructor-Injection ersetzen
- `App.xaml.cs`: `MainWindow.Show()` ist auskommentiert → klären ob gewollt
- Kein DI-Container vorhanden → bei Wachstum einführen (z. B. Microsoft.Extensions.DependencyInjection)

## Was Claude hier tun soll
- MVVM-Muster konsequent einhalten
- Bei neuen Features: zuerst Interface definieren, dann Implementierung
- Bestehende Patterns (AsyncCommandBase, ViewModelBase) weiterverwenden, nicht neu erfinden
- Keine NuGet-Pakete hinzufügen ohne explizite Aufforderung

## Was Claude hier NICHT tun soll
- Keinen Code in Code-Behind schreiben (außer `InitializeComponent()`)
- Keine direkte Instanziierung von Services im ViewModel
- Keine `async void`-Methoden außerhalb von `AsyncCommandBase`
- Namespace nicht umbenennen
