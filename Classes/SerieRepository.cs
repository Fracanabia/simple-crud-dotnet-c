using System.Collections.Generic;

namespace DIO.Series
{
  class SerieRepository : IRepository<Serie>
  {
    private List<Serie> series = new List<Serie>();
    public void SetUpdate(int id, Serie entity)
    {
      series[id] = entity;
    }

    public void SetInactive(int id)
    {
      series[id].SetInactive();
    }

    public void SetAdd(Serie entity)
    {
      series.Add(entity);
    }

    public List<Serie> GetAll()
    {
      return series;
    }

    public int GetNextId()
    {
      return series.Count;
    }

    public Serie GetById(int id)
    {
      return series[id];
    }
  }
}
