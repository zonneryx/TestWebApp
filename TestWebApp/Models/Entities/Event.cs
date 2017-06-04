using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TestWebApp.Models
{
    public class Event
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Укажите название")]
        [Display(Name = "Название")]
        [MaxLength(64)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Укажите дату и время")]
        [Display(Name = "Дата и время")]
        public DateTime Date { get; set; }
        [Display(Name = "Место проведения")]
        [MaxLength(128)]
        public string Place { get; set; }
        [Display(Name = "Участники")]
        public virtual ICollection<User> Users { get; set; }

    }
  

}