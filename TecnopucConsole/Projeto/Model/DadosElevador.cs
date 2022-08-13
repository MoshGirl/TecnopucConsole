namespace TecnopucConsole.Projeto.Model
{
    public class DadosElevador
    {
        public int andar { get; set; }
        public char elevador { get; set; }
        public char turno { get; set; }
    }

    public class ElevadorDto
    {
        public char tipoElevador { get; set; }
        public float usoElevador { get; set; }
    }
}