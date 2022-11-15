using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Description_House.Models
{
    public class Person
    {
        #region(properties)
        public string Name { get; set; }
        public House? Maison { get; set; }
        #endregion

        #region(constructor)
        public Person() { }
        public Person(string name, House maison)
        {
            Name = name;
            Maison = maison;
        }

        public Person(string name)
        {
            Name = name;
        }
        #endregion

        #region(public methods)
        public void Display()
        {
            Console.WriteLine($" Mon nom est {Name}, ma maison a une superficie" +
                $" de {Maison.Surface}m2 et ma porte est de couleur " +
                $"{Maison.Porte.Color}");
        }
        #endregion
    }
}
