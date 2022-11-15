using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Description_House.Models
{
    public class House : Door
    {
        #region(properties)
        public string Name_House { get; set; }
        public double Surface { get; set; }
        public Door Porte { get; set; }
        public Person Person { get; set; }

        #endregion


        #region(constructor)
        public House() { }
        public House(string name_House, double surface, Door porte)
        {
            Name_House = name_House;
            Surface = surface;
            Porte = porte;
        }

        public House(string name_House, double surface, Door porte,Person person)
        {
            Name_House = name_House;
            Surface = surface;
            Porte = porte;
            Person = person;
        }

        public House(string name_House, double surface)
        {
            Name_House = name_House;
            Surface = surface;
        }

        #endregion



        #region(public methods)
        public void Display()
        {
            Console.WriteLine($" Je suis une maison, ma surface est de" +
                $"{Surface}m2");
        }

        public Door GetDoor()
        {
            return Porte;
        }
        #endregion
    }
}
