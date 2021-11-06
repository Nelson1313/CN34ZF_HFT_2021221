using CN34ZF_HFT_2021221.Models;
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

            // Leagues
            League l1 = new League() { LeagueId = 1, LeagueName = "La Liga", CountryId = c1.CountryId, NumberofTeams = 20, LeagueRanking = 2 };
            League l2 = new League() { LeagueId = 2, LeagueName = "Serie A", CountryId = c2.CountryId, NumberofTeams = 20, LeagueRanking = 4 };
            League l3 = new League() { LeagueId = 3, LeagueName = "Premier League", CountryId = c3.CountryId, NumberofTeams = 20, LeagueRanking = 1 };

            c1.CountryId = l1.CountryId;
            c2.CountryId = l2.CountryId;
            c3.CountryId = l3.CountryId;

            // Teams
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

            // Serie A (CountryId: 2)
            Team t21 = new Team() { TeamId = 21, CountryId = l2.CountryId, TeamName = "Atalanta", YearofFoundation = 1907, Seat = "Gewiss Stadium", Manager = "Gian Piero Gasperini" };
            Team t22 = new Team() { TeamId = 22, CountryId = l2.CountryId, TeamName = "Bologna", YearofFoundation = 1909, Seat = "Stadio Renato Dall'Ara", Manager = "Siniša Mihajlović" };
            Team t23 = new Team() { TeamId = 23, CountryId = l2.CountryId, TeamName = "Cagliari", YearofFoundation = 1920, Seat = "Sardegna Arena", Manager = "Walter Mazzarri" };
            Team t24 = new Team() { TeamId = 24, CountryId = l2.CountryId, TeamName = "Empoli", YearofFoundation = 1920, Seat = "Stadio Carlo Castellani", Manager = "Aurelio Andreazzoli" };
            Team t25 = new Team() { TeamId = 25, CountryId = l2.CountryId, TeamName = "Fiorentina", YearofFoundation = 1926, Seat = "Stadio Artemio Franchi", Manager = "Vincenzo Italiano" };
            Team t26 = new Team() { TeamId = 26, CountryId = l2.CountryId, TeamName = "Genoa", YearofFoundation = 1893, Seat = "Stadio Luigi Ferraris", Manager = "Davide Ballardini" };
            Team t27 = new Team() { TeamId = 27, CountryId = l2.CountryId, TeamName = "Hellas Verona", YearofFoundation = 1903, Seat = "Stadio Marcantonio Bentegodi", Manager = "Igor Tudor" };
            Team t28 = new Team() { TeamId = 28, CountryId = l2.CountryId, TeamName = "Internazionale", YearofFoundation = 1908, Seat = "San Siro", Manager = "Simone Inzaghi" };
            Team t29 = new Team() { TeamId = 29, CountryId = l2.CountryId, TeamName = "Juventus", YearofFoundation = 1897, Seat = "Allianz Stadium", Manager = "Massimiliano Allegri" };
            Team t30 = new Team() { TeamId = 30, CountryId = l2.CountryId, TeamName = "Lazio", YearofFoundation = 1900, Seat = "Stadio Olimpico", Manager = "Maurizio Sarri" };
            Team t31 = new Team() { TeamId = 31, CountryId = l2.CountryId, TeamName = "Milan", YearofFoundation = 1899, Seat = "San Siro", Manager = "Stefano Pioli" };
            Team t32 = new Team() { TeamId = 32, CountryId = l2.CountryId, TeamName = "Napoli", YearofFoundation = 1926, Seat = "Stadio Diego Armando Maradona", Manager = "Luciano Spalletti" };
            Team t33 = new Team() { TeamId = 33, CountryId = l2.CountryId, TeamName = "Roma", YearofFoundation = 1927, Seat = "Stadio Olimpico", Manager = "José Mourinho" };
            Team t34 = new Team() { TeamId = 34, CountryId = l2.CountryId, TeamName = "Salernitana", YearofFoundation = 1919, Seat = "Stadio Arechi", Manager = "Fabrizio Castori" };
            Team t35 = new Team() { TeamId = 35, CountryId = l2.CountryId, TeamName = "Sampdoria", YearofFoundation = 1946, Seat = "Stadio Luigi Ferraris", Manager = "Roberto D'Aversa" };
            Team t36 = new Team() { TeamId = 36, CountryId = l2.CountryId, TeamName = "Sassuolo", YearofFoundation = 1920, Seat = "Mapei Stadium", Manager = "Alessio Dionisi" };
            Team t37 = new Team() { TeamId = 37, CountryId = l2.CountryId, TeamName = "Spezia", YearofFoundation = 1906, Seat = "Stadio Alberto Picco", Manager = "Thiago Motta" };
            Team t38 = new Team() { TeamId = 38, CountryId = l2.CountryId, TeamName = "Torino", YearofFoundation = 1906, Seat = "Stadio Olimpico Grande Torino", Manager = "Ivan Jurić" };
            Team t39 = new Team() { TeamId = 39, CountryId = l2.CountryId, TeamName = "Udinese", YearofFoundation = 1896, Seat = "Stadio Friuli", Manager = "Luca Gotti" };
            Team t40 = new Team() { TeamId = 40, CountryId = l2.CountryId, TeamName = "Venezia", YearofFoundation = 1907, Seat = "Stadio Pier Luigi Penzo", Manager = "Paolo Zanetti" };

            // Premier League (CountryId: 3)
            Team t41 = new Team() { TeamId = 41, CountryId = l3.CountryId, TeamName = "Arsenal", YearofFoundation = 1886, Seat = "Emirates Stadium", Manager = "Mikel Arteta" };
            Team t42 = new Team() { TeamId = 42, CountryId = l3.CountryId, TeamName = "Aston Villa", YearofFoundation = 1874, Seat = "Villa Park", Manager = "Dean Smith" };
            Team t43 = new Team() { TeamId = 43, CountryId = l3.CountryId, TeamName = "Brentford", YearofFoundation = 1889, Seat = "Brentford Community Stadium", Manager = "Thomas Frank" };
            Team t44 = new Team() { TeamId = 44, CountryId = l3.CountryId, TeamName = "Brighton & Hove Albion", YearofFoundation = 1901, Seat = "Falmer Stadium", Manager = "Graham Potter" };
            Team t45 = new Team() { TeamId = 45, CountryId = l3.CountryId, TeamName = "Burnley", YearofFoundation = 1882, Seat = "Turf Moor", Manager = "Sean Dyche" };
            Team t46 = new Team() { TeamId = 46, CountryId = l3.CountryId, TeamName = "Chelsea", YearofFoundation = 1905, Seat = "Stamford Bridge", Manager = "Thomas Tuchel" };
            Team t47 = new Team() { TeamId = 47, CountryId = l3.CountryId, TeamName = "Crystal Palace", YearofFoundation = 1905, Seat = "Selhurst Park", Manager = "Patrick Vieira" };
            Team t48 = new Team() { TeamId = 48, CountryId = l3.CountryId, TeamName = "Everton", YearofFoundation = 1878, Seat = "Goodison Park", Manager = "Rafael Benítez" };
            Team t49 = new Team() { TeamId = 49, CountryId = l3.CountryId, TeamName = "Leeds United", YearofFoundation = 1917, Seat = "Elland Road", Manager = "Marcelo Bielsa" };
            Team t50 = new Team() { TeamId = 50, CountryId = l3.CountryId, TeamName = "Leicester City", YearofFoundation = 1884, Seat = "King Power Stadium", Manager = "Brendan Rodgers" };
            Team t51 = new Team() { TeamId = 51, CountryId = l3.CountryId, TeamName = "Liverpool", YearofFoundation = 1892, Seat = "Anfield", Manager = "Jürgen Klopp" };
            Team t52 = new Team() { TeamId = 52, CountryId = l3.CountryId, TeamName = "Manchester City", YearofFoundation = 1880, Seat = "Etihad Stadium", Manager = "Pep Guardiola" };
            Team t53 = new Team() { TeamId = 53, CountryId = l3.CountryId, TeamName = "Manchester United", YearofFoundation = 1902, Seat = "Old Trafford", Manager = "Ole Gunnar Solskjær" };
            Team t54 = new Team() { TeamId = 54, CountryId = l3.CountryId, TeamName = "Newcastle United", YearofFoundation = 1892, Seat = "St James' Park", Manager = "Steve Bruce" };
            Team t55 = new Team() { TeamId = 55, CountryId = l3.CountryId, TeamName = "Norwich City", YearofFoundation = 1902, Seat = "Carrow Road", Manager = "Daniel Farke" };
            Team t56 = new Team() { TeamId = 56, CountryId = l3.CountryId, TeamName = "Southampton", YearofFoundation = 1885, Seat = "St Mary's Stadium", Manager = "Ralph Hasenhüttl" };
            Team t57 = new Team() { TeamId = 57, CountryId = l3.CountryId, TeamName = "Tottenham Hotspur", YearofFoundation = 1882, Seat = "Tottenham Hotspur Stadium", Manager = "Nuno Espírito Santo" };
            Team t58 = new Team() { TeamId = 58, CountryId = l3.CountryId, TeamName = "Watford", YearofFoundation = 1881, Seat = "Vicarage Road", Manager = "Claudio Ranieri" };
            Team t59 = new Team() { TeamId = 59, CountryId = l3.CountryId, TeamName = "West Ham United", YearofFoundation = 1900, Seat = "London Stadium", Manager = "David Moyes" };
            Team t60 = new Team() { TeamId = 60, CountryId = l3.CountryId, TeamName = "Wolverhampton Wanderers", YearofFoundation = 1877, Seat = "Molineux Stadium", Manager = "Bruno Lage" };


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

            modelBuilder.Entity<League>().HasData(l1, l2, l3);
            modelBuilder.Entity<Country>().HasData(c1, c2, c3);
            modelBuilder.Entity<Team>().HasData(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26, t27, t28, t29, t30,
                t31, t32, t33, t34, t35, t36, t37, t38, t39, t40, t41, t42, t43, t44, t45, t46, t47, t48, t49, t50, t51, t52, t53, t54, t55, t56, t57, t58, t59, t60);
        }
    }
}

