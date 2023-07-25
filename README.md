[![Version: 1.0 Release](https://img.shields.io/badge/Version-1.0%20Release-green.svg)](https://github.com/ak-app) [![.NET Core Desktop](https://github.com/ak-app/coding/actions/workflows/dotnet-release.yml/badge.svg)](https://github.com/ak-app/coding/actions/workflows/dotnet-release.yml) [![codecov](https://codecov.io/gh/ak-app/coding/branch/main/graph/badge.svg)](https://codecov.io/gh/ak-app/coding) [![License: GPL v3](https://img.shields.io/badge/License-GPL%20v3-blue.svg)](https://www.gnu.org/licenses/gpl-3.0)


# C# library example

## Program Layout

| Main | Add | Update |
|------|-----|--------|
| ![FormMain](./FormMain.png) | ![FormData](./FormData_Create.png) | ![FormData](./FormData_Update.png) |

> An empty template that includes the forms above can be downloaded [here](https://github.com/ak-app/coding/releases/latest/download/LibraryManagement-FormTemplate.zip). A full running example can be downloaded [here](https://github.com/ak-app/coding/releases/latest/download/LibraryManagement.zip).

---

## Example program

The standard example program uses a list as data store. It can not be adaptet like the following [program](#example-program-with-abstraction) with abstraction. It can be found in the `LibraryManagement` solution under [_FormsNoAbstraction](./_FormsNoAbstraction).

---

## Example program with abstraction

The example program with abstraction includes a modular `IDataAccess` which is implemented by different libraries as `BookDataAccess` with:

1. `Book List`
1. `SQLite Database`
1. `EF Core`
1. `File`

The abstract `ValidateBookDataAccess` library implements the Validation of the `Book` objects. It can be found in the `LibraryManagement` solution under [LibraryManagement.Access](./LibraryManagement.Access).

### `BookDataAccess as List`

Implements a simple list in backend and is designed for testing purpose.

``` csharp
_bookDataAccess = new Access.Memory.BookDataAccess();
```

### `BookDataAccess with Database`

Data is saved in a SQLite database either with EFCore or with raw SQL. Can be used within every database that inherits from `DbConnection` and `DbCommand` (e.g. `mSQL`, `MySQL`, `mariaDB`, `...`).

``` csharp
IConfiguration config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();
```

``` csharp
// -> With native SQL (sqlite, mariadb, mysql, msql)
_connection = new SqliteConnection(config.GetConnectionString("SQLiteConnectionString"));
_bookDataAccess = new Access.Db.BookDataAccess(_connection);
```

``` csharp
// -> With EFCore
_connection = new SqliteConnection(config.GetConnectionString("SQLiteCoreConnectionString"));
DbContextOptionsBuilder builder = new DbContextOptionsBuilder<Access.Core.DataContext>()
    .UseSqlite(_connection);
_bookDataAccess = new Access.Core.BookDataAccess(new Access.Core.DataContext(builder.Options));
```


### `BookDataAccess with File`

Implements a file reader/writer for handling the list of books

``` csharp
_bookDataAccess = new Access.File.BookDataAccess("Books.dat");
```

### Global class diagram

![Diagram](./GlobalClassDiagram.png)

---

R. GÄCHTER
