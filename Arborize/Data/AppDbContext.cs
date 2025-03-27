using Microsoft.EntityFrameworkCore;
using Arborize.Models;
using Arborize.Controllers;
using Arborize.Data;

namespace Arborize.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

        public required DbSet<CadastroModel> Usuario { get; set; }
        public required DbSet<FeedbackModel> Feedbacks { get; set; }
        public required DbSet<CadastrarArvore> CadastrarArvores { get; set; }
        public required DbSet<FeedModel> Feed { get; set; }
        public required DbSet<MarketPlaceModel> MarketPlace {get; set;}

        // Método OnModelCreating para configurar mapeamentos e relacionamentos

        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // relacionamento entre cadastroModel e cadastrarArvore
        modelBuilder.Entity<CadastrarArvore>()
            .HasOne(a => a.Usuario)
            .WithMany(u => u.Arvores)
            .HasForeignKey(a => a.IdUsuario);

    }
        
    }
}