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
using I4GUI;

namespace AGENT_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Agents _data = new Agents();
        public MainWindow()
        {
            InitializeComponent();

            Agent james = new Agent("007", "James Bond", "Spyville 20", "Seducing women", "Halle Barry");
            Agent simon = new Agent("8210", "Simon Vu", "DK", "Reading Chinese letters", "procrastination");
            _data.Add(james);
            _data.Add(simon);
            DataContext = _data;
        }

        private void Left_OnClick(object sender, RoutedEventArgs e)
        {
            if (AgentListBox.SelectedIndex > 0)
                AgentListBox.SelectedIndex--;
        }

        private void Right_OnClick(object sender, RoutedEventArgs e)
        {
            if (AgentListBox.SelectedIndex < AgentListBox.Items.Count - 1)
                AgentListBox.SelectedIndex++;
        }

        private void New_OnClick(object sender, RoutedEventArgs e)
        {
            _data.Add(new Agent());
        }
    }
}
