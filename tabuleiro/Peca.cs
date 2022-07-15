using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tabuleiro
{
    public class Peca
    {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; set; }
        public int GetMovimentos { get; protected set; }
        public Tabuleiro Tab { get; protected set; }

        public Peca(Tabuleiro tab, Cor cor)
        {
            Posicao = null;
            Tab = tab;
            Cor = cor;
            GetMovimentos = 0;
        }

    }
}