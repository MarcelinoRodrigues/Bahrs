using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bahrsDB.Services.Enum
{
    [Serializable]
    public enum Pagina : int
    {
        Departamento = 0,
        Funcionario = 1,
        Estacionamento = 2,
        Produto = 3,
        Vendedor = 4,
        Estoque = 5,
        Vagas = 6,
        Veiculo = 7
    }
}
