using CN34ZF_HFT_2021221.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CN34ZF_HFT_2021221.WPFClient
{
    public class MainWindowViewModel : ObservableRecipient
    {
        public RestCollection<Team> Teams { get; set; }

        private Team selectedTeam;

        public Team SelectedTeam
        {
            get { return selectedTeam; }
            set
            {
                selectedTeam = new Team()
                { 
                    League = value.League,
                    LeagueId = value.LeagueId,
                    TeamName = value.TeamName,
                    TeamId = value.TeamId,
                    Manager = value.Manager,
                    Seat = value.Seat,
                    YearofFoundation = value.YearofFoundation
                };
                OnPropertyChanged();
                (DeleteTeamCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        public ICommand CreateTeamCommand { get; set; }
        public ICommand DeleteTeamCommand { get; set; }
        public ICommand UpdateTeamCommand { get; set; }

        public MainWindowViewModel()
        {
            Teams = new RestCollection<Team>("http://localhost:56403/", "team", "hub");
            CreateTeamCommand = new RelayCommand(() =>
            {
                Teams.Add(new Team()
                {
                    TeamName = SelectedTeam.TeamName
                });
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
            SelectedTeam = new Team();
        }
    }
}
