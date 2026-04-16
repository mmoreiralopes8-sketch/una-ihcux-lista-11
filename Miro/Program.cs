using System;
using System.Collections.Generic;
using System.Linq;

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

class Mensagem
{
    public string Texto { get; set; }
    public DateTime Data { get; set; }
}

class Usuario
{
    public string Nome { get; set; }
    public int SelosEco { get; set; }
}

class Program
{
    static List<Item> itens = new List<Item>();
    static List<Mensagem> chat = new List<Mensagem>();
    static Usuario usuario = new Usuario { Nome = "Matheus", SelosEco = 0 };

    static void Main()
    {
        MenuPrincipal();
    }

    // MENU PRINCIPAL (HOME)
    static void MenuPrincipal()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== ♻️ ReCiclo ===");
            Console.WriteLine("1 - Ver Feed");
            Console.WriteLine("2 - Filtrar Itens");
            Console.WriteLine("3 - Cadastrar Item");
            Console.WriteLine("4 - Chat");
            Console.WriteLine("5 - Perfil");
            Console.WriteLine("0 - Sair");

            Console.Write("Escolha: ");
            string op = Console.ReadLine();

            switch (op)
            {
                case "1": TelaFeed(); break;
                case "2": TelaFiltro(); break;
                case "3": TelaCadastro(); break;
                case "4": TelaChat(); break;
                case "5": TelaPerfil(); break;
                case "0": return;
            }
        }
    }

    // TELA FEED
    static void TelaFeed()
    {
        Console.Clear();
        Console.WriteLine("=== FEED DE ITENS ===");

        if (itens.Count == 0)
        {
            Console.WriteLine("Nenhum item disponível.");
        }

        foreach (var item in itens)
        {
            Console.WriteLine($"{item.Id} - {item.Nome} ({item.Categoria}) - {item.DistanciaKm}km");
        }

        Console.Write("\nDigite o ID para ver detalhes ou ENTER para voltar: ");
        string input = Console.ReadLine();

        if (int.TryParse(input, out int id))
        {
            var item = itens.FirstOrDefault(i => i.Id == id);
            if (item != null)
                TelaDetalhes(item);
        }
    }

    // TELA FILTRO
    static void TelaFiltro()
    {
        Console.Clear();
        Console.Write("Categoria: ");
        string categoria = Console.ReadLine();

        Console.Write("Distância máxima: ");
        double distancia = double.Parse(Console.ReadLine());

        var filtrados = itens.Where(i =>
            (string.IsNullOrEmpty(categoria) || i.Categoria == categoria) &&
            i.DistanciaKm <= distancia
        ).ToList();

        Console.WriteLine("\n=== RESULTADO ===");
        foreach (var item in filtrados)
        {
            Console.WriteLine($"{item.Nome} - {item.DistanciaKm}km");
        }

        Console.ReadKey();
    }

    // TELA DETALHES
    static void TelaDetalhes(Item item)
    {
        Console.Clear();
        Console.WriteLine("=== DETALHES ===");
        Console.WriteLine($"Nome: {item.Nome}");
        Console.WriteLine($"Descrição: {item.Descricao}");
        Console.WriteLine($"Estado: {item.Estado}");
        Console.WriteLine($"Doador: {item.Doador}");

        Console.WriteLine("\n1 - Conversar");
        Console.WriteLine("2 - Concluir Doação");
        Console.WriteLine("0 - Voltar");

        string op = Console.ReadLine();

        if (op == "1") TelaChat();
        if (op == "2") ConcluirDoacao();
    }

    // TELA CADASTRO
    static void TelaCadastro()
    {
        Console.Clear();
        Item novo = new Item();

        novo.Id = itens.Count + 1;

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

        novo.Doador = usuario.Nome;

        itens.Add(novo);

        Console.WriteLine("Item cadastrado!");
        Console.ReadKey();
    }

    // TELA CHAT
    static void TelaChat()
    {
        Console.Clear();
        Console.WriteLine("=== CHAT ===");

        foreach (var msg in chat)
        {
            Console.WriteLine($"[{msg.Data}] {msg.Texto}");
        }

        Console.Write("\nDigite mensagem (ou ENTER para sair): ");
        string texto = Console.ReadLine();

        if (!string.IsNullOrEmpty(texto))
        {
            chat.Add(new Mensagem
            {
                Texto = texto,
                Data = DateTime.Now
            });
        }
    }

    // TELA PERFIL
    static void TelaPerfil()
    {
        Console.Clear();
        Console.WriteLine("=== PERFIL ===");
        Console.WriteLine($"Nome: {usuario.Nome}");
        Console.WriteLine($"Selos Eco: {usuario.SelosEco}");

        Console.ReadKey();
    }

    // GAMIFICAÇÃO
    static void ConcluirDoacao()
    {
        usuario.SelosEco++;
        Console.WriteLine("Doação concluída! Você ganhou um Selo Eco 🌱");
        Console.ReadKey();
    }
}