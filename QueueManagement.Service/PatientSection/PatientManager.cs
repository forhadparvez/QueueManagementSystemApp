using QueueManagement.Core.DataModels;
using QueueManagement.Repository.PatientSection;
using System.Collections.Generic;

namespace QueueManagement.Service.PatientSection
{
    public class PatientManager
    {
        private readonly PatientRepository _patientRepository;

        public PatientManager()
        {
            _patientRepository = new PatientRepository();
        }

        public bool IsPhoneNoExist(string phoneNo)
        {
            bool isPhoneNoExist = false;
            var patient = _patientRepository.GetPatientByPhoneNo(phoneNo);
            if (patient != null)
            {
                isPhoneNoExist = true;
            }

            return isPhoneNoExist;
        }

        public int Save(Patient patient)
        {
            return _patientRepository.Save(patient);
        }

        public int Update(int id, Patient patient)
        {
            return _patientRepository.Update(id, patient);
        }

        public int Delete(int id)
        {
            return _patientRepository.Delete(id);
        }

        public IEnumerable<Patient> GetAll()
        {
            return _patientRepository.GetAllPatients();
        }

        public Patient GetPatientByPhoneNo(string phoneNo)
        {
            return _patientRepository.GetPatientByPhoneNo(phoneNo);
        }

        public Patient GetById(int id)
        {
            return _patientRepository.GetById(id);
        }
    }
}
