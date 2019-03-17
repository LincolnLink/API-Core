using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Entidades
{
    public class Cliente
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public DateTime DataCadastro { get; set; }
    }
}
