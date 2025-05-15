using Microsoft.EntityFrameworkCore;
using WebApplicationMYSQL.Data.Map;
using WebApplicationMYSQL.Models;

namespace WebApplicationMYSQL.Data
{
    public class ColaboradoresDB : DbContext
    {
        //Construtor
        public ColaboradoresDB(DbContextOptions<ColaboradoresDB> options) : base(options) { }

        //Tabela Colaborador
        public DbSet<Colaborador> Colaborador { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ColaboradoresMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
