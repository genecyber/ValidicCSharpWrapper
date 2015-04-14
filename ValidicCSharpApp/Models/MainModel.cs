using System.Collections.Generic;

namespace ValidicCSharpApp.Models
{
    public class MainModel
    {
        public List<OrganizationAuthenticationCredentialModel> OrganizationAuthenticationCredentials { get; set; }

        public void Populate()
        {
            OrganizationAuthenticationCredentials = new List<OrganizationAuthenticationCredentialModel>
            {
                new OrganizationAuthenticationCredentialModel
                {
                    OrganizationId = "51aca5a06dedda916400002b",
                    AccessToken = "ENTERPRISE_KEY"
                },
                new OrganizationAuthenticationCredentialModel
                {
                    OrganizationId = "52e175c5e5af473f13000034",
                    AccessToken = "8a54ead80e25826eac4c281d7f50e71a7a5778d4e776b0fc8f972c7ace908ad6"
                }
            };
        }
    }
}