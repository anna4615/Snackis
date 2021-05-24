using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnackisApp.Models
{
    public interface ISubjectGateway
    {
        Task<List<Subject>> GetSubjects();
        Task<Subject> PostSubject(Subject subject);
        Task<Subject> PutSubject(int editId, Subject subject);
        Task<Subject> DeleteSubject(int deleteId);

      
    }
}
