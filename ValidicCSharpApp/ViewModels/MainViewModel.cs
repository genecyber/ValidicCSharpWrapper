using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ValidicCSharp;
using ValidicCSharp.Model;
using ValidicCSharp.Request;
using ValidicCSharp.Utility;
using ValidicCSharpApp.Models;

namespace ValidicCSharpApp.ViewModels
{
    internal class MainViewModel : ViewModelBase
    {

        public RelayCommand CommandGetOrganization { get; private set; }
        public RelayCommand CommandClearOrganization { get; private set; }
        public Organization Organization { get; set; }
        public MainModel Model { get; set; }

        public List<OrganizationAuthenticationCredentialModel> OrganizationAuthenticationCredentials
        {
            get { return _organizationAuthenticationCredentials; }
        }

        public OrganizationAuthenticationCredentialModel SelectedOrganizationAuthenticationCredential { get; set; }

        private readonly List<OrganizationAuthenticationCredentialModel> _organizationAuthenticationCredentials =
            new List<OrganizationAuthenticationCredentialModel>();

        public MainViewModel()
        {
            Model = new MainModel();
            Model = ReadFromFile<MainModel>("validic.json");
            Client.AddLine += s => Debug.WriteLine(s);
            CommandGetOrganization = new RelayCommand(GetOrganization, () => true);
            CommandClearOrganization = new RelayCommand(ClearOrganization, () => true);
            SelectedOrganizationAuthenticationCredential = Model.OrganizationAuthenticationCredentials[0];
            // SaveToFile("validic.json", Model);

        }

        private void GetOrganization()
        {
            var oac = SelectedOrganizationAuthenticationCredential;
            if (oac == null)
                return;

            var client = new Client {AccessToken = oac.AccessToken};
            GetOrganizationData(client, oac.OrganizationId);
        }

        private void ClearOrganization()
        {
            Organization = null;
            RaisePropertyChanged("Organization");
        }

        public void GetOrganizationData(Client client, string orgId)
        {
            var command = new Command().FromOrganization(orgId);
            var json = client.PerformCommand(command);
            var result = json.ToResult<Organization>();
            Organization = (Organization) result.Object;
            RaisePropertyChanged("Organization");
        }

        public static void SaveToFile(string path, object value)
        {
            using (var fs = File.Open(path, FileMode.CreateNew))
            using (var sw = new StreamWriter(fs))
            using (var jw = new JsonTextWriter(sw))
            {
                jw.Formatting = Formatting.Indented;

                var serializer = new JsonSerializer();
                serializer.Serialize(jw, value);
            }
        }

        public T ReadFromFile<T>(string path)
        {
            // read JSON directly from a file
            using (var file = File.OpenText(path))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                var o2 = (JObject)JToken.ReadFrom(reader);
                return o2.ToObject<T>();
            }
        }
    }
}
