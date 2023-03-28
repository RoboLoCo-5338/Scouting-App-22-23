using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoutingApp2023.Components
{
    public class ConeButton : ToggleButton
    {
        public ConeButton() : base()
        {
            EnabledImage = "cone.png";
            DisabledImage = "graycone.png";
            ButtonType = "cone";
        }
    }
}
