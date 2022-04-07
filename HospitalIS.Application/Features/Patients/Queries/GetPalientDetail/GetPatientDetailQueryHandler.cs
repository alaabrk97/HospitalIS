using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using HospitalInfoSystem.Application.Contracts;

namespace HospitalInfoSystem.Application.Features.Palients.Quries.GetPalientDetail
{
    public class GetPatientDetailQueryHandler : IRequestHandler<GetPatientDetailQuery, List<GetPatientDetailViewModel>>
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;

        public GetPatientDetailQueryHandler(IPatientRepository patientRepository,IMapper mapper)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }

        public async Task<List<GetPatientDetailViewModel>> Handle(GetPatientDetailQuery request, CancellationToken cancellationToken)
        {
            var allPatient = await _patientRepository.GetAllPatientAsync();
            return _mapper.Map<List<GetPatientDetailViewModel>>(allPatient);  
        }
    }
}
