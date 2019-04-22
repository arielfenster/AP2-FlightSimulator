﻿using FlightSimulator.Model;
using FlightSimulator.Model.Interface;
using FlightSimulator.Views;
using FlightSimulator.Servers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;

namespace FlightSimulator.ViewModels
{
    internal class FlightBoardViewModel : BaseNotify
    {
        private FlightBoardModel model;

        public FlightBoardViewModel(FlightBoardModel model)
        {
            this.model = model;
            this.model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                this.NotifyPropertyChanged("VM_" + e.PropertyName);
            };
        }

        public double VM_Lon
        {
            get { return this.model.Lon; }
        }

        public double VM_Lat
        {
            get { return this.model.Lat; }
        }
        
        /*
        public double VM_Lon
        {
            get { return model.lon; }
            set
            {
                this.lon = value;
                this.NotifyPropertyChanged("Lon");
            }
        }

        public double VM_Lat
        {
            get { return this.lat; }
            set
            {
                this.lat = value;
                this.NotifyPropertyChanged("Lat");
            }
        }
        */
        #region Commands
        #region SettingsCommand
        private ICommand _settingsCommand;
        public ICommand SettingsCommand
        {
            get
            {
                return _settingsCommand ?? (_settingsCommand = new CommandHandler(() => this.OnSettings()));
            }
        }
        private void OnSettings()
        {
            SettingsWindow window = new SettingsWindow();
            window.ShowDialog();
        }
        #endregion

        #region ConnectCommand
        private ICommand _connectCommand;
        public ICommand ConnectCommand
        {
            get
            {
                return _connectCommand ?? (_connectCommand = new CommandHandler(() => this.OnConnect()));
            }
        }
        private void OnConnect()
        {
            ISettingsModel settings = new ApplicationSettingsModel();

            InfoServer infoServ = new InfoServer(this.model);
            infoServ.Connect(settings);
            CommandClient commandsServ = new CommandClient();
            commandsServ.Connect(settings);
        }
        #endregion
        #endregion
    }
}
