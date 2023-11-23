# Razor Pages
ASP.NET Razor Pages is a server-side, page-focused framework that enables building dynamic, data-driven web sites with clean separation of concerns.

Part of the ASP.NET Core web development framework from Microsoft, Razor Pages supports cross platform development and can be deployed to Windows, Unix and Mac operating systems.

The Razor Pages framework is lightweight and very flexible. It provides the developer with full control over rendered HTML. Razor Pages is the recommended framework for cross-platform server-side HTML generation.

Razor Pages makes use of the popular C# programming language for server-side programming, and the easy-to-learn Razor templating syntax for embedding C# in HTML mark-up to generate content for browsers dynamically.

Architecturally, Razor Pages is an implementation of the MVC pattern and encourages separation of concerns.

## For using Razor Pages in solution
Add two things:
<services container>.AddRazorPages();   // This for enabling "Razor Pages" functionality
optional:
.AddRazorRuntimeCompilation(); // This for enabling "Razor Runtime Compilation" functionality, it allows re-compile the page without rebuild application.

<app>.MapRazorPages();
or
<app>.UseEndpoints(endpoint => endpoint.MapRazorPages());
// This is config pipeline that will redirect request to correct endpoint of razor pages

## Structure
In an Razor Page, it has two components, one is the view - content page (.cshtml) and the other is its handler(.cshtml.cs).
For example, we have a razor page named to Admin. So we will have a content view named to Admin.cshtml and a handler named to Admin.cshtml.cs.

Although, a Razor page also has only one content view instead of has both content and handler. This razor is called a component of view, or a razor view, or partial view. This is a special file. With the component of view, or a razor view, we named the file by default conventions, but with partial, the name must start with underscore (_).

Some popular Partial views that support by default are:
_Layout.cshtml: This is a skeleton, or the layout that will be rendered most of the page. Its look like below

The request to Admin Razor Page ----> Server found the Admin Razor Page -----> Server found the layout that Admin page will be embedded into ---> Server handle everything about data on Admin page -----> Server take everything HTML after handle data progress and embedded it into Layout ----> Server returns the response (HTML page that handled).


> All pages will be located in Pages folder, it is the convention of Razor Pages service that user must follow. (AddRazorPages)

## Razor syntax
For making dynamic HTML pages, Razor Page provide a thing called Razor syntax, that allow dev can embedded C# code into Razor Views.
The Razor syntax begin with an @ or @{}
The @ for single line
@{} for multiple lines

Razor also has some properties for itself, an example is Layout properties, that specifies the layout of that Razor View.
Other properties: ViewBag, ViewData, TempData,...


## Routing
The default url: / => The Endpoint middleware will find the Index razor page
Also, if we have a url is "https://<domain>:<port>/admin/ => It will find the Admin folder in Pages folder, and then find the Index Razor page in Admin folder.

https://<domain>:<port>/    => Find the Index in Pages Directory
https://<domain>:<port>/admin    => Find the Index page in Admin directory in Pages Directory
https://<domain>:<port>/admin/login    => Find the login page inside Admin directory in Pages Directory
https://<domain>:<port>/privacy    => Find Privacy page in Pages Directory

## Directive
Each page has @page on the top, this is called directive. If no has this directive, the file will be not treated as a page by compiler. 