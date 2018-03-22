
using QueueManagement.Core.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QueueManagement.Repository.PatientSection
{
    public class PatientRepository : IDisposable
    {
        private readonly QueueManagementDbEntities _dbEntities;

        public PatientRepository()
        {
            _dbEntities = new QueueManagementDbEntities();
        }

        public int Save(Patient patient)
        {
            _dbEntities.Patients.Add(patient);
            return _dbEntities.SaveChanges();
        }

        public int Update(int id, Patient patient)
        {
            var patientInDb = _dbEntities.Patients.SingleOrDefault(c => c.Id == id);
            if (patientInDb != null)
            {
                patientInDb.Name = patient.Name;
                patientInDb.PhoneNo = patient.PhoneNo;
                patientInDb.Age = patient.Age;

                return _dbEntities.SaveChanges();
            }

            return 0;
        }

        public int Delete(int id)
        {
            var patientInDb = _dbEntities.Patients.SingleOrDefault(c => c.Id == id);
            if (patientInDb != null)
            {
                _dbEntities.Patients.Remove(patientInDb);
                return _dbEntities.SaveChanges();
            }

            return 0;
        }

        public IEnumerable<Patient> GetAllPatients()
        {
            return _dbEntities.sp_PatientGetAll();
        }

        public Patient GetPatientByPhoneNo(string phoneNo)
        {
            var entitylist = _dbEntities.sp_PatientGetByPhoneNo(phoneNo);
            return entitylist.FirstOrDefault();
        }

        public Patient GetById(int id)
        {
            return _dbEntities.Patients.SingleOrDefault(c => c.Id == id);
        }

        public void Dispose()
        {
            _dbEntities.Dispose();
        }


    }
}
