using Modelo.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Domain.Entities
{
    public class Consumo 
    {
        public PrecoLigacao ObjPrecoLigacao { get; set; }

        public bool IsFaleMais { get; set; }

        public int Tempo { get; set; }

        public EnumPlanoFaleMais PlanoFaleMaisEnum { get; set; }

        /// <summary>
        /// Retorna o calculo do consumo sendo plano fale mais ou não.
        /// </summary>
        /// <returns></returns>
        public decimal CalculoDoConsumo()
        {
            if (IsFaleMais)
                return CalcularConsumoComFalaMais();

            return CalcularConsumoSemFalaMais();
        }

        public bool IsFalaMaisExcedeuConsumo()
        {
            if (PlanoFaleMaisEnum == EnumPlanoFaleMais.PlanoFalaMais30 && Tempo > 30)
                return true;
            else if (PlanoFaleMaisEnum == EnumPlanoFaleMais.PlanoFalaMais30 && Tempo <= 30)
                return false;

            if (PlanoFaleMaisEnum == EnumPlanoFaleMais.PlanoFalaMais60 && Tempo > 60)
                return true;
            else if (PlanoFaleMaisEnum == EnumPlanoFaleMais.PlanoFalaMais60 && Tempo <= 60)
                return false;

            if (PlanoFaleMaisEnum == EnumPlanoFaleMais.PlanoFalaMais120 && Tempo > 120)
                return true;

            else if (PlanoFaleMaisEnum == EnumPlanoFaleMais.PlanoFalaMais120 && Tempo <= 120)
                return false;

            return false;
        }

        /// <summary>
        /// Método para retornar o calculo do consumo do plano com fala mais
        /// </summary>
        /// <returns></returns>
        public decimal CalcularConsumoComFalaMais()
        {
            if (IsFalaMaisExcedeuConsumo())
                return  RetornaValorExcedidoComFalaMaisComJuros();

            return 0.0m;
        }

        /// <summary>
        /// Método para retornar o calculo do consumo do plano sem fala mais
        /// </summary>
        /// <returns></returns>
        public decimal CalcularConsumoSemFalaMais()
        {
            return Tempo * ObjPrecoLigacao.Valor;
        }

        private decimal RetornaValorExcedidoComFalaMaisComJuros() {

            var calculo = (Tempo - Convert.ToInt32(PlanoFaleMaisEnum)) * (ObjPrecoLigacao.Valor * 1.1m);

            return calculo;
        }
    }
}
