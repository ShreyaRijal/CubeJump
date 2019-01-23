using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets
{
    class Agent
    {
        int fitness;
        List<int> inNodes;
        List<float> hiddenNodes;
        List<float> outNodes;
        List<Connection> connections;

        public Agent(List<int> inNodes, List<float> hiddenNodes, List<float> outNodes,
                     List<Connection> connections, int fitness)
        {
            this.inNodes = inNodes;
            this.hiddenNodes = hiddenNodes;
            this.outNodes = outNodes;
            this.connections = connections;
            this.fitness = fitness;

        }

        public int GetFitness()
        {
            return fitness;
        }

        public List<Connection> GetConnections()
        {
            return connections;
        }
        public void AddConnection(int input, float output, int weight, bool expressed)
        {
            Connection c = new Connection(input, output, weight, true);

            connections.Add(c);
        }

        public void AddNode(int input, float output, Connection old)
        {
            old.DisableConnection();
            int newNode =0;
            hiddenNodes.Add(newNode);

            Connection inputToHidden = new Connection(input, newNode, 1, true);
            connections.Add(inputToHidden);
            Connection hiddenToOutput = new Connection(newNode, output, old.GetWeight(), true);
            connections.Add(hiddenToOutput);

        }

        public Agent Crossover(Agent fitterParent, Agent parent)
        {
            Agent offspring;
            List<int> inputs = new List<int>();
            List<float> hiddens = new List<float>();
            List<float> outputs = new List<float>();
            List<Connection> cons = new List<Connection>();
            int fitness= fitterParent.GetFitness();

            offspring = new Agent(inputs, hiddens, outputs, cons, fitness);
            foreach (Connection gene in fitterParent.GetConnections())
            {
                foreach (Connection gene2 in parent.GetConnections())
                {
                    if (gene.GetInnovationNum() == gene2.GetInnovationNum())
                    {
                        cons.Add(gene);
                        //todo: add to list of nodes. getting nodes from gene connection. then do 
                        //excess/disjoint stuff in if statement
                    }
                }
            }
            return null;
        }
    }
}
