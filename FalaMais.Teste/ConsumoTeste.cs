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
        public void ObterResultadoValorNaoExcedidoComPlanoFaleMais()
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
            mock.Setup(m => m.CalculoDoConsumo()).Returns(00.00m);

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
            var resultadoEsperado = mock.Object.CalculoDoConsumo();
            var resultado = consumoIsFalamais.CalculoDoConsumo();

            Assert.AreEqual(resultado, resultadoEsperado);
        }

        [Test]
        public void ObterResultadoValorNaoExcedidoSemPlanoFaleMais()
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

            //tempo = 20, valor = 1.90.
            var calculoNaoExcedidoSemFalaMais = 20 * 1.90m;

            // act
            var resultadoEsperado = mock.Object.CalculoDoConsumo();
            var resultado = calculoNaoExcedidoSemFalaMais;

            Assert.AreEqual(resultado, resultadoEsperado);
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