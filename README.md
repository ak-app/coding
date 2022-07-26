[![Version: 1.0 Release](https://img.shields.io/badge/Version-1.0%20Release-green.svg)](https://github.com/sunriax) [![.NET Core Desktop](https://github.com/ak-app/coding/actions/workflows/dotnet-release.yml/badge.svg)](https://github.com/ak-app/coding/actions/workflows/dotnet-release.yml) [![codecov](https://codecov.io/gh/ak-app/coding/branch/main/graph/badge.svg)](https://codecov.io/gh/ak-app/coding) [![License: GPL v3](https://img.shields.io/badge/License-GPL%20v3-blue.svg)](https://www.gnu.org/licenses/gpl-3.0)


# C# library example

## Program Layout

| Main | Add | Update |
|------|-----|--------|
| ![FormMain](./FormMain.png) | ![FormData](./FormData_Create.png) | ![FormData](./FormData_Update.png) |

> A empty template that includes the forms above can be downloaded [here](https://github.com/ak-app/coding/releases/latest/download/LibraryManagement-FormTemplate.zip). A full running example can be downloaded [here](https://github.com/ak-app/coding/releases/latest/download/LibraryManagement.zip).

---

## Example program

The standard example program uses a list as data store. It can not be adaptet like the following [program](#example-program-with-abstraction) with abstraction. It can be found in the `LibraryManagement` solution under [FormsNoAbstraction](./FormsNoAbstraction).

---

## Example program with abstraction

The example program with abstraction includes a modular `DataService` which is implemented by different libraries e.g.:

1. `ListDataService`
1. `SQLiteDataService`
1. `DbDataService`

The `DataService` library implements the Validation of the `Book` objects. It can be found in the `LibraryManagement` solution under [Forms](./Forms).

### `ListDataService`

Implements a simple list in backend and is designed for testing purpose.

### `SQLiteDataService`

Data is saved in a SQLite database

### `DbDataService`

Can be used within every database that inherits from `DbConnection` and `DbCommand` (e.g. `mSQL`, `MySQL`, `mariaDB`, `...`).

### Global class diagram

![Diagram](./GlobalClassDiagram.png)

---

R. GÄCHTER
