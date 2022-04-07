using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalInfoSystem.Application.Features.Palients.Quries.GetPalientDetail
{
    public class GetPatientDetailViewModel
    {
        public Guid Id { get; set; }
        public String? Name { get; set; }
        public int FileNo { get; set; }
        public String? CitizenId { get; set; }
        public DateTime Birthdate { get; set; }
        public Gender Gender { get; set; }
        public String? Natinality { get; set; }
        public String? PhoneNumber { get; set; }
        public String? Email { get; set; }
        public String? Country { get; set; }
        public String? City { get; set; }
        public String? Street { get; set; }
        public String? Address1 { get; set; }
        public String? Address2 { get; set; }
        public String? ContactPerson { get; set; }
        public String? ContactRelation { get; set; }
        public String? ContactPhone { get; set; }
        public DateTime FirstVisitDate { get; set; }
        public DateTime RecordCreationDate { get; set; }
    }
}
