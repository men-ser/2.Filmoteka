using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Filmoteka.Annotations;
using Microsoft.AspNetCore.Mvc;

namespace Filmoteka.Models
{
    public class Film
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Необходимо ввести название фильма")]
        [Display(Name = "Название фильма")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Необходимо ввести данные по режиссеру")]
        [RegularExpression(@"[а-яА-ЯёЁa-zA-Z .]{1,}", ErrorMessage = "Можно вводить буквы, точку и пробел")]
        [Display(Name = "Режиссер")]
        public string Director { get; set; }

        [Required(ErrorMessage = "Необходимо ввести жанр фильма")]
        [Display(Name = "Жанр фильма")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Необходимо ввести год выпуска фильма")]
        [Range(1900, 2030, ErrorMessage = "год должен быть между 1900-2030гг")]
        [Display(Name = "Год выпуска")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Необходимо указать путь к постеру")]
        [ReservedImgAttribute(new string[] { "img1", }, ErrorMessage = "Недопустимое имя файла")]
        [Display(Name = "Постер")]
        public string Poster { get; set; }
        //"img2", "img3", "img4", "img5", "img6", "img7", "img8", "img9", "img10" 

        [Required(ErrorMessage = "Необходимо ввести описание фильма")]
        [Display(Name = "Краткое описание")]
        public string Description { get; set; }
    }
}
