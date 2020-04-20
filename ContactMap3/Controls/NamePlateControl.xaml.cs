using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ContactMap3.Controls
{
    public partial class NamePlateControl : RelativeLayout
    {

        NamePlateControl control;
        public string Text
        {
            get
            {
                return GetValue(textProperty).ToString();
            }

            set
            {
                SetValue(textProperty, value);
            }
        }

        public string TextColor
        {
            get
            {
                return GetValue(colorProperty).ToString();
            }
            set
            {
                SetValue(textColorProperty, value);
            }
        }

        public string Size
        {
            get
            {
                return GetValue(sizeProperty).ToString();
            }

            set
            {
                SetValue(sizeProperty, value);
            }
        }

        public string BackColor
        {
            get
            {
                //string _color = GetValue(colorProperty).ToString();
                return GetValue(colorProperty).ToString();
            }

            set
            {
                Console.WriteLine($"Color prop setvalue called,{value}");
                SetValue(colorProperty, value);
            }
        }
        static double Radius { get; set; }
        static double FontSize { get; set; }
        public static readonly BindableProperty textProperty = BindableProperty.Create(
                                                            propertyName: "Text",
                                                            returnType: typeof(string),
                                                            declaringType: typeof(NamePlateControl),
                                                            defaultValue: "",
                                                            defaultBindingMode: BindingMode.TwoWay,
                                                            propertyChanged: TextPropertyChanged);
        

        public static readonly BindableProperty colorProperty = BindableProperty.Create(
                                                            propertyName: "BackColor",
                                                            returnType: typeof(string),
                                                            declaringType: typeof(NamePlateControl),
                                                            defaultValue: "#00000000",
                                                            defaultBindingMode: BindingMode.TwoWay,
                                                            propertyChanged: ColorPropertyChanged);

        public static readonly BindableProperty textColorProperty = BindableProperty.Create(
                                                            propertyName: "TextColor",
                                                            returnType: typeof(string),
                                                            declaringType: typeof(NamePlateControl),
                                                            defaultValue: "#FFFFFFFF",
                                                            defaultBindingMode: BindingMode.TwoWay,
                                                            propertyChanged: TextColorPropertyChanged);

        public static readonly BindableProperty sizeProperty = BindableProperty.Create(
                                                            propertyName: "Size",
                                                            returnType: typeof(string),
                                                            declaringType: typeof(NamePlateControl),
                                                            defaultValue: "",
                                                            defaultBindingMode: BindingMode.TwoWay,
                                                            propertyChanged: SizePropertyChanged);
        //propertyChanged: TextPropertyChanged);;;

        public NamePlateControl()
        {
            if (control == null)
            {
                control = this;
                InitializeComponent();
            }
        }

        public static string GetRandomHexColor()
        {
            int min = 256;
            int max = 512;
            int[] rgb = new int[3];
            Random rand = new Random();
            for (int i = 0; i < 3; i++)
            {
                int High = Math.Min(256, max);
                int Low = Math.Min(256 - min, High);
                rgb[i] = rand.Next(Low, High);
                min -= rgb[i];
                min = Math.Max(min, 0);
                max -= rgb[i];
                //Console.WriteLine($"Min: {Low}, Max: {High}, RGBA[{i}]: {rgb[i]}");
            }
            return $"#{rand.Next(150, 200):X}{rgb[0]:X}{rgb[1]:X}{rgb[2]:X}";
        }

        protected override void OnSizeAllocated(double width, double height)
        {

            double _size = 0;
            if (width > 0 && GetValue(sizeProperty).ToString() == "")
            {
                Console.WriteLine($"Width/Height:{width}/{height}, " +
                    $"Size: {Size}, Color: {BackColor}, " +
                    $"thisHash:{this.GetHashCode()}\n ColorDefault = {Color.FromHex("#FFFFFFFF")}");

                if (Size == null || Size == "")
                {
                    _size = Math.Min(width, height);
                }
                else
                {
                    try
                    {
                        _size = double.Parse(Size);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Error parsing string to double");
                    }
                }

                SetValue(sizeProperty, _size.ToString());
            }
            else if (width > 0)
            {
                _size = int.Parse(GetValue(sizeProperty).ToString());
                Radius = _size / 2;
                Console.WriteLine($"Radius: {Radius}");
                FontSize = Radius * 1.25;
                background.CornerRadius = Radius;
                initials.FontSize = FontSize;

                base.OnSizeAllocated(width, height);
            }
        }


        private static void TextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            //Console.WriteLine($"TextPropertyChangedMethod{newValue}");
            var control = (NamePlateControl)bindable;
            if (control.initials.Text != newValue.ToString())
            {
                control.initials.Text = newValue.ToString();
                control.OnPropertyChanged("Text");
            }
        }

        private static void ColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {

            var control = (NamePlateControl)bindable;
            string _hexColor = newValue.ToString();

            if ( _hexColor[0] != '#' || _hexColor == "Random")
            {
                _hexColor = GetRandomHexColor();
            }
            Console.WriteLine($"ColorPropertyChangedMethod: {_hexColor}");

            if (control.background.Color != Color.FromHex(_hexColor))
            {
                control.background.Color = Color.FromHex(_hexColor);
                control.SetValue(colorProperty, _hexColor);

                control.OnPropertyChanged("BackColor");

            }

        }

        private static void TextColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            Console.WriteLine($"TextColorPropertyChangedMethod{newValue}");
            var control = (NamePlateControl)bindable;
            if (control.initials.TextColor != Color.FromHex(newValue.ToString()))
            {
                control.initials.TextColor = Color.FromHex(newValue.ToString());
                control.OnPropertyChanged("TextColor");
            }
        }

        private static void SizePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            Console.WriteLine($"SizePropertyChangedMethod: {oldValue}/{newValue}");
            var control = (NamePlateControl)bindable;
            try
            {
                double v = double.Parse(newValue.ToString());

                if (v != control.background.Width)
                {
                    control.background.WidthRequest = v;
                    control.background.HeightRequest = v;
                    control.OnPropertyChanged("Size");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error Converting Size To Number, is Input Valid?  Input:{newValue}");

                control.background.WidthRequest = 16;
                control.background.HeightRequest = 16;
                control.OnPropertyChanged("Size");
            }
        }
    }


}
