using System;
using Description_House.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Description_House.Services.Apartments
{
    public interface IApartmentService
    {
        /// <summary>
        /// retourne la maison  modifier
        /// </summary>
        /// <returns></returns>
        Apartment Update();
    }
}
