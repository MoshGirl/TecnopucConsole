using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace TecnopucConsole.Projeto.Model
{
    public class DadosElevador
    {
        public int andar { get; set; }
        public char elevador { get; set; }
        public char turno { get; set; }
    }
}