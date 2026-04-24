using System;
using System.Collections.Generic;
using System.Text;

namespace Jogo_Batalha_POO
{
    public class Jogador : Personagem
    {
        private int _pocoes;
        public bool Defendendo { get; set; }

        public int Pocoes
        {
            get { return _pocoes; }
            set { _pocoes = Math.Max(value, 0); }
        }

        public Jogador(string nome) : base(nome, 100)
        {
            _pocoes = 2;
            Defendendo = false;
        }

        public override int Atacar(Random random)
        {
            return random.Next(5, 11);
        }

        public int Atacar(int escolha, Random random)
        {
            switch (escolha)
            {
                case 1:
                    return random.Next(5, 11);
                case 2:
                    if (random.Next(1, 101) <= 80)
                        return random.Next(10, 21);
                    else
                    {
                        Console.WriteLine("❌ Ataque Médio errou!");
                        return 0;
                    }
                case 3:
                    if (random.Next(1, 101) <= 50)
                        return random.Next(20, 31);
                    else
                    {
                        Console.WriteLine("❌ Ataque Forte errou!");
                        return 0;
                    }
                default:
                    return 0;
            }
        }

        public bool UsarPocao()
        {
            if (Pocoes > 0)
            {
                Vida = Math.Min(Vida + 20, 100);
                Pocoes--;
                return true;
            }
            return false;
        }
    }
}