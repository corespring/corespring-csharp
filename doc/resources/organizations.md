## Organizations

A CoreSpring
[Organization](https://github.com/corespring/corespring-csharp/blob/master/Corespring/Corespring.Resources/Organization.cs) contains information about an organization within the CoreSpring platform. Organizations are typically 
development partners who work with CoreSpring, and **not** groups within an educational institution (districts, 
schools, etc.). After registering for the CoreSpring platform, a developer will have a single Organization associated 
with their account. You should be able to retrieve your current organization from 
[CorespringClient](https://github.com/corespring/corespring-csharp/blob/master/Corespring/CorespringClient.cs)'s 
getOrganizations method after you initialize it with your access token.


### CorespringClient methods

#### List organizations

    CorespringClient client = new CorespringClient(clientId, clientSecret);

    List<Organization> organizations = client.getOrganizations();
    
    foreach (Organization organization in client.getOrganizations()) {
      System.Console.WriteLine(organization.name);              // "Demo Organization"
      System.Console.WriteLine(organization.id);                // "51114b307fc1eaa866444648"
    }