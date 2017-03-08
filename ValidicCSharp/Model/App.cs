using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using ValidicCSharp.Utility;

namespace ValidicCSharp.Model
{
    /// <summary>
    ///     <example>
    ///         "name": "BodyMedia",
    ///         "sync_url": "https://app.validic.com/organizations/51aca5a06dedda916400002b/auth/bodymedia?user_token=USERTOKEN
    ///         &format_redirect=json",
    ///         "unsync_url": "",
    ///         "refresh_url": "",
    ///         "download_link": "http://www.bodymedia.com/Support-Help/BodyMedia-FIT-Apps",
    ///         "excerpt": "The leading on-body monitoring system. Accurate information about your body.",
    ///         "extra_excerpt": "It's a lot easier to treat everyone as if they're exactly the same. Other body monitoring
    ///         systems do just that. Easier? Yes. More accurate? No. At BodyMedia, we're driven by facts and how they can help
    ///         you.",
    ///         "subname": "bodymedia",
    ///         "kind": [
    ///         "fitness",
    ///         "nutrition",
    ///         "calorie_tracking",
    ///         "meal_tracking"
    ///         ],
    ///         "logo_url": "/assets/appicons/bodymedia-icon.png",
    ///         "AppPlatformTypes": [
    ///         "Web",
    ///         "iOS",
    ///         "Android"
    ///         ],
    ///         "synced": false,
    ///         "last_sync": null
    ///     </example>
    /// </summary>
    public class App
    {
        // [JsonProperty("name"          )]public string Name         { get; set; }
        // [JsonProperty("sync_url"      )]public string SyncUrl      { get; set; }
        // [JsonProperty("unsync_url"    )]public string UnsyncUrl    { get; set; }
        // [JsonProperty("refresh_url"   )]public string RefreshUrl   { get; set; }
        // [JsonProperty("download_link" )]public string DownloadLink { get; set; }
        // [JsonProperty("excerpt"       )]public string Excerpt      { get; set; }
        // [JsonProperty("extra_excerpt" )]public string ExtraExcerpt { get; set; }
        // [JsonProperty("subname"       )]public string Subname      { get; set; }
        // [JsonProperty("kind"          )]public string Kind         { get; set; }
        // [JsonProperty("logo_url"      )]public string LogoUrl      { get; set; }
        // [JsonProperty("platform_types")]public string PlatformType { get; set; }
        // [JsonProperty("synced"        )]public string Synced       { get; set; }
        // [JsonProperty("last_sync"     )]public string LastSync     { get; set; }


        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("sync_url")]
        public string SyncUrl { get; set; }

        [JsonProperty("unsync_url")]
        public string UnsyncUrl { get; set; }

        [JsonProperty("refresh_url")]
        public string RefreshUrl { get; set; }

        [JsonProperty("download_link")]
        public string DownloadLink { get; set; }

        [JsonProperty("excerpt")]
        public string Excerpt { get; set; }

        [JsonProperty("extra_excerpt")]
        public string ExtraExcerpt { get; set; }

        [JsonProperty("subname")]
        public string Subname { get; set; }

        [JsonProperty("kind")]
        public List<string> Kind { get; set; }

        [JsonProperty("logo_url")]
        public string LogoUrl { get; set; }

        [JsonProperty("platform_types")]
        public List<string> PlatformTypes { get; set; }

        [JsonProperty("synced")]
        public string Synced { get; set; }

        [JsonProperty("last_sync")]
        public string LastSync { get; set; }

        public override string ToString()
        {
            return Utilities.ToString(this, Environment.NewLine);
        }
    }

    public class Apps
    {
        [JsonProperty("apps")]
        public List<App> AppCollection { get; set; }
    }
}