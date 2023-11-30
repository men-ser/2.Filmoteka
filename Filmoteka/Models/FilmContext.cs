﻿using Microsoft.EntityFrameworkCore;

namespace Filmoteka.Models
{
    public class FilmContext : DbContext
    {
        public DbSet<Film> Films { get; set; }

        public FilmContext(DbContextOptions<FilmContext> options) 
            : base(options)
        {
            if (Database.EnsureCreated())
            {
                Films.Add(new Film { Name = "Побег из Шоушенка", Director = "Фрэнк Дарабонт", Genre = "Драма", Year=1994, Poster = "img1", Description = "В течение нескольких лет двое заключенных подружились, ища утешения и, в конечном итоге, искупления через элементарное сострадание." });
                Films.Add(new Film { Name = "Список Шиндлера", Director = "Стивен Спилберг", Genre = "Драма", Year = 1993, Poster = "img2", Description = "В оккупированной немцами Польше во время Второй мировой войны промышленник Оскар Шиндлер постепенно начинает беспокоиться о своей еврейской рабочей силе после того, как стал свидетелем их преследования со стороны нацистов." });
                Films.Add(new Film { Name = "Криминальное чтиво", Director = "Квентин Тарантино", Genre = "Драма", Year = 1994, Poster = "img3", Description = "Жизни двух наемных убийц, боксера, гангстера и его жены, а также пары бандитов из закусочной переплетаются в четырех историях о насилии и искуплении." });
                Films.Add(new Film { Name = "Форрест Гамп", Director = "Роберт Земекис", Genre = "Драма", Year = 1994, Poster = "img4", Description = "История Соединенных Штатов с 1950-х по 70-е годы разворачивается с точки зрения жителя Алабамы с IQ 75, который жаждет воссоединения со своей возлюбленной детства." });
                Films.Add(new Film { Name = "Начало", Director = "Кристофер Нолан", Genre = "Фантастика", Year = 2010, Poster = "img5", Description = "Вору, который крадет корпоративные секреты с помощью технологии обмена мечтами, предстоит обратная задача: внедрить идею в сознание генерального директора, но его трагическое прошлое может обречь проект и его команду на катастрофу." });
                Films.Add(new Film { Name = "Интерстеллар", Director = "Кристофер Нолан", Genre = "Фантастика", Year = 2014, Poster = "img6", Description = "Когда в будущем Земля станет непригодной для жизни, фермеру и бывшему пилоту НАСА Джозефу Куперу поручается пилотировать космический корабль вместе с командой исследователей, чтобы найти новую планету для людей." });
                Films.Add(new Film { Name = "Зеленая миля", Director = "Фрэнк Дарабонт", Genre = "Драма", Year = 1999, Poster = "img7", Description = "История происходит в камере смертников в южной тюрьме, где нежный великан Джон обладает таинственной силой исцелять недуги людей. Когда главный охранник Пол узнает дар Джона, он пытается помочь предотвратить казнь осужденного." });
                Films.Add(new Film { Name = "Леон", Director = "Люк Бессон", Genre = "Драма", Year = 1994, Poster = "img8", Description = "12-летнюю Матильду неохотно принимает Леон, профессиональный убийца, после того, как ее семья была убита. Необычные отношения складываются, когда она становится его протеже и осваивает ремесло убийцы." });
                Films.Add(new Film { Name = "Игры разума", Director = "Рон Ховард", Genre = "Драма", Year = 2001, Poster = "img9", Description = "После того, как Джон Нэш, блестящий, но асоциальный математик, соглашается на секретную работу в области криптографии, его жизнь превращается в кошмар." });
                Films.Add(new Film { Name = "Хатико:Собачья сказка", Director = "Лассе Халльстрём", Genre = "Драма", Year = 2009, Poster = "img10", Description = "Профессор колледжа дружит с брошенной собакой, которую берет в свой дом." });
                SaveChanges();
            }
        }
    }
}