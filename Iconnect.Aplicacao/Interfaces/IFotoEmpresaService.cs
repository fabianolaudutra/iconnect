using Iconnect.Infraestrutura.Interfaces;
using Iconnect.Infraestrutura.Models;

namespace Iconnect.Aplicacao.Interfaces
{
    public interface IFotoEmpresaService : IRepositoryBase<tb_fem_fotoEmpresa>
    {
        public string uploadFoto(string id, byte[] imageByte);
        public byte[] GetFoto(int id);
        public bool DeletarFoto(int id);


    }
}
