using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week5.Esercitazione.Entities;

namespace Week5.Esercitazione.Repositories
{
    public interface IRepositoryStudente : IRepository<Studente>
    {

        //questa è la Irepository specifica dello studente ,dove potrò mettere i metodi specifici della classe studente

    }
}
