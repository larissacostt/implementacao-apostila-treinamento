using capitulo01.Models;
using System.Linq;


namespace capitulo01.Data
{
    public class IESDbInitializer
    {
        public static void Initialize(IESContext context)
        {

            context.Database.EnsureDeleted();

            context.Database.EnsureCreated();

            if (!context.Instituicoes.Any())
            {
                return;
            }

            var instituicoes = new Instituicao[]
            {
                new Instituicao() { Nome = "UniCampo", Endereco ="São Paulo"},
                new Instituicao() { Nome = "UniAcre", Endereco="Acre" }
            };

            foreach (Instituicao i in instituicoes)
            {
                context.Instituicoes.Add(i);
            }

            context.SaveChanges();


            if (!context.Departamentos.Any())
            {
                return;
            }

            var departamentos = new Departamento[] {

                new Departamento() { Nome = "Ciências da Computação" },
                new Departamento() { Nome = "Ciências de Alimentos" }
                };

            foreach (Departamento d in departamentos)
            {
                context.Departamentos.Add(d);
            }

        }
    }
}


