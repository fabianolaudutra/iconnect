using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Interfaces;
using Iconnect.Infraestrutura.Models;


namespace Iconnect.Aplicacao.Interfaces
{
    public interface IFotoService : IRepositoryBase<tb_fot_foto>
    {
        public string uploadFoto(string id, byte[] imageByte);
        public RetornoFotoViewModel GetFoto(int id);
        public bool DeletarFoto(int id);
    }
}