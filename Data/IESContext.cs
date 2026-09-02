using capitulo01.Data;
using capitulo01.Models;
using Microsoft.EntityFrameworkCore;

namespace capitulo01.Data
{
    public class IESContext : DbContext
    {

        // passa o construtor e diz as configurações que a EF vai usar
        public IESContext(DbContextOptions<IESContext> options) : base(options)
        {

        }

        //entidades que EF Core vai mapear no banco de dados
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Instituicao> Instituicoes { get; set; }

        
        //como as classes vao ser mapeadas no banco de dados
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Departamento>().ToTable("Departamento");
            // configura a entidade departamento e como deve ser mapeada
        }
    }
}
