using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.Interfaces
{
    public interface ISegurancaService
    {
        public string getCodigoInstalacao();
        public string getSerial(string codigoInstalacao, int numeroDiasExpiracao);
        public  bool IsValid(string codigoInstalacao, string serial);
        public  DateTime? getDataCriacao(string codigoInstalacao, string serial);
        public  DateTime? getDataExpiracao(string codigoInstalacao, string serial);
        public string AjustarCodigoInstalacao(int length, string str, char[] newKey);
    }
}
