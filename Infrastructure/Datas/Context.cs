using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Datas;

public class Context(DbContextOptions<Context> options): DbContext(options)
{
    public DbSet<Hackathon> Hackathons { get; set; }
    public DbSet<Participant> Participants { get; set; }
    public DbSet<Team> Teams { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Hackathon>()
            .HasMany<Team>(h => h.Teams)
            .WithOne(t => t.Hackathon).HasForeignKey(t=>t.HackathonId);
        modelBuilder.Entity<Team>()
            .HasMany<Participant>(t => t.Participants)
            .WithOne(p=>p.Team).HasForeignKey(p=>p.TeamId);
    }
    
}