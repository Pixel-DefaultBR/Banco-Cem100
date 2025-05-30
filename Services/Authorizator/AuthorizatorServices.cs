namespace BancoCem.Services.Authorizator
{
    public class AuthorizatorServices: IAuthorizatorServices
    {
        private readonly HttpClient _httpClient;
        private const string AuthorizatorUrl = "https://util.devi.tools/api/v2/authorize";

        public AuthorizatorServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<bool> AuthorizeAsync()
        {
            string content = string.Empty;

            var response = await _httpClient.GetAsync(AuthorizatorUrl);
            if (!response.IsSuccessStatusCode)
            {
                return false;
            }

            response.EnsureSuccessStatusCode();
            content = await response.Content.ReadAsStringAsync();

            var result = System.Text.Json.JsonSerializer.Deserialize<ApiResonse>(content);

            return result?.status == "success";
        }
    }

    public class ApiResonse
    {
        public string status { get; set; }
        public DataResponse data { get; set; }
    }
    public class DataResponse
    {
        public bool authorization { get; set; }
    }
}
