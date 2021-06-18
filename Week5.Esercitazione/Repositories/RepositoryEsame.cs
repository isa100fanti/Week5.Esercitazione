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
    public class RepositoryEsame : IRepositoryEsame
    {
        const string connectionString = @"Server = .\SQLEXPRESS; Persist Security Info = False; 
                Integrated Security = true; Initial Catalog = RegistrazioneEsami;";
       
        IRepositoryStudente repoStud = new RepositoryStudente();


        public IList<Esame> GetAll()
        {
            IList<Esame> esami = new List<Esame>();
            //creo la connessione
            using (SqlConnection conn = new SqlConnection(connectionString))   //installo il pacchetto system.data.sqlclient - o lo importo e basta
            {
                //creo adapter
                SqlDataAdapter adapter = new SqlDataAdapter();
                    //creo il comando
                    SqlCommand command = new SqlCommand()
                    {
                        Connection = conn,
                        CommandType = System.Data.CommandType.Text,
                        CommandText = "select* from esame"  //indico la query che mi serve! in questo caso una select*
                    };

                //assegno comando
                adapter.SelectCommand = command;
                DataSet dataSet = new DataSet();
                try
                {
                    //apertura connessione
                    conn.Open();
                    adapter.Fill(dataSet, "Esame");
                    //ciclo il risultato del dataset: vado a prendere ogni risultato
                    foreach (DataRow row in dataSet.Tables["Esame"].Rows) //in ogni tabella ho una collezione di righe,voglio farmi stampare i record!
                    {
                        //per ogni riga creo l'oggetto esame
                        esami.Add(new Esame()
                        {

                            Nome = row["Nome"].ToString(),
                            Cfu = Int32.Parse(row["Cfu"].ToString()),
                            DataEsame = DateTime.Parse(row["DataEsame"].ToString()),
                            Votazione = Int32.Parse(row["Votazione"].ToString()),
                            Passato = Int32.Parse(row["Passato"].ToString()),
                            IDstudente = Int32.Parse(row["IdStudente"].ToString())
                            
                        });
                    }

                   

                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }




            return esami;

        }

        public Esame GetById(int value)
        {
            return GetAll().FirstOrDefault(e => e.ID == value);
        }

        public IList<Esame> OrdinatiVotazioneData(int idStud)
        {
           
           return GetAll().OrderBy(e => e.Votazione).ThenBy(e => e.DataEsame).ToArray();
            
             
        }
        public bool Add(Esame item)
        {
            return true; //non ho finito
        }

    }
}
