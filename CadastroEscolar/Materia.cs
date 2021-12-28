using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroEscolar
{
    public class Materia
    {
        string Titulo;
        string Prof;
        double[] Notas = new double[4];
        double media;
        int faltas;
        string status;

        public void setNotas(int i, double v)
        {
            Notas[i-1] = v;
        }
        public double getMedia()
        {
            double soma = 0;
            foreach(double d in Notas)
            {
                soma += d;
            }

            media = soma / 4;
            return media;
        }
        public string getStatus()
        {
            if (media >= 6.0)
                return "Aprovado.";
            else
                return "Reprovado";
        }
    }
}
