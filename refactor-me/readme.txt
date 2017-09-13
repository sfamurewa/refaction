
Oluwaseun Famurewa
Implementations
Objectives were to create a maintainable, clean, lean code and modify the solution to be unit testable. In addition, the solution eliminates security risk such as SQL injection found in the command queries.  

Entity Framework
This ORM tool implemented as the data layer to help eliminate SQL injection, introduce optimized and efficient queries while also providing a clean and lean code. 

Model Factory using Data Transfer Objects (DTOs)
Prevents self-referencing when returning chain of objects and provide a level of abstraction between the data layers and the controllers. 

Dependency Injection Pattern
This design ensures a loosely coupled pattern between objects and classes by the removal of hard-coded dependencies 
In other words it allows you to load mock classes in test environments vs real objects in production environments (Wikipedia).

IQueryable
The Product Repository implements the IQueryable return type for the Product Repository to prevent returning too many records from the database. It gives the benefits of deferred execution and full support for LINQ-to-SQL. 

IHTTPActionResult
The return types of the controller actions was changed to IHttpActionResult interface
This will allow us to return http status code along with the results. It also helps to 
•	simplify unit testing your controllers
•	moves common logic for creating HTTP responses into separate classes
•	makes the intent of the controller action clearer, by hiding the low-level details of constructing the response
Source (docs.microsoft.com)

Enable CORs action for cross-domain
Enabling the Cross Origin Resource Sharing will allow clients to issue requests from a different domain to the API




