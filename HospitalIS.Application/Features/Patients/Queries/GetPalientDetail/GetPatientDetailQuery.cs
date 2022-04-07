using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
namespace HospitalInfoSystem.Application.Features.Palients.Quries.GetPalientDetail
{
    public class GetPatientDetailQuery:IRequest<List<GetPatientDetailViewModel>>
    {
        public Guid Id { get; set; }
    }
}
