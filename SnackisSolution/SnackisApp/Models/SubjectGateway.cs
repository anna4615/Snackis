using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SnackisApp.Models
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

        public Task<Subject> DeleteSubject(int deleteId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Subject>> GetSubjects()
        {
            throw new NotImplementedException();
        }

        public Task<Subject> PostSubject(Subject subject)
        {
            throw new NotImplementedException();
        }

        public Task<Subject> PutSubject(int editId, Subject subject)
        {
            throw new NotImplementedException();
        }
    }
}
