using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Assets
{
    class Population
    {
        List<Agent> agents = new List<Agent>();
        List<Agent> sortedAgentList;
        string filename = @"C:\Users\Hosanna\Documents\year3\3rdyearproject\application\2DGame\agent.txt";

        public Population(List<Agent> agents)
        {
            this.agents = agents;
            RemoveWeakest();
            WriteFile(filename);
        }

        public void RemoveWeakest()
        {
            sortedAgentList = agents.OrderBy(o => o.fitness).ToList();

            var firstRem = sortedAgentList.ElementAt(0);
            var secondRem = sortedAgentList.ElementAt(1);

            List<Connection> l1 = firstRem.GetConnections();
            List<Connection> l2 = secondRem.GetConnections();

            XmlDocument loadDoc = new XmlDocument();
            loadDoc.Load("C:\\Users\\Hosanna\\Documents\\year3\\3rdyearproject\\application\\2DGame\\xmlText.xml");
            foreach (XmlNode n in loadDoc.SelectNodes("Population/NeuralNetwork"))
            {
                if (n.SelectSingleNode("ID").InnerText == l1.ElementAt(0).GetNeuralNetID()
                    || n.SelectSingleNode("ID").InnerText == l2.ElementAt(0).GetNeuralNetID())
                {
                    n.RemoveAll();
                }
            }

            loadDoc.Save("C:\\Users\\Hosanna\\Documents\\year3\\3rdyearproject\\application\\2DGame\\xmlText.xml");
            

            sortedAgentList.Remove(firstRem);
            sortedAgentList.Remove(secondRem);
        }

        public void WriteFile()
        {
            WriteFile(filename);
        }

        private void WriteFile(string filename)
        {
            TextWriter tw;

            if (!File.Exists(filename))
            {
                File.Create(filename);
                tw = new StreamWriter(filename);
            }
            else
            {
                File.WriteAllText(filename, String.Empty);
                tw = new StreamWriter(filename, true);

            }

            tw.WriteLine(sortedAgentList.Count + " agents in total:\n");

            foreach (Agent a in sortedAgentList)
            {
                tw.WriteLine(a.fitness + " ");
            }

            tw.Close();
        }

    }
}
