# MicroserviceAuthenticator
This is a nuget package built in ASP.NET Core to help quickly setup authentication up and running on your Web api app and also secure microservices. It's built on jwtBearer library.

![.NET Core](https://github.com/eskye/MicroserviceAuthenticator/workflows/.NET%20Core/badge.svg?branch=master) ![Nuget](https://img.shields.io/nuget/dt/MicroServiceAuthenticator) ![Nuget](https://img.shields.io/nuget/v/MicroServiceAuthenticator)


# Installation
MicroServiceAuthenticator can be installed via the nuget UI (as MicroServiceAuthenticator), or via the nuget package manager console:

`PM> Install-Package MicroServiceAuthenticator`

# Dependencies

`PM> Install-Package Microsoft.AspNetCore.Authentication.JwtBearer -Version 3.1.2`

# Configuring Settings

```
{
   "TokenAuthentication": {
    "SecretKey": "secret-key",
    "Issuer": "issuer-app",
    "Audience": "audience-key",
    "ExpirationTime":300
    
  }
}
```

# Usage
After updating the application settings, open the Startup.cs file. Startup class is the heart of ASP.NET Core application’s configuration. First we need to import the `MicroServiceAuthenticator` namespace.

The most important type in this library is the just adding it to the services configure pipline. Which can be added as shown below:

```C#
public ConfigureServices(IServiceCollection services)
{
    services.AddMicroServiceAuthenticator(new TokenProviderOptions
            {
               Issuer =  configuration["TokenAuthentication:Issuer"],
               Audience = configuration["TokenAuthentication:Audience"],
               SecretKey = configuration["TokenAuthentication:SecretKey"],
               ExpirationTime = configuration["TokenAuthentication:ExpirationTime"] 
           });
}


```


## Testing
Place the `[Authorize]` attribute on the controller you want to authenticate and use the identity service to get your token and set the token to the authorization of the api endpoint and boom you are authenticated successfully.

## Contribution

Feel free to send a PR.

## Contributors

<!-- ALL-CONTRIBUTORS-LIST:START - Do not remove or modify this section -->
<!-- prettier-ignore -->
[<img src="https://avatars0.githubusercontent.com/u/16523891?s=60&v=4" width="100px;"/><br /><sub><b>Sunkanmi Ijatuyi</b></sub>](https://github.com/eskye)<br />[💻](https://github.com/eskye/MicroserviceAuthenticator/commits?author=eskye "Code")

<!-- ALL-CONTRIBUTORS-LIST:END -->

This project follows the [all-contributors](https://github.com/kentcdodds/all-contributors) specification. Contributions of any kind are welcome!

### License

MIT 



