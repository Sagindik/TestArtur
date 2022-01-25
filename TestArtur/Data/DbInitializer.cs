using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestArtur.Models;

namespace TestArtur.Data
{
    public class DbInitializer
    {
        public static void Initialize(NovostiContext context) 
        {

            context.Database.EnsureCreated();

            if (context.Novosts.Any())
            {
                return;
            }


            var categorys = new Category[]
            {
                new Category{Naimenovanie="Спорт"},
                new Category{Naimenovanie="Экономика"},
                new Category{Naimenovanie="Культура"}
            };

            foreach (Category c in categorys)
            {
                context.Categorys.Add(c);
            }

            var tegs = new Teg[]
            {
                new Teg{Nazvanie="Футбол"},
                new Teg{Nazvanie="Кино"},
                new Teg{Nazvanie="Банки"}
            };

            tegs[0].Category = categorys[0];
            tegs[1].Category = categorys[0];
            tegs[2].Category = categorys[0];

            foreach (Teg t in tegs)
            {
                context.Tegs.Add(t);
            }

            var novosts = new Novost[]
            {
                new Novost{Zagolovok="Месси получил золотой мяч", Datadobavleniya=DateTime.Parse("2001-06-15"), Vidimost=true, Kartinka=""},
                new Novost{Zagolovok="Банки по всему миру закрылись", Datadobavleniya=DateTime.Parse("2001-06-16"), Vidimost=true, Kartinka=""},
                new Novost{Zagolovok="Кинотеатры стали самым посещаемым местом за август", Datadobavleniya=DateTime.Parse("2001-06-17"), Vidimost=true, Kartinka=""}
            };

            novosts[0].Teg = tegs[0];
            novosts[1].Teg = tegs[0];
            novosts[2].Teg = tegs[0];


            foreach (Novost n in novosts)
            {
                context.Novosts.Add(n);
            }

            

            context.SaveChanges();

        }
    }
}
