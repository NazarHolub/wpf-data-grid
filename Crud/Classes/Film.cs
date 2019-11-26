using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Crud.Classes
{
    [Serializable]
    public class Film
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Genre  { get; set; }

        public float Duration { get; set; }

        public DateTime Date { get; set; }

        public Film()
        {

        }

        public Film(string name,string genre,int id,float dur,DateTime date)
        {
            Name = name;
            Genre = genre;
            Duration = dur;
            Id = id;
            Date = date;
        }
    }
}
