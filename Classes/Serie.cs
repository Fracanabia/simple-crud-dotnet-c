using System;

namespace DIO.Series
{
  class Serie : EntityBase
  {
    private Genero Genero { get; set; }
    private string Titulo { get; set; }
    private string Descricao { get; set; }
    private int Ano { get; set; }
    private bool Inactive { get; set; }

    public Serie(int id, Genero genero, string titulo, string descricao, int ano)
    {
      this.Id = id;
      this.Genero = genero;
      this.Titulo = titulo;
      this.Descricao = descricao;
      this.Ano = ano;
      this.Inactive = false;
    }

    public override string ToString()
    {
      string retorno = "";
      retorno += "Gênero: " + this.Genero + Environment.NewLine;
      retorno += "Titulo: " + this.Titulo + Environment.NewLine;
      retorno += "Descrição: " + this.Descricao + Environment.NewLine;
      retorno += "Ano de Início: " + this.Ano + Environment.NewLine;
      retorno += "Inativo: " + this.Inactive;
      return retorno;
    }

    public string GetTitle()
    {
      return this.Titulo;
    }

    public int GetId()
    {
      return this.Id;
    }

    public bool GetInactive()
    {
      return this.Inactive;
    }

    public void SetInactive()
    {
      this.Inactive = true;
    }
  }


}
