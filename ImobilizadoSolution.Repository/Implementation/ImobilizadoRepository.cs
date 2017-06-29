using ImobilizadoSolution.Domain;
using ImobilizadoSolution.Repository.Contract;

namespace ImobilizadoSolution.Repository.Implementation
{
    public class ImobilizadoRepository : BaseRepository<Imobilizado>, IImobilizadoRepository
    {
            public ImobilizadoRepository(string nomeTabela) : base (nomeTabela)
            {

            }
    }
}
