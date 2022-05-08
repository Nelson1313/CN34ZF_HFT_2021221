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

                    };
                    OnPropertyChanged();
                    (DeleteTeamCommand as RelayCommand).NotifyCanExecuteChanged();
                    (UpdateTeamCommand as RelayCommand).NotifyCanExecuteChanged();
                }
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
                    TeamId = SelectedTeam.TeamId,
                    TeamName = SelectedTeam.TeamName,
                    Manager = SelectedTeam.Manager,
                    Seat = SelectedTeam.Seat,
                    YearofFoundation = SelectedTeam.YearofFoundation,
                    LeagueId = SelectedTeam.LeagueId

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
