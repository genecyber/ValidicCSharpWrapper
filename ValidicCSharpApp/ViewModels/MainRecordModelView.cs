using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ValidicCSharp;
using ValidicCSharp.Model;
using ValidicCSharp.Request;
using ValidicCSharp.Utility;
using ValidicCSharpApp.Models;
using ValidicCSharpApp.Views.DataViews;

namespace ValidicCSharpApp.ViewModels
{
    public class MainRecordModelView : BaseViewModel
    {
        #region Members

        private Organization _organization;

        private object _selectedData;
        private MeViewModel _selectedMeRecord;

        #endregion

        #region Commands

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
        public RelayCommand CommandGetOrganizationApps { get; private set; }
        public RelayCommand CommandDataSelected { get; private set; }
        public RelayCommand CommandMeUpdate { get; private set; }
        public RelayCommand CommandMeUpdateAll { get; private set; }

        #endregion

        #region Properties

        public OrganizationAuthenticationCredentialModel OrganizationAuthenticationCredential { get; set; }

        public Organization Organization
        {
            get { return _organization; }
            set
            {
                if (_organization == value)
                    return;

                _organization = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<MeViewModel> MeData { get; set; }

        public List<Profile> Profiles { get; set; }

        public List<Weight> Weights { get; set; }

        public List<Biometrics> Biometrics { get; set; }

        public List<Fitness> FitnessData { get; set; }

        public List<Diabetes> DiabetesData { get; set; }

        public List<Nutrition> NutritionData { get; set; }

        public List<Routine> RoutineData { get; set; }

        public List<Sleep> SleepData { get; set; }

        public List<Tobacco_Cessation> TobaccoCessationData { get; set; }

        public List<ValidicCSharp.Model.App> Apps { get; set; }

        public object SelectedData
        {
            get { return _selectedData; }
            set
            {
                if (_selectedData == value)
                    return;


                _selectedData = value;
                TestSelecteData();
                RaisePropertyChanged();
            }
        }

        public MeViewModel SelectedMeRecord
        {
            get { return _selectedMeRecord; }
            set
            {
                if (_selectedMeRecord == value)
                    return;


                _selectedMeRecord = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region Constructor

        public MainRecordModelView()
        {
            MeData = new ObservableCollection<MeViewModel>();

            CommandGetOrganization = new RelayCommand(GetOrganization, () => true);
            CommandClearOrganization = new RelayCommand(ClearOrganization, () => true);

            CommandGetOrganizationWeight = new RelayCommand(GetOrganizationWeight, () => true);
            CommandGetOrganizationBiometrics = new RelayCommand(GetOrganizationBiometrics, () => true);
            CommandGetOrganizationFitnessData = new RelayCommand(GetOrganizationFitnessData, () => true);
            CommandGetOrganizationDiabetesData = new RelayCommand(GetOrganizationDiabetesData, () => true);
            CommandGetOrganizationNutritionData = new RelayCommand(GetOrganizationNutritionData, () => true);
            CommandGetOrganizationRoutineData = new RelayCommand(GetOrganizationRoutineData, () => true);
            CommandGetOrganizationSleepData = new RelayCommand(GetOrganizationSleepData, () => true);
            CommandGetOrganizationTobaccoCessationData = new RelayCommand(GetOrganizationTobaccoCessationData,
                () => true);
            CommandGetOrganizationProfiles = new RelayCommand(GetOrganizationProfiles, () => true);
            CommandGetOrganizationMeData = new RelayCommand(GetOrganizationMeData, () => true);
            CommandGetOrganizationApps = new RelayCommand(GetOrganizationApps, () => true);
            // 
            CommandDataSelected = new RelayCommand(DataSelected, () => true);
            CommandMeUpdate = new RelayCommand(async () =>  await MeUpdateAsync(), () => true);
            CommandMeUpdateAll = new RelayCommand(async ()=> await MeUpdateAllAsync(), () => true);
        }

        #endregion


        #region  Commands Implemenation

        public void GetOrganizationMeData()
        {
            var oac = OrganizationAuthenticationCredential;
            if (oac == null)
                return;

            var client = new Client { AccessToken = oac.AccessToken };
            var command = new Command().FromOrganization(oac.OrganizationId)
                .GetUsers();

            var json = client.PerformCommand(command);
            var result = json.ToResult<List<Me>>("users");
            if (result != null)
            {
                foreach (var me in result.Object)
                {
                    MeData.Add(new MeViewModel { Me = me, RefreshToken = new RefreshToken() });
                }
            }
            RaisePropertyChanged("MeData");
        }

        public void GetOrganizationApps()
        {
            var json = GetOrganizationJsonData(CommandType.Apps);
            if (json == null)
                return;

            Apps = json.Objectify<Apps>().AppCollection;
            RaisePropertyChanged("Apps");
        }


        public void GetOrganizationProfiles()
        {
            var result = GetOrganizationData<Profile>(CommandType.Profile);
            Profiles = result != null ? result.Object : null;
            RaisePropertyChanged("Profiles");
        }

        public void GetOrganizationTobaccoCessationData()
        {
            var result = GetOrganizationData<Tobacco_Cessation>(CommandType.Tobacco_Cessation);
            TobaccoCessationData = result != null ? result.Object : null;
            RaisePropertyChanged("TobaccoCessationData");
        }

        public void GetOrganizationSleepData()
        {
            var result = GetOrganizationData<Sleep>(CommandType.Sleep);
            SleepData = result != null ? result.Object : null;
            RaisePropertyChanged("SleepData");
        }

        public void GetOrganizationRoutineData()
        {
            var result = GetOrganizationData<Routine>(CommandType.Routine);
            RoutineData = result != null ? result.Object : null;
            RaisePropertyChanged("RoutineData");
        }

        public void GetOrganizationNutritionData()
        {
            var result = GetOrganizationData<Nutrition>(CommandType.Nutrition);
            NutritionData = result != null ? result.Object : null;
            RaisePropertyChanged("NutritionData");
        }

        public void GetOrganizationDiabetesData()
        {
            var result = GetOrganizationData<Diabetes>(CommandType.Diabetes);
            DiabetesData = result != null ? result.Object : null;
            RaisePropertyChanged("DiabetesData");
        }


        public void GetOrganizationFitnessData()
        {
            var result = GetOrganizationData<Fitness>(CommandType.Fitness);
            FitnessData = result != null ? result.Object : null;
            RaisePropertyChanged("FitnessData");
        }

        public void GetOrganizationBiometrics()
        {
            var result = GetOrganizationData<Biometrics>(CommandType.Biometrics);
            Biometrics = result != null ? result.Object : null;
            RaisePropertyChanged("Biometrics");
        }

        public void GetOrganizationWeight()
        {
            var result = GetOrganizationData<Weight>(CommandType.Weight);
            Weights = result != null ? result.Object : null;
            RaisePropertyChanged("Weights");
        }

        public void GetOrganization()
        {
            var oac = OrganizationAuthenticationCredential;
            if (oac == null)
                return;

            var client = new Client { AccessToken = oac.AccessToken };
            var command = new Command().FromOrganization(oac.OrganizationId);

            var json = client.PerformCommand(command);
            var result = json.ToResult<Organization>();
            Organization = result.Object;
            RaisePropertyChanged("Organization");
        }

        public void ClearOrganization()
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


        private async Task UpdateAsync(MeViewModel record)
        {
            var oac = OrganizationAuthenticationCredential;
            if (oac == null)
                return;

            var client = new Client { AccessToken = oac.AccessToken };
            var command = new Command()
                .FromOrganization(oac.OrganizationId)
                .GetInformationType(CommandType.refresh_token)
                .FromUser(record.Me.Id);

            var json = await client.PerformCommandAsync(command);
            var result = json.ToResult<RefreshToken>("user");
            record.RefreshToken = result.Object;
        }

        private async Task MeUpdateAsync()
        {
            await UpdateAsync(SelectedMeRecord);
        }

        private async Task MeUpdateAllAsync()
        {
            foreach (var record in MeData)
            {
                Debug.WriteLine(record);
                Dispatcher(async () => await UpdateAsync(record));
            }
        }


        #endregion


        private void TestSelecteData()
        {
            var tabItem = SelectedData as TabItem;
            if (tabItem == null)
                return;

            if (tabItem.Content is WeightView && Weights == null) GetOrganizationWeight();
            else if (tabItem.Content is AppsView && Apps == null) GetOrganizationApps();
            else if (tabItem.Content is BiometricsView && Biometrics == null) GetOrganizationBiometrics();
            else if (tabItem.Content is FitnessView && FitnessData == null) GetOrganizationFitnessData();
            else if (tabItem.Content is DiabetesView && DiabetesData == null) GetOrganizationDiabetesData();
            else if (tabItem.Content is NutritionView && NutritionData == null) GetOrganizationNutritionData();
            else if (tabItem.Content is RoutineView && RoutineData == null) GetOrganizationRoutineData();
            else if (tabItem.Content is SleepView && SleepData == null) GetOrganizationSleepData();
            else if (tabItem.Content is TobaccoCessationView && TobaccoCessationData == null)
                GetOrganizationTobaccoCessationData();
            else if (tabItem.Content is ProfileView && Profiles == null) GetOrganizationProfiles();
            else if (tabItem.Content is MeView && MeData.Count == 0) GetOrganizationMeData();
        }

        private void DataSelected()
        {
        }

        public string GetOrganizationJsonData(CommandType commandType)
        {
            var oac = OrganizationAuthenticationCredential;
            if (oac == null)
                return null;

            var client = new Client {AccessToken = oac.AccessToken};
            var command = new Command().FromOrganization(oac.OrganizationId)
                .GetInformationType(commandType);
            // .GetLatest();

            var json = client.PerformCommand(command);
            return json;
        }

        public ValidicResult<List<T>> GetOrganizationData<T>(CommandType commandType)
        {
            var json = GetOrganizationJsonData(commandType);
            if (json == null)
                return null;

            var result = json.ToResult<List<T>>();
            return result;
        }
    }
}