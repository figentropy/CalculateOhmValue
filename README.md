<img src="http://clipground.com/images/electrical-resistance-clipart-5.jpg" width="50">

# CalculateOhmValue
Calculates resistor values for 4 band resistors and is easily extendable to 5-6 band resistors without too many changes.


## Installing / Getting started

This solution was designed using Visual Studio 2017 using the 4.71 .NET Framework.  It should also work with Visual Studio 2015.



## Developing

In order to get started with development, bring the code down to your local instance.

```shell
git clone https://github.com/figentropy/CalculateOhmValue.git

cd CalculateOhmValue

Using Visual Studio, open the solution OhmCalculator.sln
```


## Building

The solution is comprised of 7 projects located in 5 separate solution folders.  To view the ASP.NET MVC
site that demonstrates all the capabilities of the solution, set the UI.Web project as the default startup project by right clicking on the UI.Web project and selecting the "<i>Set as Startup Project</i>" option.


```
1. <b>Domain Folder</b>
   - Domain.Entity
   - Domain.Interface
   
2. <b>Infrastructure Folder</b>
   - Infrastructure.ExceptionManager
   - Services Folder

3. <b>Services Folder</b>
   - Services.UseCase

4. <b>UI Folder</b>
   - UI.Web

5. <b>UnitTest Folder</b>
   - UnitTest.OhmCalculator
```

