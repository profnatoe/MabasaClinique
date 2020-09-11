using HealthClinique.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinique.Data
{
    public class MabasaDbContext  : IdentityDbContext
    {
        public MabasaDbContext(DbContextOptions<MabasaDbContext> options) : base(options) { }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientAddress> PatientAddresses { get; set; }
        public DbSet<PatientTests> PatientTests { get; set; }
        public DbSet<Appointment> Appointment { get; set; }
    }
}
