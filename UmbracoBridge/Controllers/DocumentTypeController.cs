using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;
using UmbracoBridge.Models;

namespace UmbracoBridge.Controllers
{
   [ApiController]
   [Route("documenttype")]
   public class DocumentTypeController : BaseController
   {
      public DocumentTypeController(HttpClient httpClient, IOptions<ApiCredentials> apiCredentials)
        : base(httpClient, apiCredentials)
      {
      }

      [HttpPost]
      public async Task<IActionResult> CreateDocumentType([FromBody] DocumentType documentType)
      {
         if (string.IsNullOrWhiteSpace(documentType.Alias) || 
           string.IsNullOrWhiteSpace(documentType.Name) || 
           string.IsNullOrWhiteSpace(documentType.Description) || 
           !documentType.Icon.StartsWith("icon"))
         {
            return BadRequest("Invalid document type data. Ensure alias, name, and description are not empty and icon starts with 'icon'.");
         }
         var requestUri = $"{_apiCredentials.baseUrl}/umbraco/management/api/v1/document-type";
         var request = await CreateRequestAsync(HttpMethod.Post, requestUri);

         var json = JsonConvert.SerializeObject(documentType);
         request.Content = new StringContent(json, Encoding.UTF8, "application/json");

         var response = await _httpClient.SendAsync(request);

         if (response.IsSuccessStatusCode)
         {
            var content = await response.Content.ReadAsStringAsync();
            var date = response.Headers.Date.ToString();
            var location = response.Headers.Location?.ToString();
            var umbGeneratedResource = response.Headers.GetValues("umb-generated-resource").FirstOrDefault();

            return Created(location, new
            {
               Date = date,
               Location = location,
               DocumentId = umbGeneratedResource
            });
         }

         return StatusCode((int)response.StatusCode, response.ReasonPhrase);
      }

      [HttpDelete("{id}")]
      public async Task<IActionResult> DeleteDocumentType(Guid id)
      {
         var requestUri = $"{_apiCredentials.baseUrl}/umbraco/management/api/v1/document-type/{id}";
         var request = await CreateRequestAsync(HttpMethod.Delete, requestUri);

         var response = await _httpClient.SendAsync(request);

         if (response.IsSuccessStatusCode)
         {
            return NoContent();
         }

         return StatusCode((int)response.StatusCode, response.ReasonPhrase);
      }
   }
}
