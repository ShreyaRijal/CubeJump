using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using UnityEngine;

namespace Assets
{
    class InitialConnectionData
    {
        public List<Connection> connections = new List<Connection>();
        public int[] inNodes = { 0, 0, 0, 0, 0, 0, 0, 0 };
        public float[] outNodes = { 1, 1, 1 };
        static XmlTextWriter textWriter;

        public InitialConnectionData()
        {
            //SetBias();
            //InputToOutput();

        }

        public void SetBias()
        {
            System.Random rand = new System.Random();

            for (int i = 0; i < outNodes.Length; i++)
            {
                float bias = rand.Next(0, 10);
                bias = bias / 10;
                outNodes[i] = outNodes[i] * bias;
            }

        }

        public void InputToOutput()
        {
            System.Random rand = new System.Random();
            Guid id = Guid.NewGuid();

            if (!File.Exists("C:\\Users\\Hosanna\\Documents\\year3\\3rdyearproject\\application\\2DGame\\xmlText.xml"))
            {
                textWriter = new XmlTextWriter
                ("C:\\Users\\Hosanna\\Documents\\year3\\3rdyearproject\\application\\2DGame\\xmlText.xml", Encoding.UTF8);

                textWriter.Formatting = Formatting.Indented;
                textWriter.WriteStartDocument();
                textWriter.WriteStartElement("Population");
                textWriter.WriteStartElement("NeuralNetwork");
                textWriter.WriteStartElement("ID");
                textWriter.WriteString(id.ToString());
                textWriter.WriteEndElement();
                for (int i = 0; i < outNodes.Length; i++)
                {
                    for (int j = 0; j < inNodes.Length; j++)
                    {
                        float weight = rand.Next(0, 10);
                        weight = weight / 10;

                        Connection c = new Connection(inNodes[j], outNodes[i], weight, true, id.ToString());
                        // Debug.Log(c.GetInnovationNum());
                        textWriter.WriteStartElement("Connection");
                        textWriter.WriteStartElement("Input");
                        textWriter.WriteString(inNodes[j].ToString());
                        textWriter.WriteEndElement();
                        textWriter.WriteStartElement("Output");
                        textWriter.WriteString(outNodes[i].ToString());
                        textWriter.WriteEndElement();
                        textWriter.WriteStartElement("Weight");
                        textWriter.WriteString(weight.ToString());
                        textWriter.WriteEndElement();
                        textWriter.WriteStartElement("Expressed");
                        textWriter.WriteString(c.GetExpressed().ToString());
                        textWriter.WriteEndElement();
                        textWriter.WriteStartElement("InnovationNum");
                        textWriter.WriteString(c.GetInnovationNum().ToString());
                        textWriter.WriteEndElement();
                        textWriter.WriteEndElement();
                        connections.Add(c);
                    }
                }

                textWriter.WriteFullEndElement();
                textWriter.WriteFullEndElement();
                textWriter.WriteEndDocument();
                textWriter.Flush();
                textWriter.Close();
            }
            else
            {
                XDocument doc = XDocument.Load("C:\\Users\\Hosanna\\Documents\\year3\\3rdyearproject\\application\\2DGame\\xmlText.xml");

                XElement elem = doc.Element("Population");
                XElement n = new XElement("NeuralNetwork");
                XElement neuralNetID = new XElement("ID", id.ToString());
                elem.Add(n);
                n.Add(neuralNetID);

                for (int i = 0; i < outNodes.Length; i++)
                {
                    for (int j = 0; j < inNodes.Length; j++)
                    {
                        float weight = rand.Next(0, 10);
                        weight = weight / 10;

                        Connection c = new Connection(inNodes[j], outNodes[i], weight, true, id.ToString());
                        n.Add(new XElement("Connection",
                                new XElement("Input", inNodes[j].ToString()),
                                new XElement("Output", outNodes[i].ToString()),
                                new XElement("Weight", weight.ToString()),
                                new XElement("Expressed", c.GetExpressed().ToString()),
                                new XElement("InnovationNum", c.GetInnovationNum().ToString())));

                        connections.Add(c);
                    }
                }
                doc.Save("C:\\Users\\Hosanna\\Documents\\year3\\3rdyearproject\\application\\2DGame\\xmlText.xml");

            }
        }
    }
}
