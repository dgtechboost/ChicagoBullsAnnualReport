# ChicagoBullsAnnualReport
MVC app, n-tier application, SOLID, Ninject, OOP, Automapper, CSV

This application:

- processes the attached CSV file (chicago-bulls.csv) located in Artifacts folder of the Solution
- loads the file content
- creates a report in JSON file (chicago-bulls.json) which is added to Artifacts folder in the project folder for ChicagoBullsAnnualReport 


Third party tools used in this project:

- Json.NET is used to load content to json file (https://www.newtonsoft.com/json)
- Automapper is used to map objects of Domain Model to MVC model (https://automapper.org/)
- Ninject is used as an Inversion of Control container for dependency injection (http://www.ninject.org/)
