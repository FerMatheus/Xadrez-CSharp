using tabuleiro;

namespace xadrez
{
    public class Peao : Peca
    {
        public Peao(Tabuleiro tab, Cor cor) : base(tab, cor) { }

        public override string ToString()
        {
            return "P";
        }
        private bool Livre(Posicao pos)
        {
            Peca p = Tab.Peca(pos);
            return p == null;
        }
        private bool TemInimigo(Posicao pos)
        {
            Peca p = Tab.Peca(pos);
            return p != null && p.Cor != Cor;
        }
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] movimentosPossiveis = new bool[Tab.Linhas, Tab.Colunas];
            Posicao pos = new(0, 0);

            if (Cor.Equals(Cor.Branca))
            {
                // Movimento
                pos.DefinirPosicao(Posicao.Linha - 1, Posicao.Coluna);
                if (Tab.VerificaPosicao(pos) && Livre(pos))
                {
                    movimentosPossiveis[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirPosicao(Posicao.Linha - 2, Posicao.Coluna);
                if (Tab.VerificaPosicao(pos) && Livre(pos) && qtdeMovimentos == 0)
                {
                    movimentosPossiveis[pos.Linha, pos.Coluna] = true;
                }
                //Captura
                pos.DefinirPosicao(Posicao.Linha - 1, Posicao.Coluna - 1);
                if (Tab.VerificaPosicao(pos) && TemInimigo(pos))
                {
                    movimentosPossiveis[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirPosicao(Posicao.Linha - 1, Posicao.Coluna + 1);
                if (Tab.VerificaPosicao(pos) && TemInimigo(pos))
                {
                    movimentosPossiveis[pos.Linha, pos.Coluna] = true;
                }
            }
            else
            {
                // Movimento
                pos.DefinirPosicao(Posicao.Linha + 1, Posicao.Coluna);
                if (Tab.VerificaPosicao(pos) && Livre(pos))
                {
                    movimentosPossiveis[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirPosicao(Posicao.Linha + 2, Posicao.Coluna);
                if (Tab.VerificaPosicao(pos) && Livre(pos) && qtdeMovimentos == 0)
                {
                    movimentosPossiveis[pos.Linha, pos.Coluna] = true;
                }
                //Captura
                pos.DefinirPosicao(Posicao.Linha + 1, Posicao.Coluna + 1);
                if (Tab.VerificaPosicao(pos) && TemInimigo(pos))
                {
                    movimentosPossiveis[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirPosicao(Posicao.Linha + 1, Posicao.Coluna - 1);
                if (Tab.VerificaPosicao(pos) && TemInimigo(pos))
                {
                    movimentosPossiveis[pos.Linha, pos.Coluna] = true;
                }
            }
            return movimentosPossiveis;
        }
    }
}