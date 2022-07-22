using tabuleiro;

namespace xadrez
{
    public class Cavalo : Peca
    {
        public Cavalo(Tabuleiro tab, Cor cor) : base(tab, cor) { }

        public override string ToString()
        {
            return "C";
        }
        private bool PodeMover(Posicao pos)
        {
            return Tab.Peca(pos) == null || Tab.Peca(pos).Cor != Cor;
        }
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];
            Posicao pos = new(0, 0);
            // Cima
            pos.DefinirPosicao(Posicao.Linha - 1, Posicao.Coluna - 2);
            if (Tab.VerificaPosicao(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirPosicao(Posicao.Linha - 1, Posicao.Coluna + 2);
            if (Tab.VerificaPosicao(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirPosicao(Posicao.Linha - 2, Posicao.Coluna - 1);
            if (Tab.VerificaPosicao(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirPosicao(Posicao.Linha - 2, Posicao.Coluna + 1);
            if (Tab.VerificaPosicao(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            // Baixo
            pos.DefinirPosicao(Posicao.Linha + 1, Posicao.Coluna - 2);
            if (Tab.VerificaPosicao(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirPosicao(Posicao.Linha + 1, Posicao.Coluna + 2);
            if (Tab.VerificaPosicao(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirPosicao(Posicao.Linha + 2, Posicao.Coluna - 1);
            if (Tab.VerificaPosicao(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirPosicao(Posicao.Linha + 2, Posicao.Coluna + 1);
            if (Tab.VerificaPosicao(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            return mat;
        }
    }
}