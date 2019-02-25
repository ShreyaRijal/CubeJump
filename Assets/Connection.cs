using UnityEngine;

namespace Assets
{
    class Connection
    {
        int input;
        float hidden;
        float output;
        float weight;
        bool expressed;
        string neuralNetID;
        static int innovationNum =0;


        public Connection(int input, float output, float weight, bool expressed, string neuralNetID)
        {
            this.input = input;
            this.output = output;
            this.weight = weight;
            this.expressed = expressed;
            this.neuralNetID = neuralNetID;
            innovationNum++;
        }

        public string GetNeuralNetID()
        {
            return neuralNetID;
        }
        public void DisableConnection()
        {
            expressed = false;
        }

        public float GetWeight()
        {
            return weight;
        }

        public int GetInnovationNum()
        {
            return innovationNum;
        }

        public int GetInNode()
        {
            return input;
        }

        public float GetHiddenNode()
        {
            return hidden;
        }

        public float GetOutNode()
        {
            return output;
        }

        public bool GetExpressed()
        {
            return expressed;
        }

        public string ConnectionToString()
        {
            return input + " " + hidden + " " + output + " " + weight + " " + expressed + " " + innovationNum;
        }
    }
}
