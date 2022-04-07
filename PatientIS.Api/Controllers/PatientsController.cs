using HospitalInfoSystem.Application.Features.Palients.Quries.GetPatientList;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using HospitalInfoSystem.Application.Features.Palients.Command.CreatePalient;
using HospitalInfoSystem.Application.Features.Palients.Command.DeletePalient;
using HospitalIS.Domain;
using HospitalInfoSystem.Application.Contracts;
using HospotalIS.Persistence.Repositories;
using HositalS.Persistence;
using Microsoft.AspNetCore.Cors;
using HospitalInfoSystem.Application.Features.Palients.Command.UpdatePalient;
using HospitalInfoSystem.Application.Features.Palients.Quries.GetPalientDetail;

namespace PatientIS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class PatientsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IPatientRepository _patientRepository;

        public PatientsController(IMediator mediator, IPatientRepository patientRepository)
        {
            _mediator = mediator;
            _patientRepository = patientRepository;
        }

        // POST api/<PatientsController>
        [HttpPost(Name = "PostPatients")]
        public async Task<ActionResult<Guid>> Post([FromBody] CreatePatientCommand createPatientCommand)
        {
            Guid id = await _mediator.Send(createPatientCommand);
            return Ok(id);
        }

        // DELETE api/<PatientsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deletePatientCommand = new DeletePatientCommand() { id = id };
            await _mediator.Send(deletePatientCommand);
            return NoContent();
        }


        // Get api/Patients/all?name=""&PageNumber=1&PageSize=1
        [HttpGet("all", Name = "GetPatients")]
        public async Task<ActionResult<List<GetPatientsListViewModel>>> GetPatientsList(string? name = null, string? fileNo = null, string? phoneNumber = null, [FromQuery] Paginator paginator = null)
        {
            try
            {
                var result = await _patientRepository.Search(name, phoneNumber, fileNo);
                if (result.Any())
                {
                    int count = _patientRepository.count();
                    Paginator page = new Paginator(paginator.PageNumber, paginator.PageSize, count);
                    return Ok(result.Skip((page.PageNumber - 1) * (page.PageSize)).Take(page.PageSize));
                }
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "There error");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePatientId(Guid id, [FromBody] Patient p)
        {
            var updatePatient = _patientRepository.UpdatePatient(id, p);
            return Ok(updatePatient);
        }

        [HttpGet("{id}", Name = "GetPatientById")]
        public async Task<ActionResult<GetPatientDetailViewModel>> GetPatientById(Guid id)
        {
            var t=await _patientRepository.GetPatientByIdAsync(id);
            return Ok(t);
        }
    }
}
