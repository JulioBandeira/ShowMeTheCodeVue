using Modelo.Domain.Entities;
using Modelo.Domain.Enums;
using System;
using Xunit;

namespace FalaMaisTeste
{
    public class ConsumoTest
    {
   
        [Theory]
        [InlineData(30, true, Modelo.Domain.Enums.EnumPlanoFaleMais.PlanoFalaMais30, 1.90, false)]
        [InlineData(60, true, Modelo.Domain.Enums.EnumPlanoFaleMais.PlanoFalaMais60, 1.90, false)]
        [InlineData(120, true, Modelo.Domain.Enums.EnumPlanoFaleMais.PlanoFalaMais120, 1.90, false)]
        public void IsFalaMaisExcedeuConsumo_Nao(int Tempo, bool IsFaleMais, EnumPlanoFaleMais PlanoFaleMaisEnum, decimal Valor, bool isExcedeuConsumoEsperado)
        {
            // arrangea
            Consumo consumoIsFalamais = new Consumo()
            {
                Tempo = Tempo,
                IsFaleMais = IsFaleMais,
                PlanoFaleMaisEnum = PlanoFaleMaisEnum,
                ObjPrecoLigacao = new PrecoLigacao()
                {
                    Valor = Valor
                },
            };

            //act
            var isExcedeuConsumo = consumoIsFalamais.IsFalaMaisExcedeuConsumo();

            //assert
            Assert.Equal(isExcedeuConsumo, isExcedeuConsumoEsperado);
        }

        [Theory]
        [InlineData(31, true, Modelo.Domain.Enums.EnumPlanoFaleMais.PlanoFalaMais30, 1.90, true)]
        [InlineData(61, true, Modelo.Domain.Enums.EnumPlanoFaleMais.PlanoFalaMais60, 1.90, true)]
        [InlineData(121, true, Modelo.Domain.Enums.EnumPlanoFaleMais.PlanoFalaMais120, 1.90, true)]
        public void IsFalaMaisExcedeuConsumo_Sim(int Tempo, bool IsFaleMais, EnumPlanoFaleMais PlanoFaleMaisEnum, decimal Valor, bool isExcedeuConsumoEsperado)
        {
            // arrange
            Consumo consumoIsFalamais = new Consumo()
            {
                Tempo = Tempo,
                IsFaleMais = IsFaleMais,
                PlanoFaleMaisEnum = PlanoFaleMaisEnum,
                ObjPrecoLigacao = new PrecoLigacao()
                {
                    Valor = Valor
                },
            };

            //act
            var isExcedeuConsumo = consumoIsFalamais.IsFalaMaisExcedeuConsumo();

            //assert
            Assert.Equal(isExcedeuConsumo, isExcedeuConsumoEsperado);
        }

        [Theory]
        [InlineData(30, true, Modelo.Domain.Enums.EnumPlanoFaleMais.PlanoFalaMais30, 1.90, 0)]
        [InlineData(60, true, Modelo.Domain.Enums.EnumPlanoFaleMais.PlanoFalaMais60, 1.90, 0)]
        [InlineData(120, true, Modelo.Domain.Enums.EnumPlanoFaleMais.PlanoFalaMais120, 1.90, 0)]
        public void ComFalaMais_Obter_ValorConsumo_Zerado(int Tempo, bool IsFaleMais, EnumPlanoFaleMais PlanoFaleMaisEnum, decimal Valor, decimal valorCalculadoEsperado)
        {
            // arrange
            Consumo consumoIsFalamais = new Consumo()
            {
                Tempo = Tempo,
                IsFaleMais = IsFaleMais,
                PlanoFaleMaisEnum = PlanoFaleMaisEnum,
                ObjPrecoLigacao = new PrecoLigacao()
                {
                    Valor = Valor
                },
            };

            //act
            var valorConsumoZerado = consumoIsFalamais.CalculoDoConsumo();

            //assert
            Assert.Equal(valorConsumoZerado, valorCalculadoEsperado);
        }

        [Theory]
        [InlineData(31, true, Modelo.Domain.Enums.EnumPlanoFaleMais.PlanoFalaMais30, 1.90, 2.09)]
        [InlineData(61, true, Modelo.Domain.Enums.EnumPlanoFaleMais.PlanoFalaMais60, 1.90, 2.09)]
        [InlineData(121, true, Modelo.Domain.Enums.EnumPlanoFaleMais.PlanoFalaMais120, 1.90, 2.09)]
        public void ComFalaMais_Obter_ValorConsumo_Excedido(int Tempo, bool IsFaleMais, EnumPlanoFaleMais PlanoFaleMaisEnum, decimal Valor, decimal valorCalculadoEsperado)
        {
            // arrange
            Consumo consumoIsFalamais = new Consumo()
            {
                Tempo = Tempo,
                IsFaleMais = IsFaleMais,
                PlanoFaleMaisEnum = PlanoFaleMaisEnum,
                ObjPrecoLigacao = new PrecoLigacao()
                {
                    Valor = Valor
                },
            };

            //act
            var valorConsumoExcedido = consumoIsFalamais.CalculoDoConsumo();

            //assert
            Assert.Equal(valorConsumoExcedido, valorCalculadoEsperado);
        }

        [Theory]
        [InlineData(31, false, 1.90, 58.90)]
        [InlineData(60, false, 1.90, 114.00)]
        [InlineData(120, false, 1.90, 228)]
        public void SemFalaMais_Obter_ValorConsumo(int Tempo, bool IsFaleMais, decimal Valor, decimal valorCalculadoEsperado)
        {
            // arrange
            Consumo consumoIsFalamais = new Consumo()
            {
                Tempo = Tempo,
                IsFaleMais = IsFaleMais,
                ObjPrecoLigacao = new PrecoLigacao()
                {
                    Valor = Valor
                },
            };

            //act
            var valorConsumoExcedido = consumoIsFalamais.CalculoDoConsumo();

            //assert
            Assert.Equal(valorConsumoExcedido, valorCalculadoEsperado);
        }
    }
}
