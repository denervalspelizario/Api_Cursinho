﻿namespace Cursinho.Dto.Administrador
{
    public class AdministradorResponseDTO
    {
        public int? id { get; set; }
        public string? nome { get; set; }
        public string? email { get; set; }
        public string? cargo { get; set; }
        public DateTime? data_cadastro { get; set; }

        public AdministradorResponseDTO(int? id, string? nome, string? email, string? cargo, DateTime? data_cadastro)
        {
            this.id = id;
            this.nome = nome;
            this.email = email;
            this.cargo = cargo;
            this.data_cadastro = data_cadastro;
        }

        public AdministradorResponseDTO()
        {
        }
    }
}
