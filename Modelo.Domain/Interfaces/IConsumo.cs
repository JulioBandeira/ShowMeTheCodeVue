using Modelo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Domain.Interfaces
{
    public interface IConsumo
    {
        void CalcularPlano(PrecoLigacao precoLigacao);
    }
}
