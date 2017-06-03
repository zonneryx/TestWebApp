using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TestWebApp.Models
{
    public class User
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Имя")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Возраст")]
        public int Age { get; set; }
        [Required]
        [Display(Name = "Адрес электронной почты")]
        [EmailAddress(ErrorMessage = "Введите корректный адрес электронной почты")]
        public string Email { get; set; }
        [Display(Name = "События")]
        public virtual ICollection<Event> Events { get; set; }
    }
}