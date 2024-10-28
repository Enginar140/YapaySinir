namespace YapaySinir
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NeuralNetwork network = new NeuralNetwork();

            // Eğitim veri seti (10 adet "1" ve 10 adet "2" matrisi)
            int[][] trainingData = new int[2][];
            int[] labels = new int[2]; // İlk 10 "1", son 10 "2" olarak etiketlenir

            // Örneğin, veri setini 5x5 matrisleri 1D diziye dönüştürerek doldur
            trainingData[0] = new int[] { 0, 1, 0, 0, 0, 1, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 1, 1, 1, 0, 0 };
            labels[0] = 1; // "1" rakamı örneği

            trainingData[10] = new int[] { 1, 1, 1, 0, 0, 0, 0, 0, 1, 0, 1, 1, 1, 0, 0, 1, 0, 0, 0, 0, 1, 1, 1, 1, 0 };
            labels[10] = 2; // "2" rakamı örneği

            // Diğer veriler eklenir...

            double learningRate = 0.03;
            int epochs = 40;

            network.Train(trainingData, labels, learningRate, epochs);

            // Test aşaması
            int correctPredictions = 0;
            for (int i = 0; i < trainingData.Length; i++)
            {
                int prediction = network.Predict(trainingData[i]);
                Console.WriteLine($"Hedef: {labels[i]}, Tahmin: {prediction}");
                if (prediction == labels[i]) correctPredictions++;
            }

            double accuracy = (double)correctPredictions / trainingData.Length * 100;
            Console.WriteLine($"Doğruluk: {accuracy}%");
        }
    }
}

