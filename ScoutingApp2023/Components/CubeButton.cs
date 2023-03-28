using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoutingApp2023.Components
{
    public class CubeButton : ToggleButton
    {
        public CubeButton() : base()
        {
            EnabledImage = "cube.png";
            DisabledImage = "graycube.png";
            ButtonType = "cube";
        }
    }
}
