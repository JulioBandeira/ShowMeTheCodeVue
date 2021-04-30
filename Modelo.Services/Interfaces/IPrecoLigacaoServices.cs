using Modelo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Services.Interfaces
{
    public interface IPrecoLigacaoServices
    {
        List<PrecoLigacao> ListaPrecosLigacoes();
    }
}
