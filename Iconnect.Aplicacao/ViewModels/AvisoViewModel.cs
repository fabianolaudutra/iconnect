using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.ViewModels
{
    public class AvisoViewModel
    {
        public string avi_n_codigo { get; set; }
        public string avi_c_titulo { get; set; }
        public string avi_c_descricao { get; set; }
        public string avi_d_inicio { get; set; }
        public string avi_d_fim { get; set; }
        public string avi_ace_n_codigo { get; set; }
        public string avi_emp_n_codigo { get; set; }
        public string avi_ope_c_enviarPara { get; set; }
        public string avi_c_status { get; set; }
        public string avi_d_alteracao { get; set; }
        public string avi_c_usuario { get; set; }
        public string avi_d_modificacao { get; set; }
        public string avi_c_unique { get; set; }
        public string avi_d_atualizado { get; set; }
        public string avi_d_inclusao { get; set; }
        public string NomeEmpresa { get; set; }
        public string[] OperadoresSelecionados { get; set; }
        public string buscaSimples { get; set; }
        public DateTime? data_inicio { get; set; }
        public DateTime? data_fim { get; set; }
    }
}