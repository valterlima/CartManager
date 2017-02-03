# CartManager
Some exercises with a cart with JSON and C#

## Requirements
* [NuGet](https://www.nuget.org/)
* [.NET Framework v4.6.1](https://www.microsoft.com/pt-br/download/details.aspx?id=49982)

## Dependencies
The nuget packages included are:
* [Newtonsoft.Json](http://www.newtonsoft.com/json) v9.0.1
* [NUnit, NUnit.Console and NUnit.ConsoleRunner](https://www.nunit.org/) v3.6.0

Download and install packages with NuGet: 

1. `nuget restore`

## How to build
To build you only need **MsBuild** from the .NET Framework

1. `MsBuild.exe .\CartManagerApplication.sln /t:Build /p:Configuration=Release /p:TargetFramework=v4.6.1`

## How to test
Run **NUNIT3-CONSOLE** on the assembly **CartManagerApplication.exe**

1. `.\packages\NUnit.ConsoleRunner.3.6.0\tools\nunit3-console.exe .\CartManagerApplication\bin\Release\CartManagerApplication.exe`

The resulting test report will be available on **TestResult.xml**

## How to execute
1. `.\CartManagerApplication\bin\Release\CartManagerApplication.exe`

## Results
The result json files are generated on:

1. `.\CartManagerApplication\bin\Release\results\level1\output.json`
2. `.\CartManagerApplication\bin\Release\results\level2\output.json`
2. `.\CartManagerApplication\bin\Release\results\level3\output.json`

