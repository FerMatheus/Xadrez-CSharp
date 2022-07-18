using tabuleiro;

namespace xadrez
{
    public class Rei : Peca
    {
        public Rei(Tabuleiro tab, Cor cor) : base(tab, cor)
        {
        }
        private bool PodeMover(Posicao pos)
        {
            Peca peca = Tab.Peca(pos);
            return peca == null || peca.Cor != Cor;
        }
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] movimentosPossiveis = new bool[Tab.Linhas, Tab.Colunas];
            Posicao pos = new Posicao(0, 0);
            // Cima
            pos.DefinirPosicao(Posicao.Linha - 1, Posicao.Coluna);
            if (Tab.VerificaPosicao(pos) && PodeMover(pos))
            {
                movimentosPossiveis[pos.Linha, pos.Coluna] = true;
            }
            // Nordeste
            pos.DefinirPosicao(Posicao.Linha - 1, Posicao.Coluna + 1);
            if (Tab.VerificaPosicao(pos) && PodeMover(pos))
            {
                movimentosPossiveis[pos.Linha, pos.Coluna] = true;
            }
            // Direita
            pos.DefinirPosicao(Posicao.Linha, Posicao.Coluna + 1);
            if (Tab.VerificaPosicao(pos) && PodeMover(pos))
            {
                movimentosPossiveis[pos.Linha, pos.Coluna] = true;
            }
            // Sudeste
            pos.DefinirPosicao(Posicao.Linha + 1, Posicao.Coluna + 1);
            if (Tab.VerificaPosicao(pos) && PodeMover(pos))
            {
                movimentosPossiveis[pos.Linha, pos.Coluna] = true;
            }
            // Baixo
            pos.DefinirPosicao(Posicao.Linha + 1, Posicao.Coluna);
            if (Tab.VerificaPosicao(pos) && PodeMover(pos))
            {
                movimentosPossiveis[pos.Linha, pos.Coluna] = true;
            }
            // Sudoeste
            pos.DefinirPosicao(Posicao.Linha + 1, Posicao.Coluna - 1);
            if (Tab.VerificaPosicao(pos) && PodeMover(pos))
            {
                movimentosPossiveis[pos.Linha, pos.Coluna] = true;
            }
            // Esquerda
            pos.DefinirPosicao(Posicao.Linha, Posicao.Coluna - 1);
            if (Tab.VerificaPosicao(pos) && PodeMover(pos))
            {
                movimentosPossiveis[pos.Linha, pos.Coluna] = true;
            }// Noroeste
            pos.DefinirPosicao(Posicao.Linha - 1, Posicao.Coluna - 1);
            if (Tab.VerificaPosicao(pos) && PodeMover(pos))
            {
                movimentosPossiveis[pos.Linha, pos.Coluna] = true;
            }
            return movimentosPossiveis;
        }
        public override string ToString()
        {
            return "R";
        }
    }
}