using HospitalInfoSystem.Application.Features.Palients.Command.UpdatePalient;
using HospitalIS.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalInfoSystem.Application.Contracts
{
    public interface IPatientRepository:IAsyncRepository<Patient>
    {
        
        Task<IReadOnlyList<Patient>> GetAllPatientAsync();
        Task<Patient> GetPatientByIdAsync(Guid id);
        Patient UpdatePatient(Guid id,Patient patient);
        Task<List<Patient>> Search(string name,string phoneNumber,string fileNo);
        Task<bool> TestExist(int p);
        int count();
    }
}
