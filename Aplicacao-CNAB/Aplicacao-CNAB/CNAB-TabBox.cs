using System;
using System.Collections;
using System.Windows.Forms;
using Aplicacao_CNAB.CNABBL;

namespace Aplicacao_CNAB
{
    public partial class CnabTabBox : Form
    {
        private readonly CnabLogica _logica;
        private bool _validacaoGeraRegHeader;
        private const string MensagemErro = "Existe(m) preenchimento(s) indevido(s) ou campo(s) vazio(s)!";

        public CnabTabBox()
        {
            InitializeComponent();
            _logica = new CnabLogica();
        }

        private bool AtivaRadioButton()
        {
            var retorno = radioButton1.Checked;
            return retorno;
        }

        public string[] GeraRegistroHeader()
        {
            var texto = "";
            //
            try
            {
                var conteudo = new ArrayList
                {
                    txtbox1.Text,
                    txtbox2.Text,
                    txtbox3.Text,
                    txtbox4.Text,
                    txtbox5.Text,
                    _logica.VerificaNumerosETamanhoTexto(txtbox6.Text, 20, true),
                    _logica.VerificaAlfanumericoETamanhoTexto(txtbox7.Text, 30, true),
                    _logica.ValidaCodigoBanco(AtivaRadioButton()),
                    txtbox8.Text,
                    txtbox9.Text.Replace("/", ""),
                    txtbox10.Text,
                    _logica.VerificaAlfanumericoETamanhoTexto(txtbox11.Text, 47, false),
                    _logica.VerificaAlfanumericoETamanhoTexto(txtbox12.Text, 47, false),
                    _logica.VerificaAlfanumericoETamanhoTexto(txtbox13.Text, 47, false),
                    _logica.VerificaAlfanumericoETamanhoTexto(txtbox14.Text, 47, false),
                    _logica.VerificaAlfanumericoETamanhoTexto(txtbox15.Text, 47, false),
                    _logica.VerificaAlfanumericoETamanhoTexto(txtbox16.Text, 40, false),
                    _logica.VerificaNumerosETamanhoTexto(txtbox17.Text, 3, true),
                    txtbox18.Text
                };
                foreach (string campos in conteudo)
                {
                    _validacaoGeraRegHeader = _logica.EmiteErroPreenchimento(campos);
                    if (_validacaoGeraRegHeader) texto += campos;
                    else
                    {
                        MessageBox.Show(MensagemErro, @"Problema no preenchimento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        _validacaoGeraRegHeader = false;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return new[] { texto };
        }

        private void bt1_Click_1(object sender, EventArgs e)
        {
            _logica.GeraArquivo(GeraRegistroHeader(), _validacaoGeraRegHeader);
        }
    }
}