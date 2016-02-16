# ASP.NET Core (ASP.NET 5) like configuration in regular .NET applications

Demo application to show how to load config values in ASP.NET 4.6 similar to how it is done in ASP.NET Core.

This is a demo project in connection to the blog post [ASP.NET 5 like configuration in regular .NET applications](http://dusted.codes/aspnet-5-like-configuration-in-regular-dotnet-applications).

In this sample project I provide 3 different configuration sources:

-   WebConfig
-   Text file (similar like an ini file)
-   Environment Variables

I demo two examples of composing the configuration object. The first option uses a simple Decorator pattern and in the second option composes the configuration via a fluent builder pattern (which uses the Decorator under the covers).

You can test this by running the application and removing/adding configuration sources as you like.

Please be aware that if you set an environment variable for the `GreetingText` that you might have to restart VisualStudio in order for the parent process to pick up environment variable changes.

If you have any further questions feel free to [reach out to me](http://dusted.codes/aspnet-5-like-configuration-in-regular-dotnet-applications#disqus_thread).