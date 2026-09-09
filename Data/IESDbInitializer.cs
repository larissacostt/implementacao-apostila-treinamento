using capitulo01.Models;
using System.Linq;


namespace capitulo01.Data
{
    public class IESDbInitializer
    {
        public static void Initialize(IESContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Departamentos.Any())
            {


                var departamentos = new Departamento[]
                {
                new Departamento() { Nome = "Ciências da Computação" },
                new Departamento() { Nome = "Ciências de Alimentos" }
                };

                foreach (Departamento d in departamentos)
                {
                    context.Departamentos.Add(d);
                }
            }

            if (!context.Instituicoes.Any())
            {


                var instituicoes = new Instituicao[] {

                new Instituicao() {

                    Nome = "UniParaná",
                    Endereco= "Curitiba"
                },

                new Instituicao()
                {
                    Nome = "UniSanta",
                    Endereco = "Santa Catarina"
                },

                new Instituicao(){
                    Nome = "UniVale",
                    Endereco = "Rio Grande do Sul"
                },

                new Instituicao()
                {
                    Nome = "Feevale",
                    Endereco = "Novo Hamburgo"
                }
            };

                foreach (Instituicao i in instituicoes)
                {
                    context.Instituicoes.Add(i);
                }
            }

                    context.SaveChanges();
                
        }
    }
 }


