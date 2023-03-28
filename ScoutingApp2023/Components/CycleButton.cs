using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoutingApp2023.Components
{
    public class CycleButton : ImageButton
    {
        public static readonly BindableProperty StateProperty = BindableProperty.CreateAttached("StateProperty", typeof(BaseState), typeof(ImageButton), BaseState.None);
        public BaseState State
        {
            get => (BaseState)GetValue(StateProperty);
            set
            {
                SetValue(StateProperty, value);
                UpdateImage();
            }
        }
        public CycleButton() : base()
        {
            WidthRequest = 55;
            HeightRequest = 55;
            State = BaseState.None;
            Loaded += (sender, e) => UpdateImage();
            Clicked += UpdateState;
        }

        private void UpdateImage()
        {
            switch (State)
            {
                case BaseState.None:
                    Source = "cube_cone_cycle_none.png";
                    break;
                case BaseState.Cube:
                    Source = "cube_cone_cycle_cube.png";
                    break;
                case BaseState.Cone:
                    Source = "cube_cone_cycle_cone.png";
                    break;
            }
        }

        private void UpdateState(object sender, EventArgs e)
        {
            if (State == BaseState.Cone)
            {
                State = BaseState.None;
            }
            else
            {
                State++;
            }
        }
    }
}
