using System;

namespace SeriesApp
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
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
						VisualizarSerie();
						break;
					case "C":
						Console.Clear();
						break;
					default:
						Console.Write("Digite uma opção válida. \n");
						break;
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }

        private static void ListarSeries()
		{
			Console.WriteLine("Listar séries");
			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma série cadastrada.");
				return;
			}

			foreach (var serie in lista)
			{
                var excluido = serie.retornaExcluido();

				if(!excluido){
                	Console.WriteLine("#ID {0}: - {1}", serie.retornaId(), serie.retornaTitulo());
				}

				//Segundo metodo
				//Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirSerie()
		{
			Console.WriteLine("Inserir nova série");

			var novaSerie = formSerie(repositorio.ProximoId());

			repositorio.Insere(novaSerie);
		}

        private static void AtualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serieAtt = formSerie(indiceSerie);

			repositorio.Atualiza(indiceSerie, serieAtt);
		}

		private static void ExcluirSerie(){
			Console.Write("Digite o id da Série: ");
			int indiceSerie = int.Parse(Console.ReadLine());
			int cont = 0;

			while(cont == 0){
				Console.Write("Deseja mesmo excluir a serie com o id: " + indiceSerie + "? (1-Sim, 2-Não) \n");
				int resp = int.Parse(Console.ReadLine());
				
				if(resp == 1){
					repositorio.Exclui(indiceSerie);
					break;
				} 
				else if(resp == 2){
					break;
				}
				else{
					Console.Write("Opção não existe, por favor responda com 1 ou 2. \n");
				}
			}
		}

		public static void VisualizarSerie(){
			Console.Write("Digite o id da serie: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = repositorio.RetornaPorId(indiceSerie);

			Console.WriteLine(serie);
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("Locker Séries a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar séries");
			Console.WriteLine("2- Inserir nova série");
			Console.WriteLine("3- Atualizar série");
			Console.WriteLine("4- Excluir série");
			Console.WriteLine("5- Visualizar série");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}

		public static Serie formSerie(int id){
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Serie serieAtt = new Serie(id: id,
										genero: (Genero)entradaGenero,
										title: entradaTitulo,
										ano: entradaAno,
										desc: entradaDescricao);

			return serieAtt;
		}
    }
}
