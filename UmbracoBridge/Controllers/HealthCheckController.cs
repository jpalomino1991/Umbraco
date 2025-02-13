using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using UmbracoBridge.Models;

namespace UmbracoBridge.Controllers
{
   [ApiController]
   [Route("healthcheck")]
   public class HealthCheckController : BaseController
    {
      public HealthCheckController(HttpClient httpClient, IOptions<ApiCredentials> apiCredentials)
        : base(httpClient, apiCredentials)
      {
      }

      [HttpGet]
      public async Task<IActionResult> GetHealthCheck()
      {
         var request = await CreateRequestAsync(HttpMethod.Get, $"{_apiCredentials.baseUrl}/umbraco/management/api/v1/health-check-group");

         var response = await _httpClient.SendAsync(request);

         if (response.IsSuccessStatusCode)
         {
            var content = await response.Content.ReadFromJsonAsync<HealthCheck>();
            return Ok(content);
         }

         return StatusCode((int)response.StatusCode, response.ReasonPhrase);
      }
    }
}
