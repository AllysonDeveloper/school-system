using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroEscolar
{
    public class Professor : Pessoa
    {
        public const string Caminho = @"C:\db\professores.txt";
        public override void Cadastrar()
        {
            string linha = this.Nome + ";" + this.Matricula + ";" + this.Idade;
            Console.WriteLine(linha);
            Arquivo.GravarArquivo(linha, Caminho, true);
        }

        public override void Excluir()
        {

        }

        public override void Editar()
        {
            throw new NotImplementedException();
        }

        public override void Listar()
        {
            throw new NotImplementedException();
        }
    }
} 
