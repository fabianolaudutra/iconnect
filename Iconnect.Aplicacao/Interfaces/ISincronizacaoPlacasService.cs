using Iconnect.Infraestrutura.Interfaces;
using Iconnect.Infraestrutura.Models;

namespace Iconnect.Aplicacao.Interfaces
{
    public interface ISincronizacaoPlacasService : IRepositoryBase<tb_sin_sincronizacaoPlacas>
    {
        bool SalvarSincronizacaoPlacasExterna(int cli_n_codigo, string sin_c_controladoras);
        void SalvarSincronizacaoPlacasInterna(int cli_n_codigo, string sin_c_controladoras, int cac_n_codigo);
    }
}