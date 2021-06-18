using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week5.Esercitazione.Entities;

namespace Week5.Esercitazione.Repositories
{
    public class RepositoryStudente : IRepositoryStudente
    {

        const string connectionString = @"Server = .\SQLEXPRESS; Persist Security Info = False; 
                Integrated Security = true; Initial Catalog = RegistrazioneEsami;";   //è la connection string che mi permette di collegarmi al DB Esami
        public static void InsertStudente(string nome,string cognome,int annoNascita)
        {
            //DISCONNECTED MODE
            //creo connessione
           using(SqlConnection conn = new SqlConnection(connectionString))
            {
                //creo adapter
                SqlDataAdapter adapter = new SqlDataAdapter();
                //creo i comandi : SELECT + INSERT
                SqlCommand selectCommand = new SqlCommand()
                {
                    Connection = conn,
                    CommandType = System.Data.CommandType.Text,
                    CommandText = "select* from studente"
                };
                SqlCommand insertCommand = new SqlCommand()
                {
                    Connection = conn,
                    CommandType = System.Data.CommandType.Text,
                    CommandText = "insert into Studente values (@Nome, @Cognome, @AnnoNascita)"
                };
                //assegno i parametri al command
                insertCommand.Parameters.Add("@Nome", SqlDbType.NVarChar, 255, "Nome");
                insertCommand.Parameters.Add("@Cognome", SqlDbType.NVarChar, 255, "Cognome");
                insertCommand.Parameters.Add("@AnnoNascita", SqlDbType.Int, 55, "AnnoNascita");
                

                //associo comando con adapter
                adapter.SelectCommand = selectCommand;
                adapter.InsertCommand = insertCommand;

                //creo DATASET
                DataSet dataSet = new DataSet();

                //APRO la connessione!!!faccio anche try catch perchè potrei intercorrere in errori
                try
                {
                    conn.Open();
                    //faccio il fill! l'adapter è il mio ponte tra db e la tabella del dataset(che ho in locale)
                    //prima guardo la tabella, poi la modifico!
                    adapter.Fill(dataSet, "Studente");
                    DataRow studente = dataSet.Tables["Studente"].NewRow();  //creo un nuovo record nella mia tabella del dataset
                    studente["Nome"] = nome;
                    studente["Cognome"] = cognome;
                    studente["AnnoNascita"] = annoNascita;

                    //aggiungo il record(il mio nuovo studente)
                    dataSet.Tables["Studente"].Rows.Add(studente);
                    //ricongiungo i miei dati col db!
                    adapter.Update(dataSet, "Studente");

                    Console.WriteLine("inserimento avvenuto!");



                }
                catch(SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                   
                }



            }

            

        }

        public bool Add(Studente item)
        {
            throw new NotImplementedException();
        }

        public IList<Studente> GetAll()
        {
            IList<Studente> studenti = new List<Studente>();
            //creo la connessione
            using(SqlConnection conn = new SqlConnection(connectionString))   //installo il pacchetto system.data.sqlclient
            {
                try
                {
                    conn.Open();

                    //creo il comando
                    SqlCommand command = new SqlCommand()
                    {
                        Connection = conn,
                        CommandType = System.Data.CommandType.Text,
                        CommandText = "select* from studente"  //indico la query che mi serve! in questo caso una select*
                    };
                    //eseguo il comando
                    SqlDataReader reader = command.ExecuteReader();
                    while(reader.Read())
                    {
                        Studente studDaInserire = new Studente()
                        {
                            Nome = reader["Nome"].ToString(),
                            Cognome = reader["Cognome"].ToString(),
                            AnnoNascita = Int32.Parse(reader["AnnoNascita"].ToString())
                        };
                        studenti.Add(studDaInserire);
                    }




                }
                catch(SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }




            return studenti;
        }

        public Studente GetById(int value)
        {
            return GetAll().FirstOrDefault(s => s.ID == value);
        }
    }
}
