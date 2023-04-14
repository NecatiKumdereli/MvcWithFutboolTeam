using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace _21660110053NecatiKumdereli.Models;

public partial class FutbolTakımıContext : DbContext
{
    public FutbolTakımıContext()
    {
    }

    public FutbolTakımıContext(DbContextOptions<FutbolTakımıContext> options)
        : base(options)
    {
    }

    public virtual DbSet<FootballPlayer> FootballPlayers { get; set; }

    public virtual DbSet<FootballPlayerHistory> FootballPlayerHistories { get; set; }

    public virtual DbSet<FootballTeam> FootballTeams { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=.\\Data\\Futbol Takımı.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FootballPlayer>(entity =>
        {
            entity.ToTable("FootballPlayer");

            entity.HasIndex(e => e.Id, "IX_FootballPlayer_Id").IsUnique();
        });

        modelBuilder.Entity<FootballPlayerHistory>(entity =>
        {
            entity.ToTable("FootballPlayerHistory");

            entity.HasIndex(e => e.Id, "IX_FootballPlayerHistory_Id").IsUnique();

            entity.HasOne(d => d.Player).WithMany(p => p.FootballPlayerHistories)
                .HasForeignKey(d => d.PlayerId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Team).WithMany(p => p.FootballPlayerHistories)
                .HasForeignKey(d => d.TeamId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<FootballTeam>(entity =>
        {
            entity.ToTable("FootballTeam");

            entity.HasIndex(e => e.Id, "IX_FootballTeam_Id").IsUnique();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
