﻿namespace eCommerce.Models
{
    public class EnderecoEntrega
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string NomeEndereco { get; set; } = null!;
        public string CEP { get; set; } = null!;
        public string Estado { get; set; } = null!;
        public string Cidade { get; set; } = null!;
        public string Bairro { get; set; } = null!;
        public string? Endereco { get; set; }
        public string? Numero { get; set; }
        public string? Complemento { get; set; }
    }
}
