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
using ConsoleApp1;
using NetworkHelper;
using Newtonsoft;
using System.IO;
using System.Windows.Media.Animation;

namespace wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            List<Versenyzo> versenyzoTomb = Backend.GET("http://localhost:3000/versenyzoLeKerdez").Send().ToList<Versenyzo>();
            //MessageBox.Show(versenyzoTomb[0].nev);
            listboxversenyzo.ItemsSource = versenyzoTomb;
            listboxversenyzo.DisplayMemberPath = "nev";
            listboxversenyzo.SelectedIndex =0;

        }

        private void listboxversenyzo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lbnev.Content = (listboxversenyzo.SelectedItem as Versenyzo).nev;
            lborszag.Content = (listboxversenyzo.SelectedItem as Versenyzo).orszagId;
            lbpont.Content = (listboxversenyzo.SelectedItem as Versenyzo).pont;
            if ((listboxversenyzo.SelectedItem as Versenyzo).pont>700)
            {
                lbertekeles.Content = "magas";
            }
            else if ((listboxversenyzo.SelectedItem as Versenyzo).pont < 400)
            {
                lbertekeles.Content = "alacsony";
            }
            else lbertekeles.Content = "közepes";
        }

        private void tbosszeg_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void tbmegjegyzes_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btfelvitel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tbmegjegyzes.Text == "")
                {
                    lbhiba.Content = "Hiba, üres mező";
                    return;
                }
                else if (tbosszeg.Text == "")
                {
                    lbhiba.Content = "Hiba, üres mező";
                    return;
                }


                var adatok = new
                {
                    bevitel1 = (listboxversenyzo.SelectedItem as Versenyzo).id,
                    bevitel2 = Convert.ToInt32(tbosszeg.Text),
                    bevitel3 = tbmegjegyzes.Text
                };
                lbhiba.Content = Backend.POST("http://localhost:3000/dijazasFelvitel").Body(adatok).Send().Message;
            }
            catch
            {
                lbhiba.Content = "nem megfelelő formátum számot adj meg légyszives <3";
            }


        }
    }
}
