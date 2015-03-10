ValidicCSharpWrapper
====================

C# Wrapper for the Validic REST API

Example usages of this wrapper are located in the tests project, specifically "/ValidicCSharpTests/ClientTests.cs"

Feel free to contact me with updates, pull requests, or questions here: shannon.null.code@gmail.com


ValidicCSharpApp
====================
C# WPF app to quickly test C# Wrapper.
Main functinality
  - by clicking on tab shows data in list views
  - In log window, shows what HTTP querie been used and 
    has link to execute query again.  
  
File validic.json used for keeping "OrganizationId" and "AccessToken". By defult it has 
{
  "OrganizationAuthenticationCredentials": [
    {
      "OrganizationId": "51aca5a06dedda916400002b",
      "AccessToken": "ENTERPRISE_KEY"
    },
  ]
}

You can add your organization info to it test you organization data.

Feel free to contact me with updates, pull requests, or questions here: alan.kharebov@validic.com
