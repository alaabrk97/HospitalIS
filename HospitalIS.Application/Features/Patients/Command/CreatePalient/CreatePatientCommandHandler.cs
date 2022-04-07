using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using HospitalInfoSystem.Application.Contracts;
using HospitalIS.Domain;

namespace HospitalInfoSystem.Application.Features.Palients.Command.CreatePalient
{
    public class CreatePatientCommandHandler:IRequestHandler<CreatePatientCommand,Guid>
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;

        public CreatePatientCommandHandler(IPatientRepository patientRepository,IMapper mapper)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
        {
            Patient patient = _mapper.Map<Patient>(request);
            CreateCommandValidator validator = new CreateCommandValidator();
            var result = await validator.ValidateAsync(request);
            if(result.Errors.Any())
            {
                throw new Exception("Patient is not Valid");

            }
            if (await _patientRepository.TestExist(patient.FileNo))
            {
                throw new Exception("already exists");
            }          
            patient = await _patientRepository.AddAsync(patient);
            return patient.Id;
            
        }
    }
}
