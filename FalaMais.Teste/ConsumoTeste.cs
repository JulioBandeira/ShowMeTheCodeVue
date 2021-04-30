using Modelo.Domain.Entities;
using Modelo.Domain.Interfaces;
using Moq;
using NUnit.Framework;

namespace FalaMais.Teste
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void IsFalaMaisExcedeuPlano30()
        {
            // arrange
            Consumo consumoIsFalaMais = new Consumo()
            {
                Tempo = 35,
                IsFaleMais = true,
                PlanoFaleMaisEnum = Modelo.Domain.Enums.EnumPlanoFaleMais.PlanoFalaMais30,
                ObjPrecoLigacao = new PrecoLigacao()
                {
                    Valor = 1.90m
                },
            };

            Mock<IConsumo> mock = new Mock<IConsumo>();
            mock.Setup(m => m.IsFalaMaisExcedeuConsumo()).Returns(true);
            Consumo consumoIsExcedeu = new Consumo() {
                Tempo = 65,
                IsFaleMais = true,
                PlanoFaleMaisEnum = Modelo.Domain.Enums.EnumPlanoFaleMais.PlanoFalaMais30,
                ObjPrecoLigacao = new PrecoLigacao()
                {
                    Valor = 1.90m
                },
            };

            // act
            var resultadoEsperado = mock.Object.IsFalaMaisExcedeuConsumo();
            var resultado = consumoIsExcedeu.IsFalaMaisExcedeuConsumo();

            Assert.AreEqual(resultado, resultadoEsperado);
        }
    }
}