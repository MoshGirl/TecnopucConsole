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
                //string json2 = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "Arquivo\\input.json"));
                dadosDosElevadores = JsonConvert.DeserializeObject<List<DadosElevador>>(json);
            }
            catch (Exception e)
            {
                throw new Exception("Houve um erro ao tentar buscar os dados", e);
            }            
        }

        public List<int> AndarMenosUtilizado()
        {
            var andares = dadosDosElevadores.GroupBy(i => i.andar).OrderBy(g => g.Count()).Select(o => o.Key).ToList();

            var menosUsado = andares.First();

            var quantidadeDoMenosUsado = dadosDosElevadores.FindAll(d => d.andar == menosUsado).Count();

            List<int> andaresMenosUtilizados = new List<int>();

            andaresMenosUtilizados.Add(menosUsado);

            for (int i = 1; i < andares.Count; i++)
            {
                var proximoAndar = andares[i];
                var quantidadeDoProximo = dadosDosElevadores.FindAll(d => d.andar == proximoAndar).Count();
                if (quantidadeDoMenosUsado == quantidadeDoProximo)
                {
                    andaresMenosUtilizados.Add(andares[i]);
                }
            }
            return andaresMenosUtilizados;
        }

        public List<char> ElevadorMaisFrequentado()
        {
            List<ElevadorDto> percentualDosElevadores = new List<ElevadorDto>();

            AdicionaListaPercentualElevadores(percentualDosElevadores);

            List<char> elevadorMaisFrequentado = new List<char>();

            var maiorElevadorUso = percentualDosElevadores.Max(x => x.usoElevador);
            var maiorElevador = percentualDosElevadores.FindAll(x => x.usoElevador == maiorElevadorUso);

            foreach (var item in maiorElevador)
            {
                elevadorMaisFrequentado.Add(item.tipoElevador);
            }

            return elevadorMaisFrequentado;
        }

        public List<char> ElevadorMenosFrequentado()
        {
            List<ElevadorDto> percentualDosElevadores = new List<ElevadorDto>();

            AdicionaListaPercentualElevadores(percentualDosElevadores);

            List<char> elevadorMenosFrequentado = new List<char>();

            var menorElevadorUso = percentualDosElevadores.Min(x => x.usoElevador);
            var menorElevador = percentualDosElevadores.FindAll(x => x.usoElevador == menorElevadorUso);

            foreach (var item in menorElevador)
            {
                elevadorMenosFrequentado.Add(item.tipoElevador);
            }

            return elevadorMenosFrequentado;
        }

        private void AdicionaListaPercentualElevadores(List<ElevadorDto> percentualDosElevadores)
        {
            ElevadorDto elevadorA = new ElevadorDto
            {
                tipoElevador = 'A',
                usoElevador = PercentualDeUsoElevadorA()
            };

            ElevadorDto elevadorB = new ElevadorDto
            {
                tipoElevador = 'B',
                usoElevador = PercentualDeUsoElevadorB()
            };

            ElevadorDto elevadorC = new ElevadorDto
            {
                tipoElevador = 'C',
                usoElevador = PercentualDeUsoElevadorC()
            };

            ElevadorDto elevadorD = new ElevadorDto
            {
                tipoElevador = 'D',
                usoElevador = PercentualDeUsoElevadorD()
            };

            ElevadorDto elevadorE = new ElevadorDto
            {
                tipoElevador = 'E',
                usoElevador = PercentualDeUsoElevadorE()
            };

            percentualDosElevadores.Add(elevadorA);
            percentualDosElevadores.Add(elevadorB);
            percentualDosElevadores.Add(elevadorC);
            percentualDosElevadores.Add(elevadorD);
            percentualDosElevadores.Add(elevadorE);
        }

        public float PercentualDeUsoElevadorA()
        {
            char tipo = 'A';
            float percentual = RetornaPercentualElevador(tipo);

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

        public List<char> PeriodoMaiorFluxoElevadorMaisFrequentado()
        {
            var elevadorMaisFrequentados = ElevadorMaisFrequentado();

            List<char> turnos = new List<char>();

            foreach (var item in elevadorMaisFrequentados)
            {
                var frequencia = dadosDosElevadores.Where(d => d.elevador.Equals(item)).GroupBy(i => i.turno).OrderBy(g => g.Count()).Select(o => o.Key).ToList();
                turnos.Add(frequencia.Last());
            }
            return turnos;
        }

        public List<char> PeriodoMaiorUtilizacaoConjuntoElevadores()
        {
            var turnos = dadosDosElevadores.GroupBy(i => i.turno).OrderBy(g => g.Count()).Select(o => o.Key).ToList();
            var maisUsado = turnos.Last();

            var quantidadeDoMaisUsado = dadosDosElevadores.FindAll(d => d.turno == maisUsado).Count();

            List<char> turnosMaisUsados = new List<char>();
            turnosMaisUsados.Add(maisUsado);

            for (int i = turnos.Count - 2; i >= 0; i--)
            {
                var proximoAndar = turnos[i];
                var quantidadeDoProximo = dadosDosElevadores.FindAll(d => d.turno.Equals(proximoAndar)).Count();
                if (quantidadeDoMaisUsado == quantidadeDoProximo)
                {
                    turnosMaisUsados.Add(turnos[i]);
                }
            }
            return turnosMaisUsados;
        }

        public List<char> PeriodoMenorFluxoElevadorMenosFrequentado()
        {
            var elevadorMenosFrequentados = ElevadorMenosFrequentado();

            List<char> turnos = new List<char>();

            foreach (var item in elevadorMenosFrequentados)
            {
                var frequencia = dadosDosElevadores.Where(d => d.elevador.Equals(item)).GroupBy(i => i.turno).OrderBy(g => g.Count()).Select(o => o.Key).ToList();
                turnos.Add(frequencia.First());
            }
            return turnos;
            throw new NotImplementedException();
        }
    }
}