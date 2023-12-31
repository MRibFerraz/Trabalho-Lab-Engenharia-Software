﻿using System;

namespace TESTE.ApiNetCore.Infrastructure.DbModels
{
    public class ClienteDbModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Cpf { get; set; }
        public int? Ddd { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Segmento { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
