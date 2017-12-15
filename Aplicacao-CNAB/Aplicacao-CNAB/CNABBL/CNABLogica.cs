using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Aplicacao_CNAB.CNABBL
{
    public class CnabLogica
    {
        private string _texto = "";

        public string ValidaNumerosEPreenchimentoEsquerda(string texto, int tamanho, bool obrigatorio)
        {
            try
            {
                if (texto != null)
                {
                    if (texto != "" && obrigatorio)
                    {
                        if (Regex.IsMatch(texto, "^[0-9]*$") == false)
                            _texto = "Err";
                        //
                        else if (texto.Length == tamanho)
                            _texto = texto;
                        //
                        else if (texto.Length < tamanho)
                            _texto = texto.PadLeft(tamanho, '0');
                    }
                    else if (!obrigatorio)
                        _texto = texto.PadLeft(tamanho, '0');
                    //
                    else
                        _texto = "Err";
                }
                else
                    _texto = "Err";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            //
            return _texto;
        }

        public string ValidaAlfanumericoEPreenchimentoDireita(string texto, int tamanho, bool obrigatorio)
        {
            try
            {
                if (texto != null)
                {
                    if (texto != "" && obrigatorio)
                    {
                        if (Regex.IsMatch(texto, "^[a-zA-Z0-9]*$") == false)
                            _texto = "Err";
                        //
                        else if (texto.Length == tamanho)
                            _texto = texto;
                        //
                        else if (texto.Length < tamanho)
                            _texto = texto.PadRight(tamanho);
                    }
                    else if (!obrigatorio)
                        _texto = texto.PadRight(tamanho);
                    //
                    else
                        _texto = "Err";
                }
                else
                    _texto = "Err";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            //
            return _texto;
        }

        public bool EmiteErroPreenchimento(string str)
        {
            var flag = true;
            try
            {
                if (string.IsNullOrEmpty(str) || string.Equals(str, "Err"))
                    flag = false;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return flag;
        }

        public string RetornaValorComboBox(string str, string val)
        {
            return string.IsNullOrEmpty(str) ? val : str;
        }

        public string GeraRandomico()
        {
            const int tamanho = 10;
            var randomico = string.Empty;
            for (var i = 0; i < tamanho; i++)
            {
                var random = new Random();
                var codigo = Convert.ToInt32(random.Next(48, 122).ToString());

                if (codigo >= 48 && codigo <= 57 || codigo >= 97 && codigo <= 122)
                {
                    var _char = ((char)codigo).ToString();
                    if (!randomico.Contains(_char))
                    {
                        randomico += _char;
                    }
                    else
                    {
                        i--;
                    }
                }
                else
                {
                    i--;
                }
            }
            return randomico;
        }

        public int GeraNumerorRandomico(int min, int max)
        {
            var random = new Random();
            return random.Next(min, max);
        }

        public void GeraArquivo(bool statusValidacao, params string[] registro)
        {
            try
            {
                if (!statusValidacao) return;
                var folderBrowserDialog = new FolderBrowserDialog
                {
                    Description = @"Selecione a pasta onde será criado o arquivo:"
                };
                var showDialog = folderBrowserDialog.ShowDialog();
                //
                if (showDialog != DialogResult.OK) return;
                var nomeArquivo = "CNAB_" + GeraRandomico() + ".txt";
                var diretorio = Path.Combine(folderBrowserDialog.SelectedPath, nomeArquivo);
                File.WriteAllLines(diretorio, registro);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }
    }
}