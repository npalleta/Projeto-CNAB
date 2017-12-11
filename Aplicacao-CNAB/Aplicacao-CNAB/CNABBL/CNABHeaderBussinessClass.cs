using Aplicacao_CNAB.CNABBL;
using System;

namespace Aplicacao_CNAB.CNABHeaderBussinessClass
{
    class CNABHeaderBussinessClass
    {
        Utils utils = new Utils();

        public String EscrevaCodigoRegistro(String CodigoRegistro) => CodigoRegistro;

        public String EscrevaCodigoRemessa(String CodigoRemessa) => CodigoRemessa;

        public String EscrevaLiteralTransmissao(String LiteralTransmissao) => LiteralTransmissao;

        public String EscrevaCodigoServico(String CodigoServico) => CodigoServico;

        public String EscrevaLiteralServico(String LiteralServico) => LiteralServico;

        public String EscrevaCodigoTransmissao(String CodigoTransmissao)
        {
            if (utils.PermiteNumeros(CodigoTransmissao) && CodigoTransmissao.Length == 20)
                return CodigoTransmissao;
            //
            else if (utils.PermiteNumeros(CodigoTransmissao) && CodigoTransmissao.Length < 20)
            {
                CodigoTransmissao.PadLeft(20);
                return CodigoTransmissao;
            }
            else
            {
                Console.WriteLine("Não foi possível definir o Código de Transmissão!");
                return "";
            }
        }

        public String EscrevaNomeCedente(String NomeCedente)
        {
            if (utils.PermiteAlphanumericos(NomeCedente) && NomeCedente.Length == 30)
                return NomeCedente;
            //
            else if (utils.PermiteAlphanumericos(NomeCedente) && NomeCedente.Length < 30)
            {
                NomeCedente.PadLeft(30);
                return NomeCedente;
            }
            else
            {
                Console.WriteLine("Não foi possível definir o Cedente!");
                return "";
            }
        }

        public String EscrevaCodigoBanco(Boolean Retorno)
        {
            String CodigoBanco;
            return CodigoBanco = Retorno == true ? "353" : "033";
        }

        public String EscrevaNomeBanco(String NomeBanco) => NomeBanco;

        public String EscrevaDataGravacao(String DataGravacao)
        {
            if (utils.PermiteNumeros(DataGravacao) && DataGravacao.Length == 6)
                return DataGravacao;
            //
            else if (utils.PermiteNumeros(DataGravacao) && DataGravacao.Length < 6)
            {
                DataGravacao.PadLeft(6);
                return DataGravacao;
            }
            else
            {
                Console.WriteLine("Não foi possível definir a Data de Gravação!");
                return "";
            }
        }

        public String EscrevaZeros(String Zeros) => Zeros;

        public String EscrevaMensagem(String Mensagem)
        {
            if (utils.PermiteAlphanumericos(Mensagem) && Mensagem.Length == 47)
                return Mensagem;
            //
            else if (utils.PermiteAlphanumericos(Mensagem) && Mensagem.Length < 47)
            {
                Mensagem.PadLeft(47);
                return Mensagem;
            }
            else
            {
                Console.WriteLine("Não foi possível definir a Data de Gravação!");
                return "";
            }
        }

        public String EscrevaNumeroVersaoRemessa(String NumeroVersaoRemessa)
        {
            if (utils.PermiteNumeros(NumeroVersaoRemessa) && NumeroVersaoRemessa.Length == 3)
                return NumeroVersaoRemessa;
            //
            else if (utils.PermiteNumeros(NumeroVersaoRemessa) && NumeroVersaoRemessa.Length < 3)
            {
                NumeroVersaoRemessa.PadLeft(3);
                return NumeroVersaoRemessa;
            }
            else
            {
                Console.WriteLine("Não foi possível definir o Número de Versão de Remessa!");
                return "";
            }
        }

        public String EscrevaNumeroSequencialRegistro(String NumSeqReg)
        {
            if (utils.PermiteNumeros(NumSeqReg) && NumSeqReg.Length == 3)
                return NumSeqReg;
            //
            else if (utils.PermiteNumeros(NumSeqReg) && NumSeqReg.Length < 3)
            {
                NumSeqReg.PadLeft(3);
                return NumSeqReg;
            }
            else
            {
                Console.WriteLine("Não foi possível definir o Número Sequencial de Registro!");
                return "";
            }
        }
    }
}
