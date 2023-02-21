using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Group11_Assignment8_MVC.Models
{
    public class AddTaskResponce
    {
        [Key]
        [Required]
        public int TaskId { get; set; }
        [Required]
        public string Task { get; set; }
        public DateTime Due_Date { get; set; }
        [Required]
        public int Quadrant { get; set; }
        public bool Completed { get; set; }

        //Foreign Key
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
