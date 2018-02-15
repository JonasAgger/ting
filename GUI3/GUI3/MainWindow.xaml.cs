using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUI3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Screen.KeyDown += MainWindow_Key_Down_Event;
        }

        private void CalcButton_OnClick(object sender, RoutedEventArgs e)
        {
            var boat = new Sailboat();

            boat.Name = NameTextBox.Text;
            boat.Length = Double.Parse(LengthTextBox.Text);

            SpeedLabel.Content = Math.Round(boat.Hullspeed(),2).ToString();
        }

        private void MainWindow_Key_Down_Event(object sender, RoutedEventArgs e)
        {
            if ((Keyboard.Modifiers & ModifierKeys.Control) != 0)
            {
                int modifier = 0;
                if (Keyboard.IsKeyDown(Key.L))
                {
                    modifier = 2;
                }
                else if (Keyboard.IsKeyDown(Key.S))
                {
                    modifier = -2;
                    if ((nameLabel.FontSize + modifier) == 0)
                        modifier = 0;
                }

                nameLabel.FontSize += modifier;
                lengthLabel.FontSize += modifier;
                feetLabel.FontSize += modifier;
                CalcButton.FontSize += modifier;
                hull.FontSize += modifier;
                SpeedLabel.FontSize += modifier;
                knots.FontSize += modifier;
            }
        }

        private void UIElement_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("The name of the ship is " + NameTextBox.Text);
        }
    }
}
