namespace SistemaEscolar01.Models
{
    public class Professor
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string Senha { get; set; }

        public decimal Nota { get; set; }
    }
}
