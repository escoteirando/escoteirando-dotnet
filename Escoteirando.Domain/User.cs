using System;
using Escoteirando.Domain.Enums;
using Escoteirando.Domain.Interfaces;
using Escoteirando.Domain.ValueObjects;

namespace Escoteirando.Domain
{
    public class User : IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Apelido { get; set; }
        public CPF Cpf { get; set; }
        public UserRole Role { get; set; }
        public string PasswordHash { get; set; }
    }
}