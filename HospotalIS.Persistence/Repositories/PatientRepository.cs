using HospitalInfoSystem.Application.Contracts;
using HospitalInfoSystem.Application.Features.Palients.Quries.GetPatientList;
using HospitalIS.Domain;
using HospotalIS.Persistence.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HositalS.Persistence.Repositories
{
    public class PatientRepository : BaseRepository<Patient>, IPatientRepository
    {
        private readonly IMediator _mediator;

        public PatientRepository(HospitalISDbContext postDbContext) : base(postDbContext)
        {
        }

        public async Task<IReadOnlyList<Patient>> GetAllPatientAsync()
        {
            List<Patient> allPatients = new List<Patient>();
            allPatients = await _context.patients.ToListAsync();
            return allPatients;
        }
        public async Task<bool> TestExist(int fileno)
        {
            var t = await _context.patients.SingleOrDefaultAsync(p => p.FileNo == fileno);
            if (t != null)
            {
                return true;
            }
            return false;

        }
        public  int count()
        {
            int count= _context.patients.Count();
            return count;
        }
        public Patient UpdatePatient(Guid id, Patient patient)
        {
            var _patient = _context.patients.FirstOrDefault(p => p.Id == id);
            if (_patient != null)
            {
                _patient.Name = patient.Name;
                _patient.FileNo = patient.FileNo;
                _patient.Gender = patient.Gender;
                _patient.Email = patient.Email;
                _patient.PhoneNumber = patient.PhoneNumber;
                _patient.CitizenId = patient.CitizenId;
                _patient.Natinality = patient.Natinality;
                _patient.Country = patient.Country;
                _patient.City = patient.City;
                _patient.Street = patient.Street;
                _patient.Address1 = patient.Address1;
                _patient.Address2 = patient.Address2;
                _patient.ContactPerson = patient.ContactPerson;
                _patient.ContactPhone = patient.ContactPhone;
                _patient.ContactRelation = patient.ContactRelation;
                _patient.Birthdate = patient.Birthdate;
                _patient.FirstVisitDate = patient.FirstVisitDate;
                _context.SaveChanges();
            }
            return _patient;
        }

        public async Task<List<Patient>> Search(string name, string phoneNumber, string fileNo)
        {
            IQueryable<Patient> query = _context.patients;

           
            if (!string.IsNullOrEmpty(name))
            {
                query =query.Where(r => r.Name.Equals(name));
            }
            if (!string.IsNullOrEmpty(phoneNumber))
            {
                query = query.Where(r => r.PhoneNumber.Equals(phoneNumber));
            }
            
            if (!string.IsNullOrEmpty(fileNo))
            {
                int FileNo = int.Parse(fileNo);
                if(FileNo>0)
                query = query.Where(r => r.FileNo== FileNo);
            }

            return await query.ToListAsync();   
        }

        public async  Task<Patient> GetPatientByIdAsync(Guid id)
        {
            var r = await _context.patients.FindAsync(id);
            return r;
        }
    }
}
