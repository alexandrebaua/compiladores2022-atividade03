using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Compilador.Lexico;
using Compilador.Sintatico;

namespace Compilador
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void btnExec_Click(object sender, EventArgs e)
        {
            // Limpa a lista de tokens e do resultado sintático.
            this.lstTokens.Items.Clear();
            this.lstSintatico.Items.Clear();

            if (this.rtxtCode.Text.Length == 0)
            {
                MessageBox.Show("Sem dados de entrada!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Cria um vetor com as linhas:
            string[] entrada = this.rtxtCode.Text.Split(new string[] { Environment.NewLine, "\n" }, StringSplitOptions.None);

            if (entrada.Length == 0)
            {
                MessageBox.Show("Sem dados de entrada!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int estado = 0;
            string lexema = String.Empty;
            List<TokenClass> listaTokens = new List<TokenClass>();

            try
            {
                // Percorre as linhas:
                for (int i = 0; i < entrada.Length; i++)
                {
                    // Converte a linha em um vetor de caracteres.
                    char[] chrs = entrada[i].ToCharArray();

                    // Percorre os caracteres da linha buscando por tokens:
                    int j = 0;
                    while (j < chrs.Length)
                    {
                        if (TabelaEstados.AFD[estado] != null && TabelaEstados.AFD[estado].ContainsKey(chrs[j]))
                        {
                            estado = TabelaEstados.AFD[estado][chrs[j]];
                            lexema += chrs[j];
                            j++;
                        }
                        else
                        {
                            if (TabelaEstados.Finais.ContainsKey(estado))
                            {
                                listaTokens.Add(new TokenClass(lexema, TabelaEstados.Finais[estado], i + 1, j));
                                estado = 0;
                                lexema = String.Empty;
                            }
                            else
                            {
                                throw new Exception($"Erro léxico no lexema: '{lexema}{chrs[j]}'");
                            }
                        }
                    }

                    // Necessário para tokens não processados devido ao final de linha
                    if (lexema.Length > 0)
                    {
                        if (TabelaEstados.Finais.ContainsKey(estado))
                        {
                            listaTokens.Add(new TokenClass(lexema, TabelaEstados.Finais[estado], i + 1, j));
                            estado = 0;
                            lexema = String.Empty;
                        }
                        else
                        {
                            throw new Exception($"Erro léxico no lexema: '{lexema}'");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Adiciona à lista os novos tokens encontrados, se existirem:
            foreach (var token in listaTokens)
                this.lstTokens.Items.Add(token);

            try
            {
                // Executa a análise sintática usando a lista de tokens encontrados
                AnalizadorDescidaRecursiva.Verificar(listaTokens, this.lstSintatico);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
