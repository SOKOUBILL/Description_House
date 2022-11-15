using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Description_House.Models
{
    public class Door
    {
        #region(properties)
        public string Name_Door { get; set; }
        public string Color { get; set; }
        #endregion

        #region(constructor)
        public Door() { }

        public Door(string name_Door, string color)
        {
            Name_Door = name_Door;
            Color = color;
        }
        #endregion


        #region(public methods)
        public void Display()
        {
            Console.WriteLine($" Je suis une porte, ma couleur est " +
                $"{Color}");
        }
        #endregion
    }
}
