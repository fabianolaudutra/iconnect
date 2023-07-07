using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.Interfaces;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Base;
using Iconnect.Infraestrutura.Context;
using Iconnect.Infraestrutura.Models;
using PagedList;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.Services
{
    public class SegurancaService : ISegurancaService
    {
        private IconnectCoreContext context;

        public SegurancaService(IconnectCoreContext context)
        {
            this.context = context;
        }

        public string getCodigoInstalacao()
        {
            try
            {
                int qtdCaracteres = 12;
                string delimitador = "-";
                string novaChave = Guid.NewGuid().ToString("N").ToUpper().Substring(0, qtdCaracteres);

                novaChave = AjustarCodigoInstalacao(qtdCaracteres, delimitador, novaChave.ToCharArray());

                return novaChave;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string getSerial(string codigoInstalacao, int numeroDiasExpiracao)
        {
            try
            {
                if (string.IsNullOrEmpty(codigoInstalacao) || numeroDiasExpiracao == 0)
                    return string.Empty;

                string novaSerial = string.Empty;
                SKGL.SerialKeyConfiguration skm = new SKGL.SerialKeyConfiguration();
                SKGL.Generate gen = new SKGL.Generate(skm);
                skm.Features[0] = true;
                gen.secretPhase = codigoInstalacao;
                novaSerial = gen.doKey(numeroDiasExpiracao);

                return novaSerial;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool IsValid(string codigoInstalacao, string serial)
        {
            try
            {
                SKGL.Validate val = new SKGL.Validate();
                val.secretPhase = codigoInstalacao;
                val.Key = serial;

                if (val.IsValid && !val.IsExpired)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DateTime? getDataCriacao(string codigoInstalacao, string serial)
        {
            try
            {
                SKGL.Validate val = new SKGL.Validate();
                val.secretPhase = codigoInstalacao;
                val.Key = serial;

                if (val.IsValid)
                    return val.CreationDate;
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DateTime? getDataExpiracao(string codigoInstalacao, string serial)
        {
            try
            {
                SKGL.Validate val = new SKGL.Validate();
                val.secretPhase = codigoInstalacao;
                val.Key = serial;

                if (val.IsValid)
                    return val.ExpireDate;
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string AjustarCodigoInstalacao(int length, string str, char[] newKey)
        {
            string newKeyStr = "";
            int k = 0;
            for (int i = 0; i < length; i++)
            {
                for (k = i; k < 4 + i; k++)
                {
                    newKeyStr += newKey[k];
                }
                if (k == length)
                {
                    break;
                }
                else
                {
                    i = (k) - 1;
                    newKeyStr += str;
                }
            }
            return newKeyStr;
        }
    }
}
