﻿using FlightSimulator.Servers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.ViewModels
{
    class ManualControlViewModel : BaseNotify
       
    {
        private CommandClient client;

        public ManualControlViewModel(CommandClient commandClient)
        {
            this.client = commandClient;
        }

        /// <commands>
        /// Set the value you get from the joy-stick to the simulator adress
        /// <commands>
        public float ThrottelChange
        {
            set
            {
                string command = "set controls/engines/current-engine/throttle ";
                command += value;
                command += "\r\n";//else the simulator woudnt do nothing
                client.WriteMsg(command);
                
            }
        }
        /// <commands>
        /// Set the value you get from the joy-stick to the simulator address
        /// <commands>
        public float RudderChanged
        {
            set
            {
                string command = "set /controls/flight/rudder ";
                command += value;
                command += "\r\n";//else the simulator woudnt do nothing
                client.WriteMsg(command);


            }
        }
        /// <commands>
        /// Set the value you get from the joy-stick to the simulator address
        /// <commands>
        public float ElevetorCommand
        {
            set
            {
                string command = " set /controls/flight/elevator ";
                command += value;
                command += "\r\n";//else the simulator woudnt do nothing
                client.WriteMsg(command);

            }
        }
        /// <commands
        /// Set the value you get from the joy-stick to the simulator address
        /// <commands>
        public float AilronCommand
        {
            set
            {
                string command = "set /controls/flight/aileron ";
                command += value;
                command += "\r\n"; //else the simulator wodnt do nothing
                client.WriteMsg(command);
            }
        }
    }
}
