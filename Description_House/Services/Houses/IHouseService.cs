using System;
using Description_House.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Description_House.Services.Houses
{
    public interface IHouseService<T> 
    {
        /// <summary>
        /// retourne la maison  modifier
        /// </summary>
        /// <returns></returns>
        House Update();

        /// <summary>
        /// Ajouter une donnee et retourne la donnee ajoute
        /// </summary>
        /// <returns></returns>
        T Add(T data);

        /// <summary>
        /// Modifie les proprites d'une donnee et retourne la nouvelle
        /// donnee
        /// </summary>
        /// <returns></returns>
        T Update(string name, T data);

        /// <summary>
        /// supprime une donnee et return true si elle a ete supprime 
        /// et false dans le cas ccontraire
        /// </summary>
        /// <returns></returns>
        bool Delete(string name);

        /// <summary>
        /// retourne la liste des donnees
        /// (les appartments d'une personne)
        /// </summary>
        /// <returns></returns>
        public ICollection<T> GetAll(int? skip = null, int? take = null);

    }
}
