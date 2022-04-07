using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
namespace HospitalInfoSystem.Application.Features.Palients.Quries.GetPatientList
{
    public class GetPatientsListQuery:IRequest<List<GetPatientsListViewModel>>
    {
        public int PageNumber { get; set; }
        public int pageSize { get; set; }
        public string? Name { get; set; }
        public int? FileNo { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
