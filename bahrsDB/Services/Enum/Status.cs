using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bahrsDB.Services.Enum
{
    [Serializable]
    public enum Status : byte
    {
        Ativo = 0,
        Desativado = 1
    }
}
