using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.ComponentModel.DataAnnotations;

namespace SushiBarApp.Data.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [MinLength(5)]
        [MaxLength(30)]
        [Display(Name = "Адрес электронной почты:")]
        [Required(ErrorMessage = "Заполните поле: Email")]
        public string Email { get; set; }

        [MinLength(6)]
        [Display(Name = "Пароль:")]
        [Required(ErrorMessage = "Заполните поле: Пароль")]
        public string Password { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Номер телефона:")]
        [Required(ErrorMessage = "Заполните поле: Телефон")]
        public string PhoneNumber { get; set; }

        [MaxLength(30)]
        [Display(Name = "Введите ваше имя:")]
        [Required(ErrorMessage = "Заполните поле: Имя")]
        public string Name { get; set; }

        [BindNever]
        [MaxLength(15)]
        public string Role { get; set; }
    }
}
