namespace ValidicCSharpTests.Mocks
{
    public class JsonMocks
    {
        public static string ValidSummaryJson()
        {
            return
                "{  \"summary\": {\"status\": 200,\"message\": \"OK\",\"results\": 3,\"start_date\": \"2013-03-27T00:00:00+00:00\",\"end_date\": \"2013-03-27T23:59:59+00:00\",\"offset\": 0,\"limit\": 100,\"previous\": null,\"next\": null,\"params\": {\"start_date\": null,\"end_date\": null,\"offset\": null,\"limit\": null}}}";
        }
    }
}