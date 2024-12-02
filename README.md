# Business Credentialing Package Plan Client
A .NET client for consuming the Microbilt Business Credentialing Package APIs.

For more about APIs You can see on [Microbilt Developer Portal](https://developer.microbilt.com/)

## APIs in this plan:

[ProfessionalLicenseSearch](https://developer.microbilt.com/api/ProfessionalLicenseSearch)

[UCCSearchReport](https://developer.microbilt.com/api/UCCSearchReport)

# Installation

`composer require AlexandrAndreev/Business-Credentialing-Package`

# Quick Start

```
BusinessCredentialingPackageClient businessCredentialingPackageClient = new BusinessCredentialingPackageClient("You_client_id", "You_client_secret", EnvironmentType.Sandbox);
```

## Configuration

`client_id` required

`client_secret` required

`EnvironmentType` optional (defaults to Production). Other option is Sandbox. 

# Usage
For usage you need create plan client with you credentials
All APIs implemented like property in ```BusinessCredentialingPackageClient``` class 
```businessCredentialingPackageClient.ProfessionalLicenseSearchClient.GetReport("You request body in JSON format")```

You can use request models for call reports from `Business_Credentialing_Package.Model`

```
var professionalLicenseSearchRequestModel = JsonSerializer.Serialize<ProfessionalLicenseSearchRequestModel>(new ProfessionalLicenseSearchRequestModel()
{
    PersonName = new PersonName()
    {
        FirstName = "John",
        LastName = "Green"
    },
    StateProv = "TX"
});

report = businessCredentialingPackageClient.ProfessionalLicenseSearchClient.GetReport(professionalLicenseSearchRequestModel);
```

or use JSON like string

```
report = businessCredentialingPackageClient.ProfessionalLicenseSearchClient.GetReport("{\"PersonName\":{\"FirstName\":\"John\",\"LastName\":\"Green\"},\"StateProv\":\"TX\"}");
```

