using Iconnect.Infraestrutura.Interfaces;
using Iconnect.Infraestrutura.Models;

namespace Iconnect.Aplicacao.Interfaces
{
    public interface IFotoDependenciaService : IRepositoryBase<tb_ftd_fotoDependencia>
    {
        public string uploadFoto(string id, byte[] imageByte);
        public byte[] GetFoto(int id);
        public bool DeletarFoto(int id);
    }
}
