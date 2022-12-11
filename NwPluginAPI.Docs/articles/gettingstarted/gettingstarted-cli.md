# Setting up your environment
## Prerequisites
- [.NET CLI](https://learn.microsoft.com/en-us/dotnet/core/install/windows?tabs=net70)
- [.NET Framework 4.8](https://dotnet.microsoft.com/en-us/download/dotnet-framework/thank-you/net48-developer-pack-offline-installer)
- Any text editor
    - [Visual Studio Code](https://code.visualstudio.com/) is the most popular choice
## Creating the project
1. Open your terminal of choice at the location you want to create your project at
2. Run `dotnet new console -n MyName`
3. Open the MyName.csproj file inside the MyName folder and change `TargetFramework` to `net4.8`

## Adding References
1. Run `dotnet add package Northwood.PluginApi -prerelease`