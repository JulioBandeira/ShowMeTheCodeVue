using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Services.Interfaces
{
    public interface IConsumoServices
    {
        decimal CalcularConsumo(bool isfalamais, string origem, string destino, int tempo);
    }
}
