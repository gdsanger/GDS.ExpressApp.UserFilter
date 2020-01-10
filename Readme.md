# GDS.ExpressApp.UserFilter (Win+Web)

With this module, user-specific filters can be created in listviews for all data elements in the XAF Applications. These filters can be created for personal use or made publicly available to all users. 

The module consists of four main elements:

* ListView "My filters" in the Navigation "personal area""
* "Filter" selection field in the menu above
* Action for adding new filters (icon at the top of the menu next to the filter selection field)
* ListView in the Administration pane of the Navigation

**This module can be used in Web and Desktop projects.**

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. See deployment for notes on how to deploy the project on a live system.

### Prerequisites

This module is based on the DevExpress eXpressApp Framework (XAF). You need an valid subscription for the DevExpress Framework to get work. (see https://www.devexpress.com)


### Installing

You can install the latest version of the package from nuget. (see https://www.nuget.org/packages/GDS.ExpressApp.UserFilter.Module/) 


Package Manager: 
```Install-Package GDS.ExpressApp.UserFilter.Module```

.NET CLI: 
```dotnet add package GDS.ExpressApp.UserFilter.Module```


Also you can download the SourceCode from Github and compile it by your self. 

After installing the Package you have to add the Module to your Module.cs File in your XAF Application.
```
this.RequiredModuleTypes.Add(typeof(GDS.ExpressApp.UserFilter.Module.UserFilterModule));
```


## Built With

* [DevExpress](https://www.devexpress.com) - DevExpress

## Versioning

I use the version information from DevExpress to make sure that there are no incompatibilities or misunderstandings. This means Version 19.2.5 can only be used in DevExpress Version 19.2.5.

## Authors

* [**Christian Angermeier**](https://github.com/gdsanger)

## License

This project is licensed under the Ms-PL License - see the [LICENSE.md](LICENSE.md) file for details

