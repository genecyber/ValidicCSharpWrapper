using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ValidicCSharp.Interfaces;
using ValidicCSharp.Model;
using ValidicCSharp.Request;
using SourceFilter = ValidicCSharp.Request.SourceFilter;

namespace ValidicCSharp.Utility
{
    public static class Extensions
    {
        public static ValidicResult<T> ToResult<T>(this string response, string fromString = null)
        {
            var parameter = typeof (T);

            if (fromString == null && parameter.Name == "List`1")
                fromString = parameter.GenericTypeArguments[0].Name.ToLower();

            var root = JObject.Parse(response);

            JObject summary = null;
            try
            {
                summary = JObject.FromObject(root["summary"]);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            string obj = null;
            try
            {
                var name = parameter.Name.ToLower();
                var element = root[name];
                if (element == null && fromString != null)
                    element = root[fromString];

                var aa = JObject.FromObject(element);
                obj = JsonConvert.SerializeObject(aa);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            if (obj == null && fromString != null)
            {
                try
                {
                    var element = root[fromString];
                    var array = JArray.FromObject(element);
                    obj = JsonConvert.SerializeObject(array);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }

            var tConverted = default(T);
            if (obj != null)
                tConverted = JsonConvert.DeserializeObject<T>(obj);

            var rootObject = new ValidicResult<T> {Object = tConverted};
            if (summary != null)
                rootObject.Summary = JsonConvert.DeserializeObject<Summary>(summary.ToString());
            ;
            return rootObject;
        }

        public static T Objectify<T>(this string response)
        {
            return JsonConvert.DeserializeObject<T>(response);
        }

        public static T As<T>(this object o)
        {
            return (T) o;
        }

        public static Command GetInformationType(this Command command, CommandType type)
        {
            command.Type = type;
            return command;
        }

        public static Command AddSourceFilter(this Command command, string value)
        {
            command.Filters.AddSourceFilter(value);
            return command;
        }

        public static Command FromDate(this Command command, string value)
        {
            command.Filters.AddFromDateFilter(value);
            return command;
        }

        public static Command ToDate(this Command command, string value)
        {
            command.Filters.AddToDateFilter(value);
            return command;
        }

        public static Command AuthenticationToken(this Command command, string value)
        {
            command.Filters.AddAuthenticationTokenFilter(value);
            return command;
        }

        public static Command AccessToken(this Command command, string value)
        {
            command.Filters.AddAccessTokenFilter(value);
            return command;
        }
        #region Add Filter

        public static List<ICommandFilter> AddFilter<T>(this List<ICommandFilter> filterList, FilterType filterType, string value) where T : ICommandFilter, new()
        {
            var filter = (T)filterList.FirstOrDefault(a => a.Type == filterType);
            if (filter == null)
            {
                filter = new T();
                filterList.Add(filter);
            }
            filter.Add(value);
            return filterList;
        }


        public static List<ICommandFilter> AddSourceFilter(this List<ICommandFilter> filterList, string value)
        {
            return AddFilter<SourceFilter>(filterList, FilterType.Source, value);
        }

        public static List<ICommandFilter> AddFromDateFilter(this List<ICommandFilter> filterList, string value)
        {
            return AddFilter<FromDateFilter>(filterList, FilterType.FromDate, value);
        }

        public static List<ICommandFilter> AddToDateFilter(this List<ICommandFilter> filterList, string value)
        {
            return AddFilter<ToDateFilter>(filterList, FilterType.ToDate, value);
        }

        public static List<ICommandFilter> AddAuthenticationTokenFilter(this List<ICommandFilter> filterList, string value)
        {
            return AddFilter<AuthenticationTokenFilter>(filterList, FilterType.AuthenticationToken, value);
        }

        public static List<ICommandFilter> AddAccessTokenFilter(this List<ICommandFilter> filterList, string value)
        {
            return AddFilter<AccessTokenFilter>(filterList, FilterType.AccessToken, value);
        }


        #endregion
    }
}