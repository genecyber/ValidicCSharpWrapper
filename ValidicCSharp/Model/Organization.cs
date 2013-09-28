using System.Collections.Generic;
using System.Runtime.Serialization;
using ValidicCSharp.Interfaces;

namespace ValidicCSharp.Model
{
    public class Organization : IValidic
    {
        [DataMember(Name = "_id")]
        public string Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "users")]
        public int Users { get; set; }

        [DataMember(Name = "users_provisioned")]
        public int UsersProvisioned { get; set; }

        [DataMember(Name = "activities")]
        public int Activities { get; set; }

        [DataMember(Name = "connections")]
        public int Connections { get; set; }

        [DataMember(Name = "organizations")]
        public List<Organization> ChildOrganizations { get; set; }
    }
}