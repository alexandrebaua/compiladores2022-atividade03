using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Compilador.Lexico;

namespace Compilador.Sintatico
{
    /// <summary>
    /// Analisador Sintático Descendente Recursivo
    /// </summary>
    public static class AnalizadorDescidaRecursiva
    {
        private static TokenClass[] lista_tk = null;
        private static int inicial;
        private static int cont, anterior;

        /// <summary>
        /// Executa a verificação sintática utilizando a lista de tokens passada.
        /// </summary>
        /// <param name="listaTokens">A lista de tokens a serem analisados.</param>
        /// <param name="resultado">O ListBox para exibir os resultados da verificação sintática.</param>
        public static void Verificar(List<TokenClass> listaTokens, ListBox resultado)
        {
            // Converte e armazena a lista de tokens recebida em um vetor local:
            lista_tk = listaTokens.ToArray();

            // Inicia as variáveis auxiliares:
            cont = 0;
            anterior = 0;
            
            string msg;
            while(cont < lista_tk.Length)
            {
                inicial = cont;

                if (E()) msg = "OK -> ";
                else msg = "Erro -> ";

                for (int i = inicial; i < cont; i++)
                    msg += $"{lista_tk[i].Token} ";

                resultado.Items.Add(msg);
            }
        }

        private static bool term(string token)
        {
            if (cont >= lista_tk.Length)
                return false;

            return lista_tk[cont++].Token.Equals(token);
        }

        private static bool E1()
        {
            return T();
        }

        private static bool E2()
        {
            return T() && term("MAIS") && E();
        }

        private static bool E()
        {
            anterior = cont;
            if (E1())
                return true;

            cont = anterior;
            return E2();
        }

        private static bool T1()
        {
            return term("INT");
        }

        private static bool T2()
        {
            return term("INT") && term("MULT") && T();
        }

        private static bool T3()
        {
            return term("AP") && E() && term("FP");
        }

        private static bool T()
        {
            anterior = cont;
            if (T1())
                return true;

            cont = anterior;
            if (T2())
                return true;

            cont = anterior;
            return T3();
        }
    }
}
