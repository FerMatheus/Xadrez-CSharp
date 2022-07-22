using tabuleiro;

namespace xadrez
{
    public class Dama : Peca
    {
        public Dama(Tabuleiro tab, Cor cor) : base(tab, cor) { }

        public override string ToString()
        {
            return "D";
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
            pos.DefinirPosicao(Posicao.Linha - 1, Posicao.Coluna);
            while (Tab.VerificaPosicao(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != Cor) break;
                pos.Linha--;
            }
            // Nordeste
            pos.DefinirPosicao(Posicao.Linha - 1, Posicao.Coluna + 1);
            while (Tab.VerificaPosicao(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != Cor) break;
                pos.Linha--;
                pos.Coluna++;
            }
            // Direita
            pos.DefinirPosicao(Posicao.Linha, Posicao.Coluna + 1);
            while (Tab.VerificaPosicao(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != Cor) break;
                pos.Coluna++;
            }
            // Sudeste
            pos.DefinirPosicao(Posicao.Linha + 1, Posicao.Coluna + 1);
            while (Tab.VerificaPosicao(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != Cor) break;
                pos.Linha++;
                pos.Coluna++;
            }
            // Sul
            pos.DefinirPosicao(Posicao.Linha + 1, Posicao.Coluna);
            while (Tab.VerificaPosicao(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != Cor) break;
                pos.Linha++;
            }
            // Sudoeste
            pos.DefinirPosicao(Posicao.Linha + 1, Posicao.Coluna - 1);
            while (Tab.VerificaPosicao(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != Cor) break;
                pos.Linha++;
                pos.Coluna--;
            }
            // Esquerda
            pos.DefinirPosicao(Posicao.Linha, Posicao.Coluna - 1);
            while (Tab.VerificaPosicao(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != Cor) break;
                pos.Coluna--;
            }
            // Noroeste
            pos.DefinirPosicao(Posicao.Linha - 1, Posicao.Coluna - 1);
            while (Tab.VerificaPosicao(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != Cor) break;
                pos.Linha--;
                pos.Coluna--;
            }
            return mat;
        }
    }
}