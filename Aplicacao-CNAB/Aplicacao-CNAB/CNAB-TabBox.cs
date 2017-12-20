using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using Aplicacao_CNAB.CNABBL;

namespace Aplicacao_CNAB
{
    public partial class CnabTabBox : Form
    {
        private readonly CnabLogica _logica;
        private int _numSeqReg;
        private bool _validacaoGeraRegistro;
        private readonly List<string[]> _listaRegistroMovimento;
        private const string MensagemErro = "Existe(m) preenchimento(s) indevido(s) ou campo(s) vazio(s)!";

        public CnabTabBox()
        {
            InitializeComponent();
            _logica = new CnabLogica();
            _numSeqReg = 1;
            _validacaoGeraRegistro = true;
            _listaRegistroMovimento = new List<string[]>();
        }

        private string[] GeraRegistroHeader()
        {
            var texto = string.Empty;
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
                    _logica.ValidaNumerosEPreenchimentoEsquerda(txtbox6.Text, 20, false),
                    _logica.ValidaAlfanumericoEPreenchimentoDireita(txtbox7.Text, 30, false),
                    AtivaRadioButtonRegHeader(),
                    txtbox8.Text,
                    txtbox9.Value.ToString("dd/MM/yy").Replace("/", ""),
                    txtbox10.Text,
                    _logica.ValidaAlfanumericoEPreenchimentoDireita(txtbox11.Text, 47, false),
                    _logica.ValidaAlfanumericoEPreenchimentoDireita(txtbox12.Text, 47, false),
                    _logica.ValidaAlfanumericoEPreenchimentoDireita(txtbox13.Text, 47, false),
                    _logica.ValidaAlfanumericoEPreenchimentoDireita(txtbox14.Text, 47, false),
                    _logica.ValidaAlfanumericoEPreenchimentoDireita(txtbox15.Text, 47, false),
                    _logica.ValidaAlfanumericoEPreenchimentoDireita(txtbox16.Text, 40, false),
                    _logica.ValidaNumerosEPreenchimentoEsquerda(txtbox17.Text, 3, false),
                    txtbox18.Text
                };
                //
                foreach (string campos in conteudo)
                {
                    // _validacaoGeraRegistro = _logica.EmiteErroPreenchimento(campos);
                    _validacaoGeraRegistro = true;
                    if (_validacaoGeraRegistro) texto += campos;
                    else
                    {
                        MessageBox.Show(MensagemErro, @"Problema no preenchimento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        _validacaoGeraRegistro = false;
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

        private string[] GeraRegistroMovimento(int numLinhas)
        {
            var texto = new List<string>();
            var linha = string.Empty;
            //
            try
            {
                for (var i = 0; i < numLinhas; i++)
                {
                    // var randomicoNossoNum = new Random().Next(0, 100000);
                    // var randomicoSeuNum = new Random().Next(0, 10000000);
                    var conteudo = new ArrayList
                    {
                        txtbox19.Text,
                        RetornaCheckBoxInscricaoCedente(),
                        _logica.ValidaNumerosEPreenchimentoEsquerda(txtbox20.Text, 14, false),
                        _logica.ValidaNumerosEPreenchimentoEsquerda(txtbox21.Text, 4, false),
                        _logica.ValidaNumerosEPreenchimentoEsquerda(txtbox22.Text, 8, false),
                        _logica.ValidaNumerosEPreenchimentoEsquerda(txtbox23.Text, 8, false),
                        _logica.ValidaAlfanumericoEPreenchimentoDireita(txtbox24.Text, 25, false),
                        _logica.ValidaNumerosEPreenchimentoEsquerda(txtbox25.Text + _logica.GeraNumerosRandomicos(0, 100000), 8, false),
                        txtbox26.Value.ToString("dd/MM/yy").Replace("/", ""),
                        txtbox27.Text,
                        _logica.ValidaNumerosEPreenchimentoEsquerda(txtbox28.Text, 1, false),
                        _logica.ValidaNumerosEPreenchimentoEsquerda(txtbox29.Text, 4, false),
                        _logica.ValidaNumerosEPreenchimentoEsquerda(txtbox30.Text, 2, false),
                        _logica.ValidaNumerosEPreenchimentoEsquerda(txtbox31.Text, 13, false),
                        txtbox32.Text,
                        txtbox33.Value.ToString("dd/MM/yy").Replace("/", ""),
                        _logica.RetornaValorComboBox(txtbox34.Text, "0"),
                        _logica.RetornaValorComboBox(txtbox35.Text, "01"),
                        _logica.ValidaNumerosEPreenchimentoEsquerda(txtbox36.Text + _logica.GeraNumerosRandomicos(0, 10000000), 10, false),
                        txtbox37.Value.ToString("dd/MM/yy").Replace("/", ""),
                        _logica.ValidaNumerosEPreenchimentoEsquerda(txtbox38.Text, 13, false),
                        AtivaRadioButtonRegMovimento(),
                        _logica.ValidaNumerosEPreenchimentoEsquerda(txtbox39.Text, 5, false),
                        _logica.RetornaValorComboBox(txtbox40.Text, "01"),
                        txtbox41.Text,
                        txtbox42.Value.ToString("dd/MM/yy").Replace("/", ""),
                        _logica.ValidaNumerosEPreenchimentoEsquerda(txtbox43.Text, 2, false),
                        _logica.RetornaValorComboBox(txtbox44.Text, "00"),
                        _logica.ValidaNumerosEPreenchimentoEsquerda(txtbox45.Text, 13, false),
                        txtbox46.Value.ToString("dd/MM/yy").Replace("/", ""),
                        _logica.ValidaNumerosEPreenchimentoEsquerda(txtbox47.Text, 13, false),
                        _logica.ValidaNumerosEPreenchimentoEsquerda(txtbox48.Text, 13, false),
                        _logica.ValidaNumerosEPreenchimentoEsquerda(txtbox49.Text, 13, false),
                        RetornaCheckBoxTipoInscricaoSacado(),
                        _logica.ValidaNumerosEPreenchimentoEsquerda(txtbox50.Text, 14, false),
                        _logica.ValidaAlfanumericoEPreenchimentoDireita(txtbox51.Text, 40, false),
                        _logica.ValidaAlfanumericoEPreenchimentoDireita(txtbox52.Text, 40, false),
                        _logica.ValidaAlfanumericoEPreenchimentoDireita(txtbox53.Text, 12, false),
                        _logica.ValidaNumerosEPreenchimentoEsquerda(txtbox54.Text, 5, false),
                        _logica.ValidaNumerosEPreenchimentoEsquerda(txtbox55.Text, 3, false),
                        _logica.ValidaAlfanumericoEPreenchimentoDireita(txtbox56.Text, 15, false),
                        _logica.ValidaAlfanumericoEPreenchimentoDireita(txtbox57.Text, 2, false),
                        _logica.ValidaAlfanumericoEPreenchimentoDireita(txtbox58.Text, 30, false),
                        txtbox59.Text,
                        _logica.ValidaNumerosEPreenchimentoEsquerda(txtbox60.Text, 1, false),
                        _logica.ValidaNumerosEPreenchimentoEsquerda(txtbox61.Text, 2, false),
                        txtbox62.Text,
                        _logica.ValidaNumerosEPreenchimentoEsquerda(txtbox63.Text, 2, false),
                        txtbox64.Text,
                        _logica.ValidaNumerosEPreenchimentoEsquerda(GeraNumeroSeqRegistro(_numSeqReg + 1), 6, false)
                    };
                    //
                    foreach (string campos in conteudo)
                    {
                        // _validacaoGeraRegistro = _logica.EmiteErroPreenchimento(campos);
                        _validacaoGeraRegistro = true;
                        if (_validacaoGeraRegistro) linha += campos;
                        else
                        {
                            MessageBox.Show(MensagemErro, @"Problema no preenchimento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            _validacaoGeraRegistro = false;
                            break;
                        }
                    }
                    texto.Add(linha);
                    linha = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return texto.ToArray();
        }

        private string[] GeraRegistroMovimentoMsg()
        {
            var texto = string.Empty;
            //
            try
            {
                var conteudo = new ArrayList
                {
                    _logica.ValidaNumerosEPreenchimentoEsquerda(txtbox66.Text, 1, false),
                    txtbox67.Text,
                    _logica.ValidaNumerosEPreenchimentoEsquerda(txtbox68.Text, 4, false),
                    _logica.ValidaNumerosEPreenchimentoEsquerda(txtbox69.Text, 8, false),
                    _logica.ValidaNumerosEPreenchimentoEsquerda(txtbox70.Text, 8, false),
                    txtbox71.Text,
                    _logica.ValidaNumerosEPreenchimentoEsquerda(txtbox72.Text, 2, false),
                    _logica.ValidaAlfanumericoEPreenchimentoDireita(txtbox73.Text, 50, false),
                    txtbox74.Text,
                    _logica.ValidaAlfanumericoEPreenchimentoDireita(txtbox75.Text, 1, false),
                    _logica.ValidaNumerosEPreenchimentoEsquerda(txtbox76.Text, 2, false),
                    txtbox77.Text,
                    _logica.ValidaNumerosEPreenchimentoEsquerda(Convert.ToString(_numSeqReg + 1), 6, false)
                };
                //
                foreach (string campos in conteudo)
                {
                    // _validacaoGeraRegistro = _logica.EmiteErroPreenchimento(campos);
                    _validacaoGeraRegistro = true;
                    if (_validacaoGeraRegistro) texto += campos;
                    else
                    {
                        MessageBox.Show(MensagemErro, @"Problema no preenchimento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        _validacaoGeraRegistro = false;
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

        private void CnabTabBox_Load(object sender, EventArgs e)
        {
            txtbox9.Text = $@"{DateTime.Now.Date:dd/MM/yyyy}";
            txtbox26.Text = $@"{DateTime.Now.Date:dd/MM/yyyy}";
            txtbox33.Text = $@"{DateTime.Now.Date:dd/MM/yyyy}";
            txtbox37.Text = $@"{DateTime.Now.Date:dd/MM/yyyy}";
            txtbox42.Text = $@"{DateTime.Now.Date:dd/MM/yyyy}";
            txtbox46.Text = $@"{DateTime.Now.Date:dd/MM/yyyy}";
        }

        private string GeraNumeroSeqRegistro(int incremento)
        {
            _numSeqReg = incremento;
            return _numSeqReg.ToString();
        }

        private string AtivaRadioButtonRegHeader() => radioButton1.Checked ? "033" : "353";

        private string AtivaRadioButtonRegMovimento() => radioButton3.Checked ? "033" : "353";

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!CheckBox1.Checked) return;
            CheckBox1.Checked = true;
            CheckBox1.Enabled = false;
            CheckBox2.Checked = false;
            CheckBox2.Enabled = true;
        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (!CheckBox2.Checked) return;
            CheckBox2.Checked = true;
            CheckBox2.Enabled = false;
            CheckBox1.Checked = false;
            CheckBox1.Enabled = true;
        }

        private string RetornaCheckBoxInscricaoCedente() => CheckBox1.Checked ? "01" : "02";

        private void CheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (!CheckBox3.Checked) return;
            CheckBox3.Checked = true;
            CheckBox3.Enabled = false;
            CheckBox4.Checked = false;
            CheckBox4.Enabled = true;
        }

        private void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (!CheckBox4.Checked) return;
            CheckBox4.Checked = true;
            CheckBox4.Enabled = false;
            CheckBox3.Checked = false;
            CheckBox3.Enabled = true;
        }

        private string RetornaCheckBoxTipoInscricaoSacado() => CheckBox3.Checked ? "01" : "02";

        private int GeraMinLinhaRegMov(string str) => string.IsNullOrEmpty(str.Trim('0')) ? 1 : int.Parse(str.TrimStart('0'));

        private void txtbox80_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && (((TextBox)sender).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void bt1_Click(object sender, EventArgs e)
        {
            //
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            try
            {
                if (_logica.IsNullOrEmpty(_listaRegistroMovimento))
                {
                    _numSeqReg = 1;
                    _logica.GeraArquivo(_validacaoGeraRegistro, GeraRegistroHeader(), GeraRegistroMovimento(1), GeraRegistroMovimentoMsg());
                    txtbox80.Text = string.Empty;
                }
                else
                {
                    var listaLinhasRegMov = _logica.TransformaMatrizEmListas(_listaRegistroMovimento);
                    var flag = _logica.GeraArquivo(_validacaoGeraRegistro, GeraRegistroHeader(), listaLinhasRegMov, GeraRegistroMovimentoMsg());
                    if (!flag)
                    {
                        return;
                    }
                    else
                    {
                        _numSeqReg = 1;
                        _listaRegistroMovimento.Clear();
                        txtbox80.Text = string.Empty;
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            _listaRegistroMovimento.Add(GeraRegistroMovimento(GeraMinLinhaRegMov(txtbox80.Text)));
            MessageBox.Show(@"Linha(s) adicionada(s) com sucesso!", @"Registro Movimento", MessageBoxButtons.OK, MessageBoxIcon.None);
            txtbox80.Text = string.Empty;
        }
    }
}