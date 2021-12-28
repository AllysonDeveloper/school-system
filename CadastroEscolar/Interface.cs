using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroEscolar
{
    class Interface
    {
        public void CadastrarProfessor()
        {
            Professor professor = new Professor();

            Console.WriteLine("Bem vindo ao cadastro do Professor");
            Console.WriteLine("Informe o Nome: ");
            professor.Nome = Console.ReadLine();
            Console.WriteLine("Informe a Matricula: ");
            professor.Matricula = Console.ReadLine();
            Console.WriteLine("Informe a Idade: ");
            professor.Idade = Int32.Parse(Console.ReadLine());

            professor.Cadastrar();
        }

        public void ListarProfessores()
        {
            string[] linhas = Arquivo.LerArquivo(Professor.Caminho);
            Console.WriteLine("Lista dos Professores Cadastrados:");
            foreach(string linha in linhas)
            {
                string[] dados = linha.Split(";");
                Console.WriteLine("Nome: "+ dados[0]);
                Console.WriteLine("Matricula: " + dados[1]);
                Console.WriteLine("Idade: " + dados[2]);
                Console.WriteLine("========================");
            }
        }
        public List<Professor> CarregarProfessores()
        {
            List<Professor> professores = new List<Professor>();
            string[] linhas = Arquivo.LerArquivo(Professor.Caminho);
            foreach (string linha in linhas)
            {
                Professor prof = new Professor();
                string[] dados = linha.Split(";");
                prof.Nome = dados[0];
                prof.Matricula = dados[1];
                prof.Idade = Int32.Parse(dados[2]);
                professores.Add(prof);
            }
            return professores;
        } 

        public void AtualizarProfessor()
        {
            List<Professor> professores = this.CarregarProfessores();
            Console.WriteLine("Informe a Matricula do Professor que deseja Alterar: ");
            var matricula = Console.ReadLine();
            bool contem = false;
            foreach(Professor prof in professores)
            {
                if(prof.Matricula == matricula)
                {
                    contem = true;
                    Console.WriteLine("Nome atual: " + prof.Nome);
                    Console.WriteLine(" Idade atual: " + prof.Idade);
                    Console.WriteLine("----------------------");
                    Console.WriteLine("Digite um novo nome ou o mesmo: ");
                    prof.Nome = Console.ReadLine();
                    Console.WriteLine("Digite uma nova idade ou a mesma: ");
                    prof.Idade = Int32.Parse(Console.ReadLine());
                    break;
                }
            }
            if(contem == false)
                Console.WriteLine("Registro não encontrado, verifique se digitou a matrícula corretamente.");
            else
            {
                var count = 0;
                foreach(Professor prof in professores)
                {
                    string linha = prof.Nome + ";" + prof.Matricula + ";" + prof.Idade;
                    if (count == 0)
                    { 
                        Arquivo.GravarArquivo(linha, Professor.Caminho, false);
                        count++;
                    }
                    else
                    {
                        Arquivo.GravarArquivo(linha, Professor.Caminho, true);
                    }
                }
            }
            this.ListarProfessores();
        }

        public void ExcluirProfessor()
        {
            Professor p = new Professor();
            List<Professor> professores = this.CarregarProfessores();
            Console.WriteLine("Informe a Matricula do Professor que deseja excluir: ");
            var matricula = Console.ReadLine();
            bool contem = false;
            
            foreach (Professor prof in professores)
            {
                if (prof.Matricula == matricula)
                {
                    p = prof;
                    contem = true;
                    break;
                }
            }
            if (contem == false)
                Console.WriteLine("Registro não encontrado, verifique se digitou a matrícula corretamente.");
            else
            {
                professores.Remove(p);
                var count = 0;
                foreach (Professor prof in professores)
                {
                    string linha = prof.Nome + ";" + prof.Matricula + ";" + prof.Idade;
                    if (count == 0)
                    {
                        Arquivo.GravarArquivo(linha, Professor.Caminho, false);
                        count++;
                    }
                    else
                    {
                        Arquivo.GravarArquivo(linha, Professor.Caminho, true);
                    }
                }
            }
            this.ListarProfessores();
        }
    }
}
