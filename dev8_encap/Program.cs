using System.Diagnostics;

namespace dev8_encap
{
    internal class Program
    {

        //DECLARER(gauche de egale) = INITIALISER cree memoire
        static List<Admin> masterList = new List<Admin>();

        static void Main(string[] args)
        {
            Debug.WriteLine("PGM - lists classes");
            //STATIC ...THINKING GLOBAL VARIABLE!
            //BATIR 3 OBJETS
            Admin kyle = new Admin();//default
            Admin ben = new Admin("ben", "trois");
            Admin mbam = new Admin("bam", "password");

            //ajouter des items a la liste
            masterList.Add(mbam);
            masterList.Add(kyle);
            masterList.Add(ben);


            //Imprimer le nom de tous le monde dans la liste
            //NOTE - le champ(field) doit etre publique pour l'acceder!
            foreach (Admin u in masterList)
            {
                Debug.WriteLine(u._name);//_name is PUBLIC
            }

            //referencer le variable statique de la classe USER
            Debug.WriteLine("Il y a UNE CERTAINE MONTANT DE USERS");

            //Menu logic
            while (true)
            {
                Console.WriteLine("-----Choisir un operation-----\n" +
                    "A - ajouter\n" +
                    "D - delete (supprimer)\n" +
                    "U - Changer le nom\n" +
                    "Q - Quitter\n" +
                    "I - Imprimer la liste\n" +
                    "N - Nombre d'utilisateurs\n" +
                    "------------------------\n");
                Console.Write("Votre choix: ");

                char userChoice = char.ToUpper(Console.ReadKey().KeyChar);//GERER MINUSCULE

                if (userChoice == 'A')
                {
                    Console.Clear();
                    AddUser();
                }
                else if (userChoice == 'D')
                {
                    Console.Clear();
                    Console.WriteLine("Delete user\nEntrer le compte a enlever");
                    DeleteUser(Console.ReadLine());
                    PrintMasterList();
                }
                else if (userChoice == 'U')
                {
                    Console.Clear();
                    Console.WriteLine("Update user\nEntrer le compte a mettre a jour");
                    UserNameChange(Console.ReadLine());
                }
                else if (userChoice == 'Q')
                {
                    Console.Clear();
                    Console.WriteLine("Au revoir....\n\n");
                    Console.ReadLine();
                    break;
                }
                else if (userChoice == 'I')
                {
                    Console.Clear();
                    PrintMasterList();
                }
                else if (userChoice == 'N')
                {
                    Console.Clear();
                    Console.WriteLine("\n\nIl y a X" + " users au present\n");
                }
                else
                {
                    Console.WriteLine("RE ENTRER LA COMMANDE");
                }
            }//fin while


        }//end main



        //CREATE: METHODE: CREER UN UTILISATEUR
        public static void AddUser()
        {
            string name;
            string pass;
            Console.WriteLine("---Ajouter un utilisateur---");

            Console.WriteLine("Entrer le nom");
            name = Console.ReadLine();

            Console.WriteLine("Entrer le pass");
            pass = Console.ReadLine();


            Admin toAdd = new Admin(name, pass);

            masterList.Add(toAdd);

            Console.WriteLine(name + " est ajoute!\n");
            Console.WriteLine("Pese enter pour continuer");
            Console.ReadLine();
            Console.Clear();

        }

        //SEARCH: METHODE CHERCHE POUR UN UTILISATEUR PAR NOM, RETOURNE LE OBJET

        //assumer qu'il y a seulement 1 utilisateur
        public static Admin SearchUserByName(string tofind)
        {
            Admin found = null;

            foreach (Admin u in masterList)
            {
                if (u._name == tofind)
                {
                    found = u;//POINTER AU OBJET 
                    break;//ASSUMER QU'ON A DES OMS UTILSIATEUR UNIQUE
                }
            }

            if (found == null)
            {
                Console.WriteLine("Aucun utilisateur avec le nom:" + tofind + " trouver");
            }
            return found;

        }

        //UPDATE: METHODE POUR CHANGER LE NOM
        public static void UserNameChange(string toChange)
        {
            //TROUVE UTILISATEUR AVEC LE NOM toChange
            //todo - VERIFIE SI USER A FAIT UN LOGIN LA PROCHAINE FOIS

            Admin toUpdate = SearchUserByName(toChange);

            if (toUpdate != null)
            {
                Console.WriteLine("Utilisateur: " + toChange + " trouver");
                Console.WriteLine("Entrer le nouveau nom");

                //Change le nom
                toUpdate._name = Console.ReadLine();

                Console.WriteLine("Le nom " + toChange + " est maintenant " + toUpdate._name);
            }
            else
            {
                Console.WriteLine("Changement de nom pour " + toChange + " na PAS fonctionner");
            }


            Console.WriteLine("pese un cle pour continuer");
            Console.ReadLine();
            Console.Clear();

        }


        //DELETE: METHODE POUR SUPPRIMER

        public static bool DeleteUser(string toDelete)
        {
            Console.WriteLine("---Supprimer un utilisateur---");

            bool success = false;

            Admin dUser = SearchUserByName(toDelete);

            if (dUser != null)
            {
                masterList.Remove(dUser);
                success = true;
                Console.WriteLine("L'utilisateur " + toDelete + " est enlever\n");
                Console.WriteLine("Pese un cle pour continuer");
                Console.ReadLine();
                Console.Clear();
            }



            return success;
        }

        public static void PrintMasterList()
        {
            Console.WriteLine("\nImprimer Liste d'utilisateurs");
            foreach (Admin u in masterList)
            {
                Console.WriteLine(u._name);
            }
            Console.WriteLine("\n\n");
        }

    }//END OF THE CLASS


    //CLASSES EN GENERALE
    //MEMBER VARIABLES (FIELDS(CHAMPS), PROPERTIES)

    //CONSTRUCTOR METHODS(BLUEPRINT OF AN OBJECT)

    //HELPER METHODS

    //NEW CLASS - DEFINIR NOTRE NOUVEAU TYPE DE VARIBALE
    class Admin
    {
        //J'aimerais aussi compter le # d'utilisateurs


        //FIELDS /PROPERTIES / VARIABLES
        public string _name;//_ veut dire privee a l'object
        public string _pass;//private by defualt

        public double _acctBalance;

        //------CONSTRUCTORS
        //DEFAULT
        public Admin()
        {
            _name = "elyk";
            _pass = "retsnom";
        }

        //Nom et pass
        public Admin(string nom, string pass)
        {
            _name = nom;
            _pass = pass;
        }


    }













}