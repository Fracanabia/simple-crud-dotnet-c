using System;

namespace DIO.Series
{
  class Program
  {
    static SerieRepository repository = new SerieRepository();
    static void Main(string[] args)
    {
      string optionsUser = OptionsUser();

      while (optionsUser.ToUpper() != "X")
      {
        switch (optionsUser)
        {
          case "1":
            GetAllSeries();
            break;
          case "2":
            AddSerie();
            break;
          case "3":
            UpdateSerie();
            break;
          case "4":
            Inactive();
            break;
          case "5":
            DetailViewSerie();
            break;
          case "C":
            Console.Clear();
            break;
          default:
            throw new ArgumentOutOfRangeException();

        }
        optionsUser = OptionsUser();
      }
    }

    private static void GetAllSeries()
    {
      Console.WriteLine("Listar séries");

      var series = repository.GetAll();

      if (series.Count == 0)
      {
        Console.WriteLine("Nenhuma séria encontrada");
        return;
      }

      foreach (var serie in series)
      {
        var inactive = serie.GetInactive();
        Console.WriteLine("#ID {0}: - {1} - {2}", serie.GetId(), serie.GetTitle(), (inactive ? "*Inativo*" : "*Ativo*"));
      }

    }

    private static void AddSerie()
    {
      Console.WriteLine("Inserir uma nova série");

      foreach (int i in Enum.GetValues(typeof(Genero)))
      {
        Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
      }

      Console.WriteLine("Digite o gênero entre as opções acima");
      int entradaGenero = int.Parse(Console.ReadLine());

      Console.WriteLine("Digite o título da série");
      string entradaTitulo = Console.ReadLine();

      Console.WriteLine("Digite o ano da série");
      int entradaAno = int.Parse(Console.ReadLine());

      Console.WriteLine("Digite a descrição da série");
      string entradaDescricao = Console.ReadLine();

      Serie novaSerie = new Serie(id: repository.GetNextId(),
                                    genero: (Genero)entradaGenero,
                                    titulo: entradaTitulo,
                                    ano: entradaAno,
                                    descricao: entradaDescricao
      );

      repository.SetAdd(novaSerie);
    }

    private static void UpdateSerie()
    {
      Console.Write("Digite o id da série: ");
      var indiceSerie = int.Parse(Console.ReadLine());

      foreach (int i in Enum.GetValues(typeof(Genero)))
      {
        Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
      }

      Console.WriteLine("Digite o gênero entre as opções acima");
      int entradaGenero = int.Parse(Console.ReadLine());

      Console.WriteLine("Digite o título da série");
      string entradaTitulo = Console.ReadLine();

      Console.WriteLine("Digite o ano da série");
      int entradaAno = int.Parse(Console.ReadLine());

      Console.WriteLine("Digite a descrição da série");
      string entradaDescricao = Console.ReadLine();

      Serie atualizaSerie = new Serie(id: indiceSerie,
                                    genero: (Genero)entradaGenero,
                                    titulo: entradaTitulo,
                                    ano: entradaAno,
                                    descricao: entradaDescricao
      );

      repository.SetUpdate(indiceSerie, atualizaSerie);
    }

    private static void Inactive()
    {
      Console.Write("Digite o id da série: ");
      var indiceSerie = int.Parse(Console.ReadLine());

      repository.SetInactive(indiceSerie);
    }

    private static void DetailViewSerie()
    {
      Console.Write("Digite o id da série: ");
      var indiceSerie = int.Parse(Console.ReadLine());

      var serie = repository.GetById(indiceSerie);

      Console.WriteLine(serie);
    }

    private static string OptionsUser()
    {
      Console.WriteLine();
      Console.WriteLine("DIO Séries ao seu dispor!!!");
      Console.WriteLine("Informe a opção desejada");
      Console.WriteLine("1 - Listar séries");
      Console.WriteLine("2 - Inserir nova série");
      Console.WriteLine("3 - Atualizar série");
      Console.WriteLine("4 - Excluir série");
      Console.WriteLine("5 - Visualizar série");
      Console.WriteLine("C - Limpar tela");
      Console.WriteLine("X - Sair");
      Console.WriteLine();

      string optionsUser = Console.ReadLine().ToUpper();
      Console.WriteLine();
      return optionsUser;
    }
  }
}
