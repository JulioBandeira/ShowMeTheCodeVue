using Modelo.Domain.Entities;
using Modelo.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Services.Services
{
    public class PrecoLigacaoServices : IPrecoLigacaoServices
    {
        public PrecoLigacaoServices() :base() { 
        
        }

        public List<PrecoLigacao> ListaPrecosLigacoes()
        {

            var listaPrecoLigacao = new List<PrecoLigacao>();

            listaPrecoLigacao.Add(new PrecoLigacao
            { 
                Origem = "011",
                Destino = "016",
                Valor = 1.90m,
            });

            listaPrecoLigacao.Add(new PrecoLigacao
            {
                Origem = "016",
                Destino = "011",
                Valor = 2.90m,
            });

            listaPrecoLigacao.Add(new PrecoLigacao
            {
                Origem = "011",
                Destino = "017",
                Valor = 1.70m,
            });


            listaPrecoLigacao.Add(new PrecoLigacao
            {
                Origem = "017",
                Destino = "011",
                Valor = 2.70m,
            });

            listaPrecoLigacao.Add(new PrecoLigacao
            {
                Origem = "011",
                Destino = "018",
                Valor = 0.90m,
            });

            listaPrecoLigacao.Add(new PrecoLigacao
            {
                Origem = "018",
                Destino = "011",
                Valor = 1.90m,
            });

            return listaPrecoLigacao;
        }

        public PrecoLigacao BuscarByOrigemDestino(string origem, string destino)
        {
            return ListaPrecosLigacoes().FirstOrDefault(x=>x.Origem == origem && x.Destino == destino);
        }

        public List<string> RetornaOrigens()
        {
            return ListaPrecosLigacoes().Select(x => x.Destino).Distinct().OrderBy(x => x).ToList();
        }

        public List<string> RetornaDestinos(string origem)
        {
            return ListaPrecosLigacoes().Where(x=>x.Origem == origem).Select(x => x.Destino).Distinct().OrderBy(x => x).ToList();
        }
    }
}
