using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CN34ZF_HFT_2021221.Data
{
    public class TeamsDbContext : DbContext
    {
        public virtual DbSet<Team> Teams { get; set; }

        public virtual DbSet<League> Leagues { get; set; }

        public virtual DbSet<Country> Countries { get; set; }

        public TeamsDbContext()
        {
            this.Database.EnsureCreated();
        }

        public TeamsDbContext(DbContextOptions<TeamsDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\FootballDb.mdf;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Countries
            Country c1 = new Country() { CountryId = 1, CountryName = "Spain", Population = 47000000, Language = "Spanish", Area = 357000 };
            Country c2 = new Country() { CountryId = 2, CountryName = "Italy", Population = 60000000, Language = "Italian", Area = 300000 };
            Country c3 = new Country() { CountryId = 3, CountryName = "England", Population = 54000000, Language = "English", Area = 130000 };
            Country c4 = new Country() { CountryId = 4, CountryName = "Germany", Population = 84000000, Language = "German", Area = 506000 };

            // Leagues
            League l1 = new League() { LeagueId = 1, LeagueName = "La Liga", CountryId = c1.CountryId, NumberofTeams = 20, FirstClass = true };
            League l2 = new League() { LeagueId = 2, LeagueName = "Serie A", CountryId = c2.CountryId, NumberofTeams = 20, FirstClass = true };
            League l3 = new League() { LeagueId = 3, LeagueName = "Premier League", CountryId = c3.CountryId, NumberofTeams = 20, FirstClass = true };
            League l4 = new League() { LeagueId = 4, LeagueName = "Bundesliga 2.", CountryId = c4.CountryId, NumberofTeams = 18, FirstClass = false };

            c1.CountryId = l1.CountryId;
            c2.CountryId = l2.CountryId;
            c3.CountryId = l3.CountryId;
            c4.CountryId = l4.CountryId;

            // Models
            // La Liga (CountryId: 1)
            Team t1 = new Team() { TeamId = 1, CountryId = l1.CountryId, TeamName = "Alavés", YearofFoundation = 1921, Seat = "Mendizorroza", Manager = "Javier Calleja" };
            Team t2 = new Team() { TeamId = 2, CountryId = l1.CountryId, TeamName = "Athletic Bilbao", YearofFoundation = 1898, Seat = "San Mamés", Manager = "Marcelino" };
            Team t3 = new Team() { TeamId = 3, CountryId = l1.CountryId, TeamName = "Atlético Madrid", YearofFoundation = 1903, Seat = "Wanda Metropolitano", Manager = "Diego Simeone" };
            Team t4 = new Team() { TeamId = 4, CountryId = l1.CountryId, TeamName = "Barcelona", YearofFoundation = 1899, Seat = "Camp Nou", Manager = "Ronald Koeman" };
            Team t5 = new Team() { TeamId = 5, CountryId = l1.CountryId, TeamName = "Cádiz", YearofFoundation = 1910, Seat = "Nuevo Mirandilla", Manager = "Álvaro Cervera" };
            Team t6 = new Team() { TeamId = 6, CountryId = l1.CountryId, TeamName = "Celta Vigo", YearofFoundation = 1923, Seat = "Abanca-Balaídos", Manager = "Eduardo Coudet" };
            Team t7 = new Team() { TeamId = 7, CountryId = l1.CountryId, TeamName = "Elche", YearofFoundation = 1923, Seat = "Martínez Valero", Manager = "Fran Escribá" };
            Team t8 = new Team() { TeamId = 8, CountryId = l1.CountryId, TeamName = "Espanyol", YearofFoundation = 1900, Seat = "RCDE Stadium", Manager = "Vicente Moreno" };
            Team t9 = new Team() { TeamId = 9, CountryId = l1.CountryId, TeamName = "Getafe", YearofFoundation = 1983, Seat = "Coliseum Alfonso Pérez", Manager = "Quique Sánchez Flores" };
            Team t10 = new Team() { TeamId = 10, CountryId = l1.CountryId, TeamName = "Granada", YearofFoundation = 1931, Seat = "Nuevo Los Cármenes", Manager = "Robert Moreno" };
            Team t11 = new Team() { TeamId = 11, CountryId = l1.CountryId, TeamName = "Levante", YearofFoundation = 1909, Seat = "Ciutat de València", Manager = "Javier Pereira" };
            Team t12 = new Team() { TeamId = 12, CountryId = l1.CountryId, TeamName = "Mallorca", YearofFoundation = 1916, Seat = "Visit Mallorca Estadi", Manager = "Luis García" };
            Team t13 = new Team() { TeamId = 13, CountryId = l1.CountryId, TeamName = "Osasuna", YearofFoundation = 1920, Seat = "El Sadar", Manager = "Jagoba Arrasate" };
            Team t14 = new Team() { TeamId = 14, CountryId = l1.CountryId, TeamName = "Rayo Vallecano", YearofFoundation = 1924, Seat = "Vallecas", Manager = "Andoni Iraola" };
            Team t15 = new Team() { TeamId = 15, CountryId = l1.CountryId, TeamName = "Real Betis", YearofFoundation = 1907, Seat = "Benito Villamarín", Manager = "Manuel Pellegrini" };
            Team t16 = new Team() { TeamId = 16, CountryId = l1.CountryId, TeamName = "Real Madrid", YearofFoundation = 1902, Seat = "Santiago Bernabéu", Manager = "Carlo Ancelotti" };
            Team t17 = new Team() { TeamId = 17, CountryId = l1.CountryId, TeamName = "Real Sociedad", YearofFoundation = 1909, Seat = "Anoeta", Manager = "Imanol Alguacil" };
            Team t18 = new Team() { TeamId = 18, CountryId = l1.CountryId, TeamName = "Sevilla", YearofFoundation = 1890, Seat = "Ramón Sánchez Pizjuán", Manager = "Julen Lopetegui" };
            Team t19 = new Team() { TeamId = 19, CountryId = l1.CountryId, TeamName = "Valencia", YearofFoundation = 1919, Seat = "Mestalla", Manager = "José Bordalás" };
            Team t20 = new Team() { TeamId = 20, CountryId = l1.CountryId, TeamName = "Villarreal", YearofFoundation = 1923, Seat = "Estadio de la Cerámica", Manager = "Unai Emery" };

            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasOne(team => team.Country)
                .WithMany(country => country.Teams)
                .HasForeignKey(team => team.CountryId)
                .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<League>(entity =>
            {
                entity.HasOne(league => league.Country)
                .WithMany(country => country.Leagues)
                .HasForeignKey(league => league.CountryId)
                .OnDelete(DeleteBehavior.SetNull);
            });
        }
    }
}

