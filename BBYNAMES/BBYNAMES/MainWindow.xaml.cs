using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace BBYNAMES
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly List<BabyName> _babyNames = new List<BabyName>();
        private readonly List<Tuple<int, string>>[] _topNames = new List<Tuple<int, string>>[11];
        public MainWindow()
        {
            InitializeComponent();

            for (int i = 0; i < 11; i++)
            {
                _topNames[i] = new List<Tuple<int, string>>();
            }
            
        }

        public void LoadNames(object Object, RoutedEventArgs e)
        {
            string[] names = File.ReadAllLines("05-babynames.txt", Encoding.Default);
            
            foreach (var name in names)
            {
                var baby = new BabyName(name);

                for (int i = 0; i < 11; i++)
                {
                    if ((baby.Rank(1900+i*10) < 11) && (baby.Rank(1900 + i * 10) != 0))
                    {
                        //Debug.WriteLine("{0}, {1}", baby.Rank(1900 + i * 10), baby.Name);
                        var tup = Tuple.Create(baby.Rank(1900 + i * 10), baby.Name);
                        _topNames[i].Add(tup);
                    }
                }

                _babyNames.Add(baby);
            }

            for (int i = 1900; i < 2005; i += 10)
            {
                Decades.Items.Add(new ListBoxItem() { Content = i.ToString() });
            }
        }

        public void Item_Selected(object Object, RoutedEventArgs e)
        {
            //string curItem = Regex.Match(Decades.SelectedItem.ToString(), @"\d+").Value;
            
            ListBoxItem item = Decades.SelectedItem as ListBoxItem;

            int dec;

            if (item != null)
                dec = int.Parse(item.Content.ToString());
            else return;

            nameListBox.Items.Clear();

            WriteNamesToListBox(dec);

        }

        private void WriteNamesToListBox(int dec)
        {
            for (int i = 1; i < 11; i++)
            {
                List<string> namesToAdd = new List<string>();
                foreach (var name in _topNames[(dec - 1900) / 10])
                {
                    if (name.Item1 == i)
                        namesToAdd.Add(name.Item2);
                }
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("{0} {1} and {2}", i, namesToAdd[0], namesToAdd[1]);
                nameListBox.Items.Add(new ListBoxItem() {Content = sb.ToString()});
            }
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var name = SearchName.Text.ToLower();
            Rankings.Items.Clear();
            AvgRankBox.Text = "";
            TrendBox.Text = "";

            var baby = (from babby in _babyNames where babby.Name.ToLower() == name select babby).FirstOrDefault();

            //foreach (var baby in _babyNames)
            {
                if (baby != null)
                {
                    AvgRankBox.Text = baby.AverageRank().ToString();

                    var trend = baby.Trend();

                    if (trend < 0)
                        TrendBox.Text = "Less popular";
                    else if (trend == 0)
                        TrendBox.Text = "Equally popular";
                    else
                        TrendBox.Text = "More popular";

                    for (var i = 0; i < 11; i++)
                    {
                        var content = $"{(1900 + i * 10).ToString()} {baby.Rank(1900 + i * 10)}";
                        Rankings.Items.Add(new ListBoxItem() {Content = content});
                    }
                    
                }
            }
        }
    }
}
