using System;
using System.Collections.Generic;
using System.IO;
using Entities;
using Newtonsoft.Json;

namespace Data.Reposirories
{
    public class DoctorsRepository
    {
        private static readonly string path = @"C:\Users\пк\Desktop\2 курс\ООП\Курсач\Coursework\Data\DataBases\doctors.json";
        private static string json = File.ReadAllText(path);
        private List<Doctor> _doctors = new List<Doctor>();

        public void AddDoctor(Doctor doctor)
        {
            json = File.ReadAllText(path);
            _doctors = JsonConvert.DeserializeObject<List<Doctor>>(json);

            if (_doctors == null)
            {
                _doctors = new List<Doctor>();
                doctor.ID = 0;
            }
            else
            {
                doctor.ID = _doctors.Count;
            }

            _doctors.Add(doctor);

            File.WriteAllText(path, JsonConvert.SerializeObject(_doctors, Formatting.Indented));
        }

        public void DeleteDoctor(Doctor doctor)
        {
            json = File.ReadAllText(path);
            _doctors = JsonConvert.DeserializeObject<List<Doctor>>(json);

            _doctors.RemoveAt(doctor.ID);

            for (int i = 0; i < _doctors.Count; i++)
            {
                if (_doctors[i].ID > doctor.ID)
                {
                    _doctors[i].ID--;
                }
            }

            File.WriteAllText(path, JsonConvert.SerializeObject(_doctors, Formatting.Indented));
        }

        public List<Doctor> GetDoctors()
        {
            json = File.ReadAllText(path);
            _doctors = JsonConvert.DeserializeObject<List<Doctor>>(json);

            if (_doctors == null)
                _doctors = new List<Doctor>();

            return _doctors;
        }

        public void UpdateDoctor(Doctor doctor)
        {
            json = File.ReadAllText(path);
            _doctors = JsonConvert.DeserializeObject<List<Doctor>>(json);

            _doctors[doctor.ID] = doctor;

            File.WriteAllText(path, JsonConvert.SerializeObject(_doctors, Formatting.Indented));
        }
    }
}
