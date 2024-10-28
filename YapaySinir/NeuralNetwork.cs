using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YapaySinir
{
    public class NeuralNetwork
    {
        private Neuron neuron1;
        private Neuron neuron2;

        public NeuralNetwork()
        {
            neuron1 = new Neuron(25);
            neuron2 = new Neuron(25);
        }
        public int Predict(int[] girdiler)
        {
            double output1 = neuron1.sonuc(girdiler);
            double output2 = neuron2.sonuc(girdiler);

            return output1 > output2 ? 1 : 2;
        }
        public void Train(int[][] trainingData, int[] labels, double learningRate, int epochs)
        {
            for (int epoch = 0; epoch < epochs; epoch++)
            {
                for (int i = 0; i < trainingData.Length; i++)
                {
                    int[] girdiler = trainingData[i];
                    int target = labels[i];

                    double output1 = neuron1.sonuc(girdiler);
                    double output2 = neuron2.sonuc(girdiler);

                    double error1 = (target == 1 ? 1.0 : 0.0) - output1;
                    double error2 = (target == 2 ? 1.0 : 0.0) - output2;

                    neuron1.agirlikGuncelleme(girdiler, error1, learningRate);
                    neuron2.agirlikGuncelleme(girdiler, error2, learningRate);
                }
            }

        }
    }
}
