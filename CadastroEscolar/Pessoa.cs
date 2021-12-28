using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroEscolar
{
    public abstract class Pessoa
    {
        public string Nome
        {
            get;
            set;
        }
        public string Matricula
        {
            get;
            set;
        }
        public int Idade
        {
            set;
            get;
        }

        public abstract void Cadastrar();
        public abstract void Listar();
        public abstract void Editar();
        public abstract void Excluir();
    }
}
