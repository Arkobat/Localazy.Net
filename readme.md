# Localazy C# SDK

This is an unofficial SDK for integrating with Localazy, a cloud-based localization platform. 
This SDK simplifies the process of managing and fetching translations for your C# projects.

## Installation

You can install the Localazy SDK using NuGet.
Run the following in the console
```bash
dotnet add package Localazy.Sdk 
```

## Setup

To get started with the Localazy SDK, follow these steps:

1) Obtain API Key:  
   You can obtain your project token at https://localazy.com/developer/tokens


2) Initialize the SDK:  
   In your application, initialize the Localazy SDK by providing the API key:

```csharp
using Localazy

services.AddLocalazySdk("YOUR_API_KEY");
```

Replace YOUR_API_KEY with your actual Localazy API key.

## Use Case Examples

Below are some use case examples to demonstrate how to use the Localazy SDK in your C# project.  
You can customize and expand upon these examples based on your specific needs.

### Example 1: Fetching All Files

```csharp
using Localazy;

const string ProjectId = "_a1234567890123456789";

var files = await localazyService.ListFilesInProject(ProjectId);
Console.WriteLine($"Fetched {files.Count} files");
```

### Example 2: Fetching translations for a file

```csharp
using Localazy;

const string ProjectId = "_a1234567890123456789";
const string FieId = "_a1234567890123456789";

var content = await localazyService.ListFileContent(ProjectId, FieId, "en");
Console.WriteLine($"Fetched {content.Keys.Count} messages");
```

## API Documentation
For more details on Localazy and its API, refer to the Official Localazy API Documentation.  
You can find it here: https://localazy.com/docs/api/

## Contribution
Feel free to contribute to this project by submitting issues or pull requests. Your contributions are highly appreciated!