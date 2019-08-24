# FoodDeliveryService
Food Delivery Services for Professionals

## Purpose
This is a web application that is designed to provide a food delivery service to busy professionals. 
It will contain the front UI layers and the back-end service layers.

## Application Design Layers
![Application Design](https://github.com/iamatran/FoodDeliveryService/blob/master/Design%20Documents/appDesign.jpg)

## Running the application locally

### Install Setup Environment

* Install Visual Studio Community 2017 (https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community&rel=16)

    #### Install the following components/packages in Visual Studio

    * .NET Core cross-platform development
    * ASPNET and web development
    * SQL Server Express 2016 LocalDB

* Install .NET Core 2.1 SDK (https://dotnet.microsoft.com/download/dotnet-core/2.1)
* Install Visual Studio Code (https://code.visualstudio.com/)
* Install NodeJS (https://nodejs.org/en/)
* Install Angular CLI (In Powershell)
```
$ npm install --global @angular/cli@7
```

### Run program in Visual Studio Code with the built-in Powershell terminal

* Setup Database Migration with Entity Frame Core 
    ```
    $ dotnet ef migrations add InitialCreate
    ```

* Update Database Schema
    ```
    $ dotnet ef database update
    ```
* Install .NET dependencies
    ```
    $ dotnet restore
    ```
* Create sql-cache for session data
    ```
    $ dotnet sql-cache create "Server=(localdb)\MSSQLLocalDB;Database=FoodDeliveryService;Trusted_Connection=True;MultipleActiveResultSets=true"  "dbo"  "SessionData"
    ```

* Update Database Migration
    ```
    $ dotnet ef migrations add Orders
    ```
* Update Database Schema
    ```
    $ dotnet ef database update
    ```
* Start the application
    ```
    $ dotnet run
    ```