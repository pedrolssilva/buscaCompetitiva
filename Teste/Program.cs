using System;
using System.Collections.Generic;
using System.Text;
using BuscaCompetitiva;

namespace Teste {
	class Program {
		// apenas para encurtar os textos abaixo ;)
		public const int X = EstadoTicTacToe.X;
		public const int O = EstadoTicTacToe.O;

		static void Main(string[] args) {
			int contadorDeJogadas = 0;

			Estado estadoDoTabuleiro = new EstadoLig4(new int[,] {
				{ 0, 0, 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 0, 0, 0, 0 }
			}, X);
            /*
			Estado estadoDoTabuleiro = new EstadoTicTacToe(new int[,] {
				{ 0, 0, 0 },
				{ 0, 0, 0 },
				{ 0, 0, 0 }
			}, X);*/

			// exemplo de resistência (X vai perder, mas não desiste logo de cara)
			//Estado estadoDoTabuleiro = new EstadoTicTacToe(new int[,] {
			//	{ 0, O, 0 },
			//	{ 0, 0, O },
			//	{ X, X, O }
			//}, X);

			// mais um empate (ambos X e O são jogadores difíceis... experimente
			// trocar um deles para fácil)
			//Estado estadoDoTabuleiro = new EstadoTicTacToe(new int[,] {
			//	{ O, 0, 0 },
			//	{ 0, O, 0 },
			//	{ X, 0, 0 }
			//}, X);

			Jogador jogadorX = new JogadorTicTacToeAleatorio(X);
			Jogador jogadorO = new JogadorTicTacToeDificil(O);

			// apenas para debug
			Minimax.UtilizarPodaAlphaBeta = true;
			Minimax.EstadosAvaliados = 0;

			while (estadoDoTabuleiro.IsTerminal == false) {
				contadorDeJogadas++;
				Console.WriteLine("Jogada " + contadorDeJogadas);

				Jogador jogador;
				if (estadoDoTabuleiro.JogadorDoTurno == EstadoTicTacToe.X) {
					jogador = jogadorX;
				} else {
					jogador = jogadorO;
				}

				Console.WriteLine("Vez de " + jogador.Nome);

				estadoDoTabuleiro = jogador.EfetuarJogada(estadoDoTabuleiro);

				Console.WriteLine(estadoDoTabuleiro);

				if (estadoDoTabuleiro.IsTerminal == false) {
					estadoDoTabuleiro.AlternarJogadorDoTurno();
				}

				Console.WriteLine();
				Console.WriteLine();
			}

			Console.WriteLine("Total de estados avaliados: " + Minimax.EstadosAvaliados);

			switch (estadoDoTabuleiro.Vencedor) {
				case EstadoTicTacToe.X:
					Console.WriteLine("Vencedor: " + jogadorX.Nome);
					break;
				case EstadoTicTacToe.O:
					Console.WriteLine("Vencedor: " + jogadorO.Nome);
					break;
				default:
					Console.WriteLine("Empate!");
					break;
			}

			Console.ReadKey();
		}
	}
}
