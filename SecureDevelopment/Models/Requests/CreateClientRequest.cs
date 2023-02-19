using SecureDevelopment.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SecureDevelopment.Models.Requests
{
    public class CreateClientRequest
    {
        public string SurName { get; set; }

        public string FirstName { get; set; }

        public string Patronymic { get; set; }
    }
}
