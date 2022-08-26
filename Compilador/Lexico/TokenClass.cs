using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador.Lexico
{
    /// <summary>
    /// Classe de armazenamento das informações de um token.
    /// </summary>
    public class TokenClass
    {
        /// <summary>
        /// Construtor da classe.
        /// </summary>
        /// <param name="lexema">O lexema à armazenar.</param>
        /// <param name="token">O token à armazenar.</param>
        /// <param name="linha">Linha onde foi encontrado.</param>
        /// <param name="posicaoFinal">Posição final do lexema na linha.</param>
        public TokenClass(string lexema, string token, int linha, int posicaoFinal) : this(lexema, token)
        {
            this.Linha = linha;
            this.Inicio = posicaoFinal - lexema.Length + 1;
            this.Final = posicaoFinal;
        }

        /// <summary>
        /// Construtor da classe.
        /// </summary>
        /// <param name="lexema">O lexema à armazenar.</param>
        /// <param name="token">O token à armazenar.</param>
        public TokenClass(string lexema, string token)
        {
            this.Lexema = lexema;
            this.Token = token;
        }

        /// <summary>
        /// Obtém ou define o lexema.
        /// </summary>
        public string Lexema { get; set; }

        /// <summary>
        /// Obtém ou define o token.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Obtém ou define o número da linha onde foi encontrado o lexema.
        /// </summary>
        public int Linha { get; set; } = 0;

        /// <summary>
        /// Obtém ou define a posição inicial onde foi encontrado o lexema na linha.
        /// </summary>
        public int Inicio { get; set; } = 0;

        /// <summary>
        /// Obtém ou define a posição final onde foi encontrado o lexema na linha.
        /// </summary>
        public int Final { get; set; } = 0;

        /// <summary>
        /// Retorna um texto contendo as informações do token armazenado.
        /// </summary>
        public override string ToString()
        {
            if (Linha != 0)
            {
                if (this.Inicio == this.Final)
                    return $"Linha: {this.Linha}, Posição: {this.Inicio}, Token: {this.Token}, Lexema: '{this.Lexema}'";
                else
                    return $"Linha: {this.Linha}, Posição: {this.Inicio}..{this.Final}, Token: {this.Token}, Lexema: '{this.Lexema}'";
            }

            return $"Token: {this.Token}, Lexema: '{this.Lexema}'";
        }
    }
}
