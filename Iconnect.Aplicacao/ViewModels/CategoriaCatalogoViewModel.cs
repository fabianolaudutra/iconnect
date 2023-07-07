using System;

namespace Iconnect.Aplicacao.ViewModels
{
    public class CategoriaCatalogoViewModel
    {
        public string cat_n_codigo { get; set; }
        public string cat_cli_n_codigo { get; set; }
        public string cat_b_ativo { get; set; }
        public string cat_b_tipoLink { get; set; }
        public string cat_b_solicitarEspecialidade { get; set; }
        public string cat_c_nome { get; set; }
        public string cat_c_descricao { get; set; }
        public string cat_c_link { get; set; }
        public string cat_c_imagem { get; set; }
        public Guid cat_c_unique { get; set; }
        public DateTime cat_d_atualizado { get; set; }
        public DateTime cat_d_inclusao { get; set; }
    }
}
