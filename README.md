# Project - Scraping Page

Project created with the objective of making web scraping, of pages informed by the user.

Project image:

![Running application](https://github.com/AndreiLuis/ScrapingPages/blob/main/Images/AppWorking.PNG)

### Front End
- Angular 9
- CSS
- HTML
- TypeScript

### Back-End
- .NETCore 3.1

## Selenium Installation

In this project, [Selenium](https://www.selenium.dev/) is being used, due to its documentation and possibilities of use.

> [!]Note: Before installing the library it is important to check if you have the webdriver installed.
> If not, follow this instruction manual: [link](https://www.selenium.dev/documentation/getting_started/installing_browser_drivers/).
> Tip: Always try to download the same version as your browser (in this project **chrome** is being used)

To use the library, run this command in the **Scraping.Core** project:
```powershell
# Using package manager
Install-Package Selenium.WebDriver
# or using .Net CLI
dotnet add package Selenium.WebDriver
```
Or use visual studio's Nuget Package visual feature:
![Installation package](https://github.com/AndreiLuis/ScrapingPages/blob/main/Images/PrintNugetPackage.PNG)


## Compile the projects

On the backend, enter the project folder:
```powershell
PS ...\ScrapingPages\Scraping.Service>
```
And run the command:
```powershell
dotnet run
```
On the front-end, enter the folder:
```powershell
PS ...\ScrapingPages\Scraping.Web>
```
Run the command:
```powershell
ng build
```
And then this command:
```powershell
ng serves
```
Or, you can also use:
```powershell
npm start
```