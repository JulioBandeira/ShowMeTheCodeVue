using Modelo.Domain.Entities;
using Modelo.Domain.Interfaces;
using Modelo.Services.Interfaces;
using Moq;
using NUnit.Framework;

namespace FalaMais.Teste
{
    public class Tests
    {
        //private readonly IPrecoLigacaoServices _iprecoLigacaoServices;
        //public Tests(IPrecoLigacaoServices iprecoLigacaoServices)
        //{
        //    _iprecoLigacaoServices = iprecoLigacaoServices;
        //}

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

            Consumo consumoIsExcedeu65 = new Consumo()
            {
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

            Mock<IConsumo> mock = new Mock<IConsumo>();
            mock.Setup(m => m.IsFalaMaisExcedeuConsumo()).Returns(false);

            // act
            var resultadoEsperado = mock.Object.IsFalaMaisExcedeuConsumo();
            var resultadoObitido = consumoIsFalamais.IsFalaMaisExcedeuConsumo();

            Assert.AreEqual(resultadoObitido, resultadoEsperado);
        }

        [Test]
        public void ObterResultadoValorNaoExcedidoComPlanoFaleMais()
        {
            // arrange
            Consumo consumoIsFalaMais = new Consumo()
            {
                Tempo = 31,
                IsFaleMais = true,
                PlanoFaleMaisEnum = Modelo.Domain.Enums.EnumPlanoFaleMais.PlanoFalaMais30,
                ObjPrecoLigacao = new PrecoLigacao()
                {
                    Valor = 1.90m
                },
            };

            Mock<IConsumo> mock = new Mock<IConsumo>();
            mock.Setup(m => m.CalculoDoConsumo()).Returns(2.09m);

            // act
            var resultadoEsperado = mock.Object.CalculoDoConsumo();
            var resultadoObitido = consumoIsFalaMais.CalculoDoConsumo();

            Assert.IsTrue(resultadoObitido == resultadoEsperado);
        }

        [Test]
        public void ObterResultadoValorSemPlanoFaleMais()
        {
            // arrange
            Consumo consumoSemFalaMais = new Consumo()
            {
                Tempo = 20,
                IsFaleMais = false,
                PlanoFaleMaisEnum = Modelo.Domain.Enums.EnumPlanoFaleMais.PlanoFalaMais30,
                ObjPrecoLigacao = new PrecoLigacao()
                {
                    Valor = 1.90m
                },
            };

            Mock<IConsumo> mock = new Mock<IConsumo>();
            mock.Setup(m => m.CalculoDoConsumo()).Returns(38.00m);

            // act
            var resultadoEsperado = mock.Object.CalculoDoConsumo();
            var resultadoObitido = consumoSemFalaMais.CalculoDoConsumo();

            Assert.AreEqual(resultadoObitido, resultadoEsperado);
        }

        [Test]
        public void ObterValorPeloCodigo()
        {

            //Arrange
            //var precoLigacao = _iprecoLigacaoServices.BuscarByOrigemDestino("011", "016");

            ////Act
            //decimal valorObtido = precoLigacao.Valor;
            //string origemObtido = precoLigacao.Origem;
            //string destinoObitido = precoLigacao.Destino;

            //decimal valorEsperado = 1.90m;
            //string origemEsperada = "011";
            //string destinoEsperado = "016";

            ////Assert:
            //Assert.AreEqual(valorObtido, valorEsperado);
            //Assert.AreEqual(origemObtido, origemEsperada);
            //Assert.AreEqual(destinoObitido, destinoEsperado);
        }
    }
}