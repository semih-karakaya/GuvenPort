using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http.Headers;


    public class httpHelpers
    {
        public HttpClient HttpHelper(HttpClient httpClient, IHttpContextAccessor contextAccessor)
        {
            var token = contextAccessor.HttpContext.Request.Cookies["authToken"];
            var handler = new HttpClientHandler
            {
                ClientCertificateOptions = ClientCertificateOption.Manual,
                ServerCertificateCustomValidationCallback = (httpRequestMessage, cert, certChain, policyErrors) => true
            };
            httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri("https://localhost:44384")
            };
            if (!string.IsNullOrEmpty(token))
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            return httpClient;
        }
    }

