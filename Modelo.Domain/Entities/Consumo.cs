using Modelo.Domain.Enums;
using Modelo.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Domain.Entities
{
    public class Consumo : IConsumo
    {
        public PrecoLigacao ObjPrecoLigacao { get; set; }

        public bool IsFaleMais { get; set; }

        public DateTime Tempo { get; set; }

        public EnumPlanoFaleMais PlanoFaleMaisEnum { get; set; }

        public void CalcularPlano(PrecoLigacao precoLigacao)
        {
            if (PlanoFaleMaisEnum == EnumPlanoFaleMais.PlanoFalaMais30 && Tempo.Minute > 30 && IsFaleMais == false)
            {
                var calculo = ObjPrecoLigacao.Valor * Tempo.Minute;
            }
                throw new NotImplementedException();
        }
    }
}
