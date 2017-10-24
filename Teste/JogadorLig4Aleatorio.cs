using BuscaCompetitiva;
using System;
using System.Collections.Generic;
using System.Text;

namespace Teste {
	public class JogadorLig4Aleatorio : JogadorLig4 {
		public JogadorLig4Aleatorio(int id) : base(id) {
		}

		public override Estado EfetuarJogada(Estado estadoAtual) {
			// o jogador aleatório não utiliza o minimax...
			// apenas adiciona a peça na em uma coluna aleatória (e vazia)

			EstadoLig4 atual = (estadoAtual as EstadoLig4);

			// @@@

			return null;
		}
	}
}
