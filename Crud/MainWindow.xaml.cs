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
using System.Xml.Serialization;
using System.IO;
using Crud.Classes;

namespace Crud
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Film> films = new List<Film>();
        public MainWindow()
        {
            InitializeComponent();
            //if(!File.Exists("Films.xml"))
            //{
            //    XmlSerializer formatter = new XmlSerializer(typeof(List<Classes.Film>));
            //    using (FileStream fs = new FileStream("Films.xml", FileMode.OpenOrCreate))
            //    {
            //        List<Film> films = new List<Film> {
            //            new Film()
            //        };
            //        formatter.Serialize(fs,films);
            //        dgFilms.ItemsSource = films;
            //    }
            //}
        }

        private void BtnRead_Click(object sender, RoutedEventArgs e)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Classes.Film>));
            using (FileStream fs = new FileStream("Films.xml", FileMode.Open))
            {
                films = (List<Film>)formatter.Deserialize(fs);
                dgFilms.ItemsSource = films;
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Window1 window = new Window1(films);
            window.Show();

            
        }

        

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        public void Serialize()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Classes.Film>));
            using (FileStream fs = new FileStream("Films.xml", FileMode.Create))
            {
                formatter.Serialize(fs, films);
            }
        }

        private void DgFilms_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {

        }

        private void BtnRemove_Click(object sender, RoutedEventArgs e)
        {
       
            films.Remove((Film)dgFilms.SelectedItem);

            dgFilms.ItemsSource = null;
            dgFilms.ItemsSource = films;

            Serialize();

        }
    }
}
