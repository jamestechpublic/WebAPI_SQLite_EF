# WebAPI_SQLite_EF

## Description
Example demo of a C# WebAPI using standard architecture.
* Controllers
* Services
* Data Context
* Models
* DTOs (included in shared project)
* Serilog Logging

## About the Tools
* Visual Studio 2022
* .NET 9.0
* Entity Framework Core v9
* Scalar (API tester)
* Serilog (logging)

## About the Data
This example uses a SQLite database for simplicity.
It contains two tables:
* Genres (Id, GenreName)
* Movies (Id, MovieName, GenreId, ReleaseYear)

## About the ORM
This example uses Entity framework Core v9.

## About the API Test
This example includes Scalar to test the API.
To test the API:
* With the source code in VS2022, run the application.
* Open a Web Browser to the specified port.
* Add /scalar/v1 to the URL to run scalar and test the API.
