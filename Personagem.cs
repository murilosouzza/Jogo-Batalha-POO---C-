using System;
using System.Collections.Generic;
using System.Text;

namespace Jogo_Batalha_POO
{
    public abstract class Personagem
    {
        public string Nome { get; set; }
        private int _vida;

        public int Vida
        {
            get { return _vida; }
            set { _vida = Math.Max(value, 0); }
        }

        public Personagem(string nome, int vida)
        {
            Nome = nome;
            Vida = vida;
        }

        public bool EstaVivo()
        {
            return Vida > 0;
        }
        public abstract int Atacar(Random random);
    }
}