using CN34ZF_HFT_2021221.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System.Windows.Input;

namespace CN34ZF_HFT_2021221.WPFClient
{
    public class MainWindowViewModel : ObservableRecipient
    {
        public RestCollection<Country> Countries { get; set; }
        public RestCollection<League> Leagues { get; set; }
        public RestCollection<Team> Teams { get; set; }

        private Country selectedCountry;
        private League selectedLeague;
        private Team selectedTeam;

        public Country SelectedCountry
        {
            get { return selectedCountry; }
            set
            {
                if (value != null)
                {
                    selectedCountry = new Country()
                    {
                        CountryId = value.CountryId,
                        CountryName = value.CountryName,
                        Area = value.Area,
                        Language = value.Language,
                        Population = value.Population,
                        Leagues = value.Leagues,
                    };
                    OnPropertyChanged();
                    (DeleteCountryCommand as RelayCommand).NotifyCanExecuteChanged();
                    (UpdateCountryCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public League SelectedLeague
        {
            get { return selectedLeague; }
            set
            {
                if (value != null)
                {
                    selectedLeague = new League()
                    {
                        LeagueId = value.LeagueId,
                        LeagueName = value.LeagueName,
                        LeagueRanking = value.LeagueRanking,
                        NumberofTeams = value.NumberofTeams,
                        CountryId = value.CountryId,
                        Teams = value.Teams,
                        Country = value.Country
                    };
                    OnPropertyChanged();
                    (DeleteLeagueCommand as RelayCommand).NotifyCanExecuteChanged();
                    (UpdateLeagueCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public Team SelectedTeam
        {
            get { return selectedTeam; }
            set
            {
                if (value != null)
                {
                    selectedTeam = new Team()
                    {
                        TeamId = value.TeamId,
                        TeamName = value.TeamName,
                        Manager = value.Manager,
                        Seat = value.Seat,
                        YearofFoundation = value.YearofFoundation,
                        LeagueId = value.LeagueId,
                        League = value.League
                    };
                    OnPropertyChanged();
                    (DeleteTeamCommand as RelayCommand).NotifyCanExecuteChanged();
                    (UpdateTeamCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand CreateCountryCommand { get; set; }
        public ICommand DeleteCountryCommand { get; set; }
        public ICommand UpdateCountryCommand { get; set; }
        public ICommand CreateLeagueCommand { get; set; }
        public ICommand DeleteLeagueCommand { get; set; }
        public ICommand UpdateLeagueCommand { get; set; }
        public ICommand CreateTeamCommand { get; set; }
        public ICommand DeleteTeamCommand { get; set; }
        public ICommand UpdateTeamCommand { get; set; }

        public MainWindowViewModel()
        {

            Countries = new RestCollection<Country>("http://localhost:56403/", "country");
            CreateCountryCommand = new RelayCommand(() =>
            {
                if (SelectedCountry != null)
                {
                    Countries.Add(new Country()
                    {
                        CountryName = SelectedCountry.CountryName,
                        Area = SelectedCountry.Area,
                        Language = SelectedCountry.Language,
                        Population = SelectedCountry.Population,
                        Leagues = SelectedCountry.Leagues,
                    });
                } else
                {
                    Countries.Add(new Country() { CountryName="Enter country name here: "});
                }
                    
            });

            UpdateCountryCommand = new RelayCommand(() =>
            {
                Countries.Update(SelectedCountry);
            });

            DeleteCountryCommand = new RelayCommand(() =>
            {
                Countries.Delete(SelectedCountry.CountryId);
            },
            () =>
            {
                return SelectedCountry != null;
            });
            

            //

            Leagues = new RestCollection<League>("http://localhost:56403/", "league");
            CreateLeagueCommand = new RelayCommand(() =>
            {
                if (SelectedLeague != null)
                {
                    Leagues.Add(new League()
                    {
                        LeagueName = SelectedLeague.LeagueName,
                        LeagueRanking = SelectedLeague.LeagueRanking,
                        NumberofTeams = SelectedLeague.NumberofTeams,
                        CountryId = SelectedLeague.CountryId,
                        Teams = SelectedLeague.Teams,
                        Country = SelectedLeague.Country,
                    });
                } else
                {
                    Leagues.Add(new League() { CountryId=1 ,LeagueName = "Enter league name here: " });
                }
                
            });

            UpdateLeagueCommand = new RelayCommand(() =>
            {
                Leagues.Update(SelectedLeague);
            });

            DeleteLeagueCommand = new RelayCommand(() =>
            {
                Leagues.Delete(SelectedLeague.LeagueId);
            },
            () =>
            {
                return SelectedLeague != null;
            });
            

            //

            Teams = new RestCollection<Team>("http://localhost:56403/", "team", "hub");
            CreateTeamCommand = new RelayCommand(() =>
            {
                if (SelectedTeam != null)
                {
                    Teams.Add(new Team()
                    {
                        TeamName = SelectedTeam.TeamName,
                        Manager = SelectedTeam.Manager,
                        Seat = SelectedTeam.Seat,
                        YearofFoundation = SelectedTeam.YearofFoundation,
                        LeagueId = SelectedTeam.LeagueId,
                        League = SelectedTeam.League
                    });
                } else
                {
                    Teams.Add(new Team() { LeagueId =1, TeamName = "Enter team name here: " });
                }    
                    
            });

            UpdateTeamCommand = new RelayCommand(() =>
            {
                Teams.Update(SelectedTeam);
            });

            DeleteTeamCommand = new RelayCommand(() =>
            {
                Teams.Delete(SelectedTeam.TeamId);
            },
            () =>
            {
                return SelectedTeam != null;
            });
        }
    }
}
