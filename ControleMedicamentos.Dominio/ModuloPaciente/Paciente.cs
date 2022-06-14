namespace ControleMedicamentos.Dominio.ModuloPaciente
{
    public class Paciente : EntidadeBase<Paciente>
    {
        public Paciente()
        {
        }

        public Paciente(string nome, string cartaoSUS)
        {
            Nome = nome;
            CartaoSUS = cartaoSUS;
        }

        public string Nome { get; set; }
        public string CartaoSUS { get; set; }

        public override bool Equals(object obj)
        {
            Paciente paciente = obj as Paciente;

            if (paciente == null)
                return false;

            return 
                paciente.Id.Equals(Id) &&
                paciente.Nome.Equals(Nome) &&
                paciente.CartaoSUS.Equals(CartaoSUS);
        }

    }
}
