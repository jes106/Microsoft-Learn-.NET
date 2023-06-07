# Microsoft-Learn-.NET


## Module 1

The first module is an introduction to C# and to all languages in general. The module explains about the programming languages, compilers, etc.

## Module 2

In this module it's explained how to build a webpage with HTML, CSS and JS. It explains the importance to separe these three concepts. 

## Module 3

In this module explains the importance of the accesibility in out website and it shows tools like Zoom, Screen Readers, etc. A good tool to check the accesibility is Lighthouse created by Google and it's included in several browsers. The main problematic elements are: hyperlinks (solved by aria-label attribute and AIRA roles) and images (solved by alt attribute). It's essential to check the structure os the code not only the design of the website

## Module 4

In this module it's purposed to create a Razor Pages of ASP.NET Core website. Razor is a mix beetwen HTML and C# and it allows to create the view of the website in function of the value of variables or return of functions. It reduces the parcial views. Here we have a list about the files in ContosoPizza:

- Models : contains the class that identifies a Pizza
- Data : contains a class that represent the context of the database. It ease the work with the database
- Services: It containts the class to interact with the database (list, add, modify, etc.)
- Migrations: It contains the code to create the database
    - ContosoPizza.db: It's the database in SQLite
- Pages: It contains Razor Pages (.chtml) and Auxiliar files (.cshtml.csPageModel)
- wwwroot: It contains the static resources (HTML, CSS y JS)
- ContosoPizza.csproj: This file contains the metadata to configurate the project and the dependences
- Program.cs: It's the enter point to the app and create the routers


