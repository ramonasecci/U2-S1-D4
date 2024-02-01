namespace Login
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool end = false;
            while (!end)
            {
                Console.WriteLine("****OPERAZIONI DISPONIBILI****");
                Console.WriteLine("1--LOGIN");
                Console.WriteLine("2--LOGOUT");
                Console.WriteLine("3--ACCESSO DATA E ORA");
                Console.WriteLine("4--LISTA DI ACCESSI");
                Console.WriteLine("5--ESCI");

                Console.Write("Scegli l'opzione: ");
                string option = Console.ReadLine();
                Console.Clear();
                switch (option)
                {
                    case "1":
                        User.Login();
                        break;

                    case "2":
                        User.Logout();
                        break;


                    case "3":
                        User.VerificaDataLogin();
                        break;

                    case "4":
                        User.MostraAccessi();
                        break;

                    case "5":
                        end = true; //anche in questo modo il ciclo si interrompe 
                        break;


                    default:
                        Console.WriteLine("Non ci sono altre operazioni disponibili");
                        break;
                }
            }
        }

    }

    static public class User
    {
        public static string username;
        public static string password;
        public static bool logged;
        public static List<DateTime> accessi = new List<DateTime>();

        public static int counter = 0;

        public static void Login()
        {

            Console.WriteLine("Inserisci username");
            username = Console.ReadLine();

            Console.WriteLine("Inserisci password");
            password = Console.ReadLine();

            //verifica password 

            Console.WriteLine("Inserisci conferma password");
            string passwordConf = Console.ReadLine();

            if (password == passwordConf)
            {
                logged = true;
                accessi.Add(DateTime.Now);
                counter++;
            }
            else
            {
                Console.WriteLine("Devi scrivere le stesse password!!!Una dietro l'altra!!!!");
                return;
            }
        }

        public static void Logout()
        {
            if (logged)
            {
                username = "";
                password = "";
                logged = false;
                Console.WriteLine("Logout andato a buon fine");
            }
            else
            {
                Console.WriteLine("Per poter effettuare il logout defi fare il login");
                return;
            }

        }

        public static void VerificaDataLogin()
        {
            if (logged)
            {
                Console.WriteLine($"Hai effettuato il login: {accessi[counter - 1]}");
            }
            else
            {
                Console.WriteLine("Per poter verificare il tuo ultimo accesso");
                return;
            }
        }

        public static void MostraAccessi()
        {
            if (logged == true)
            {
                foreach (var data in accessi)
                {
                    Console.WriteLine(data);
                }
            }
            else
            {
                Console.WriteLine("Non sei loggato");
                return;
            }
        }




    }




}
