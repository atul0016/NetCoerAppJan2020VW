EntifyFramework Core
1. Microsoft.EntityFrameworkCore
	DbContext class
		- Connect to Database
		- map CLR object to DB Table using DbSet<T>
				Where T is the CLR class map with DT Table of name T
		- Manage the DB Connection Resiliancy (DB Connection Retry) EF Core 2.x
		- DbConext Pooling new feature of EF Core 2.x 128
		- Async Task based DB Transactions
			SaveChangesAsync(), AddAsync(), AddRangeAsync(), FindAsync()	
	EF Core 2.x	
		- HasOne()/HasMany(), methods for One-to-one and One-to-Many
		- OwnOne() and OwnMany()	
1. Microsoft.EntityFrameworkCore.Relational
1. Microsoft.EntityFrameworkCore.SqlServer
1. Microsoft.EntityFrameworkCore.Tools --> CLI for Data Migration
1. Microsoft.EntityFrameworkCore.Design --> Map the CLR objects with the Db table

=========================================================================================================

Note: .NET Core 3.x +
dotnet tool install --global dotnet-ef --version 3.1.0 / 3.0.0 

Data Migration Commands

1. Generate Migration Files
	YYYYMMDD<RNDNumber>_<MigrationName>.cs
			Create Table Commnands based on CLR Classes

dotnet ef migrations add <migrationname> -c <NameSpace.DbContext class>

e.g.
dotnet ef migrations add fisrtMigration -c Core_APIApp.Models.AppDataDbContext
 20200120656565_firstMigration.cs

 The Snapshot file that will defin the Mapping between CLR to Table

 Command to Update database

 dotnet ef  database  update -c <NameSpace.DbContext class>
 e.g

 dotnet ef  database update -c Core_APIApp.Models.AppDataDbContext
 ==========================================================================================================

 ModelStateDictionary : The 'ModelState' against the Data Validation
 ControllerContext : COntroller that is currently under execution
			--> Map the HTTP request to a method from Controller class

- IActionResult is a common contract between API and Client 

===========================================================================================================
ASP.NET Core API Programming
1. Parameter Binding
	Body Parameters for POST (Default but managed by ApiController Attribute class)
	Parameter Binding Objects
		FromBody --> Read data from Http request Body for POST request
		FromQuery --> Read data from Http request in QuryString for POST request
		FromForm --> Read data from Http request in Form Model Object for POST request
		FromRoute --> Data is posted using HTTP Route Parameters for POST request
2. Exception Handling
3. Middlewares
4. Secure
5. CORS
6. Deploymentp