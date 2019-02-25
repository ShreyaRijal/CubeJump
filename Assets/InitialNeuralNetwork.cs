using System;
using System.Collections.Generic;


namespace Assets
{
    class InitialNeuralNetwork
    {
        public int[] inNodes = new int[8];
        public float[] outNodes = new float[3];
        public InitialConnectionData con = new InitialConnectionData();
        public List<Connection> connections = new List<Connection>();

        public InitialNeuralNetwork(int[] inNodes)
        {
            this.inNodes = inNodes;

            MakeNetwork();
        }

        public InitialNeuralNetwork(int[] inNodes, InitialConnectionData con)
        {
            this.con = con;
            this.inNodes = inNodes;

            MakeNetwork();
        }

        public void MakeNetwork()
        {
            connections = con.connections;

            for (int j = 0; j < 8; j++)
            {
                outNodes[0] += connections[j].GetOutNode() + (inNodes[j] * connections[j].GetWeight());


            }

            for (int j = 8; j < 16; j++)
            {
                outNodes[1] += connections[j].GetOutNode() + (inNodes[j - 8] * connections[j].GetWeight());

 
            }


            for (int j = 16; j < 24; j++)
            {
                outNodes[2] += connections[j].GetOutNode() + (inNodes[j - 16] * connections[j].GetWeight());

            }

        }

    }
}
