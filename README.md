# CartManager
Some exercises with a cart with JSON and C#

# Requirements
* [.NET Framework v4.6.1](https://www.microsoft.com/pt-br/download/details.aspx?id=49982)

# Dependencies
The nuget packages included are:
* Newtonsoft.Json
* NUnit
* NUnit.Console
* NUnit.ConsoleRunner

# How to build
1. `MsBuild.exe .\CartManagerApplication.sln /t:Build /p:Configuration=Release /p:TargetFramework=v4.6.1`

# How to execute
1. `.\CartManagerApplication\bin\Release\CartManagerApplication.exe`

# Results
The result json files are generated on: <br>
1. `.\CartManagerApplication\bin\Release\results\level1\output.json` <br>
2. `.\CartManagerApplication\bin\Release\results\level2\output.json` <br>
2. `.\CartManagerApplication\bin\Release\results\level3\output.json` <br>
