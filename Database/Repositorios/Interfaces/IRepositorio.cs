using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repositorios.Interfaces
{
    public interface IRepositorio<T>
    {
        void Gravar(T obj);

        List<T> BuscaTodos();

        void ApagaPorId(int id);

        T? BuscaPorId(int id);
    }
}
