using Microsoft.Extensions.Configuration;
using SnackisApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace SnackisApp.Gateways

{
    public class SubjectGateway : ISubjectGateway
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _client;

        public SubjectGateway(IConfiguration configuration, HttpClient client)
        {
            _configuration = configuration;
            _client = client;
        }

        public async Task<List<Subject>> GetSubjects()
        {
            var response = await _client.GetAsync(_configuration["SubjectAPILocal"]);
            string apiResponse = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<List<Subject>>(apiResponse);
        }

        public async Task<Subject> GetSubject(int id)
        {
            var response = await _client.GetAsync(_configuration["SubjectAPILocal"] + "/" + id);
            Subject returnValue = await response.Content.ReadFromJsonAsync<Subject>();

            return returnValue;
        }

        public async Task<Subject> PostSubject(Subject subject)
        {
            var response = await _client.PostAsJsonAsync(_configuration["SubjectAPILocal"], subject);
            Subject returnValue = await response.Content.ReadFromJsonAsync<Subject>();

            return returnValue;
        }

        public async Task PutSubject(int editId, Subject subject)
        {
            await _client.PutAsJsonAsync(_configuration["SubjectAPILocal"] + "/" +  editId, subject);
        }

        public async Task DeleteSubject(int deleteId)
        {
            await _client.DeleteAsync(_configuration["SubjectAPILocal"] + "/" + deleteId);
        }

       
    }
}
