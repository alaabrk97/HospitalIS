using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
namespace HospitalInfoSystem.Application.Features.Palients.Command.DeletePalient
{
    public class DeletePatientCommand:IRequest
    {
        public Guid id { get; set; }   
    }
}
