using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class vw_proprietario
    {
        public int pro_n_codigo { get; set; }
        public string pro_c_nome { get; set; }
        public string pro_c_email { get; set; }
        public string pro_c_observacao { get; set; }
        public int? pro_ace_n_codigo { get; set; }
        public DateTime? pro_d_dataNascimento { get; set; }
        public string pro_c_rg { get; set; }
        public string pro_c_cpf { get; set; }
        public string pro_c_telefone { get; set; }
        public string pro_c_celular { get; set; }
        public string pro_c_email2 { get; set; }
        public string pro_c_rua { get; set; }
        public string pro_c_numero { get; set; }
        public string pro_c_complemento { get; set; }
        public string pro_c_bairro { get; set; }
        public string pro_c_cep { get; set; }
        public int? pro_cid_n_codigo { get; set; }
        public int? pro_est_n_codigo { get; set; }
        public DateTime? pro_d_alteracao { get; set; }
        public string pro_c_usuario { get; set; }
        public DateTime? pro_d_modificacao { get; set; }
        public string pro_c_cargo { get; set; }
        public int cid_n_codigo { get; set; }
        public string cid_n_ibge { get; set; }
        public string cid_c_nome { get; set; }
        public string cid_c_estado { get; set; }
        public int? cid_est_n_codigo { get; set; }
        public int est_n_codigo { get; set; }
        public string est_c_descricao { get; set; }
        public string est_c_sigla { get; set; }
    }
}
