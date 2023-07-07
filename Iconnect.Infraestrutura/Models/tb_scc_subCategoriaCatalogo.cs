using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public class tb_scc_subCategoriaCatalogo
    {        
        public int scc_n_codigo{ get; set; }
        public int scc_cat_n_codigo { get; set; }
        public int scc_cli_n_codigo { get; set; }        
        public bool scc_b_ativo { get; set; }
        public string scc_c_nome { get; set; }
        public string scc_c_imagem { get; set; }
        public Guid scc_c_unique { get; set; }
        public DateTime scc_d_atualizado { get; set; }
        public DateTime scc_d_inclusao { get; set; }        

        public virtual tb_cat_categoriaCatalogo scc_cat_n_codigoNavigation { get; set; }        

        public virtual ICollection<tb_cal_catalogo> tb_cal_catalogo { get; set; } 

    }
}
