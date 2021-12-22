using Entities.Abstract;
using System;
using System.Collections.Generic;

namespace Entities
{
    public class Patient : BaseEntity
    {
        public string Disease { get; set; }
        public string DetectionDate { get; set; }
        public List<MedicalBookNote> MedicalBook { get; set; }
    }
}
