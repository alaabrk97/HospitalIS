using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalIS.Domain;
using Microsoft.EntityFrameworkCore;
namespace HositalS.Persistence
{
    public class HospitalISDbContext:DbContext
    {
        public HospitalISDbContext(DbContextOptions<HospitalISDbContext> options):base(options)
        {

        }
        public DbSet<Patient> patients { get; set; }
       
    }
}
