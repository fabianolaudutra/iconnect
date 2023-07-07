using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.ViewModels
{
    public class CategorizacaoEventoViewModel
    {
        public string cev_n_codigo { get; set; }
        public string cev_c_descricao { get; set; }
        public string cev_c_codigoEvento { get; set; }
        public string cev_c_cor { get; set; }
        public DateTime? cev_d_alteracao { get; set; }
        public string cev_c_usuario { get; set; }
        public bool? cev_b_geraAtendimento { get; set; }
        public DateTime? cev_d_modificacao { get; set; }
        public bool? cev_b_utilizaTemporizador { get; set; }
        public int? cev_cev_n_temporizador { get; set; }
        public Guid cev_c_unique { get; set; }
        public DateTime cev_d_atualizado { get; set; }
        public DateTime cev_d_inclusao { get; set; }
        public string buscaSimples { get; set; }

    }
}
