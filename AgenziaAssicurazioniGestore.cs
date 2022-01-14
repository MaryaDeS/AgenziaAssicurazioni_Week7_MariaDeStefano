using AgenziaAssicurazioni_Week7_MariaDeStefano.Models;
using AgenziaAssicurazioni_Week7_MariaDeStefano.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenziaAssicurazioni_Week7_MariaDeStefano
{
    internal static class AgenziaAssicurazioniGestore
    {
        static IRepositoryCliente repoCliente = new RepositoryCliente();
        static IRepositoryPolizza repoPolizza = new RepositoryPolizza();


        internal static void StartMenu()
        {
            char choice;

            do
            {
                Console.WriteLine("Benvenuto, scegli un'opzione" +
                    "\n[1] Inserisci un nuovo Cliente" +
                    "\n[2] Inserisci una nuova polizza" +
                    "\n[3] Stampa tutte le polizza assicurative in DB e relative info" +
                    "\n[Q] Esci");

                //recupero la scelta dell'utente
                Console.WriteLine("La tua scelta è: ");
                choice = Console.ReadKey().KeyChar;

                switch (choice)
                {
                    case '1':
                        AggiungiCliente();
                        break;
                    case '2':
                        AggiungiPolizza();
                        break;
                    case '3':
                        StampaDatiDatabase();
                        break;
                    case 'Q':
                        break;
                    default:
                        Console.WriteLine("La tua scelta non è valida");
                        break;
                }
            } while (choice != 'Q');
        }

        private static void StampaDatiDatabase()
        {
            char choice1;
            do
            {
                Console.WriteLine("Sei sicuro di voler stampare le polizze?+" +
                        "\n[P] Premi P per conoscere le Polizze" +
                        "\n[O] Premi O per uscire");
                choice1 = Console.ReadKey().KeyChar;
            } while (choice1 != 'O');

            if (choice1 == 'P')
            {
                var polizze = repoPolizza.GetAll();
                StampaCollection<Polizza>(polizze);

            }
            else
            {
                Console.WriteLine("Ciao");
            }
        }

        private static void StampaCollection<T>(ICollection<T> collection) where T : class
        {
            if (collection.Count == 0)
            {
                Console.WriteLine("Lista Vuota");
                return;
            }
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }

        private static void AggiungiPolizza()
        {
            Polizza polizzaDaAggiungere = new Polizza();

            Console.WriteLine("\nInserisci il numero");
            int numero = int.Parse(Console.ReadLine());

            Console.WriteLine("\nInserisci data: ");
            DateTime dateTime = DateTime.Now;
            if (dateTime.Year != DateTime.Now.Year)
            {
                Console.WriteLine("L'anno inserito non è corretto");
            }

            else
            {
                Console.WriteLine("L'anno è corretto continua il tuo inserimento polizza");
            }

            Console.WriteLine("\nInserisci l'importo: ");
            float importo;
            bool verificaImporto = float.TryParse(Console.ReadLine(), out importo);
            while (!verificaImporto || importo < 0)
            {
                verificaImporto = float.TryParse(Console.ReadLine(), out importo);
            }

            Console.WriteLine("\nInserisci Rata mensile: ");
            float rataMensile;
            bool verificarataMensile = float.TryParse(Console.ReadLine(), out rataMensile);
            while (!verificarataMensile || rataMensile < 0)
            {
                verificarataMensile = float.TryParse(Console.ReadLine(), out rataMensile);
            }


            Console.WriteLine("\nScegli il tipo di polizza che vuoi inserire:" +
                "\n 1-RCAuto" +
                "\n 2-Furto" +
                "\n 3-Vita");
            int tipoPolizza;
            bool verifica = Int32.TryParse(Console.ReadLine(), out tipoPolizza);
            while (tipoPolizza > 4 || tipoPolizza < 0 || verifica == false)
            {
                Console.WriteLine("Inserisci un valore corretto");
                verifica = Int32.TryParse(Console.ReadLine(), out tipoPolizza);
            }

            if (tipoPolizza == 1)
            {
                Console.WriteLine("\nIserisci targa veicolo: ");
                string targa = VerificaTarga();
                int cilindrata = VerificaCilindrata();

                polizzaDaAggiungere = new RCAuto()
                {
                    NumeroPolizza = numero,
                    DataStipula = dateTime,
                    ImportoAssicurazione = importo,
                    RataMensile = rataMensile,
                    Targa = targa,
                    Cilindrata = cilindrata
                };
            }
            else if (tipoPolizza == 2)
            {
                Console.WriteLine("\n Inserisci Percentuale coperta: ");
                int percentuale = Int32.Parse(Console.ReadLine());
                polizzaDaAggiungere = new Furto()
                {
                    NumeroPolizza = numero,
                    DataStipula = dateTime,
                    ImportoAssicurazione = importo,
                    RataMensile = rataMensile,
                    PercentualeCopertura = percentuale

                };
            }
            else if (tipoPolizza == 3)
            {
                Console.WriteLine("\n Inserisci Anni:");
                int numeroAnni = Int32.Parse(Console.ReadLine());
                polizzaDaAggiungere = new Vita()
                {

                    NumeroPolizza = numero,
                    DataStipula = dateTime,
                    ImportoAssicurazione = importo,
                    RataMensile = rataMensile,
                    AnniAssicurato = numeroAnni


                };
            }
            repoPolizza.Create(polizzaDaAggiungere);
            Console.WriteLine("Polizza Aggiunta");

            var polizzaEsistente = repoPolizza.GetByNumero(numero);
            if (polizzaEsistente == null)
            {
                Console.WriteLine("Questa Polizza non esiste");
            }
            else
            {

            }
        }

        private static int VerificaCilindrata()
        {
            throw new NotImplementedException();
        }

        private static string VerificaTarga()
        {
            throw new NotImplementedException();
        }

        private static void AggiungiCliente()
        {

            string codice;
            do
            {
                Console.WriteLine("\nInserisci codice fiscale cliente:");
                codice = Console.ReadLine();
            } while (!((!string.IsNullOrWhiteSpace(codice)) && codice.Length == 16));

            string nome;
            do
            {
                Console.WriteLine("\nInserisci il nome:");
                nome = Console.ReadLine();
            }while (!((!string.IsNullOrWhiteSpace(nome)) && nome.Length >1));

            string cognome;
            do
            {
                Console.WriteLine("\nInserisci il cognome:");
                cognome = Console.ReadLine();
            } while (!((!string.IsNullOrWhiteSpace(nome)) && nome.Length > 1)) ;

            string indirizzo;
            do
            {
                Console.WriteLine("\nInserisci l'indirizzo:");
                indirizzo = Console.ReadLine();
            } while (!((!string.IsNullOrWhiteSpace(indirizzo)) && indirizzo.Length > 1));

            var clienti = repoCliente.GetAll();
            foreach (var item in clienti)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nScegli il tipo di polizza:");
            int tipoPolizza=int.Parse(Console.ReadLine());
            var polEsistente=repoPolizza.GetByNumero(tipoPolizza);
            if (repoPolizza==null)
            {
                Console.WriteLine("Tipo di Polizza inesistente");
            }
            else
            {
                Cliente cliente = new Cliente()
                {
                    CodiceFiscale = codice,
                    Nome = nome,
                    Cognome = cognome,
                    Indirizzo = indirizzo
                };

                repoCliente.Create(cliente);
                Console.WriteLine("Cliente Aggiunto");
            }

        }
    }
    
}
