using UnityEngine;

namespace Assets
{
    class Connection: MonoBehaviour
    {
        int input;
        float hidden;
        float output;
        float weight;
        bool expressed;
        static int innovationNum =0;


        public Connection(int input, float output, float weight, bool expressed)
        {
            this.input = input;
            this.output = output;
            this.weight = weight;
            this.expressed = expressed;
            innovationNum++;
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
    }
}
