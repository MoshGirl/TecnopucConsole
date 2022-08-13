using System;
using TecnopucConsole.Projeto.Interface;
using TecnopucConsole.Projeto.Service;

namespace TecnopucConsole
{
    class Program
    {
        private static IElevadorService _elevadorService;

        static void Main(string[] args)
        {        
            try
            {
                _elevadorService = new ElevadorService();

                Console.WriteLine("O(s) andar(es) menos utilizado(s): ");
                foreach (var item in _elevadorService.AndarMenosUtilizado())
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine();
                Console.WriteLine("O(s) elevador(es) mais frequentado(s): ");
                foreach (var item in _elevadorService.ElevadorMaisFrequentado())
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("Com o período de maior fluxo: ");
                foreach (var item in _elevadorService.PeriodoMaiorFluxoElevadorMaisFrequentado())
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine();
                Console.WriteLine("O(s) elevador(es) menos frequentado(s): ");
                foreach (var item in _elevadorService.ElevadorMenosFrequentado())
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("Com o período de menor fluxo: ");
                foreach (var item in _elevadorService.PeriodoMenorFluxoElevadorMenosFrequentado())
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine();
                Console.WriteLine("O(s) periodo(s) mais frequentado(s): ");
                foreach (var item in _elevadorService.PeriodoMaiorUtilizacaoConjuntoElevadores())
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine();
                Console.WriteLine("Os percentuais de uso de cada elevador: ");
                Console.WriteLine("Elevador A: " + _elevadorService.PercentualDeUsoElevadorA() + "%");
                Console.WriteLine("Elevador B: " + _elevadorService.PercentualDeUsoElevadorB() + "%");
                Console.WriteLine("Elevador C: " + _elevadorService.PercentualDeUsoElevadorC() + "%");
                Console.WriteLine("Elevador D: " + _elevadorService.PercentualDeUsoElevadorD() + "%");
                Console.WriteLine("Elevador E: " + _elevadorService.PercentualDeUsoElevadorE() + "%");
            }
            catch (Exception e)
            {
                Console.WriteLine("Algo de errado não está certo / " + e.Message, e.InnerException);
            }
        }
    }
}