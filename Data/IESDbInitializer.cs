using capitulo01.Models;
using System.Linq;


namespace capitulo01.Data
{
    public interface IESDbInitializer
    {
        public static void Initialize(IESContext context)
        {
            context.Database.EnsureCreated();

            if (context.Departamentos.Any())
            {
                return;
            }
            var departamentos = new Departamento[]
            {
                new Departamento() { Nome = "Ciências da Computação" },
                new Departamento() { Nome = "Ciências de Alimentos" }
            };

            foreach(Departamento d in departamentos)
            {
                context.Departamentos.Add(d);
            }
            context.SaveChanges();
        }       
    }
}


