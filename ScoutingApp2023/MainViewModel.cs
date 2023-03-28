using Microsoft.Maui.Layouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoutingApp2023
{
    public class MainViewModel
    {
        public FlexDirection FlowDirection { get; set; }
        public Entry TeamNumberEntry;
        public Entry ScouterNameEntry;
        public Picker SidePicker;
        public Entry MatchNumberEntry;
        public VerticalStackLayout AutoStack;
        public VerticalStackLayout TeleopStack;
        public CheckBox AutoMobility;
        public CheckBox AutoDocked;
        public CheckBox AutoEngaged;
        public CheckBox TeleopParked;
        public CheckBox TeleopDocked;
        public CheckBox TeleopEngaged;

        public MainViewModel()
        {
            FlowDirection = FlexDirection.Row;
        }
    }
}
