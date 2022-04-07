using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using HospitalInfoSystem.Application.Contracts;

namespace HospitalInfoSystem.Application.Features.Palients.Quries.GetPatientList
{
    public class GetPatientsListQueryHandler : IRequestHandler<GetPatientsListQuery, List<GetPatientsListViewModel>>
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;

        public GetPatientsListQueryHandler(IPatientRepository patientRepository,IMapper mapper)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }

        public async Task<List<GetPatientsListViewModel>> Handle(GetPatientsListQuery request, CancellationToken cancellationToken)
        {
            var allPatient = await _patientRepository.GetAllPatientAsync();
            return _mapper.Map<List<GetPatientsListViewModel>>(allPatient);
        }
    }
}
