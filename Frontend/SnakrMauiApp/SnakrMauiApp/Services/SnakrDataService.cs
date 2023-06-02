namespace SnakrMauiApp.Services
{
    public class SnakrDataService
    {
        public async Task<List<MasterUsersDTO>> GetMasterUsersAsync()
        {
            var handler = new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator,
            };

            HttpClient httpClient = new(handler);
            httpClient.BaseAddress = new Uri("http://192.168.0.96:5078/");
            SnakrAPIClient snakrAPIClient = new(httpClient);

            return (List<MasterUsersDTO>) await snakrAPIClient.MasterusersAllAsync();
            
        }


    }
}
