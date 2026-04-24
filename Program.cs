namespace Jogo_Batalha_POO
{
    internal class Program
    {
        static void ExibirMenu(int pocoes)
        {
            Console.WriteLine("\nO que você deseja fazer?");
            Console.WriteLine("1 - Ataque Leve  (5-10 dano, 100% acerto)");
            Console.WriteLine("2 - Ataque Médio (10-20 dano, 80% acerto)");
            Console.WriteLine("3 - Ataque Forte (20-30 dano, 50% acerto)");
            Console.WriteLine("4 - Defender (Reduz dano pela metade)");
            Console.WriteLine($"5 - Usar Poção  (Restaura 20 de vida, {pocoes} restantes)");
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Jogador jogador = new Jogador("Herói");
            Inimigo inimigo = new Inimigo("Dragão");
            Random random = new Random();

            Console.WriteLine("⚔️  Bem-vindo a Espadas, Poções e Bits!");
            Console.WriteLine("========================================");

            while (jogador.EstaVivo() && inimigo.EstaVivo())
            {
                Console.WriteLine($"\n{jogador.Nome}: {jogador.Vida} | {inimigo.Nome}: {inimigo.Vida}");
                Console.WriteLine($"Poções: {jogador.Pocoes}");

                ExibirMenu(jogador.Pocoes);

                int escolha = 0;
                try
                {
                    escolha = int.Parse(Console.ReadLine() ?? "0");
                }
                catch
                {
                    Console.WriteLine("Entrada inválida!");
                    continue;
                }

                jogador.Defendendo = false;

                switch (escolha)
                {
                    case 1:
                    case 2:
                    case 3:
                        int dano = jogador.Atacar(escolha, random);
                        inimigo.Vida -= dano;
                        Console.WriteLine($"Você causou {dano} de dano!");
                        break;
                    case 4:
                        jogador.Defendendo = true;
                        Console.WriteLine("Você se defendeu!");
                        break;
                    case 5:
                        if (jogador.UsarPocao())
                            Console.WriteLine("Você usou uma poção! +20 de vida.");
                        else
                            Console.WriteLine("Sem poções!");
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        continue;
                }

                if (inimigo.EstaVivo())
                {
                    int danoInimigo = inimigo.Atacar(random);

                    if (danoInimigo == -1) 
                    {
                        Console.WriteLine("Rodada anulada!");
                    }
                    else
                    {
                        if (jogador.Defendendo) danoInimigo /= 2;
                        jogador.Vida -= danoInimigo;
                        Console.WriteLine($"{inimigo.Nome} causou {danoInimigo} de dano!");
                    }
                }
            }

            if (jogador.EstaVivo())
                Console.WriteLine($"\nVocê venceu!");
            else
                Console.WriteLine($"\nVocê foi derrotado!");
        }
    }
}
