using System;
using Week5.Esercitazione.Repositories;

namespace Week5.Esercitazione
{
    class Program
    {
        static void Main(string[] args)
        {

            //Vedere tutti gli studenti del database    x
            //Registrare un esame per uno studente specifico
            //Mostrare gli esami di uno studente ordinati per votazione e per data”
            //Aggiungere un nuovo studente utilizzando la modalità disconnessa di ADO.NET     x

            //Requisiti Tecnici:
            //•	Usare la tecnologia ADO.NET
            //•	Utilizzare opportunamente il Repository Pattern
            //•	Realizzare le interrogazioni attraverso System.Linq in modalità Lambda Expression

            //Opzionale: Gestire l’interazione con l’utente con un menù.

            //     1)Vedere gli studenti nel DB

            //IRepositoryStudente repoStud = new RepositoryStudente();
            //foreach(var stud in repoStud.GetAll())
            //{
            //    Console.WriteLine($"Studente: Nome {stud.Nome} - Cognome {stud.Cognome} - Anno di Nascita {stud.AnnoNascita}");
            //}

            //     2)vedere gli esami per uno specifico studente

            //IRepositoryEsame repoEs = new RepositoryEsame();
            //Console.WriteLine("scegli l'id dello studente");
            //int idstudente = Int32.Parse(Console.ReadLine());
            //repoEs.GetById(idstudente);
            
            ///{
            //foreach (var es in repoEs.GetById(idstudente))
            //{
            //    string passato = (es.Passato == 1) ? "si" : "no";
            //    Console.WriteLine($"Esame: Nome {es.Nome} - Cfu {es.Cfu} - Data Esame {es.DataEsame} -" +
            //        $"Votazione {es.Votazione} - Passato {passato}");
            //}
             
            //      3) inserisci uno studente
            //Console.WriteLine("inserisci nome,cognome e anno di nascita dello studente");
            //string nome = Console.ReadLine();
            //string cognome = Console.ReadLine();
            //int annoNascita = Convert.ToInt32(Console.ReadLine());
            //RepositoryStudente.InsertStudente(nome,cognome,annoNascita);

            //mostrare esami di uno studente specifico ordinati per valutazione e data

        }
    }
}
