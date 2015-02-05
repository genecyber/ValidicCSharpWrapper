using System.Collections.Generic;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ValidicCSharp;
using ValidicCSharp.Model;
using ValidicCSharp.Request;
using ValidicCSharp.Utility;
using ValidicCSharpApp.Models;

namespace ValidicCSharpApp.ViewModels
{
    public class MainRecordModelView : ViewModelBase
    {
        OrganizationAuthenticationCredentialModel _organizationAuthenticationCredential;
        Organization        _organization;
        List<Me>            _meData; 
        List<Profile>       _profiles ;
        List<Weight>        _weights ;
        List<Biometrics>    _biometrics ;
        List<Fitness>       _fitnessData ;
        List<Diabetes>      _diabetesData ;
        List<Nutrition>     _nutritionData ;
        List<Routine>       _routineData ;
        List<Sleep>         _sleepData ;
        List<Tobacco_Cessation> _tobaccoCessationData ;


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

        public OrganizationAuthenticationCredentialModel OrganizationAuthenticationCredential
        {
            get { return _organizationAuthenticationCredential; }
            set { _organizationAuthenticationCredential = value; }
        }

        public Organization Organization
        {
            get { return _organization; }
            set
            {
                if(_organization == value)
                    return;

                _organization = value;
                RaisePropertyChanged();
            }
        }

        public List<Me> MeData
        {
            get { return _meData; }
            set { _meData = value; }
        }

        public List<Profile> Profiles
        {
            get { return _profiles; }
            set { _profiles = value; }
        }

        public List<Weight> Weights
        {
            get { return _weights; }
            set { _weights = value; }
        }

        public List<Biometrics> Biometrics
        {
            get { return _biometrics; }
            set { _biometrics = value; }
        }

        public List<Fitness> FitnessData
        {
            get { return _fitnessData; }
            set { _fitnessData = value; }
        }

        public List<Diabetes> DiabetesData
        {
            get { return _diabetesData; }
            set { _diabetesData = value; }
        }

        public List<Nutrition> NutritionData
        {
            get { return _nutritionData; }
            set { _nutritionData = value; }
        }

        public List<Routine> RoutineData
        {
            get { return _routineData; }
            set { _routineData = value; }
        }

        public List<Sleep> SleepData
        {
            get { return _sleepData; }
            set { _sleepData = value; }
        }

        public List<Tobacco_Cessation> TobaccoCessationData
        {
            get { return _tobaccoCessationData; }
            set { _tobaccoCessationData = value; }
        }

        #endregion

        public MainRecordModelView()
        {
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
            
        }

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
            MeData = result != null ? result.Object : null;
            RaisePropertyChanged("MeData");
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

        public ValidicResult<List<T>> GetOrganizationData<T>(CommandType commandType)
        {
            var oac = OrganizationAuthenticationCredential;
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
            Organization = (Organization)result.Object;
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

        #endregion
    }
}