using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_pro_proprietario
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
        public Guid pro_c_unique { get; set; }
        public DateTime pro_d_atualizado { get; set; }
        public DateTime pro_d_inclusao { get; set; }
        public bool? pro_b_tipoGaren { get; set; }

        public virtual tb_ace_acesso pro_ace_n_codigoNavigation { get; set; }
        public virtual tb_cid_cidade pro_cid_n_codigoNavigation { get; set; }
        public virtual tb_est_estado pro_est_n_codigoNavigation { get; set; }
    }
}
