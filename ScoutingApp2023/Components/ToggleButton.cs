using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoutingApp2023.Components
{
    public class ToggleButton : ImageButton
    {
        public static readonly BindableProperty EnabledProperty = BindableProperty.CreateAttached(nameof(Enabled), typeof(bool), typeof(ToggleButton), false);
        public static readonly BindableProperty ButtonTypeProperty = BindableProperty.CreateAttached(nameof(ButtonType), typeof(string), typeof(ToggleButton), string.Empty);
        public ImageSource EnabledImage { get; set; }
        public ImageSource DisabledImage { get; set; }

        public bool Enabled
        {
            get => (bool)GetValue(EnabledProperty);
            set
            {
                SetValue(EnabledProperty, value);
                UpdateImage();
            }
        }

        public string ButtonType
        {
            get => (string)GetValue(ButtonTypeProperty);
            set
            {
                SetValue(ButtonTypeProperty, value);
                UpdateImage();
            }
        }

        public ToggleButton() : base()
        {
            WidthRequest = 55;
            HeightRequest = 55;
            Enabled = false;
            Loaded += (sender, e) => UpdateImage();
            Clicked += (sender, e) => Enabled = !Enabled;
        }

        private void UpdateImage()
        {
            Source = Enabled ? EnabledImage : DisabledImage;
        }
    }
}
