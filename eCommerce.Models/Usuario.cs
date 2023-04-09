﻿namespace eCommerce.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Sexo { get; set; }
        public string? Rg { get; set; }
        public string Cpf { get; set; } = null!;
        public string? NomeDaMae { get; set; }
        public string? SituacaoCadastro { get; set; }
        public DateTimeOffset DataCadastro { get; set; }
        public Contato? Contato { get; set; }
        public ICollection<EnderecoEntrega>? EnderecosEntregas { get; set; }
        public ICollection<Departamento>? Departamentos { get; set; }
    }
}
