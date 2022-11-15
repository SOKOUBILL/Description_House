using System;
using Description_House.Models;
using Description_House.Services.Houses;
using Description_House.Services.Apartments;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Description_House
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string c;
            Console.WriteLine("\n\n Bonjour !!!!");
            do
            {
                
                Console.WriteLine(" appuyer sur entrer pour continuer !!!");
                c = Console.ReadLine();
                Console.Clear();
                Main();
            } while(c!= null);
            

            void Main()
            {
                bool isvalide;
                bool isvalide2;
                int choix;
                double surface;
                string name_House;
                string name_Door;
                string color;
                string mod;
                string name;
                string name_m;
                string value2;

                ApartmentService Aparts = new ApartmentService();
                HouseService<House> house = new HouseService<House>();




                #region(menu)

                Console.WriteLine("\n\n \t\t########################################################");

                Console.WriteLine("\n  \t\t\t\t =====MENU==== \n\n");
                Console.WriteLine(" \t\t\t1- Enregistrer une maison");
                Console.WriteLine(" \t\t\t2- Modifier une maison ");
                Console.WriteLine(" \t\t\t3- Suprimer une maison ");
                Console.WriteLine(" \t\t\t4- Afficher les maisons d'une " +
                    "personne ");
                
                do
                {
                    Console.Write(" Choisir une operation : ");
                    string value1 = Console.ReadLine();
                    isvalide2 = int.TryParse(value1, out choix);
                } while (isvalide2 == false);

                #endregion


                #region(choix)

                switch (choix)
                {


                    /// <summary>
                    /// creation d'une maison  
                    /// </summary>
                    /// <returns></returns>
                    case 1 :
                        Console.Clear();

                        Console.WriteLine(" ************CREATION D'UNE MAISON************");
                        do
                        {
                            Console.WriteLine(" Votre maison est un appartement ?" +
                                " (oui = o et non = n )");
                            value2 = Console.ReadLine();
                        } while (value2 != "o" && value2 != "n" );

                        do
                        {
                            Console.WriteLine(" -Entrer le nom de la maison :");
                            name_House = Console.ReadLine();
                        } while (name_House == "");

                        do
                        {
                            Console.WriteLine($" -Entrer sa surface :");
                            string value = Console.ReadLine();
                            isvalide = double.TryParse(value, out surface);
                        } while (isvalide == false);

                        do
                        {
                            Console.WriteLine(" -Entrer le nom de sa porte :");
                            name_Door = Console.ReadLine();
                        } while (name_Door == "");
                        do
                        {
                            Console.WriteLine(" -Entrer la  couleur de sa porte : \n");
                            color = Console.ReadLine();
                        } while (color == "");

                        Door door = new Door(name_Door, color);
                        door.Display();

                        if(value2 == "o")
                        {
                            Apartment apartment = new Apartment(name_House, surface, door);
                            apartment.Display();
                            do
                            {
                                Console.WriteLine("\n\n -Entrer le nom de la personne a" +
                                    " qui appartient l'appartement :");
                                name = Console.ReadLine();
                            } while (name == "");

                            Person person = new Person(name, apartment);
                            HouseService<House> hous = new HouseService<House>("Database"
                            , person.Name);

                            hous.Add(person.Maison);
                        }

                        else
                        {
                            House maisons = new House(name_House, surface, door);
                            maisons.Display();
                            do
                            {
                                Console.WriteLine("\n\n -Entrer le nom de la personne a" +
                                    " qui appartient l'appartement :");
                                name = Console.ReadLine();
                            } while (name == "");

                            Person person = new Person(name, maisons);
                            person.Display();

                            HouseService<House> hous = new HouseService<House>("Database"
                            , person.Name);

                            hous.Add(person.Maison);
                        }

                        break;


                    /// <summary>
                    /// modification d'une maison 
                    /// </summary>
                    /// <returns></returns>

                    case 2:

                        Console.Clear();

                        Console.WriteLine(" ************MODIFIER UNE MAISON************ ");

                        do
                        {
                            Console.WriteLine(" Veiller entrer le nom de la maison que vous voulez" +
                            " modifier ");
                            mod = Console.ReadLine();
                        } while (mod == "");

                        do
                        {
                            Console.WriteLine(" -Entrer le nom de la personne a" +
                                " qui appartient a la maison :");
                            name_m = Console.ReadLine();
                        } while (name_m == "");

                        do
                        {
                            Console.WriteLine(" Votre maison est un appartement ?" +
                                " (oui = o et non = n ");
                            value2 = Console.ReadLine();
                        } while (value2 != "o" && value2 != "n");

                        if (value2 == "o")
                        {
                            var maison = Aparts.Update();

                            Person person2 = new Person(name_m, maison);

                            person2.Display();

                            HouseService<House> hs = new HouseService<House>("Database"
                               , person2.Name);

                            hs.Update(name_m, maison);
                        }
                        else
                        {
                            var maison = house.Update();

                            Person person2 = new Person(name_m, maison);

                            person2.Display();

                            HouseService<House> hs = new HouseService<House>("Database"
                               , person2.Name);

                            hs.Update(name_m, maison);
                        }

                        break;



                    /// <summary>
                    /// Supprimer une maison 
                    /// </summary>
                    /// <returns></returns>
                    case 3:
                        Console.Clear();

                        string mods;
                        string name_s;

                        Console.WriteLine(" ************SUPPRIMER UNE MAISON************ ");
                        
                        do
                        {
                            Console.WriteLine(" Veiller entrer le nom de la maison que vous voulez" +
                            " supprimer ");
                            mods = Console.ReadLine();
                        } while (mods == "");

                        do
                        {
                            Console.WriteLine(" -Entrer le nom de la personne a" +
                                " qui appartient la maison :");
                            name_s = Console.ReadLine();
                        } while (name_s == "");

                        House m = new House();
                        Person person3 = new Person(name_s, m);

                        HouseService<House> house_delete = new HouseService<House>("Database"
                               , person3.Name);
                        house_delete.Delete(name_s);

                        break;


                    /// <summary>
                    /// Afficher les maisons d'une personne  
                    /// </summary>
                    /// <returns></returns>
                    case 4:
                        Console.Clear();

                        string name_a;
                        Console.WriteLine(" ************AFFICHER LES MAISONS D'UNE PERSONNE************ ");
                        do
                        {
                            Console.WriteLine(" -Entrer le nom de la personne a" +
                                " qui appartient a la maison :");
                            name_a = Console.ReadLine();
                        } while (name_a == "");

                        House house_A = new House();
                        Person person4 = new Person(name_a, house_A);

                        HouseService<House> house_Affiche = new HouseService<House>("Database"
                               , person4.Name);

                        var l = house_Affiche.GetAll();
                        List<House> liste = new List<House>();
                        liste = l.ToList();
                        int i = 1;

                        Console.WriteLine($"la liste des maisons de {name_a} est :");

                        foreach (House h in liste)
                        {
                            Console.WriteLine($"-la maison numero {i} s'appele {h.Name_House} " +
                                $"et elle est de couleur {h.Porte.Color}");
                            i++;
                        }

                        break;




                    default:

                        break;
                        
                        
                        

                }





                

                #endregion

            }
        }
        
        
    }
}
