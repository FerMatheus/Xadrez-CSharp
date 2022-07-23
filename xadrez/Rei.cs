using tabuleiro;

namespace xadrez
{
    public class Rei : Peca
    {
        private PartidaDeXadrez partida;
        public Rei(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(tab, cor)
        {
            this.partida = partida;
        }
        private bool PodeMover(Posicao pos)
        {
            Peca peca = Tab.Peca(pos);
            return peca == null || peca.Cor != Cor;
        }

        public bool TesteTorreRoque(Posicao pos)
        {
            Peca torre = Tab.Peca(pos);
            return torre != null && torre is Torre && torre.Cor == Cor && torre.qtdeMovimentos == 0;
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
            // #JogadaEspecial = Roque
            if (qtdeMovimentos == 0 && !partida.Xeque)
            {
                // Roque curto
                Posicao posTorre1 = new(Posicao.Linha, Posicao.Coluna + 3);
                if (TesteTorreRoque(posTorre1))
                {
                    Posicao p1 = new(Posicao.Linha, Posicao.Coluna + 1);
                    Posicao p2 = new(Posicao.Linha, Posicao.Coluna + 2);
                    if (Tab.Peca(p1) == null && Tab.Peca(p2) == null)
                    {
                        movimentosPossiveis[Posicao.Linha, Posicao.Coluna + 2] = true;
                    }
                }
                //Roque Longo
                Posicao posTorre2 = new(Posicao.Linha, Posicao.Coluna - 4);
                if (TesteTorreRoque(posTorre2))
                {
                    Posicao p1 = new(Posicao.Linha, Posicao.Coluna - 1);
                    Posicao p2 = new(Posicao.Linha, Posicao.Coluna - 2);
                    Posicao p3 = new(Posicao.Linha, Posicao.Coluna - 3);
                    if (Tab.Peca(p1) == null && Tab.Peca(p2) == null && Tab.Peca(p3) == null)
                    {
                        movimentosPossiveis[Posicao.Linha, Posicao.Coluna - 2] = true;
                    }
                }
            }
            return movimentosPossiveis;
        }
        public override string ToString()
        {
            return "R";
        }
    }
}