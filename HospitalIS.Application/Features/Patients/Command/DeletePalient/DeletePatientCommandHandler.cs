using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalInfoSystem.Application.Contracts;
using MediatR;
namespace HospitalInfoSystem.Application.Features.Palients.Command.DeletePalient
{
    public class DeletePatientCommandHandler:IRequestHandler<DeletePatientCommand>  
    {
        private readonly IPatientRepository _patientRepository;

        public DeletePatientCommandHandler(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<Unit> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
        {
            var patient = await _patientRepository.GetPatientByIdAsync(request.id);
            await _patientRepository.DeleteAsync(patient);
            return Unit.Value;    
        }
    }
}
