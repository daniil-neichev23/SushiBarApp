using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SushiBarApp.Data.Models
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Заполните поле: Название")]
        [MaxLength(70)]
        [Display(Name = "Название товара:")]
        public string Name { get; set; }
        [MaxLength(250)]
        [Display(Name = "Описание товара:")]
        [Required(ErrorMessage = "Заполните поле: Описание")]
        public string? Description { get; set; }

        [Display(Name = "Выберите категорию для товара:")]
        [Required(ErrorMessage = "Категория не выбрана")]
        public Guid CategoryId { get; set; }

        [Range(0,100000)]
        [Display(Name = "Цена:")]
        [Required(ErrorMessage = "Заполните поле: Цена")]
        public decimal Price { get; set; }

        [Range(0,100000)]
        [Display(Name = "Кл-во (штук):")]
        [Required(ErrorMessage = "Заполните поле: Количество")]
        public int Count { get; set; }
        
        [Display(Name = "Рейтинговый товар:")]
        [Required]
        public bool IsFavourite { get; set; }

        [Range(0, 1000000)]
        [Display(Name = "Грамм:")]
        [Required(ErrorMessage = "Заполните поле: Грамм")]
        public double Volume { get; set; }

        [Display(Name = "Тип продукта:")]
        [Required(ErrorMessage = "Заполните поле: Тип")]
        [MaxLength(30)]
        public string Type { get; set; }
        public IList<Review> Reviews { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
    }
}
