using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week5.Esercitazione.Entities;

namespace Week5.Esercitazione.Repositories
{
    public interface IRepositoryEsame : IRepository<Esame>
    {
        //questa è la Irepository specifica dell'esame,dove potrò mettere i metodi specifici della classe esame
        public IList<Esame> OrdinatiVotazioneData(int idStud);
        
    }
}
