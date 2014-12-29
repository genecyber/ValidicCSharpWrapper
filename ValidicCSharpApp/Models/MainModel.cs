using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidicCSharpApp.Models
{
    public class MainModel
    {
        public List<OrganizationAuthenticationCredentialModel> OrganizationAuthenticationCredentials { get; set; }

        public MainModel()
        {
        //     OrganizationAuthenticationCredentials = new List<OrganizationAuthenticationCredentialModel>();
        }



        private void Init()
        {
            OrganizationAuthenticationCredentials = new List<OrganizationAuthenticationCredentialModel>
            {
                new OrganizationAuthenticationCredentialModel
                {
                    OrganizationId = "51aca5a06dedda916400002b",
                    AccessToken = "ENTERPRISE_KEY"
                },
            };
        }
    }
}
