


string mensagemBoasVindas = "\nBem Vindo ao Screen Sound";


Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();
bandasRegistradas.Add("Linkin Park", new List<int> { 10 });
bandasRegistradas.Add("The Beatles", new List<int>());

void ExibirLogo()
{
  Console.WriteLine(@"
█████████████████████████████████████████████████████████████████████████
█─▄▄▄▄█─▄▄▄─█▄─▄▄▀█▄─▄▄─█▄─▄▄─█▄─▀█▄─▄███─▄▄▄▄█─▄▄─█▄─██─▄█▄─▀█▄─▄█▄─▄▄▀█
█▄▄▄▄─█─███▀██─▄─▄██─▄█▀██─▄█▀██─█▄▀─████▄▄▄▄─█─██─██─██─███─█▄▀─███─██─█
▀▄▄▄▄▄▀▄▄▄▄▄▀▄▄▀▄▄▀▄▄▄▄▄▀▄▄▄▄▄▀▄▄▄▀▀▄▄▀▀▀▄▄▄▄▄▀▄▄▄▄▀▀▄▄▄▄▀▀▄▄▄▀▀▄▄▀▄▄▄▄▀▀");
  Console.WriteLine(mensagemBoasVindas);
}

void ExibirOpcoesMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para mostrar todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a média de uma banda");
    Console.WriteLine("Digite 0 para sair");

    Console.Write("\nDigite a opção: ");
    string armazenarOpcao = Console.ReadLine()!;
    int opcaoEscolhida = int.Parse(armazenarOpcao);

    switch (opcaoEscolhida)
    {
        case 1: RegistroDeBandas();
            break;
        case 2: MostrarBandas();
            break;
        case 3: AvaliarUmaBanda();
            break;
        case 4: ExibirMediaDasBandas();
            break;
        case 0: Console.WriteLine(@"

              ▄▀█ ▀█▀ █▀▀   ▄▀█   █▀█ █▀█ █▀█ ▀▄▀ █ █▀▄▀█ ▄▀█
              █▀█ ░█░ ██▄   █▀█   █▀▀ █▀▄ █▄█ █░█ █ █░▀░█ █▀█");
            break;
        default: Console.WriteLine("Opção inválida");
            break;
    }
}

void RegistroDeBandas()
{
    Console.Clear();
    ExibirTituloDaOpcao("REGISTRO DE BANDAS");
    Console.Write("Digite a banda que deseja registrar: ");
    string nomeDaBanda = Console.ReadLine()!;
    bandasRegistradas.Add(nomeDaBanda, new List<int>());
    Console.Clear();
    Console.WriteLine($"Você registrou {nomeDaBanda} a lista de bandas com sucesso!");
    Thread.Sleep(2000);
    Console.Clear();
    ExibirOpcoesMenu();
}

void MostrarBandas()
{
    Console.Clear();
    ExibirTituloDaOpcao("BANDAS REGISTRADAS");

    //for (int i = 0; i < listaDeBandas.Count; i++)
    //{
        //Console.WriteLine($"Banda Registrada: {listaDeBandas[i]}");
    //}

    foreach (string banda in bandasRegistradas.Keys)
    {
        Console.WriteLine($"Banda: {banda}");
    }
    Console.WriteLine("\nDigite qualquer tecla para voltar ao menu principal");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesMenu();
}

void AvaliarUmaBanda()
{
    //digite qual banda deseja avaliar
    //se a banda existir no dicionario>>atribuir uma nota
    //se não existir>>exibir mensagem de aviso e volta ao menu principal
    Console.Clear();
    ExibirTituloDaOpcao("Avalie uma banda");
    Console.Write("Digite uma banda que deseja avaliar: ");
    string nomeDaBanda = Console.ReadLine()!;

    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        Console.Write($"\nDigite a nota que banda {nomeDaBanda} merece: ");
        int nota = int.Parse(Console.ReadLine()!);
        bandasRegistradas[nomeDaBanda].Add(nota);
        Console.WriteLine($"A nota {nota} foi atribuída com sucesso para a banda {nomeDaBanda}.");
        Thread.Sleep(3000);
        Console.Clear();
        ExibirOpcoesMenu();
    }
    else
    {
        Console.WriteLine($"A banda {nomeDaBanda} não existe.\n");
        Console.WriteLine("Digite qualquer tecla para voltar ao menu principal.");
        Console.ReadKey();
        Thread.Sleep(1500);
        Console.Clear();
        ExibirOpcoesMenu();
    }
}

void ExibirMediaDasBandas()
{
    Console.Clear();
    ExibirTituloDaOpcao("Exibindo Média da Banda");
    Console.Write("\nDigite o nome da banda para ver a média da banda: ");
    string nomeDaBanda = Console.ReadLine()!;

    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        List<int> mediaDasBandas = bandasRegistradas[nomeDaBanda];
        Console.WriteLine($"\nA média da banda {nomeDaBanda} é {mediaDasBandas.Average()}.");
        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu principal.");
        Console.ReadKey();
        Thread.Sleep(1500);
        Console.Clear();
        ExibirOpcoesMenu();
    }
    else
    {
        Console.WriteLine($"A banda {nomeDaBanda} não existe.\n");
        Console.WriteLine("Digite qualquer tecla para voltar ao menu principal");
        Console.ReadKey();
        Thread.Sleep(1500);
        Console.Clear();
        ExibirOpcoesMenu();

    }
}



void ExibirTituloDaOpcao(string titulo)
{
    int quantidadeDeLetras = titulo.Length;
    string asterisco = string.Empty.PadLeft(quantidadeDeLetras, '*');
    Console.WriteLine(asterisco);
    Console.WriteLine(titulo);
    Console.WriteLine(asterisco + "\n");
}

ExibirOpcoesMenu();
