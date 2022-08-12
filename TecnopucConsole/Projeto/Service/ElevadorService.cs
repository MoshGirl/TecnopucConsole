using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TecnopucConsole.Projeto.Interface;
using TecnopucConsole.Projeto.Model;

namespace TecnopucConsole.Projeto.Service
{
    public class ElevadorService : IElevadorService
    {
        private static List<DadosElevador> dadosDosElevadores;

        public ElevadorService()
        {
            BuscarDados();
        }

        //Método que busca e converte os dados do arquivo em uma lista de objetos do tipo DadosElevador
        private void BuscarDados()
        {
            try
            {
                string json = File.ReadAllText(@"C:\Users\Windows 10\source\repos\TecnopucConsole\TecnopucConsole\Projeto\Arquivo\input.json");
                dadosDosElevadores = JsonConvert.DeserializeObject<List<DadosElevador>>(json);
            }
            catch (Exception e)
            {
                throw new Exception("Houve um erro ao tentar buscar os dados", e);
            }            
        }

        public List<int> AndarMenosUtilizado()
        {
            throw new NotImplementedException();
        }

        public List<char> ElevadorMaisFrequentado()
        {
            throw new NotImplementedException();
        }

        public List<char> ElevadorMenosFrequentado()
        {
            throw new NotImplementedException();
        }

        public float PercentualDeUsoElevadorA()
        {
            char tipo = 'A';
            float percentual = RetornaPercentualElevador(tipo);

            return percentual;
        }

        private static float RetornaPercentualElevador(char Tipo)
        {
            int numeroDeUsos = dadosDosElevadores.Count();
            int quantidadeElevador = 0;

            foreach (var item in dadosDosElevadores)
            {
                if (item.elevador.Equals(Tipo))
                {
                    quantidadeElevador++;
                }
            }

            float percentual = (quantidadeElevador * 100) / numeroDeUsos;
            return percentual;
        }

        public float PercentualDeUsoElevadorB()
        {
            char tipo = 'B';
            float percentual = RetornaPercentualElevador(tipo);

            return percentual;
        }

        public float PercentualDeUsoElevadorC()
        {
            char tipo = 'C';
            float percentual = RetornaPercentualElevador(tipo);

            return percentual;
        }

        public float PercentualDeUsoElevadorD()
        {
            char tipo = 'D';
            float percentual = RetornaPercentualElevador(tipo);

            return percentual;
        }

        public float PercentualDeUsoElevadorE()
        {
            char tipo = 'E';
            float percentual = RetornaPercentualElevador(tipo);

            return percentual;
        }

        public List<char> PeriodoMaiorFluxoElevadorMaisFrequentado()
        {
            throw new NotImplementedException();
        }

        public List<char> PeriodoMaiorUtilizacaoConjuntoElevadores()
        {
            throw new NotImplementedException();
        }

        public List<char> PeriodoMenorFluxoElevadorMenosFrequentado()
        {
            throw new NotImplementedException();
        }
    }
}