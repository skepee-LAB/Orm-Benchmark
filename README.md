# Orm-Compare

### Intro
Which is the best way in terms of effort and performance to expose data in Json format? I will show you a comparison between two most common ORMs: **EntityFrameworkCore** and **Dapper**. Finally, I will show the performance by retrieving Json data directly from SQL Server. In fact, starting from Sql Server 2016 there is native support for JSON. A complete guide can be found [here](https://docs.microsoft.com/en-us/sql/relational-databases/json/json-path-expressions-sql-server?view=sql-server-2017). 
I will show you just a simple example of GET with three different methods.


### Content
The solution contains three projects and a unit test for each project. The unit test gets circa 16000 rows from a table with four fields. The performance profiler is used to check the CPU % of the use dmodules. After that, Postman is used as client to measure times.

##### Entity Framework
* JsonEF
* XUnitJsonEF

##### Dapper
* JsonDapper
* XUnitJsonDapper

##### Json Path
* JsonPath
* XUnitJsonPath

### Project description
##### Steps for Entity Framework Core project.
1. Add *Microsoft.EntityFrameworkCore* by *NuGet* package to your project.
2. Update ConfigureServices in *Startup* class.
3. Create your model, *Portfolio* class, **ensuring you will add a primary key**.
4. Create your own context, *MyContext* class, inherited from DbContext where you set your data set. This class will use your model.
5. Create your repository class by injecting your context class. This class will have only one method, * * GetPortfolios()* *.
6. Creat your resourse in *PortfolioController*.

##### Steps for Dapper project:
1. Add *Dapper* by NuGet package to your project.
2. Create your model, *Portfolio* class.
3. Create your resourse in *PortfolioController*.

##### Steps for Json Path project:
1. Create your resourse in *PortfolioController*. It is only needed to pass the query you need. That's all.




### Performance results
Here the performance results are listed:

### CPU comparison with performance profiler
##### Entity Framework
![Entity Framework](https://github.com/skepee/Orm-Compare/blob/master/screenshots/EF.png)

##### Dapper
![Dapper](https://github.com/skepee/Orm-Compare/blob/master/screenshots/Dapper.png)

##### Json Path
![JsonPath](https://github.com/skepee/Orm-Compare/blob/master/screenshots/JsonPath.png)



### Timing comparison by using Postman
##### Entity Framework in Postman
![Entity Framework in Postman](https://github.com/skepee/Orm-Compare/blob/master/screenshots/PostmanEF.png)

##### Dapper in Postman
![Dapper in Postman](https://github.com/skepee/Orm-Compare/blob/master/screenshots/PostmanDapper.png)

##### Json Path in Postman
![JsonPath in Postman](https://github.com/skepee/Orm-Compare/blob/master/screenshots/PostmanJsonPath.png)


By using Sql Server Json support, the  API call is vry fast because you do not need any class mapping and no extra code.
Compare these results: 
#### CPU %

  Type  | Entity Framework Core | Dapper | Sql Server Json Support
------- | --------------------- | ------ |--------------------------
  CPU % |         23.15%        | 8.99%  |       5.31%
  Time  |         3.84s         | 3.58s  |       3.41s



### Final conclusions
This is just a very simple example showing us that by using the Json native support we can have many benefits:
1. No NuGet package to install.
2. No extra code to add (repository, context).
3. No mapping class needed (then no CPU time spent).
4. More efficient in terms of time and CPU usage.

