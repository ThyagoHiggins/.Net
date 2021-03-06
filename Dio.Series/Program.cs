using System;

namespace Dio.Series
{
    class Program   
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while(opcaoUsuario.ToUpper()!= "X")
            {
                switch(opcaoUsuario)
                {
                case "1":
                    ListarSeries();
                    break;
                case "2":
                   InserirSerie();
                        break; 
                case "3":
                    AtualizarSerie();
                    break;
                case "4":
                   ExcluirSerie();
                    break;
                case "5":
                    VisualizarSeries();
                    break;
                case "C":
                    Console.Clear();
                    break;    

                default:
                throw new ArgumentOutOfRangeException();                     
            }
                opcaoUsuario = ObterOpcaoUsuario();

            }

        }

        private static void VisualizarSeries()
        {
            Console.Write("Digite o id da série: ");
             int indiceSerie = int.Parse(Console.ReadLine());

             var serie = repositorio.RetornaporID(indiceSerie);

             Console.WriteLine(serie);
        }

        private static void ExcluirSerie()
        {
           Console.Write("Digite o ida da Série: ");
           int indiceSerie = int.Parse(Console.ReadLine());

           repositorio.Exclui(indiceSerie);
        }

        private static void AtualizarSerie()
        {
           Console.Write("Digite o id da série: ");
           int indiceSerie = int.Parse(Console.ReadLine());

           foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero),i));
            }

            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTítulo = Console.ReadLine();

            Console.Write("Digite o Ano de Inicio da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série:");
            string entradaDescricao = Console.ReadLine();

            Serie AtualizarSerie = new Serie(id: indiceSerie,
                                        genero:(Genero)entradaGenero,
                                        Titulo:entradaTítulo,
                                        ano:entradaAno,
                                        descricao:entradaDescricao);
            
            repositorio.Atualiza(indiceSerie, AtualizarSerie);
        }

        private static void ListarSeries()
        {
        Console.WriteLine("Listar séries");

        var lista = repositorio.Lista();
        
        if(lista.Count == 0)
        {
            Console.WriteLine("Nenhuma série cadastrada");
        }

        foreach(var serie in lista)
        {
            var excluido = serie.retornaExcluido();

            Console.WriteLine("#ID {0}: {1} - {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluido*": ""));
        }

        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero),i));
            }

            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTítulo = Console.ReadLine();

            Console.Write("Digite o Ano de Inicio da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série:");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero:(Genero)entradaGenero,
                                        Titulo:entradaTítulo,
                                        ano:entradaAno,
                                        descricao:entradaDescricao);
            
            repositorio.Insere(novaSerie);

        }
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Dio Séries");
            Console.WriteLine();

            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Listar série");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;

        }
    }
}
