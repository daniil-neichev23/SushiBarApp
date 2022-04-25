using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.ComponentModel.DataAnnotations;

namespace SushiBarApp.Data.Models
{
    public class Order
    {
        [BindNever]
        public Guid Id { get; set; }
        [Display(Name = "Введите ваше имя:")]
        [MinLength(3)]
        [MaxLength(25)]
        [Required(ErrorMessage = "Заполните поле: Имя")]
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Адрес электронной почты:")]
        [Required(ErrorMessage = "Заполните поле: Email")]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [MaxLength(25)]
        [Display(Name = "Телефон:")]
        [Required(ErrorMessage = "Заполните поле: Телефон")]
        public string Phone { get; set; }

        [BindNever]
        public DateTime OrderTime { get; set; }
    }
}
