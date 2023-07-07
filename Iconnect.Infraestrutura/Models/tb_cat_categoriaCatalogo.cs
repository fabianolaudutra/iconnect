using Iconnect.Infraestrutura.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Iconnect.Infraestrutura.Models
{
    public class tb_cat_categoriaCatalogo
    {
      
        [Key]
        public int cat_n_codigo { get; set; }
        public int cat_cli_n_codigo { get; set; } 
        public bool cat_b_ativo { get; set; }
        public bool cat_b_tipoLink { get; set; }
        public bool cat_b_solicitarEspecialidade { get; set; }
        public string cat_c_nome { get; set; }
        public string cat_c_descricao { get; set; }
        public string cat_c_link { get; set; }
        public string cat_c_imagem { get; set; }
        public Guid cat_c_unique { get; set; }
        public DateTime cat_d_atualizado { get; set; }
        public DateTime cat_d_inclusao { get; set; }

        public virtual ICollection<tb_scc_subCategoriaCatalogo> tb_scc_subCategoriaCatalogo { get; set; }


        public virtual tb_cli_cliente cat_cli_n_codigoNavigation { get; set; }

    }
}
