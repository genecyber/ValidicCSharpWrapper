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
    public class MainViewModel : ViewModelBase
    {

        public RelayCommand CommandGetOrganization { get; private set; }
        public RelayCommand CommandClearOrganization { get; private set; }
        public RelayCommand CommandGetOrganizationWeight { get; private set; }
        public RelayCommand CommandGetOrganizationBiometrics { get; private set; }
        public RelayCommand CommandGetOrganizationFitnessData { get; private set; }
        public RelayCommand CommandGetOrganizationDiabetesData { get; private set; }
        public RelayCommand CommandGetOrganizationNutritionData { get; private set; }
        public RelayCommand CommandGetOrganizationRoutineData { get; private set; }
        public RelayCommand CommandGetOrganizationSleepData { get; private set; }
        public RelayCommand CommandGetOrganizationTobaccoCessationData { get; private set; }
        public RelayCommand CommandGetOrganizationProfiles { get; private set; }
        public RelayCommand CommandGetOrganizationMeData { get; private set; }
        
        
        public Organization Organization { get; set; }
        public MainModel Model { get; set; }

        public List<Me> MeData { get; set; }
        public List<Profile> Profiles { get; set; }

        public List<Weight> Weights { get; set; }
        public List<Biometrics> Biometrics { get; set; }
        public List<Fitness> FitnessData { get; set; }
        public List<Diabetes> DiabetesData { get; set; }
        public List<Nutrition> NutritionData { get; set; }
        public List<Routine> RoutineData { get; set; }
        public List<Sleep> SleepData { get; set; }
        public List<Tobacco_Cessation> TobaccoCessationData { get; set; }



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
            CommandGetOrganizationBiometrics = new RelayCommand(GetOrganizationBiometrics, () => true);
            CommandGetOrganizationFitnessData = new RelayCommand(GetOrganizationFitnessData, () => true);
            CommandGetOrganizationDiabetesData = new RelayCommand(GetOrganizationDiabetesData, () => true);
            CommandGetOrganizationNutritionData = new RelayCommand(GetOrganizationNutritionData, () => true);
            CommandGetOrganizationRoutineData = new RelayCommand(GetOrganizationRoutineData, () => true);
            CommandGetOrganizationSleepData = new RelayCommand(GetOrganizationSleepData, () => true);
            CommandGetOrganizationTobaccoCessationData = new RelayCommand(GetOrganizationTobaccoCessationData, () => true);
            CommandGetOrganizationProfiles = new RelayCommand(GetOrganizationProfiles, () => true);
            CommandGetOrganizationMeData = new RelayCommand(GetOrganizationMeData, () => true);
            
            SelectedOrganizationAuthenticationCredential = Model.OrganizationAuthenticationCredentials[0];
            // SaveToFile("validic.json", Model);

        }

        private void GetOrganizationMeData()
        {
            var oac = SelectedOrganizationAuthenticationCredential;
            if (oac == null)
                return;

            var client = new Client { AccessToken = oac.AccessToken };
            var command = new Command().FromOrganization(oac.OrganizationId)
                .GetUsers();

            var json = client.PerformCommand(command);
            var result  = json.ToResult<List<Me>>("users");
            MeData = result != null ? result.Object : null;
            RaisePropertyChanged("MeData");
        }


        private void GetOrganizationProfiles()
        {
            var result = GetOrganizationData<Profile>(CommandType.Profile);
            Profiles = result != null ? result.Object : null;
            RaisePropertyChanged("Profiles");
        }


        private void GetOrganizationTobaccoCessationData()
        {
            var result = GetOrganizationData<Tobacco_Cessation>(CommandType.Tobacco_Cessation);
            TobaccoCessationData = result != null ? result.Object : null;
            RaisePropertyChanged("TobaccoCessationData");
        }

        
        private void GetOrganizationSleepData()
        {
            var result = GetOrganizationData<Sleep>(CommandType.Sleep);
            SleepData = result != null ? result.Object : null;
            RaisePropertyChanged("SleepData");
        }


        private void GetOrganizationRoutineData()
        {
            var result = GetOrganizationData<Routine>(CommandType.Routine);
            RoutineData = result != null ? result.Object : null;
            RaisePropertyChanged("RoutineData");
        }


        private void GetOrganizationNutritionData()
        {
            var result = GetOrganizationData<Nutrition>(CommandType.Nutrition);
            NutritionData = result != null ? result.Object : null;
            RaisePropertyChanged("NutritionData");
        }


        private void GetOrganizationDiabetesData()
        {
            var result = GetOrganizationData<Diabetes>(CommandType.Diabetes);
            DiabetesData = result != null ? result.Object : null;
            RaisePropertyChanged("DiabetesData");
        }


        private ValidicResult<List<T>> GetOrganizationData<T>(CommandType commandType)
        {
            var oac = SelectedOrganizationAuthenticationCredential;
            if (oac == null)
                return null;

            var client = new Client { AccessToken = oac.AccessToken };
            var command = new Command().FromOrganization(oac.OrganizationId)
                .GetInformationType(commandType)
                .GetLatest();

            var json = client.PerformCommand(command);
            var validicResult = json.ToResult<List<T>>();
            return validicResult;
        }

        private void GetOrganizationFitnessData()
        {
            var result = GetOrganizationData<Fitness>(CommandType.Fitness);
            FitnessData = result != null ? result.Object : null;
            RaisePropertyChanged("FitnessData");
        }

        private void GetOrganizationBiometrics()
        {
            var result = GetOrganizationData<Biometrics>(CommandType.Biometrics);
            Biometrics = result != null ? result.Object : null;
            RaisePropertyChanged("Biometrics");
        }

        private void GetOrganizationWeight()
        {
            var result = GetOrganizationData<Weight>(CommandType.Weight);
            Weights = result != null ?result.Object : null;
            RaisePropertyChanged("Weights");
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
