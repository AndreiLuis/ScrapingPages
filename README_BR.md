# Projeto - Scraping Page

Projeto criado com o objetivo de fazer web scraping, de paginas informadas pelo usuário.

Imagem do projeto:

![Aplicação em execução](https://github.com/AndreiLuis/ScrapingPages/blob/main/Images/AppWorking.PNG)

### Front-End 
- Angular 9
- CSS
- HTML
- TypeScript

### Back-End
- .NETCore 3.1

## Intalação do Selenium

Neste projeto está sendo utilizado o [Selenium](https://www.selenium.dev/), devido a sua documentação e possibilidades de uso.

> [!]Obs.: Antes de instalar a biblioteca é importante checar se tem o webdriver intalado.
> Caso não tive, sigar este manual de instrução: [link](https://www.selenium.dev/documentation/getting_started/installing_browser_drivers/).
> Dica: Tente sembre baixar a mesma versão que se navegador(que neste projeto está sendo usado o **chrome**)

Para a utilização da biblioteca, executem no projeto **Scraping.Core** esté comando:
```powershell
# Using package manager
Install-Package Selenium.WebDriver
# or using .Net CLI
dotnet add package Selenium.WebDriver
```
Ou use o recuro visual Nuget Package do visual studio:
![Pacote de instalação](https://github.com/AndreiLuis/ScrapingPages/Images/PrintNugetPackage.png)


## Compilar os projetos

No back-end, entre na pasta do projeto:
```powershell
PS ...\ScrapingPages\Scraping.Service>
```
E execute o comando:
```powershell
dotnet run
```
No front-end, entre na pasta:
```powershell
PS ...\ScrapingPages\Scraping.Web>
```
Execute o comando:
```powershell
ng build
```
E depois esse comando:
```powershell
ng serve
```
Também pode usar:
```powershell
npm start
```