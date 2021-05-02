using Modelo.Domain.Entities;
using Modelo.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Services.Services
{
    public class ConsumoServices : IConsumoServices
    {
        private readonly IPrecoLigacaoServices _precoLigacaoServices;

        public ConsumoServices(IPrecoLigacaoServices precoLigacaoServices) : base()
        {
            _precoLigacaoServices = precoLigacaoServices;
        }

        public decimal CalcularConsumo(bool isfalamais, string origem, string destino, int tempo, string plano)
        {
            var precoLIgacao = _precoLigacaoServices.BuscarPrecoLigacaoPeloOrigemDestino(origem, destino);

            var consumo = new Consumo
            {
                IsFaleMais = isfalamais,
                Tempo = tempo,
                PlanoFaleMaisEnum = (Domain.Enums.EnumPlanoFaleMais)Enum.Parse(typeof(Domain.Enums.EnumPlanoFaleMais), plano),
                ObjPrecoLigacao = precoLIgacao,
            };

            return consumo.CalculoDoConsumo();
        }
    }
}
