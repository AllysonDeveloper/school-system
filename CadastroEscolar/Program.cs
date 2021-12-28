using System;

namespace CadastroEscolar
{
    class Program
    {
        static void Main(string[] args)
        {
            Interface inter = new Interface();
            //inter.CadastrarProfessor();
            inter.ListarProfessores();
            inter.ExcluirProfessor();

        }
    }
}
