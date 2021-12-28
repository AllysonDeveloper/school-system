using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CadastroEscolar
{
    class Arquivo
    {
        public static string[] LerArquivo(string caminho)
        {
            string[] lines = System.IO.File.ReadAllLines(caminho);
            return lines;

        }

        public static void GravarArquivo(string line, string caminho, bool adicionar)
        {
            
            if (!System.IO.File.Exists(caminho))
            {
                var meuArquivo = System.IO.File.Create(caminho);
                meuArquivo.Close();
            }
            StreamWriter arquivo = new StreamWriter(caminho,adicionar);
            arquivo.WriteLine(line);
            arquivo.Close();
        }

        public static bool ExisteArquivo(string caminho)
        {
            if (System.IO.File.Exists(caminho))
                return true;
            else
                return false;
        }
    }
}
