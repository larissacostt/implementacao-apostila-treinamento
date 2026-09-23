using Modelo.Cadastros;
using Microsoft.EntityFrameworkCore;
using Modelo.Discente;
using capitulo01.Models.Infra;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Modelo.Docente;


namespace capitulo01.Data
{
    public class IESContext : IdentityDbContext<UsuarioDaAplicacao>
    {

        // passa o construtor e diz as configurações que a EF vai usar
        public IESContext(DbContextOptions<IESContext> options) : base(options)
        {
        }
        //entidades que EF Core vai mapear no banco de dados
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Instituicao> Instituicoes { get; set; }

        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Academico> Academicos { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<CursoProfessor> CursosProfessores { get; set; }
      
        //como as classes vao ser mapeadas no banco de dados
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CursoDisciplina>()
                .HasKey(cd => new { cd.CursoID, cd.DisciplinaID });

            modelBuilder.Entity<CursoDisciplina>()
                .HasOne(c => c.Curso)
                .WithMany(cd => cd.CursosDisciplinas)
                .HasForeignKey(c => c.CursoID);

            modelBuilder.Entity<CursoDisciplina>()
                .HasOne(d => d.Disciplina)
                .WithMany(cd => cd.CursosDisciplinas)
                .HasForeignKey(d => d.DisciplinaID);

            modelBuilder.Entity<CursoProfessor>()
                .HasKey(cd => new { cd.CursoID, cd.ProfessorID });

            modelBuilder.Entity<CursoProfessor>()
                .HasOne(c => c.Curso)
                .WithMany(cd => cd.CursosProfessores)
                .HasForeignKey(c => c.CursoID);

            modelBuilder.Entity<CursoProfessor>()
                .HasOne(d => d.Professor)
                .WithMany(cd => cd.CursosProfessores)
                .HasForeignKey(d => d.ProfessorID);


            modelBuilder.Entity<Departamento>().ToTable("Departamento");
            modelBuilder.Entity<Instituicao>().ToTable("Instituicao");
            // configura a entidade departamento e como deve ser mapeada
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQllocaldb;Database = IESCasaDoCodigo; Trusted_Connection = True");
        }


    }
}
