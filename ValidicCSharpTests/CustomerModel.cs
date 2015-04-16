using ValidicCSharp.Model;

namespace ValidicCSharpTests
{
    public class CustomerModel
    {
        public OrganizationAuthenticationCredentials Credentials { get; set; }
        public Organization Organization { get; set; }
        public Profile Profile { get; set; }
    }
}