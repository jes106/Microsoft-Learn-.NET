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

To start the app we can use `dotnet watch`

In the file `index.cshtml` that includes C# code and HTML we can see this importante directives in C#:

```
ViewData["Title"] = "The home for Pizza Lovers";
TimeSpan timeInBussiness = DateTime.Now - new DateTime(2018, 8, 14);
```

To create a new page in the project we write

`dotnet new page --name PizzaList --namespace ContosoPizza.pages --output Pages`

that creates the cshtml and cshtml.cs files 

We add the content to the new created page and we add the page to the nav menu defined in Pages/Shared/_Layout.cshtml:

```
                        <li class="nav-item">
                            <a class="nav-link text-dark" asp-area="" asp-page="/PizzaList">Pizza List 🍕</a>
                        </li>
```

Now, we will show the list of pizzas, first we need to create the dependence of the PizzaService in the file Program.cs with the code:

`builder.Services.AddScoped<PizzaService>();`

Then, we will create the code to get the list of pizzas in the file PizzaList.cshtml.cs:

```
    public class PizzaListModel : PageModel
    {
        private readonly PizzaService _service;
        public IList<Pizza> PizzaList { get; set; } = default!;

        public PizzaListModel(PizzaService service)
        {
            _service = service;
        }

        public void OnGet()
        {
            PizzaList = _service.GetPizzas();
        }
    }
```

And we will show it on the page in the file PizzaList.cshtml:

```
<table class="table mt-5">
    <thead>
        <tr>
            <th scope="col">Name</th>
            <th scope="col">Price</th>
            <th scope="col">Size</th>
            <th scope="col">Gluten Free</th>
            <th scope="col">Delete</th>
        </tr>
    </thead>
    <tbody>
        @foreach(var pizza in Model.PizzaList)
                {
                <tr>
                    <td>@pizza.Name</td>
                    <td>($"{@pizza.Price:C}")</td>
                    <td>@pizza.Size</td>
                    <td>@(pizza.IsGlutenFree ? "✔️" : string.Empty) </td>
                    <td>
                        <form method="post" asp-page-handler="Delete" asp-route-id="@pizza.Id">
                            <button class="btn btn-danger">Delete</button>
                        </form>
                    </td>
                </tr>
                } 
    </tbody>
</table>
```

The attributes `asp-page-handler` indicates the action to do in the click of the button and `asp-route-id`indicates the Id of the object pizza to send to the Delete controller.

### AN UNHANDLED EXCEPTION OCURRED WHILE PROCESSING THE REQUEST

Now we will learn how to include C# code in our HTML by rewriting them:

- Partial tags: `<partial name="_ValidatorScriptsPartial">` include the content of the file in the page
- Auxiliar tags: `<label asp-for="Foo.Id" class="control-label"></label>` accepts a property of PageModel and show it in a label
- Input tags: `<input asp-for="Foo.Id" class="form-control" />` indicates the property of PageModel that changes on input
- Validation tags = `<div asp-validation-summary="All"></div>` show a validation message for a property of the model.

Like we have done in the PizzaList page we can control the HTTP request with methods like `OnGet()`, `OnPost()`, etc.

The annotation BindProperty fills the variable in the form POST