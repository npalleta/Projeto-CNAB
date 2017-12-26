using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace Aplicacao_CNAB.CNABBL
{
    public class CnabLogica
    {
        private string _texto = string.Empty;

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

        public static int GeraNumerosRandomicamente(int qtdNumeros)
        {
            Thread.Sleep(1);
            //
            var numeros = new List<int>();
            for (var i = 1; i < qtdNumeros; i++)
                numeros.Add(i);

            numeros.Embaralhar();
            return int.Parse(string.Join(",", numeros).Replace(",", "")); ;
        }

        public string GeraNomeArquivo() => $"CNAB_{DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss", CultureInfo.InvariantCulture)}.txt";

        public string GeraNumerosRandomicos(int min, int max)
        {
            var random = new Random();
            Thread.Sleep(1);
            return random.Next(min, max).ToString();
        }

        public int GeraArquivo(bool statusValidacao, string[] registroHeader, string[] registroMoviment, string[] registroMovimentMsg)
        {
            var numVerificador = 0;
            //
            try
            {
                if (statusValidacao)
                {
                    var folderBrowserDialog = new FolderBrowserDialog
                    {
                        Description = @"Selecione a pasta onde será criado o arquivo:"
                    };
                    var showDialog = folderBrowserDialog.ShowDialog();
                    //
                    if (showDialog == DialogResult.OK)
                    {
                        var diretorio = Path.Combine(folderBrowserDialog.SelectedPath, GeraNomeArquivo());
                        var arquivo = registroHeader.Concat(registroMoviment).Concat(registroMovimentMsg);
                        // var nomeArquivo = "CNAB_" + GeraRandomico() + ".txt";
                        File.WriteAllLines(diretorio, arquivo);
                    }
                    else if (showDialog == DialogResult.Cancel)
                    {
                        var result = MessageBox.Show(@"Você realmente deseja cancelar a geração do CNAB?", @"Cancela Geração - Arquivo CNAB", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        //
                        switch (result)
                        {
                            case DialogResult.No:
                                numVerificador = 1;
                                break;
                            case DialogResult.Yes:
                                numVerificador = 2;
                                break;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return numVerificador;
        }

        public string[] TransformaMatrizEmListas(List<string[]> matriz) => matriz.SelectMany(listas => listas).ToArray();

        public string ConverteRegistros(string[] registros) => registros.Aggregate(string.Empty, (texto, registro) => texto + (registro + "\n"));

        public bool IsNullOrEmpty(List<string[]> arrStr)
        {
            var flag = arrStr == null || arrStr.Count < 1;
            return flag;
        }
    }
}

internal static class Extension
{
    public static IList<T> Embaralhar<T>(this IList<T> list)
    {
        var random = new Random();
        //
        for (var i = 0; i < list.Count; i++)
        {
            var indice = random.Next(list.Count);
            var obj = list[indice];
            //list[indice] = list[i];
            list[i] = obj;
        }
        return list;
    }
}