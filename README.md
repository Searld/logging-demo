# Фильтрация логов в Microsoft.Extensions.Logging

**Автор:** Безносов Иван

**Исследуемая библиотека:** Microsoft.Extensions.Logging, версия **10.0.14**
(NuGet-пакеты `Microsoft.Extensions.Logging*` 10.0.14).

**Исходный код библиотеки:** <https://github.com/dotnet/runtime/tree/v10.0.14/src/libraries/Microsoft.Extensions.Logging>
(репозиторий dotnet/runtime, тег `v10.0.14`).

## Запуск демо-проекта

Нужен [.NET SDK 10](https://dotnet.microsoft.com/download/dotnet/10.0).

```bash
dotnet run
```
## Примеры изменений для проверки

- Добавить в секцию `"Console"` → `"LogLevel"` строку `"MyApp": "Information"` — консоль начнёт
  писать Information: у этого правила тоже указан провайдер, но категория длиннее.
- `"Debug": { "LogLevel": { "Default": "None" } }` — провайдер `Debug` исключается из `MessageLoggers`.
- `"LogLevel": { "MyApp": "Trace" }` без секции `"Console"` — оба провайдера пишут всё.
- Добавить в `Program.cs` после `AddConfiguration` строку
  `logging.AddFilter<Microsoft.Extensions.Logging.Console.ConsoleLoggerProvider>("MyApp", LogLevel.Debug);` —
  правило из кода встанет в список после правил из конфигурации и перебьёт правило `Console`
  из `appsettings.json`, потому что у него есть категория.
