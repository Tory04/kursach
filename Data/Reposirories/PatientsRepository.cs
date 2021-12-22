using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Newtonsoft.Json;

namespace Data.Reposirories
{
    public class PatientsRepository
    {
        private static readonly string path = @"C:\Users\пк\Desktop\2 курс\ООП\Курсач\Coursework\Data\DataBases\patients.json";
        private static string json = File.ReadAllText(path);
        private static List<Patient> _patients = new List<Patient>();

        public void AddPatient(Patient patient)
        {
            json = File.ReadAllText(path);
            _patients = JsonConvert.DeserializeObject<List<Patient>>(json);

            if (_patients == null)
            {
                _patients = new List<Patient>();
                patient.ID = 0;
            }
            else
            {
                patient.ID = _patients.Count;
            }

            _patients.Add(patient);

            File.WriteAllText(path, JsonConvert.SerializeObject(_patients, Formatting.Indented));
        }

        public void DeletePatient(Patient patient)
        {
            json = File.ReadAllText(path);
            _patients = JsonConvert.DeserializeObject<List<Patient>>(json);

            _patients.RemoveAt(patient.ID);

            for (int i = 0; i < _patients.Count; i++)
            {
                if (_patients[i].ID > patient.ID)
                {
                    _patients[i].ID--;
                }
            }

            File.WriteAllText(path, JsonConvert.SerializeObject(_patients, Formatting.Indented));
        }

        public List<Patient> GetPatients()
        {
            json = File.ReadAllText(path);
            _patients = JsonConvert.DeserializeObject<List<Patient>>(json);

            if (_patients == null)
                _patients = new List<Patient>();

            return _patients;
        }

        public void UpdatePatient(Patient patient)
        {
            json = File.ReadAllText(path);
            _patients = JsonConvert.DeserializeObject<List<Patient>>(json);

            _patients[patient.ID] = patient;
            File.WriteAllText(path, JsonConvert.SerializeObject(_patients, Formatting.Indented));
        }
    }
}
