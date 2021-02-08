| README.md |
|:---|

<div align="center">

![Cake.Args](asset/cake-args-logo.png)

</div>

<h1 align="center">Cake.Args</h1>
<div align="center">

Cross-platform addin for the [Cake](https://cakebuild.net) build automation system that adds Arguments extensions in Cake build scripts. Cake.Args targets .NET 5.0, .NET Standard 2.0 and .NET Framework 4.6.1.

[![NuGet Version](https://img.shields.io/nuget/v/Cake.Args.svg?color=blue&style=flat-square)](https://www.nuget.org/packages/Cake.Args/) [![Stack Overflow Cake Build](https://img.shields.io/badge/stack%20overflow-cakebuild-orange.svg?style=flat-square)](http://stackoverflow.com/questions/tagged/cakebuild)

</div>

## Give a Star! :star:

If you like or are using this project please give it a star. Thanks!

## Getting started :rocket:

Simply add `Cake.Args` in your build script by using the [`addin`](http://cakebuild.net/docs/writing-builds/preprocessor-directives#add-in-directive) directive:

```csharp
#addin "nuget:?package=Cake.Args&version=1.0.0"
```

_Make sure the `&version=` attribute references the [latest version of Cake.Args](https://www.nuget.org/packages/Cake.Args/) compatible with the Cake runner that you are using. Check the [compatibility table](#compatibility) to see which version of Cake.Args to choose_.

And you're ready to use the arguments extensions in your Cake build script:

```csharp
#addin "nuget:?package=Cake.Args&version=1.0.0"

var configuration =
    ArgumentOrDefault<string>("configuration") ??
    ArgumentOrDefault<string>("config") ??
    "Release";

var majorVersion =
    ArgumentOrDefault<int?>("majorVersion") ??
    ArgumentOrDefault<int?>("major");

Task("Example")
    .Does(context =>
{
    var settings = new DotNetCoreBuildSettings
    {
        Configuration = configuration,
    };

    if (majorVersion.HasValue)
    {
        settings.VersionSuffix = $"{majorVersion}.0.0";
    }

    DotNetCoreBuild("./MyProject.sln", settings);
});

RunTarget("Example");
```

## Arguments extensions available

| Method                 | Description                                                                   |
| ---------------------- | ----------------------------------------------------------------------------- |
| `ArgumentOrDefault<T>` | Returns an argument value by name or `default(T)` if the argument is missing. |

## Compatibility

Cake.Args is compatible with all [Cake runners](https://cakebuild.net/docs/running-builds/runners/), and below you can find which version of Cake.Args you should use based on the version of the Cake runner you're using.

| Cake runner     | Cake.Args       | Cake addin directive                              |
|:---------------:|:---------------:| ------------------------------------------------- |
| 1.0.0 or higher | 1.0.0 or higher | `#addin "nuget:?package=Cake.Args&version=1.0.0"` |
| 0.33.0 - 0.38.5 | 0.1.0           | `#addin "nuget:?package=Cake.Args&version=0.1.0"` |
| < 0.33.0        | _N/A_           | _(not supported)_                                 |

## Discussion

For questions and to discuss ideas & feature requests, use the [GitHub discussions on the Cake GitHub repository](https://github.com/cake-build/cake/discussions), under the [Extension Q&A](https://github.com/cake-build/cake/discussions/categories/extension-q-a) category.

[![Join in the discussion on the Cake repository](https://img.shields.io/badge/GitHub-Discussions-green?logo=github)](https://github.com/cake-build/cake/discussions)

## Release History

Click on the [Releases](https://github.com/augustoproiete/Cake.Args/releases) tab on GitHub.

---

_Copyright &copy; 2021 C. Augusto Proiete & Contributors - Provided under the [MIT License](LICENSE)._
