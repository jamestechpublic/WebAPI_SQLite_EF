using Microsoft.EntityFrameworkCore;
using WebAPI_SQLite_EF.Models;

namespace WebAPI_SQLite_EF.Data;

internal partial class MovieDataContext : DbContext
{
    public MovieDataContext()
    {
    }

    public MovieDataContext(DbContextOptions<MovieDataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    /// <summary>
    ///     Configures the database connection for the context.
    ///     Ensures that the context uses SQLite with a connection string named "DbMovieData".
    /// </summary>
    /// <param name="optionsBuilder"></param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Name=ConnectionStrings:DbMovieData");

    /// <summary>
    ///     Setup the model for the context.
    ///     Includes configuration for the Genre and Movie entities,
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasIndex(e => e.Id, "IX_Genres_Id").IsUnique();
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasIndex(e => e.Id, "IX_Movies_Id").IsUnique();

            entity.HasOne(d => d.Genre).WithMany(p => p.Movies)
                .HasForeignKey(d => d.GenreId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
