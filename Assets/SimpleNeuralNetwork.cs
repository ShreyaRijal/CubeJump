using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets
{
    class SimpleNeuralNetwork
    {
        public int[] inNodes = new int[8];
        public int[] hiddenNodes = new int[5];
        public int[] hiddenNodesBias = new int[5];
        public int[] outNodesIntermediate = new int[3];
        public int[] outNodesBias = new int[3];
        public bool[] outNodes = new bool[3];

        public SimpleNeuralNetwork(int[]inNodes)
        {
            this.inNodes = inNodes;

            SetBias();
            InputToHidden();
            HiddenToOutput();
            Output();
        }

        public void SetBias()
        {
            Random rand = new Random();
            for(int i =0;i<hiddenNodesBias.Length;i++)
            {
                int bias = rand.Next(0, 10);
                hiddenNodesBias[i] = bias;
            }

            for (int i = 0; i < outNodesBias.Length; i++)
            {
                int bias = rand.Next(0, 10);
                outNodesBias[i] = bias;
            }
        }

        public void InputToHidden()
        {
            Random rand = new Random();
            for (int i = 0; i < hiddenNodes.Length; i++)
            {
                for(int j = 0; j < inNodes.Length; j++)
                {
                    int weight = rand.Next(0, 10);
                    hiddenNodes[i] += inNodes[j] * weight;
                }
                hiddenNodes[i] += hiddenNodesBias[i];
            }
        }

        public void HiddenToOutput()
        {
            Random rand = new Random();
            for (int i =0; i < outNodesIntermediate.Length; i++)
            {
                for(int j =0; j < hiddenNodes.Length; j++)
                {
                    int weight = rand.Next(0, 10);
                    outNodesIntermediate[i] += hiddenNodes[j] * weight;
                }
                outNodesIntermediate[i] += outNodesBias[i];
            }
        }

        public void Output()
        {
            for(int i = 0; i < outNodesIntermediate.Length; i++)
            {
                if (outNodesIntermediate[i] > 600)
                {
                    outNodes[i] = true;
                }
            }
        }
    }
}
