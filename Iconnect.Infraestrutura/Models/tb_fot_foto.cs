using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_fot_foto
    {
        public tb_fot_foto()
        {
            tb_grf_grupoFamiliar = new HashSet<tb_grf_grupoFamiliar>();
            tb_mor_Moradormor_fot_n_codigoNavigation = new HashSet<tb_mor_Morador>();
            tb_mor_Moradormor_fot_n_documentoNavigation = new HashSet<tb_mor_Morador>();
            tb_pet_pet = new HashSet<tb_pet_pet>();
            tb_pse_prestadorServicopse_fot_n_codigoNavigation = new HashSet<tb_pse_prestadorServico>();
            tb_pse_prestadorServicopse_fot_n_documentoNavigation = new HashSet<tb_pse_prestadorServico>();
            tb_vis_visitantevis_fot_n_codigoNavigation = new HashSet<tb_vis_visitante>();
            tb_vis_visitantevis_fot_n_documentoNavigation = new HashSet<tb_vis_visitante>();
            tb_cli_cliente = new HashSet<tb_cli_cliente>();
        }

        public int fot_n_codigo { get; set; }
        public byte[] fot_c_imagem { get; set; }
        public DateTime? fot_d_modificacao { get; set; }
        public Guid fot_c_unique { get; set; }
        public DateTime fot_d_atualizado { get; set; }
        public DateTime fot_d_inclusao { get; set; }
        public string fot_c_url { get; set; }
        public DateTime? fot_d_upload { get; set; }

        public virtual ICollection<tb_grf_grupoFamiliar> tb_grf_grupoFamiliar { get; set; }
        public virtual ICollection<tb_mor_Morador> tb_mor_Moradormor_fot_n_codigoNavigation { get; set; }
        public virtual ICollection<tb_mor_Morador> tb_mor_Moradormor_fot_n_documentoNavigation { get; set; }
        public virtual ICollection<tb_pet_pet> tb_pet_pet { get; set; }
        public virtual ICollection<tb_pse_prestadorServico> tb_pse_prestadorServicopse_fot_n_codigoNavigation { get; set; }
        public virtual ICollection<tb_pse_prestadorServico> tb_pse_prestadorServicopse_fot_n_documentoNavigation { get; set; }
        public virtual ICollection<tb_vis_visitante> tb_vis_visitantevis_fot_n_codigoNavigation { get; set; }
        public virtual ICollection<tb_vis_visitante> tb_vis_visitantevis_fot_n_documentoNavigation { get; set; }
        public virtual tb_cal_catalogo tb_cal_catalogo { get; set; }
        public virtual ICollection<tb_cli_cliente> tb_cli_cliente { get; set; }
        public virtual tb_cal_catalogo tb_cal_catalogoLogo { get; set; }
    }
}
