using System;

namespace Iconnect.Aplicacao.ViewModels
{
    public class UsuarioAppViewModel
    {
        public string usu_n_codigo { get; set; }
        public string usu_c_email { get; set; }
        public string usu_c_rg { get; set; }
        public string usu_c_telefone { get; set; }
        public string usu_c_senha { get; set; }
        public string usu_mor_n_codigo { get; set; }
        public string usu_c_nome { get; set; }
        public string usu_b_liberado { get; set; }
        public string usu_c_condominio { get; set; }
        public string usu_d_dataInclusao { get; set; }
        public string usu_d_modificacao { get; set; }
        public string usu_d_atualizado { get; set; }
        public string usu_d_inclusao { get; set; }
        public DateTime dateOrder { get; set; }
        public string NomeMorador { get; set; }
        public string NomeCliente { get; set; }
        public string mor_usu_c_cpf { get; set; }
        public string usu_c_codigoRecuperacao { get; set; }
    }
}
