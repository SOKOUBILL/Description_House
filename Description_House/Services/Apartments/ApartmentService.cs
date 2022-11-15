using System;
using Description_House.Models;
using Description_House.Services.Houses;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Description_House.Services.Apartments
{
    public class ApartmentService :  HouseService<Apartment>, IApartmentService
    {
        bool isvalide;
        double surface;
        string name_House;
        string name_Door;
        string color;
        string name;



        /// <summary>
        /// retourne la maison  modifier
        /// </summary>
        /// <returns></returns>
        public Apartment Update()
        {
            Console.WriteLine(" Veiller renseigner les nouvelles informations de" +
                " l'appartement :");

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

            Apartment apartment = new Apartment(name_House, surface, door);

            return apartment;
        }





        //public Apartment Create()
        //{
        //    do
        //    {
        //        Console.WriteLine("Entrer le nom de la maison :");
        //        name_House = Console.ReadLine();
        //    } while (name_House == "");

        //    do
        //    {
        //        Console.WriteLine($"Entrer sa surface :");
        //        string value = Console.ReadLine();
        //        isvalide = double.TryParse(value, out surface);
        //    } while (isvalide == false);

        //    do
        //    {
        //        Console.WriteLine("Entrer le nom de sa porte :");
        //        name_Door = Console.ReadLine();
        //    } while (name_Door == "");
        //    do
        //    {
        //        Console.WriteLine("Entrer la  couleur de sa porte :");
        //        color = Console.ReadLine();
        //    } while (color == "");

        //    Door door = new Door(name_Door, color);
        //    door.Display();

        //    Apartment apartment = new Apartment(name_House, surface, door);
        //    apartment.Display();

        //    return apartment;
        //}



    }
}
