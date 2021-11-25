# Orm-Compare

### Introduction
Scope of this project is to analyze different .NET approaches to retrieve data from MSSQL database and expose through a Web Api Rest. For semplicity only Get method will be considered but
interaction with database will use different ways and different technologies:

1. EntityFrameworkCore 2.1
2. EntityFrameworkCore 3.1
3. EntityFrameworkCore 5.0
4. EntityFrameworkCore 6.0
5. Dapper (.Net 6.0) [[info](https://github.com/DapperLib/Dapper)]
6. JsonPath (.Net 6.0) [[info](https://docs.microsoft.com/en-us/sql/relational-databases/json/json-path-expressions-sql-server?view=sql-server-2017)]

### Database project.
The database contains one table with five fields:

```
CREATE TABLE [dbo].[portfolio] (`
    [PortfolioId]     INT            NOT NULL,
    [PortfolioCode]   NVARCHAR (100) NOT NULL,
    [PortfolioName]   NVARCHAR (100) NOT NULL,
    [PortfolioType]   NVARCHAR (100) NOT NULL,
    [PortfolioStatus] NVARCHAR (100) NOT NULL
);
```

The table contains 20,000 rows.

### Structure of the project
The solution contains six projects for each technology plus a database project. All Web Api projects have the same structure:
1. Controller contains the controller
2. Models contains class that maps the database table
3. Services contains the repository patter
4. MyContext is the database context 

##### Steps for Entity Framework Core projects.
1. Add *Microsoft.EntityFrameworkCore* by *NuGet* package to your project.
2. Update ConfigureServices in *Startup* class.
3. Create your model, *Portfolio* class, **ensuring you will add a primary key**.
4. Create your own context, *MyContext* class, inherited from DbContext where you set your data set. This class will use your model.
5. Create your repository class by injecting your context class. This class will have only one method, * GetPortfolios()*.
6. Creat your resourse in *PortfolioController*.

##### Steps for Dapper project:
1. Add *Dapper* by NuGet package to your project.
2. Create your model, *Portfolio* class.
3. Create your resourse in *PortfolioController*.

##### Steps for Json Path project:
1. Create your resourse in *PortfolioController*. It is only needed to pass the query you need. That's all.


### How to test
In order to test web api's, the response time will be considered. I created a Benchmark Rest Get project that I used for this purpose and can be found [here](https://github.com/skepee/Benchmark-Rest-Api-Get). It is a console app that you can invoke in the command line by passing these parameters:
1. Web Api url
2. number of iterations
3. Y/N if you want a log file, optional

###Performance results
In order to test the response time I used Benchmark Rewst Get console in this way:

```
BenchmarkRestGet https://localhost:44347/api/portfolio/ef3_1 5000 Y
BenchmarkRestGet https://localhost:44323/api/portfolio/ef5_0 5000 Y
BenchmarkRestGet https://localhost:44397/api/portfolio/ef2_1 5000 Y
BenchmarkRestGet https://localhost:7266/api/portfolio/dapper 5000 Y
BenchmarkRestGet https://localhost:7230/api/portfolio/ef6_0 5000 Y
BenchmarkRestGet https://localhost:7113/api/portfolio/jsonpath 5000 Y
```

These are the results for the *GetPortfolios()* calling on 5000 iterations to get 20,000 rows each time:

   Type    | Min Time | Max Time | Avg Time     | Initial memory allocation | Memory allocation after 10 iterations |
---------- | -------- | -------- |--------------|---------------------------| ------------------------------------- |  
  EF 2.1   | 148 ms   | 5142 ms  |  407.9812 ms |                           |                                       | 
  EF 3.1   | 117 ms   | 7126 ms  |  375.5712 ms |                           |                                       | 
  EF 5.0   | 103 ms   | 1636 ms  |  277.197 ms  |                           |                                       | 
  EF 6.0   | 79 ms    | 983 ms   |  195.111 ms  |                           |                                       | 
  Dapper   | 60 ms    | 7012 ms  |  135.8858 ms |                           |                                       | 
  JsonPath | 87 ms    | 527 ms   |  183.673 ms  |                           |                                       | 


### Conclusions
In this very simple example a ORM perfomance comparison has been shown. By using Sql Server Json native support we can have many benefits:
1. No NuGet package to install.
2. No extra code to add (repository, context).
3. No mapping class needed (then no CPU time spent).
4. More efficient in terms of time and CPU usage.


### Final notes
Attached to the solution also the benchmark results I used for this test.

