using System;
using System.Collections.Generic;
using System.IO;
using Entities;
using Newtonsoft.Json;

namespace Data.Reposirories
{
    public class ScheduleNoteRepository
    {
        private static readonly string path = @"C:\Users\пк\Desktop\2 курс\ООП\Курсач\Coursework\Data\DataBases\schedule.json";
        private static string json = File.ReadAllText(path);
        private static List<Schedule> _notes = new List<Schedule>();

        public void AddNote(Schedule note)
        {
            json = File.ReadAllText(path);
            _notes = JsonConvert.DeserializeObject<List<Schedule>>(json);

            if (_notes == null)
            {
                _notes = new List<Schedule>();
                note.ID = 0;
            }
            else
            {
                note.ID = _notes.Count;
            }

            _notes.Add(note);

            File.WriteAllText(path, JsonConvert.SerializeObject(_notes, Formatting.Indented));
        }

        public void DeleteNote(Schedule note)
        {
            json = File.ReadAllText(path);
            _notes = JsonConvert.DeserializeObject<List<Schedule>>(json);

            _notes.RemoveAt(note.ID);

            for (int i = 0; i < _notes.Count; i++)
            {
                if (_notes[i].ID > note.ID)
                {
                    _notes[i].ID--;
                }
            }

            File.WriteAllText(path, JsonConvert.SerializeObject(_notes, Formatting.Indented));
        }

        public List<Schedule> GetSchedule()
        {
            json = File.ReadAllText(path);
            _notes = JsonConvert.DeserializeObject<List<Schedule>>(json);

            if (_notes == null)
                _notes = new List<Schedule>();

            return _notes;
        }

        public void UpdateSchedule(Schedule note)
        {
            json = File.ReadAllText(path);
            _notes = JsonConvert.DeserializeObject<List<Schedule>>(json);

            _notes[note.ID] = note;
            File.WriteAllText(path, JsonConvert.SerializeObject(_notes, Formatting.Indented));
        }
    }
}
