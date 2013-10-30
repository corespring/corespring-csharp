![corespring](doc/images/logo.png)

## corespring-csharp

[![Build Status](https://travis-ci.org/corespring/corespring-csharp.png)](https://travis-ci.org/corespring/corespring-csharp)

Corespring-csharp is a C# library designed for interfacing with the CoreSpring REST API.

**DISCLAIMER**: This library is in an alpha state, and should not yet be used in production code!

### Setup

Interestingly, corespring-csharp has only been officially run/tested on OS X using Mono.

#### OS X

Download NuGet 2.7 from the [NuGet homepage](http://nuget.codeplex.com/), and use the following command to install the dependencies:

    mono --runtime=v4.0.30319 NuGet.exe install ./packages.config


### Quick Start

Instantiate the CorespringClient by passing in your client ID and client secret (you will receive these when you
register for the CoreSpring platform), and use its methods to interact with the platform:

    string clientId = "524c5cb5300401522ab21db1";
    string clientSecret = "325hm11xiz7ykeen2ibt";
    
    CorespringClient client = new CorespringClient(clientId, clientSecret);
    
    List<Organization> organizations = client.getOrganizations();
    
    foreach (Organization organization in client.getOrganizations()) {
      System.Console.WriteLine(organization.name);              // "Demo Organization"
    }


### Resources

Below you will find additional documentation related to the individual resources in the domain model of the CoreSpring
platform:

* [Organizations](/doc/resources/organizations.md)
