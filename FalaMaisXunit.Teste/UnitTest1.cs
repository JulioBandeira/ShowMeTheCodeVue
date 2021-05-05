using Modelo.Domain.Entities;
using Modelo.Domain.Enums;
using Modelo.Domain.Interfaces;
using Xunit;

namespace FalaMaisXunit.Teste
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(30, true, Modelo.Domain.Enums.EnumPlanoFaleMais.PlanoFalaMais30, 1.90, false)]
        [InlineData(60, true, Modelo.Domain.Enums.EnumPlanoFaleMais.PlanoFalaMais60, 1.90, false)]
        [InlineData(120, true, Modelo.Domain.Enums.EnumPlanoFaleMais.PlanoFalaMais120, 1.90, false)] 
        public void IsFalaMaisNaoExcedeuConsumo_Nao(int Tempo, bool IsFaleMais, EnumPlanoFaleMais PlanoFaleMaisEnum, decimal Valor, bool isExcedeuConsumoEsperado)
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
    }
}
