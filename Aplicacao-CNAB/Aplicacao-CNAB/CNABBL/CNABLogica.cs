using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Aplicacao_CNAB.CNABBL
{
    public class CnabLogica
    {
        private string _texto = "";

        public string VerificaNumerosETamanhoTexto(string texto, int tamanho, bool obrigatorio)
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

        public string VerificaAlfanumericoETamanhoTexto(string texto, int tamanho, bool obrigatorio)
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

        public string ValidaCodigoBanco(bool retorno) => retorno ? "353" : "033";

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

        public void GeraArquivo(string[] registro, bool statusValidacao)
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