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
        public void IsFalaMaisExcedeuPlano()
        {
            // arrange
            Consumo consumoIsExcedeu30 = new Consumo()
            {
                Tempo = 31,
                IsFaleMais = true,
                PlanoFaleMaisEnum = Modelo.Domain.Enums.EnumPlanoFaleMais.PlanoFalaMais30,
                ObjPrecoLigacao = new PrecoLigacao()
                {
                    Valor = 1.90m
                },
            };

            Consumo consumoIsExcedeu60 = new Consumo()
            {
                Tempo = 61,
                IsFaleMais = true,
                PlanoFaleMaisEnum = Modelo.Domain.Enums.EnumPlanoFaleMais.PlanoFalaMais60,
                ObjPrecoLigacao = new PrecoLigacao()
                {
                    Valor = 1.90m
                },
            };

            Consumo consumoIsExcedeu120 = new Consumo()
            {
                Tempo = 121,
                IsFaleMais = true,
                PlanoFaleMaisEnum = Modelo.Domain.Enums.EnumPlanoFaleMais.PlanoFalaMais120,
                ObjPrecoLigacao = new PrecoLigacao()
                {
                    Valor = 1.90m
                },
            };

            Mock<IConsumo> mock30 = new Mock<IConsumo>();
            mock30.Setup(m => m.IsFalaMaisExcedeuConsumo()).Returns(true);

            Mock<IConsumo> mock60 = new Mock<IConsumo>();
            mock60.Setup(m => m.IsFalaMaisExcedeuConsumo()).Returns(true);

            Mock<IConsumo> mock120 = new Mock<IConsumo>();
            mock120.Setup(m => m.IsFalaMaisExcedeuConsumo()).Returns(true);

            // act
            var resultadoEsperado30 = mock30.Object.IsFalaMaisExcedeuConsumo();
            var resultadoObtido30 = consumoIsExcedeu30.IsFalaMaisExcedeuConsumo();

            var resultadoEsperado60 = mock60.Object.IsFalaMaisExcedeuConsumo();
            var resultadoObtido60= consumoIsExcedeu60.IsFalaMaisExcedeuConsumo();

            var resultadoEsperado120 = mock120.Object.IsFalaMaisExcedeuConsumo();
            var resultadoObtido120 = consumoIsExcedeu120.IsFalaMaisExcedeuConsumo();

            // asst
            Assert.IsTrue(resultadoObtido30 == resultadoEsperado30);
            Assert.IsTrue(resultadoObtido60 == resultadoEsperado60);
            Assert.IsTrue(resultadoObtido120 == resultadoEsperado120);
        }

        [Test]
        public void IsFalaMaisNaoExcedeuConsumo()
        {
            // arrange
            Consumo consumoIsFalamais30 = new Consumo()
            {
                Tempo = 30,
                IsFaleMais = true,
                PlanoFaleMaisEnum = Modelo.Domain.Enums.EnumPlanoFaleMais.PlanoFalaMais30,
                ObjPrecoLigacao = new PrecoLigacao()
                {
                    Valor = 1.90m
                },
            };

            Consumo consumoIsFalamais60 = new Consumo()
            {
                Tempo = 60,
                IsFaleMais = true,
                PlanoFaleMaisEnum = Modelo.Domain.Enums.EnumPlanoFaleMais.PlanoFalaMais60,
                ObjPrecoLigacao = new PrecoLigacao()
                {
                    Valor = 1.90m
                },
            };

            Consumo consumoIsFalamais120 = new Consumo()
            {
                Tempo = 120,
                IsFaleMais = true,
                PlanoFaleMaisEnum = Modelo.Domain.Enums.EnumPlanoFaleMais.PlanoFalaMais120,
                ObjPrecoLigacao = new PrecoLigacao()
                {
                    Valor = 1.90m
                },
            };

            Mock<IConsumo> mock30 = new Mock<IConsumo>();
            mock30.Setup(m => m.IsFalaMaisExcedeuConsumo()).Returns(false);

            Mock<IConsumo> mock60 = new Mock<IConsumo>();
            mock60.Setup(m => m.IsFalaMaisExcedeuConsumo()).Returns(false);

            Mock<IConsumo> mock120 = new Mock<IConsumo>();
            mock120.Setup(m => m.IsFalaMaisExcedeuConsumo()).Returns(false);

            // act
            var resultadoEsperado30 = mock30.Object.IsFalaMaisExcedeuConsumo();
            var resultadoObitido30 = consumoIsFalamais30.IsFalaMaisExcedeuConsumo();

            var resultadoEsperado60 = mock60.Object.IsFalaMaisExcedeuConsumo();
            var resultadoObitido60 = consumoIsFalamais60.IsFalaMaisExcedeuConsumo();

            var resultadoEsperado120 = mock120.Object.IsFalaMaisExcedeuConsumo();
            var resultadoObitido120 = consumoIsFalamais120.IsFalaMaisExcedeuConsumo();

            Assert.AreEqual(resultadoObitido30, resultadoEsperado30);
            Assert.AreEqual(resultadoObitido60, resultadoEsperado60);
            Assert.AreEqual(resultadoObitido120, resultadoEsperado120);
        }

        [Test]
        public void ObterResultadoValorNaoExcedidoComPlanoFaleMais()
        {
            // arrange
            Consumo consumoFalaMais30 = new Consumo()
            {
                Tempo = 30,
                IsFaleMais = true,
                PlanoFaleMaisEnum = Modelo.Domain.Enums.EnumPlanoFaleMais.PlanoFalaMais30,
                ObjPrecoLigacao = new PrecoLigacao()
                {
                    Valor = 1.90m
                },
            };

            Consumo consumoFalaMais60 = new Consumo()
            {
                Tempo = 60,
                IsFaleMais = true,
                PlanoFaleMaisEnum = Modelo.Domain.Enums.EnumPlanoFaleMais.PlanoFalaMais60,
                ObjPrecoLigacao = new PrecoLigacao()
                {
                    Valor = 1.90m
                },
            };

            Consumo consumoFalaMais120 = new Consumo()
            {
                Tempo = 120,
                IsFaleMais = true,
                PlanoFaleMaisEnum = Modelo.Domain.Enums.EnumPlanoFaleMais.PlanoFalaMais120,
                ObjPrecoLigacao = new PrecoLigacao()
                {
                    Valor = 1.90m
                },
            };

            Mock<IConsumo> mock30 = new Mock<IConsumo>();
            mock30.Setup(m => m.CalculoDoConsumo()).Returns(0.00m);

            Mock<IConsumo> mock60 = new Mock<IConsumo>();
            mock60.Setup(m => m.CalculoDoConsumo()).Returns(0.00m);

            Mock<IConsumo> mock120 = new Mock<IConsumo>();
            mock120.Setup(m => m.CalculoDoConsumo()).Returns(0.00m);

            // act
            var resultadoEsperado30 = mock30.Object.CalculoDoConsumo();
            var resultadoObitido30 = consumoFalaMais30.CalculoDoConsumo();

            var resultadoEsperado60 = mock60.Object.CalculoDoConsumo();
            var resultadoObitido60 = consumoFalaMais60.CalculoDoConsumo();

            var resultadoEsperado120 = mock120.Object.CalculoDoConsumo();
            var resultadoObitido120 = consumoFalaMais120.CalculoDoConsumo();

            Assert.IsTrue(resultadoObitido30 == resultadoEsperado30);
            Assert.IsTrue(resultadoEsperado60 == resultadoObitido60);
            Assert.IsTrue(resultadoEsperado120 == resultadoObitido120);
        }

        [Test]
        public void ObterResultadoValorExcedidoComPlanoFaleMais()
        {
            // arrange
            Consumo consumoFalaMais30 = new Consumo()
            {
                Tempo = 31,
                IsFaleMais = true,
                PlanoFaleMaisEnum = Modelo.Domain.Enums.EnumPlanoFaleMais.PlanoFalaMais30,
                ObjPrecoLigacao = new PrecoLigacao()
                {
                    Valor = 1.90m
                },
            };

            Consumo consumoFalaMais60 = new Consumo()
            {
                Tempo = 80,
                IsFaleMais = true,
                PlanoFaleMaisEnum = Modelo.Domain.Enums.EnumPlanoFaleMais.PlanoFalaMais60,
                ObjPrecoLigacao = new PrecoLigacao()
                {
                    Valor = 1.70m
                },
            };

            Consumo consumoFalaMais120 = new Consumo()
            {
                Tempo = 200,
                IsFaleMais = true,
                PlanoFaleMaisEnum = Modelo.Domain.Enums.EnumPlanoFaleMais.PlanoFalaMais120,
                ObjPrecoLigacao = new PrecoLigacao()
                {
                    Valor = 1.90m
                },
            };

            Mock<IConsumo> mock30 = new Mock<IConsumo>();
            mock30.Setup(m => m.CalculoDoConsumo()).Returns(2.09m);

            Mock<IConsumo> mock60 = new Mock<IConsumo>();
            mock60.Setup(m => m.CalculoDoConsumo()).Returns(37.4m);

            Mock<IConsumo> mock120 = new Mock<IConsumo>();
            mock120.Setup(m => m.CalculoDoConsumo()).Returns(167.2m);

            // act
            var resultadoEsperado30 = mock30.Object.CalculoDoConsumo();
            var resultadoObitido30 = consumoFalaMais30.CalculoDoConsumo();

            var resultadoEsperado60 = mock60.Object.CalculoDoConsumo();
            var resultadoObitido60 = consumoFalaMais60.CalculoDoConsumo();

            var resultadoEsperado120 = mock120.Object.CalculoDoConsumo();
            var resultadoObitido120 = consumoFalaMais120.CalculoDoConsumo();

            Assert.IsTrue(resultadoObitido30 == resultadoEsperado30);
            Assert.IsTrue(resultadoEsperado60 == resultadoObitido60);
            Assert.IsTrue(resultadoEsperado120 == resultadoObitido120);
        }

        [Test]
        public void ObterResultadoValorSemPlanoFaleMais()
        {
            // arrange
            Consumo consumoSemFalaMais20 = new Consumo()
            {
                Tempo = 20,
                IsFaleMais = false,      
                ObjPrecoLigacao = new PrecoLigacao()
                {
                    Valor = 1.90m
                },
            };

            Consumo consumoSemFalaMais80 = new Consumo()
            {
                Tempo = 80,
                IsFaleMais = false,
                ObjPrecoLigacao = new PrecoLigacao()
                {
                    Valor = 1.70m
                },
            };

            Consumo consumoSemFalaMais200 = new Consumo()
            {
                Tempo = 200,
                IsFaleMais = false,
                ObjPrecoLigacao = new PrecoLigacao()
                {
                    Valor = 1.90m
                },
            };

            Mock<IConsumo> mock20 = new Mock<IConsumo>();
            mock20.Setup(m => m.CalculoDoConsumo()).Returns(38.00m);

            Mock<IConsumo> mock80 = new Mock<IConsumo>();
            mock80.Setup(m => m.CalculoDoConsumo()).Returns(136.00m);

            Mock<IConsumo> mock200 = new Mock<IConsumo>();
            mock200.Setup(m => m.CalculoDoConsumo()).Returns(380.00m);

            // act
            var resultadoEsperado20 = mock20.Object.CalculoDoConsumo();
            var resultadoObitido20 = consumoSemFalaMais20.CalculoDoConsumo();

            var resultadoEsperado80 = mock80.Object.CalculoDoConsumo();
            var resultadoObitido80 = consumoSemFalaMais80.CalculoDoConsumo();

            var resultadoEsperado200 = mock200.Object.CalculoDoConsumo();
            var resultadoObitido200 = consumoSemFalaMais200.CalculoDoConsumo();

            Assert.IsTrue(resultadoEsperado20 == resultadoObitido20);
            Assert.IsTrue(resultadoEsperado80 == resultadoObitido80);
            Assert.IsTrue(resultadoEsperado200 == resultadoObitido200);
        }
    }
}