using System;
using System.Collections.Generic;
using Entities;
using Data.Reposirories;

namespace Services
{
    public class ScheduleServices
    {
        private static ScheduleNoteRepository scheduleRepository = new ScheduleNoteRepository();
        private List<Schedule> _notes = scheduleRepository.GetSchedule();

        public void AddNote(Schedule note)
        {
            scheduleRepository.AddNote(note);
        }

        public void UpdateNote(Schedule old, Schedule newNote)
        {
            Schedule note = new Schedule
            {
                ID = old.ID,
                AdmissionDate = newNote.AdmissionDate,
                Patient = newNote.Patient,
                Doctor = newNote.Doctor
            };

            scheduleRepository.UpdateSchedule(note);
        }

        public bool DeleteNote(Schedule note)
        {
            try
            {
                _notes = scheduleRepository.GetSchedule();
                Schedule noteToDelete = _notes.Find(findedNote => findedNote.Patient.IdentificationCode == note.Patient.IdentificationCode &&
                                                                  findedNote.Doctor.IdentificationCode == note.Doctor.IdentificationCode &&
                                                                  findedNote.AdmissionDate == note.AdmissionDate);

                if (noteToDelete == null)
                {
                    throw new Exception("Об'єкта не існує");
                }
                else
                {
                    scheduleRepository.DeleteNote(noteToDelete);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Schedule> GetNotes(DateTime date)
        {
            try
            {
                _notes = scheduleRepository.GetSchedule();
                List<Schedule> notes = _notes.FindAll(note => note.AdmissionDate == date);

                if (notes == null)
                    throw new Exception("");
                else
                    return notes;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
