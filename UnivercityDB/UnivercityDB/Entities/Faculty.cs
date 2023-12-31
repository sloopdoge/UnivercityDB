﻿using System.ComponentModel.DataAnnotations;

namespace UnivercityDB.Entities
{
    public class Faculty
    {
        public int FacultyID { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        public string? Note { get; set; }

        public virtual List<Group> Groups { get; set; }
        public virtual List<Chair> Chairs { get; set; }
    }
}
