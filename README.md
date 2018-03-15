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

The solution is comprised of 6 projects located in separate solution folders.  To view the ASP.NET MVC
site that demonstrates all the capabilities of the solution, set the UI.Web project as the default startup project by right clicking on the UI.Web project and selecting the "<i>Set as Startup Project</i>" option.

<dl>
  <dt>Domain Folder</dt>
  <dd>Domain.Entity</dd>
  <dd>Domain.Interface</dd>
  <dt style="color:blue;">Infrastructure Folder</dt>
  <dd>Infrastructure.ExceptionManager</dd>
  <dt>Services Folder</dt>
  <dd>Services.UseCase</dd>
  <dt style="color:blue;">UI Folder</dt>
  <dd>UI.Web</dd>
  <dt>UnitTest Folder</dt>
  <dd>UnitTest.OhmCalculator</dd>
</dl>


