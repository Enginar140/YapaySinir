using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YapaySinir
{
    public class Neuron
    {
        public double[] agirliklar;
        public Random random = new Random();
        public Neuron(int matrixSize)
        {
            agirliklar = new double[matrixSize];
            for (int i = 0; i < matrixSize; i++)
            {
                agirliklar[i] = random.NextDouble();
            }
        }
        public double sonuc(int[] girdiler)
        {
            double sum = 0;
            for (int i = 0; i < girdiler.Length; i++)
            {
                sum += girdiler[i] * agirliklar[i];
            }
            return fonksiyon(sum);
        }
        public double fonksiyon(double sum)
        {
            return sum <= 0.5 ? 0.0 : 1.0;
        }
        public void agirlikGuncelleme(int[] girdiler,double error,double learningRate)
        {
            for (int i = 0;i < agirliklar.Length; i++)
            {
                agirliklar[i] += learningRate * error *girdiler [i];
            }
        }
            
            
            
            
            
            
    }
}

