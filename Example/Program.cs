using Business_Credentialing_Package;
using Business_Credentialing_Package.Model;
using System.Text.Json;
using System.Text.Json.Nodes;

var businessCredentialingPackageClient = new BusinessCredentialingPackageClient("You_client_id", "You_client_secret", EnvironmentType.Sandbox);
JsonObject report, archiveReport;
Console.WriteLine("Test ProfessionalLicenseSearchClient:");
Console.WriteLine("Test GetReport:");

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
Console.WriteLine(report.ToString());
Console.WriteLine("Test GetArchiveReport:");

archiveReport = businessCredentialingPackageClient.ProfessionalLicenseSearchClient.GetArchiveReport("{C76E01F3-8D6F-4D9D-B0F9-CD33ECE09F58}");
Console.WriteLine(archiveReport.ToString());

Console.WriteLine("Test UCCSearchReport:");
Console.WriteLine("Test GetReport:");

var UCCSearchReportRequestModel = JsonSerializer.Serialize<UCCSearchReportRequestModel>(new UCCSearchReportRequestModel()
{
    OrgInfo = new OrgInfo()
    {
        ContactInfo = [new ContactInfo()
        {
            PostAddr = new PostAddr()
            { 
                Addr1 = "1900 US HWY 69",
                City = "EXCELSIOR SPRINGS",
                StateProv = "MO",
                PostalCode = "64024",
                Country = "USA"
            }
        }],
        Name = "69 AUTO SALES LLC"
    }
});

report = businessCredentialingPackageClient.UCCSearchReport.GetReport(UCCSearchReportRequestModel);
Console.WriteLine(report.ToString());
Console.WriteLine("Test GetArchiveReport:");
archiveReport = businessCredentialingPackageClient.UCCSearchReport.GetArchiveReport("{0B75ABF4-0360-48BC-816D-6687FB7089F0}");
Console.WriteLine(archiveReport.ToString());