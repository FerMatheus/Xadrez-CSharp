using tabuleiro;
namespace xadrez
{
    public class PartidaDeXadrez
    {
        public Tabuleiro Tab { get; private set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool Terminada { get; private set; }
        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;
        public bool Xeque { get; private set; }
        public Peca VulneravelEnPassant { get; private set; }

        public PartidaDeXadrez()
        {
            Tab = new Tabuleiro(8, 8);
            Turno = 1;
            Xeque = false;
            Terminada = false;
            VulneravelEnPassant = null;
            JogadorAtual = Cor.Branca;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            ColocarPecas();
        }
        private Peca ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = Tab.RetirarPeca(origem);
            p.IncrementarMovimentos();
            Peca pecaCapturada = Tab.RetirarPeca(destino);
            Tab.ColocarPeca(p, destino);
            if (pecaCapturada != null)
            {
                capturadas.Add(pecaCapturada);
            }
            // JogadaEspecial = roque
            // Roque pequeno
            if (p is Rei && origem.Coluna + 2 == destino.Coluna)
            {
                Posicao posTorre = new(origem.Linha, origem.Coluna + 3);
                Peca torre = Tab.RetirarPeca(posTorre);
                torre.IncrementarMovimentos();
                Tab.ColocarPeca(torre, new(origem.Linha, origem.Coluna + 1));
            }
            // Roque longo
            if (p is Rei && origem.Coluna - 2 == destino.Coluna)
            {
                Posicao posTorre = new(origem.Linha, origem.Coluna - 4);
                Peca torre = Tab.RetirarPeca(posTorre);
                torre.IncrementarMovimentos();
                Tab.ColocarPeca(torre, new(origem.Linha, origem.Coluna - 1));
            }
            // #JogadaEspecial = En Passant
            if (p is Peao)
            {
                if (origem.Coluna != destino.Coluna && pecaCapturada == null)
                {
                    Posicao posP;
                    if (p.Cor.Equals(Cor.Branca))
                    {
                        posP = new(destino.Linha + 1, destino.Coluna);
                    }
                    else
                    {
                        posP = new(destino.Linha - 1, destino.Coluna);
                    }
                    pecaCapturada = Tab.RetirarPeca(posP);
                    capturadas.Add(pecaCapturada);
                }
            }
            return pecaCapturada;
        }
        private void DesfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            Peca p = Tab.RetirarPeca(destino);
            p.DecrementarMovimentos();
            if (pecaCapturada != null)
            {
                Tab.ColocarPeca(pecaCapturada, destino);
                capturadas.Remove(pecaCapturada);
            }
            Tab.ColocarPeca(p, origem);
            // Roque pequeno
            if (p is Rei && origem.Coluna + 2 == destino.Coluna)
            {
                Posicao posTorre = new(origem.Linha, origem.Coluna + 3);
                Peca torre = Tab.RetirarPeca(new(origem.Linha, origem.Coluna + 1));
                torre.DecrementarMovimentos();
                Tab.ColocarPeca(torre, posTorre);
            }
            // Roque longo
            if (p is Rei && origem.Coluna - 2 == destino.Coluna)
            {
                Posicao posTorre = new(origem.Linha, origem.Coluna - 4);
                Peca torre = Tab.RetirarPeca(new(origem.Linha, origem.Coluna - 1));
                torre.IncrementarMovimentos();
                Tab.ColocarPeca(torre, posTorre);
            }
            // #JogadaEspecial = En Passant
            if (p is Peao)
            {
                if (origem.Coluna != destino.Coluna && pecaCapturada.Equals(VulneravelEnPassant))
                {
                    Peca peao = Tab.RetirarPeca(destino);
                    Posicao posP;
                    if (p.Cor.Equals(Cor.Branca))
                    {
                        posP = new(3, destino.Coluna);
                    }
                    else
                    {
                        posP = new(4, destino.Coluna);
                    }
                    Tab.ColocarPeca(peao, posP);
                    capturadas.Remove(pecaCapturada);
                }
            }
        }

