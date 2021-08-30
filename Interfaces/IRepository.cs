using System.Collections.Generic;

namespace DIO.Series
{
  interface IRepository<T>
  {
    List<T> GetAll();
    T GetById(int id);
    void SetAdd(T entidade);
    void SetInactive(int id);
    void SetUpdate(int id, T entidade);
    int GetNextId();
  }
}
