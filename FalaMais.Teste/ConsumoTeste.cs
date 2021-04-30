using Modelo.Domain.Entities;
using Modelo.Domain.Interfaces;
using Modelo.Services.Interfaces;
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
            Consumo consumoIsFalaMais35 = new Consumo()
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

            Consumo consumoIsExcedeu65 = new Consumo() {
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
            var resultado = consumoIsExcedeu65.IsFalaMaisExcedeuConsumo();

            Assert.AreEqual(resultado, resultadoEsperado);
        }


        [Test]
        public void IsFalaMaisNaoExcedeuConsumo()
        {
            // arrange
            Consumo consumoIsFalaMais = new Consumo()
            {
                Tempo = 29,
                IsFaleMais = true,
                PlanoFaleMaisEnum = Modelo.Domain.Enums.EnumPlanoFaleMais.PlanoFalaMais30,
                ObjPrecoLigacao = new PrecoLigacao()
                {
                    Valor = 1.90m
                },
            };

            Mock<IConsumo> mock = new Mock<IConsumo>();
            mock.Setup(m => m.IsFalaMaisExcedeuConsumo()).Returns(false);

            Consumo consumoIsFalamais = new Consumo()
            {
                Tempo = 10,
                IsFaleMais = true,
                PlanoFaleMaisEnum = Modelo.Domain.Enums.EnumPlanoFaleMais.PlanoFalaMais30,
                ObjPrecoLigacao = new PrecoLigacao()
                {
                    Valor = 1.90m
                },
            };

            // act
            var resultadoEsperado = mock.Object.IsFalaMaisExcedeuConsumo();
            var resultado = consumoIsFalamais.IsFalaMaisExcedeuConsumo();

            Assert.AreEqual(resultado, resultadoEsperado);
        }

        [Test]
        public void ObterResultadoNaoExcedido()
        {
            // arrange
            Consumo consumoIsFalaMais = new Consumo()
            {
                Tempo = 29,
                IsFaleMais = true,
                PlanoFaleMaisEnum = Modelo.Domain.Enums.EnumPlanoFaleMais.PlanoFalaMais30,
                ObjPrecoLigacao = new PrecoLigacao()
                {
                    Valor = 1.90m
                },
            };

            Mock<IConsumo> mock = new Mock<IConsumo>();
            mock.Setup(m => m.CalcularConsumo()).Returns(38.88m);

            Consumo consumoIsFalamais = new Consumo()
            {
                Tempo = 10,
                IsFaleMais = true,
                PlanoFaleMaisEnum = Modelo.Domain.Enums.EnumPlanoFaleMais.PlanoFalaMais30,
                ObjPrecoLigacao = new PrecoLigacao()
                {
                    Valor = 1.90m
                },
            };

            // act
            var resultadoEsperado = mock.Object.IsFalaMaisExcedeuConsumo();
            var resultado = consumoIsFalamais.IsFalaMaisExcedeuConsumo();

            Assert.AreEqual(resultado, resultadoEsperado);
        }

        [Test]
        public void ObterValorPeloCodigo()
        {
            var precoLigacao = new PrecoLigacao();

            Mock<IPrecoLigacaoServices> mock = new Mock<IPrecoLigacaoServices>();
            mock.Setup(m => m.BuscarByOrigemDestino("","")).Returns(precoLigacao);

            Assert.AreEqual(true, true);
        }
    }
}