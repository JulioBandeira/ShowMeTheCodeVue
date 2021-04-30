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

        public int Tempo { get; set; }

        public EnumPlanoFaleMais PlanoFaleMaisEnum { get; set; }

        public bool IsFalaMaisExcedeuConsumo()
        {
            if (PlanoFaleMaisEnum == EnumPlanoFaleMais.PlanoFalaMais30 && Tempo > 30 && IsFaleMais == true)
                return true;

            if (PlanoFaleMaisEnum == EnumPlanoFaleMais.PlanoFalaMais60 && Tempo > 60 && IsFaleMais == true)
                return true;

            if (PlanoFaleMaisEnum == EnumPlanoFaleMais.PlanoFalaMais120 && Tempo > 120 && IsFaleMais == true)
                return true;

            return false;
        }

        public decimal CalcularConsumo()
        {
            if (IsFalaMaisExcedeuConsumo())
                return Tempo + (ObjPrecoLigacao.Valor * 0.1m);

            return Tempo + ObjPrecoLigacao.Valor;
        }
    }
}
