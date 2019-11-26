using Crud.Classes;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace Crud
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        List<Film> films;
        public Window1(List<Film> films)
        {
            this.films = films;
            InitializeComponent();
        }

        public void Serialize(List<Film> films)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Classes.Film>));
            using (FileStream fs = new FileStream("Films.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, films);
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (txtboxGenre != null && txtboxHour != null && txtboxId != null && txtboxMinute != null
                && txtboxName != null && calendar.SelectedDate != null)
            {
                float dur = int.Parse(txtboxHour.Text) + int.Parse(txtboxMinute.Text) / 100;

                films.Add(new Film(txtboxName.Text, txtboxGenre.Text, int.Parse(txtboxId.Text), dur, (DateTime)calendar.SelectedDate));

                this.Serialize(films);
                
            }
            else
            {
                MessageBox.Show("error");
                return;
            }
            this.Close();
        }
    }
}
