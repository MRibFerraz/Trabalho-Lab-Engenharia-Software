﻿using AutoMapper;
using TESTE.ApiNetCore.Domain.Entities;
using TESTE.ApiNetCore.Domain.ValueObjects;
using TESTE.ApiNetCore.Infrastructure.DbModels;

namespace TESTE.ApiNetCore.Infrastructure.Mapping
{
    public class ClienteMap : Profile
    {
        public ClienteMap()
        {
            CreateMap<ClienteDbModel, Cliente>()
                .ForMember(dest => dest.Nome, m => m.Ignore())
                .ForMember(dest => dest.Cpf, m => m.Ignore())
                .ForMember(dest => dest.Email, m => m.Ignore())
                .ForMember(dest => dest.Telefone, m => m.MapFrom(src => src.Ddd.HasValue ? new Telefone(src.Ddd.Value, src.Telefone) : null))
                .ConstructUsing(src =>
                    new Cliente(
                        new Nome(src.Nome, src.Sobrenome),
                        new CPF(src.Cpf),
                        new Email(src.Email),
                        src.Segmento)
                    );
        }
    }
}
