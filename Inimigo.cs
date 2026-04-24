using System;
using System.Collections.Generic;
using System.Text;

namespace Jogo_Batalha_POO
{
    public class Inimigo : Personagem
    {
        public Inimigo(string nome) : base(nome, 100)
        {
        }

        public override int Atacar(Random random)
        {
            int acao = random.Next(1, 5); 
            switch (acao)
            {
                case 1:
                    Console.WriteLine($"👹 {Nome} usou Ataque Leve!");
                    return random.Next(5, 11);
                case 2:
                    Console.WriteLine($"👹 {Nome} usou Ataque Médio!");
                    if (random.Next(1, 101) <= 80)
                        return random.Next(10, 21);
                    else
                    {
                        Console.WriteLine($"👹 {Nome} errou!");
                        return 0;
                    }
                case 3:
                    Console.WriteLine($"👹 {Nome} usou Ataque Forte!");
                    if (random.Next(1, 101) <= 50)
                        return random.Next(20, 31);
                    else
                    {
                        Console.WriteLine($"👹 {Nome} errou!");
                        return 0;
                    }
                case 4:
                    Console.WriteLine($"🛡️ {Nome} se defendeu! Rodada anulada.");
                    return -1;
                default:
                    return 0;
            }
        }    
    }       
}           