        public void ValidaPosicaoOrigem(Posicao pos)
        {
            Tab.ValidadorPosicao(pos);

            if (Tab.Peca(pos) == null)
            {
                throw new TabuleiroException("N??o h?? pe??a na posi????o de origem escolhida.");
            }
            if (JogadorAtual != Tab.Peca(pos).Cor)
            {
                throw new TabuleiroException("A pe??a de origem escolhida n??o ?? sua.");
            }
            if (!Tab.Peca(pos).ExisteMovimentoValido())
            {
                throw new TabuleiroException("N??o h?? movimentos v??lidos para essa pe??a escolhida.");
            }
        }
        public void ValidarPosicaoDestino(Posicao origem, Posicao destino)
        {
            Tab.ValidadorPosicao(destino);

            if (!Tab.Peca(origem).MovimentoPossivel(destino))
            {
                throw new TabuleiroException("Posi????o de destino ?? inv??lida!");
            }
        }

        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            Peca pecacapturada = ExecutaMovimento(origem, destino);
            if (EstaEmXeque(JogadorAtual))
            {
                DesfazMovimento(origem, destino, pecacapturada);
                throw new TabuleiroException("Voc?? n??o pode se por em xeque!");
            }
            Peca p = Tab.Peca(destino);
            // #JogadaEspecial Promo????o
            if (p is Peao)
            {
                if (p.Cor.Equals(Cor.Branca) && p.Posicao.Linha == 0 || p.Cor.Equals(Cor.Preta) && p.Posicao.Linha == 7)
                {
                    p = Tab.RetirarPeca(destino);
                    pecas.Remove(p);
                    Dama dama = new(Tab, p.Cor);
                    Tab.ColocarPeca(dama, destino);
                    pecas.Add(dama);
                }
            }
            if (EstaEmXeque(Adversaria(JogadorAtual)))
            {
                Xeque = true;
            }
            else
            {
                Xeque = false;
            }
            if (XequeMate(Adversaria(JogadorAtual)))
            {
                Terminada = true;
            }
            else
            {
                Turno++;
                MudaJogador();
            }
            // #JogadaEspecial En Passant
            if (p is Peao && (destino.Linha - 2 == origem.Linha || destino.Linha + 2 == origem.Linha))
            {
                VulneravelEnPassant = p;
            }
            else
            {
                VulneravelEnPassant = null;
            }

        }
        private void MudaJogador()
        {
            if (JogadorAtual.Equals(Cor.Branca))
            {
                JogadorAtual = Cor.Preta;
            }
            else
            {
                JogadorAtual = Cor.Branca;
            }
        }

        public void ColocarNovaPeca(char coluna, int linha, Peca peca)
        {
            Tab.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
            pecas.Add(peca);
        }
        private void ColocarPecas()
        {
            // Brancas
            // Pe??as especiais
            ColocarNovaPeca('a', 1, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('b', 1, new Cavalo(Tab, Cor.Branca));
            ColocarNovaPeca('c', 1, new Bispo(Tab, Cor.Branca));
            ColocarNovaPeca('d', 1, new Dama(Tab, Cor.Branca));
            ColocarNovaPeca('e', 1, new Rei(Tab, Cor.Branca, this));
            ColocarNovaPeca('f', 1, new Bispo(Tab, Cor.Branca));
            ColocarNovaPeca('g', 1, new Cavalo(Tab, Cor.Branca));
            ColocarNovaPeca('h', 1, new Torre(Tab, Cor.Branca));
            // Pe??es
            ColocarNovaPeca('a', 2, new Peao(Tab, Cor.Branca, this));
            ColocarNovaPeca('b', 2, new Peao(Tab, Cor.Branca, this));
            ColocarNovaPeca('c', 2, new Peao(Tab, Cor.Branca, this));
            ColocarNovaPeca('d', 2, new Peao(Tab, Cor.Branca, this));
            ColocarNovaPeca('e', 2, new Peao(Tab, Cor.Branca, this));
            ColocarNovaPeca('f', 2, new Peao(Tab, Cor.Branca, this));
            ColocarNovaPeca('g', 2, new Peao(Tab, Cor.Branca, this));
            ColocarNovaPeca('h', 2, new Peao(Tab, Cor.Branca, this));

            // Pretas
            // Pe??as especiais
            ColocarNovaPeca('a', 8, new Torre(Tab, Cor.Preta));
            ColocarNovaPeca('b', 8, new Cavalo(Tab, Cor.Preta));
            ColocarNovaPeca('c', 8, new Bispo(Tab, Cor.Preta));
            ColocarNovaPeca('d', 8, new Dama(Tab, Cor.Preta));
            ColocarNovaPeca('e', 8, new Rei(Tab, Cor.Preta, this));
            ColocarNovaPeca('f', 8, new Bispo(Tab, Cor.Preta));
            ColocarNovaPeca('g', 8, new Cavalo(Tab, Cor.Preta));
            ColocarNovaPeca('h', 8, new Torre(Tab, Cor.Preta));
            // Pe??es
            ColocarNovaPeca('a', 7, new Peao(Tab, Cor.Preta, this));
            ColocarNovaPeca('b', 7, new Peao(Tab, Cor.Preta, this));
            ColocarNovaPeca('c', 7, new Peao(Tab, Cor.Preta, this));
            ColocarNovaPeca('d', 7, new Peao(Tab, Cor.Preta, this));
            ColocarNovaPeca('e', 7, new Peao(Tab, Cor.Preta, this));
            ColocarNovaPeca('f', 7, new Peao(Tab, Cor.Preta, this));
            ColocarNovaPeca('g', 7, new Peao(Tab, Cor.Preta, this));
            ColocarNovaPeca('h', 7, new Peao(Tab, Cor.Preta, this));

        }
        public HashSet<Peca> PecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in capturadas)
            {
                if (x.Cor.Equals(cor))
                {
                    aux.Add(x);
                }
            }
            return aux;
        }
        public HashSet<Peca> PecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in pecas)
            {
                if (x.Cor.Equals(cor))
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(PecasCapturadas(cor));
            return aux;
        }
        private Cor Adversaria(Cor cor)
        {
            if (cor.Equals(Cor.Branca))
            {
                return Cor.Preta;
            }
            else
            {
                return Cor.Branca;
            }
        }
        private Peca Rei(Cor cor)
        {
            foreach (var peca in PecasEmJogo(cor))
            {
                if (peca is Rei)
                {
                    return peca;
                }
            }
            return null;
        }
        public bool EstaEmXeque(Cor cor)
        {
            Peca R = Rei(cor);
            foreach (Peca peca in PecasEmJogo(Adversaria(cor)))
            {
                bool[,] mat = peca.MovimentosPossiveis();
                if (mat[R.Posicao.Linha, R.Posicao.Coluna])
                {
                    return true;
                }
            }
            return false;
        }
        public bool XequeMate(Cor cor)
        {

            if (!EstaEmXeque(cor))
            {
                return false;
            }
            foreach (Peca x in PecasEmJogo(cor))
            {
                bool[,] movimentosPossiveis = x.MovimentosPossiveis();
                for (int i = 0; i < Tab.Linhas; i++)
                {
                    for (int j = 0; j < Tab.Colunas; j++)
                    {
                        if (movimentosPossiveis[i, j])
                        {
                            Posicao origem = x.Posicao;
                            Posicao destino = new Posicao(i, j);
                            Peca pecaCapturada = ExecutaMovimento(origem, destino);
                            bool testeXeque = EstaEmXeque(cor);
                            DesfazMovimento(origem, destino, pecaCapturada);
                            if (!testeXeque)
                            {
                                return false;
                            }
                        }
                    }
                }
            }

            return true;
        }
    }

}