using System;
using Description_House.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Description_House.Services.Houses
{
    public class HouseService<T> : IHouseService<T>
        where T : House
    {
        #region(properties)
        private string fileLocation;
        private List<T> list = new List<T>();
        #endregion

        #region(constructor)
        public HouseService(string storageDirectory)
        {
            var fileName = $"{typeof(T).Name}.json";

            fileLocation = Path.Combine(storageDirectory, fileName);
            FileStream fStream = null;
            if (!Directory.Exists(storageDirectory))
                Directory.CreateDirectory(storageDirectory);

            if (!File.Exists(fileLocation))
                fStream = File.Create(fileLocation);

            fStream?.Close();
            Deserialize();
        }

        public HouseService(string storageDirectory, string fileName)
        {
            fileLocation = Path.Combine(storageDirectory, fileName);
            FileStream fStream = null;
            if (!File.Exists(fileName))
                File.Create(fileName);
            if (!Directory.Exists(storageDirectory))
                Directory.CreateDirectory(storageDirectory);

            if (!File.Exists(fileLocation))
                fStream = File.Create(fileLocation);

            fStream?.Close();
            Deserialize();
        }

        public HouseService() { }

        #endregion

        #region(public methods)


        /// <summary>
        /// retourne la maison  modifier
        /// </summary>
        /// <returns></returns>
        public House Update()
        {
            bool isvalide;
            double surface;
            string name_House;
            string name_Door;
            string color;
            string name;

            Console.WriteLine(" Veiller renseigner les nouvelles informations de" +
                " la maison :");

            do
            {
                Console.WriteLine("Entrer le nom de l'appartement :");
                name_House = Console.ReadLine();
            } while (name_House == "");

            do
            {
                Console.WriteLine($"Entrer sa surface :");
                string value = Console.ReadLine();
                isvalide = double.TryParse(value, out surface);
            } while (isvalide == false);

            do
            {
                Console.WriteLine("Entrer le nom de sa porte :");
                name_Door = Console.ReadLine();
            } while (name_Door == "");
            do
            {
                Console.WriteLine("Entrer la  couleur de sa porte :");
                color = Console.ReadLine();
            } while (color == "");

            Door door = new Door(name_Door, color);

            House maison = new House(name_House, surface, door);

            return maison;
        }

        /// <summary>
        /// Ajouter une donnee et retourne la donnee ajoute
        /// </summary>
        /// <returns></returns>
        public T Add(T data)
        {
            if (data == null)
                throw new ArgumentNullException("data: is not reference as instance " +
                    "of an object");
            list.Add(data);
            Serialize();
            return data;
        }


        /// <summary>
        /// Modifie les proprites d'une donnee et retourne la nouvelle
        /// donnee
        /// </summary>
        /// <returns></returns>
        public T Update(string name, T data)
        {

            try
            {
                if (data == null)
                    throw new ArgumentNullException("data: is not reference as instance " +
                        "of an object");
                var result = list.FirstOrDefault(x => x.Name_House == name);
                if (result == null)
                    throw new ArgumentNullException("Entity not found");
                var index = list.IndexOf(result);
                list[index] = data;
                Serialize();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return data;
        }


        /// <summary>
        /// supprime une donnee et return true si elle a ete supprime 
        /// et false dans le cas ccontraire
        /// </summary>
        /// <returns></returns>
        public bool Delete(string name)
        {
            bool decision = false;
            try
            {
                var result = list.FirstOrDefault(x => x.Name_House == name);
                if (result == null)
                    throw new ArgumentNullException("Cette personne  n'existe " +
                        "pas !");
                decision = list.Remove(result);
                Serialize();

            }
            catch (Exception exception)
            {

                Console.WriteLine(exception.Message);
            }
            if (decision)
                return true;
            return false;
        }


        /// <summary>
        /// retourne la liste des donnees
        /// (les appartments d'une personne)
        /// </summary>
        /// <returns></returns>
        public ICollection<T> GetAll(int? skip = null, int? take = null) =>
            list.Skip(skip ?? 0).Take(take ?? list.Count).ToList();


        #endregion


        #region(private methods)

        private void Deserialize()
        {
            var json = File.ReadAllText(fileLocation);
            list = JsonConvert.DeserializeObject<List<T>>(json) ?? new List<T>();
        }
        private void Serialize()
        {
            try
            {
                var jsonData = JsonConvert.SerializeObject(list);
                File.WriteAllText(fileLocation, jsonData);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        #endregion
    }
}
