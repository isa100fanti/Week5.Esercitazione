using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5.Esercitazione.Repositories
{
    public interface IRepository<T>
    {
        //il repository mi serve per scrivere dei metodi generici e comuni a piu repository,cosi dovrò solo implementarli
        public IList<T> GetAll();
        public bool Add(T item);
        public T GetById(int value);


    }
}
