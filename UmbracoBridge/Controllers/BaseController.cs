using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using UmbracoBridge.Models;

public abstract class BaseController : ControllerBase
{
  protected readonly HttpClient _httpClient;
  protected readonly ApiCredentials _apiCredentials;

  protected BaseController(HttpClient httpClient, IOptions<ApiCredentials> apiCredentials)
  {
       _httpClient = httpClient;
       _apiCredentials = apiCredentials.Value;
  }

  protected async Task GetTokenAsync()
  {
      var tokenResponse = await _httpClient.RequestClientCredentialsTokenAsync(
          new ClientCredentialsTokenRequest
          {
             Address = $"{_apiCredentials.baseUrl}/umbraco/management/api/v1/security/back-office/token",
             ClientId = _apiCredentials.clientId,
             ClientSecret = _apiCredentials.clientSecret
          }
      );

      if (tokenResponse.IsError || tokenResponse.AccessToken is null)
      {
         Console.WriteLine($"Error obtaining a token: {tokenResponse.ErrorDescription}");
         return;
      }

      // use the access token as Bearer token
      _httpClient.SetBearerToken(tokenResponse.AccessToken);
  }

  protected async Task<HttpRequestMessage> CreateRequestAsync(HttpMethod method, string requestUri)
  {
       await GetTokenAsync();
       var request = new HttpRequestMessage(method, requestUri);
       return request;
  }
}