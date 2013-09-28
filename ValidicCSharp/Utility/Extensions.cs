using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ValidicCSharp.Command;
using ValidicCSharp.Interfaces;
using ValidicCSharp.Model;

namespace ValidicCSharp.Utility
{
    public static class Extensions
    {
        public static RootObject<T> ToRootObject<T>(this String response, string fromString = null)
        {
            
            var parameter = typeof(T);
            if (fromString == null && parameter.Name == "List`1")
                fromString = parameter.GenericTypeArguments[0].Name.ToLower();
            var root = JObject.Parse(response);
            JObject summary = null;
            try { summary = JObject.FromObject(root["summary"]);} catch (Exception){}
            string obj;
            try
            {
                obj = JsonConvert.SerializeObject(JObject.FromObject(root[parameter.Name.ToLower()]));
            }
            catch (Exception)
            {
                if (fromString != null)
                    obj = JsonConvert.SerializeObject(JArray.FromObject(root[fromString]));
                else
                    obj = JsonConvert.SerializeObject(JArray.FromObject(root[fromString]));
            }
            var tConverted = JsonConvert.DeserializeObject<T>(obj);
            var rootObject = new RootObject<T>() { Object = tConverted };
            if (summary != null)
                rootObject.Summary = JsonConvert.DeserializeObject<Summary>(summary.ToString());;
            return rootObject;

        } 
       
        public static T Objectify<T>(this String response)
        {
            return JsonConvert.DeserializeObject<T>(response);
        }

        public static T As<T>(this object o)
        { 
            return (T)o;
        }

        public static Command.Command GetInformationType(this Command.Command command, CommandType type)
        {
            command.Type = type;
            return command;
        }

        public static Command.Command AddSourceFilter(this Command.Command command, String sourceToAdd)
        {
            command.Filters.AddSourceFilter(sourceToAdd);
            return command;
        }

        public static Command.Command FromDate(this Command.Command command, string date)
        {
            command.Filters.AddFromDateFilter(date);
            return command;
        }

        public static Command.Command ToDate(this Command.Command command, string date)
        {
            command.Filters.AddToDateFilter(date);
            return command;
        }

        public static List<ICommandFilter> AddSourceFilter(this List<ICommandFilter> filterList, String sourceToAdd)
        {
            var source = (SourceFilter)filterList.FirstOrDefault(a => a.Type == FilterType.Source);
            if (source == null)
            {
                source = new SourceFilter();
                filterList.Add(source);
            }
            source.AddSource(sourceToAdd);

            return filterList;
        }

        public static List<ICommandFilter> AddFromDateFilter(this List<ICommandFilter> filterList, String date)
        {
            var dateFilter = (FromDateFilter)filterList.FirstOrDefault(a => a.Type == FilterType.FromDate);
            
            if (dateFilter == null)
            {
                dateFilter = new FromDateFilter();
                filterList.Add(dateFilter);
            }
            dateFilter.AddDate(date);
            return filterList;
        }

        public static List<ICommandFilter> AddToDateFilter(this List<ICommandFilter> filterList, String date)
        {
            var dateFilter = (ToDateFilter)filterList.FirstOrDefault(a => a.Type == FilterType.ToDate);

            if (dateFilter == null)
            {
                dateFilter = new ToDateFilter();
                filterList.Add(dateFilter);
            }
            dateFilter.AddDate(date);
            return filterList;
        }
    }
}
