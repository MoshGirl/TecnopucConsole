using System;
using System.Collections.Generic;
using System.Text;

namespace TecnopucConsole.Projeto.Model
{
    public class DadosElevador
    {
        public int Andar { get; private set; }
        public char Elevador { get; private set; }
        public char Turno { get; private set; }
    }
}