using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using TecnopucConsole.Projeto.Interface;
using TecnopucConsole.Projeto.Model;
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
            }
            catch (Exception e)
            {
                Console.WriteLine("Algo de errado não está certo / " + e.Message, e.InnerException);
            }
        }
    }
}
