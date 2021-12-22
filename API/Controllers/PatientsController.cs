using System;
using System.Collections.Generic;
using Entities;
using Services;

namespace API.Controllers
{
    public class PatientsController
    {
        private PatientsService patientsService = new PatientsService();

        public string AddOrUpdatePatient(string Name, string LastName, int Age, string Email, string IdentificationCode, string Disease, string DetectionDate)
        {
            try
            {
                Patient patient = new Patient
                {
                    Name = Name,
                    LastName = LastName,
                    Age = Age,
                    Email = Email,
                    IdentificationCode = IdentificationCode,
                    Disease = Disease,
                    DetectionDate = DetectionDate
                
                };

                patientsService.AddOrUpdatePatient(patient);
                return "Дані оновлено\n";
            }
            catch (Exception)
            {
                return "Щось пішло не так, перевірте корректність вводу даних\n";
            }            
        }

        public string DeletePatient(string id)
        {
            if(patientsService.DeletePatient(id))
                return "Дані пацієнта успішно видалено";
            else
                return "Пацієнта не знайдено";
        }

        public Patient GetPatient(string id)
        {
            if (patientsService.GetPatient(id) == null)
            {
                return null;
            }

            return patientsService.GetPatient(id);
        }

        public string GetPatientInfo(string id)
        {
            Patient patient = GetPatient(id);

            if (patient == null)
            {
                return "Пацієнта не знайдено";
            }

            string res =  $"Ім'я: {patient.Name}\n" +
                          $"Прізвище: {patient.LastName}\n" +
                          $"Вік: {patient.Age}\n" +
                          $"Електронна пошта: {patient.Email}\n" +
                          $"Ідентифікаційний код: {patient.IdentificationCode}\n" +
                          $"Передбачувана хвороба: {patient.Disease}\n" +
                          $"Орієнтовна дата виявлення симптомів: {patient.DetectionDate}\n";

            List<MedicalBookNote> medicalBook = patientsService.GetMedicalBook(id);

            if (medicalBook == null || medicalBook.Count == 0)
                return res;

            for(int i = 0, k = 1; i < medicalBook.Count; i++, k++)
            {
                res += "\n-----------------------\n\n" +
                       $"Запис №{k}\n" +
                       $"Хвороба:{medicalBook[i].Disease} \t Дата виявленя хвороби: {medicalBook[i].DetactionDate} \t Дата вилікування: {medicalBook[i].RecoveryDate}\n";
            }

            return res;
        }

        public List<Patient> GetPatients()
        {
            return patientsService.GetPatients();
        }

        public string GetMedicalBook(string id)
        {
            Patient patient = GetPatient(id);

            if (patient == null)
            {
                return "Пацієнта не знайдено";
            }

            string res = "";

            foreach(var medicalBook in patientsService.GetMedicalBook(id))
            {
                if (res != "")
                    res += "\n---------------------------\n\n";

                res += $"Хвороба: {medicalBook.Disease}\n" +
                       $"Орієнтовна дата захворювання: {medicalBook.DetactionDate}\n" +
                       $"Орієнтовна дата одужання: {medicalBook.RecoveryDate}";
            }

            return res;
        }

        public bool AddNewMedicalBookNote(string id, string Disease, string DetactionDate, string RecoveryDate)
        {
            try
            {
                Patient patient = GetPatient(id);

                if (patient == null)
                {
                    return false;
                }

                MedicalBookNote medicalBookNote = new MedicalBookNote()
                {
                    Disease = Disease,
                    DetactionDate = DetactionDate,
                    RecoveryDate = RecoveryDate
                };

                patientsService.AddMedicalBookNote(id, medicalBookNote);

                return true;
            }
            catch (Exception)
            {
                return false;
            }                   
        }

        public string GetPatientsInfo()
        {
            List<Patient> Patients = GetPatients();

            string res = "";

            if (Patients.Count == 0)
            {
                return "База даних пуста";
            }

            foreach (var patient in Patients)
            {
                res += GetPatientInfo(patient.IdentificationCode);

                if (Patients.Count != 1)
                    res += "-------------------------\n\n";
            }

            return res;
        }
    }
}
