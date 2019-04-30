using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace FavoriteArtists.DLA.Repos
{
    public interface IBaseRepo<T>
    {
        int GetNextId();
        T Create(T obj);
        T Update(T obj);
        List<T> GetAll();
        T GetById(int id);
        bool Delete(int id);
    }
}
