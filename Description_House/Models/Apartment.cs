using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Description_House.Models
{
    public class Apartment : House
    {
        public Apartment(string name_House, double surface,Door porte
            ) : base(name_House, surface=50,porte) { }
    }
}
