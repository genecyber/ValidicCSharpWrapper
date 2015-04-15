using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using GalaSoft.MvvmLight;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ValidicCSharp;
using ValidicCSharpApp.Models;

namespace ValidicCSharpApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region Ccnstructor

        public MainViewModel()
        {
            Client.AddLine += AddLine;
            OpenOrCreateModel();
            foreach (var organizationAuthenticationCredential in Model.OrganizationAuthenticationCredentials)
            {
                var record = new MainRecordModelView();
                record.OrganizationAuthenticationCredential = organizationAuthenticationCredential;
                MainRecords.Add(record);
            }
            SelectedMainRecord = MainRecords[0];
            // SaveToFile("validic.json", Model);
        }


        #endregion

        private void AddLine(LogItem a)
        {
            _logItems.Add(a);
            SelectedLogItemIndex = _logItems.Count;
        }

        #region Members

        private readonly List<MainRecordModelView> _mainRecords = new List<MainRecordModelView>();
        private readonly ObservableCollection<LogItem> _logItems = new ObservableCollection<LogItem>();
        private int _selectedLogItemIndex;

        #endregion

        #region Properties

        public MainModel Model { get; set; }

        public override Action<Action> Dispatcher
        {
            get { return base.Dispatcher; }
            set
            {
                base.Dispatcher = value;
                foreach (var record in MainRecords)
                {
                    record.Dispatcher = value;
                }
            }
        }

        public int SelectedLogItemIndex
        {
            get { return _selectedLogItemIndex; }
            set
            {
                if (_selectedLogItemIndex == value)
                    return;

                _selectedLogItemIndex = value;
                RaisePropertyChanged("SelectedLogItemIndex");
            }
        }


        private MainRecordModelView _selectedMainRecord;

        public ObservableCollection<LogItem> LogItems
        {
            get { return _logItems; }
        }

        public List<MainRecordModelView> MainRecords
        {
            get { return _mainRecords; }
        }

        public MainRecordModelView SelectedMainRecord
        {
            get { return _selectedMainRecord; }
            set
            {
                if (_selectedMainRecord == value)
                    return;

                _selectedMainRecord = value;
                if (_selectedMainRecord.Organization == null)
                    _selectedMainRecord.GetOrganization();

                RaisePropertyChanged();
            }
        }

        #endregion

        #region Support Functions

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

        public static T ReadFromFile<T>(string path)
        {
            using (var file = File.OpenText(path))
            using (var reader = new JsonTextReader(file))
            {
                var o2 = (JObject) JToken.ReadFrom(reader);
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

        #endregion
    }
}