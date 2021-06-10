using System;


namespace CRUD___Simples
{
    public class Colaborador
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public string Cargo { get; set; }
        public bool Ativo { get; set; }

        public override string ToString()
        {
            return $"Colaborador: { this.Id }, { this.Nome }, { this.Sexo }, { this.DataDeNascimento }, { this.Cargo }, { this.Ativo }";
        }
    }
}
