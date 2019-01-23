using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets
{
    class InitialConnectionData
    {
        public List<Connection> connections = new List<Connection>();
        public int[] inNodes = { 0, 0, 0, 0, 0, 0, 0, 0 };
        public float[] outNodes = { 1, 1, 1 };


        public InitialConnectionData()
        {
            SetBias();
            InputToOutput();

        }

        public void SetBias()
        {
            Random rand = new Random();

            for (int i = 0; i < outNodes.Length; i++)
            {
                float bias = rand.Next(0, 10);
                bias = bias / 10;
                outNodes[i] = outNodes[i]*bias;
            }

        }
        public void InputToOutput()
        {
            Random rand = new Random();
            for (int i = 0; i < outNodes.Length; i++)
            {
                for (int j = 0; j < inNodes.Length; j++)
                {
                    float weight = rand.Next(0, 10);
                    weight = weight / 10;

                    Connection c = new Connection(inNodes[j], outNodes[i], weight, true);
                    connections.Add(c);
                }
            }
        }
    }
}
