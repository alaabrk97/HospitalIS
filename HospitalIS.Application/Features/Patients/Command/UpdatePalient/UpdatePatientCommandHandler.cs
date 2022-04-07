using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalInfoSystem.Application.Contracts;
using MediatR;
using AutoMapper;
using HospitalIS.Domain;

namespace HospitalInfoSystem.Application.Features.Palients.Command.UpdatePalient
{
    public class UpdatePatientCommandHandler:IRequestHandler<UpdatePatientCommand>
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;

        public UpdatePatientCommandHandler(IPatientRepository patientRepository,IMapper mapper)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
        {
            Patient patient = _mapper.Map<Patient>(request);
            await _patientRepository.UpdateAsync(patient);
            return Unit.Value;
        }
    }
}
