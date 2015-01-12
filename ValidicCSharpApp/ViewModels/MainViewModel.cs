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
        public RelayCommand CommandGetOrganizationWeight { get; private set; }

        
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
            OpenOrCreateModel();
            Client.AddLine += s => Debug.WriteLine(s);
            CommandGetOrganization = new RelayCommand(GetOrganization, () => true);
            CommandClearOrganization = new RelayCommand(ClearOrganization, () => true);
            CommandGetOrganizationWeight = new RelayCommand(GetOrganizationWeight, () => true);
            SelectedOrganizationAuthenticationCredential = Model.OrganizationAuthenticationCredentials[0];
            // SaveToFile("validic.json", Model);

        }

        public List<Weight> Weights { get; set; }

        private void GetOrganizationWeight()
        {
            var oac = SelectedOrganizationAuthenticationCredential;
            if (oac == null)
                return;

            var client = new Client { AccessToken = oac.AccessToken };
            var command = new Command().FromOrganization(oac.OrganizationId)
                .GetInformationType(CommandType.Weight)
                .GetLatest();

            string json = client.PerformCommand(command);
            var validicResult = json.ToResult<List<Weight>>();
            Weights = validicResult.Object;
            RaisePropertyChanged("Weights");
            var sum = validicResult.Summary;
        }


        private void GetOrganization()
        {
            var oac = SelectedOrganizationAuthenticationCredential;
            if (oac == null)
                return;

            var client = new Client {AccessToken = oac.AccessToken};
            var command = new Command().FromOrganization(oac.OrganizationId);

            var json = client.PerformCommand(command);
            var result = json.ToResult<Organization>();
            Organization = (Organization)result.Object;
            RaisePropertyChanged("Organization");
        }

        private void ClearOrganization()
        {
            Organization = null;
            RaisePropertyChanged("Organization");
        }

        public void GetOrganizationWeight(Client client, string orgId)
        {
            // Assert.True(weight.Object.First()._id != null);



//            var command = new Command().GetInformationType(CommandType.Weight);
//            var json = client.PerformCommand(command);
//            var result = json.ToResult<Organization>();
//            Organization = (Organization)result.Object;
//            RaisePropertyChanged("Organization");
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
            using (var file = File.OpenText(path))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                var o2 = (JObject)JToken.ReadFrom(reader);
                return o2.ToObject<T>();
            }
        }

        private void OpenOrCreateModel()
        {
            var path = "validic.json";
            Model = new MainModel();
            // read JSON directly from a file
            if (!File.Exists(path))
            {
                Model.Populate();
                SaveToFile(path, Model);
            }

            Model = ReadFromFile<MainModel>("validic.json");
        }

    }
}
