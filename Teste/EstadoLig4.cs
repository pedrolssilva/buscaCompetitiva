using BuscaCompetitiva;
using System;
using System.Collections.Generic;
using System.Text;

namespace Teste {
	public class EstadoLig4 : Estado {
		public const int VAZIO = 0;
		public const int X = 1;
		public const int O = 2;

		public const int LINHAS = 6;
		public const int COLUNAS = 7;

		private readonly int[,] tabuleiro;
		// @@@
		// falta(m) atributo(s) aqui... ;)
		private readonly int vencedor;
		private int jogadorDaVez, hashCode;

		public EstadoLig4(int[,] tabuleiro, int jogadorDaVez) {
			this.tabuleiro = tabuleiro;
			this.jogadorDaVez = jogadorDaVez;
			// @@@
			vencedor = 0;
		}

		public override string ToString() {
			// para poder imprimir a solução completa na tela
			StringBuilder sb = new StringBuilder();
			for (int linha = 0; linha < LINHAS; linha++) {
				if (linha != 0) {
					sb.AppendLine();
					for (int coluna = 0; coluna < COLUNAS; coluna++) {
						if (coluna != 0)
							sb.Append('-');
						sb.Append('-');
					}
					sb.AppendLine();
				}
				for (int coluna = 0; coluna < COLUNAS; coluna++) {
					if (coluna != 0)
						sb.Append('|');
					switch (tabuleiro[linha, coluna]) {
						case X:
							sb.Append('X');
							break;
						case O:
							sb.Append('O');
							break;
						default:
							sb.Append(' ');
							break;
					}
				}
			}
			return sb.ToString();
		}

		public override bool Equals(object obj) {
			if (obj == this) {
				return true;
			}
			EstadoLig4 e = (obj as EstadoLig4);
			if (e == null || e.jogadorDaVez != jogadorDaVez) {
				return false;
			}
			for (int linha = 0; linha < LINHAS; linha++) {
				for (int coluna = 0; coluna < COLUNAS; coluna++) {
					if (e.tabuleiro[linha, coluna] != tabuleiro[linha, coluna]) {
						return false;
					}
				}
			}
			return true;
		}

		public override int GetHashCode() {
			// aqui é necessário que o hash code já tenha sido calculado!!!
			if (hashCode == 0) {
				hashCode = CalcularHashCode();
			}
			return hashCode;
		}

		private int CalcularHashCode() {
			int h = jogadorDaVez * 7919;
			for (int linha = 0; linha < LINHAS; linha++) {
				for (int coluna = 0; coluna < COLUNAS; coluna++) {
					h += ((tabuleiro[linha, coluna] - 1) * (((linha + 1) * COLUNAS) + (coluna + 1)));
				}
			}
			return h;
		}

        // @@@
        // Faltam métodos aqui
        public bool IsCelulaVazia(int linha,int coluna)
        {   
            return (tabuleiro[linha, coluna] == VAZIO);
        }

        public int CalculaVencedor(int[,] tabuleiro)
        {
            int conta = 1;
            //vertical
            for (int col = 0; col < COLUNAS; col++)
            {
                for (int row = 0; row < LINHAS; row++)
                {
                    if (!IsCelulaVazia(row, col))
                    {
                        if ((tabuleiro[col, row] == X) && (tabuleiro[col, row + 1] == X))
                        {
                            conta++;
                            if (conta >= 4)
                                return X;
                        }
                        else if ((tabuleiro[col, row] == O) && (tabuleiro[col, row + 1] == O))
                        {
                            conta++;
                            if (conta >= 4)
                                return O;
                        }
                        else
                        {
                            conta = 1;
                        }
                    }
                }
            }
            //Horizontal
            for (int row = 0; row < COLUNAS; row++)
            {
                for (int col = 0; col < COLUNAS; col++)
                {
                    if (!IsCelulaVazia(row, col))
                    {
                        if ((tabuleiro[col, row] == X) && (tabuleiro[col + 1, row] == X))
                        {
                            conta++;
                            if (conta >= 4)
                                return X;
                        }
                        else if ((tabuleiro[col, row] == O) && (tabuleiro[col + 1, row] == O))
                        {
                            conta++;
                            if (conta >= 4)
                                return O;
                        }
                        else
                        {
                            conta = 1;
                        }
                    }
                }
            }
            //Diagonal debaixo pra cima
            for (int row = 0; row < LINHAS; row++)
            {
                for (int col = 0; col < COLUNAS; col++)
                {
                    if (!IsCelulaVazia(row, col))
                    {
                        for (int i = 0; i + row < LINHAS && col - i >= 0; i++)
                        {
                            if ((tabuleiro[col, row] == X) && (tabuleiro[col - i, row + i] == X))
                            {
                                conta++;
                                if (conta >= 4)
                                    return X;
                            }
                            else if ((tabuleiro[col, row] == O) && (tabuleiro[col - i, row + i] == O))
                            {
                                conta++;
                                if (conta >= 4)
                                    return O;
                            }
                            else
                            {
                                conta = 1;
                            }
                        }
                    }
                }
            }
            //Diagonal de cima pra baixo
            for (int row = 0; row < LINHAS; row++)
                    {
                        for (int col = 0; col < COLUNAS; col++)
                        {
                            if (!IsCelulaVazia(row, col))
                            {
                                for (int i = 0; i + row < LINHAS && col + i < LINHAS; i++)
                                {
                                    if ((tabuleiro[col, row] == X) && (tabuleiro[col + i, row + i] == X))
                                    {
                                        conta++;
                                        if (conta >= 4)
                                            return X;
                                    }
                                    else if ((tabuleiro[col, row] == O) && (tabuleiro[col + i, row + i] == O))
                                    {
                                        conta++;
                                        if (conta >= 4)
                                            return O;
                                    }
                                    else
                                    {
                                        conta = 1;
                                    }
                                }
                            }
                        }
                    }
            return 0;
        }

        public EstadoLig4 MarcarCelula(int linha, int coluna, int jogador)
        {
            int[,] novo = new int[LINHAS, COLUNAS];

            Array.Copy(tabuleiro, novo, LINHAS * COLUNAS);
            novo[linha, coluna] = jogador;

            return new EstadoLig4(novo, jogadorDaVez);
        }

        private int CalcularVazios()
        {
            int vazios = 0;

            // testa cada uma das linhas
            for (int linha = 0; linha < LINHAS; linha++)
            {
                for (int coluna = 0; coluna < COLUNAS; coluna++)
                {
                    if (tabuleiro[linha, coluna] == VAZIO)
                    {
                        vazios++;
                    }
                }
            }

            return vazios;
        }

        public string Descricao {
			get {
				return "Jogo Lig-4";
			}
		}

		public int NumeroMaximoDeTurnos {
			get {
				// impossível existirem mais turnos do que células na matriz! ;)
				return LINHAS * COLUNAS;
			}
		}

		public bool IsTerminal {
			get {
				// @@@
				return true;
			}
		}

		public int JogadorDoTurno {
			get {
				return jogadorDaVez;
			}
		}

		public void AlternarJogadorDoTurno() {
			if (jogadorDaVez == X) {
				jogadorDaVez = O;
			} else {
				jogadorDaVez = X;
			}
		}

		public int Vencedor {
			get {
				return vencedor;
			}
		}

		public int Pontuacao {
			get {
				switch (vencedor) {
					case X:
						if (jogadorDaVez == X) {
							return 1;
						}
						return -1;
					case O:
						if (jogadorDaVez == X) {
							return -1;
						}
						return 1;
					default:
						return 0;
				}
			}
		}
	}
}
