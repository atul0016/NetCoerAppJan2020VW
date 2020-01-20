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
