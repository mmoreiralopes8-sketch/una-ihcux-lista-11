1. Classe Base (Modelo do Sistema)
class Item
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Categoria { get; set; }
    public string Descricao { get; set; }
    public string Estado { get; set; }
    public double DistanciaKm { get; set; }
    public string Doador { get; set; }
}
class Usuario
{
    public string Nome { get; set; }
    public int SelosEco { get; set; }
}

 2. Feed de Itens (Tela Home)
static void ExibirFeed(List<Item> itens)
{
    Console.WriteLine("=== FEED DE ITENS ===");

    foreach (var item in itens)
    {
        Console.WriteLine($"Nome: {item.Nome}");
        Console.WriteLine($"Categoria: {item.Categoria}");
        Console.WriteLine($"Distância: {item.DistanciaKm} km");
        Console.WriteLine("----------------------");
    }
}

 3. Filtro de Busca
static List<Item> FiltrarItens(List<Item> itens, string categoria, double distanciaMax)
{
    return itens.Where(i => 
        (categoria == "" || i.Categoria == categoria) &&
        i.DistanciaKm <= distanciaMax
    ).ToList();
}

 4. Detalhes do Item
static void VerDetalhes(Item item)
{
    Console.WriteLine("=== DETALHES ===");
    Console.WriteLine($"Nome: {item.Nome}");
    Console.WriteLine($"Descrição: {item.Descricao}");
    Console.WriteLine($"Estado: {item.Estado}");
    Console.WriteLine($"Doador: {item.Doador}");
}

 5. Cadastro de Novo Item
static void CadastrarItem(List<Item> itens)
{
    Item novo = new Item();

    Console.Write("Nome: ");
    novo.Nome = Console.ReadLine();

    Console.Write("Categoria: ");
    novo.Categoria = Console.ReadLine();

    Console.Write("Descrição: ");
    novo.Descricao = Console.ReadLine();

    Console.Write("Estado: ");
    novo.Estado = Console.ReadLine();

    Console.Write("Distância (km): ");
    novo.DistanciaKm = double.Parse(Console.ReadLine());

    itens.Add(novo);

    Console.WriteLine("Item cadastrado com sucesso!");
}

 6. Chat entre Usuários
class Mensagem
{
    public string Texto { get; set; }
    public DateTime Data { get; set; }
}

static List<Mensagem> chat = new List<Mensagem>();

static void EnviarMensagem(string texto)
{
    chat.Add(new Mensagem
    {
        Texto = texto,
        Data = DateTime.Now
    });

    Console.WriteLine("Mensagem enviada!");
}

 7. Sistema de Selos (Gamificação)
static void ConcluirDoacao(Usuario usuario)
{
    usuario.SelosEco++;

    Console.WriteLine($"Doação concluída! Selos Eco: {usuario.SelosEco}");
}

 8. Jornada Completa (Fluxo do App)
static void Jornada()
{
    List<Item> itens = new List<Item>();
    Usuario user = new Usuario { Nome = "Matheus", SelosEco = 0 };

    CadastrarItem(itens);
    ExibirFeed(itens);

    var filtrados = FiltrarItens(itens, "", 10);
    ExibirFeed(filtrados);

    if (itens.Count > 0)
    {
        VerDetalhes(itens[0]);
        EnviarMensagem("Tenho interesse!");
        ConcluirDoacao(user);
    }
}

tela 1. Localiza os itens desejados proximos a voce

tela 2. filtro para localizar itens desejados 

tela 3. descrição do item e endereço de retirada

tela 4. cadastro de item

tela 5. chat para negociação 

tela 6. perfil
