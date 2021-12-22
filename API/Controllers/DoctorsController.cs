using System;
using System.Collections.Generic;
using Services;
using Entities;

namespace API.Controllers
{
    public class DoctorsController
    {
        private DoctorsService doctorsService = new DoctorsService();

        public string AddOrUpdateDoctor(string Name, string LastName, int Age, string Email, string IdentificationCode, string Qualification, int Experience, int OfficeNumber)
        {
            try
            {
                Doctor doctor = new Doctor
                {
                    Name = Name,
                    LastName = LastName,
                    Age = Age,
                    Email = Email,
                    IdentificationCode = IdentificationCode,
                    Qualification = Qualification,
                    Experience = Experience,
                    OfficeNumber = OfficeNumber
                };

                doctorsService.AddOrUpdateDoctor(doctor);

                return "Дані оновлено\n";
            }
            catch (Exception)
            {
                return "Щось пішло не так, перевірте корректність вводу даних\n";
            }
        }

        public string DeleteDoctor(string id)
        {
            if (doctorsService.DeleteDoctor(id))
                return "Дані лікаря успішно видалено";
            else
                return "Лікаря не знайдено";
        }

        public Doctor GetDoctor(string id)
        {
            if (doctorsService.GetDoctor(id) == null)
            {
                return null;
            }

            return doctorsService.GetDoctor(id);
        }

        public Doctor GetDoctorByQualification(string qualification)
        {
            if (doctorsService.GetDoctorByQualification(qualification) == null)
            {
                return null;
            }

            return doctorsService.GetDoctorByQualification(qualification);
        }

        public string GetDoctorInfo(string id)
        {
            Doctor doctor = GetDoctor(id);

            if (doctor == null)
            {
                return "Лікаря за даним ідентифікаційним кодом не існує";
            }

            return $"Ім'я: {doctor.Name}\n" +
                   $"Прізвище: {doctor.LastName}\n" +
                   $"Вік: {doctor.Age}\n" +
                   $"Електронна пошта: {doctor.Email}\n" +
                   $"Ідентифікаційний код: {doctor.IdentificationCode}\n" +
                   $"Кваліфікація лікаря: {doctor.Qualification}\n" +
                   $"Стаж роботи: {doctor.Experience}\n" +
                   $"Номер кабінету: {doctor.OfficeNumber}\n";
        }

        public string GetDoctorsInfo()
        {
            List<Doctor> Doctors = GetDoctorsList();

            string res = "";

            if (Doctors.Count == 0)
            {
                return "База даних пуста";
            }

            foreach (var doctor in Doctors)
            {
                res += GetDoctorInfo(doctor.IdentificationCode);

                if (Doctors.Count != 1)
                    res += "-------------------------\n\n";
            }

            return res;
        }

        public List<Doctor> GetDoctorsList()
        {
            return doctorsService.GetDoctorsList();
        }
    }
}
