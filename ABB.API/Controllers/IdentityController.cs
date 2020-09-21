using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ABB.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;

namespace ABB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private IConfiguration _config;
        private IOptions<JwtSettings> _jwtSettings;
        public IdentityController(IConfiguration config,IOptions<JwtSettings> jwtSettings)
        {
            _config = config;
            _jwtSettings = jwtSettings;
        }

        [AllowAnonymous]
        [HttpGet("GetToken")]
        public async Task<string> GetAccessToken()
        {
            string access_token = string.Empty;
            JwtSettings jwtObj = new JwtSettings()
            {
                client_id = _jwtSettings.Value.client_id,
                client_secret = _jwtSettings.Value.client_secret,
                audience = _jwtSettings.Value.audience,
                grant_type = _jwtSettings.Value.grant_type
            };
            
            var client = new RestClient(_config.GetValue<string>("Auth0URL:URL"));
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddParameter("application/json", JsonConvert.SerializeObject(jwtObj), ParameterType.RequestBody);
            IRestResponse response =await client.ExecuteAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                AuthZeroResponse jwtResponse = JsonConvert.DeserializeObject<AuthZeroResponse>(response.Content);
                access_token = jwtResponse.access_token;
            }
            return access_token;
        }
    }
}
