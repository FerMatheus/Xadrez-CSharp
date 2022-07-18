using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tabuleiro
{
    public abstract class Peca
    {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; set; }
        public int qtdeMovimentos { get; protected set; }
        public Tabuleiro Tab { get; protected set; }

        public Peca(Tabuleiro tab, Cor cor)
        {
            Posicao = null;
            Tab = tab;
            Cor = cor;
            qtdeMovimentos = 0;
        }
        public void IncrementarMovimentos()
        {
            qtdeMovimentos = qtdeMovimentos + 1;
        }

        public abstract bool[,] MovimentosPossiveis();
    }
}