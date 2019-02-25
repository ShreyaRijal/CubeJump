using Assets;
using UnityEngine;
using System.Collections.Generic;
using System;
using System.Xml;
using System.Text;

public class DetectionWithRays : MonoBehaviour
{
    public Transform cube;
    bool col = false;
    Vector2 forward = Vector2.right;
    Vector2 back = Vector2.left;
    Vector2 up = Vector2.up;
    Vector2 down = Vector2.down;
    Vector2 northEast = new Vector2(1f, 1f);
    Vector2 northWest = new Vector2(-1f, 1f);
    Vector2 southEast = new Vector2(1f, -1f);
    Vector2 southWest = new Vector2(-1f, -1f);
    static List<Agent> agents = new List<Agent>();
    Population pop;
    float fitness = 0f;

    float distance = 2f;

    bool grounded = false;

    int first = 0;
    int second = 0;
    int third = 0;
    int fourth = 0;
    int fifth = 0;
    int sixth = 0;
    int seventh = 0;
    int eighth = 0;

    private static InitialConnectionData con = new InitialConnectionData();
    private static InitialConnectionData con2 = new InitialConnectionData();
    private static InitialConnectionData con3 = new InitialConnectionData();
    private static InitialConnectionData con4 = new InitialConnectionData();
    private static InitialConnectionData con5 = new InitialConnectionData();
    private static InitialConnectionData con6 = new InitialConnectionData();
    private static InitialConnectionData con7 = new InitialConnectionData();
    private static InitialConnectionData con8 = new InitialConnectionData();
    private static InitialConnectionData con9 = new InitialConnectionData();
    private static InitialConnectionData con10 = new InitialConnectionData();

    int[] input = new int[8];

    InitialNeuralNetwork network;

    InitialNeuralNetwork firstNetwork;
    InitialNeuralNetwork secondNetwork;
    InitialNeuralNetwork thirdNetwork;
    InitialNeuralNetwork fourthNetwork;
    InitialNeuralNetwork fifthNetwork;
    InitialNeuralNetwork sixthNetwork;
    InitialNeuralNetwork seventhNetwork;
    InitialNeuralNetwork eighthNetwork;
    InitialNeuralNetwork ninthNetwork;
    InitialNeuralNetwork tenthNetwork;

    static int counter = 0;

    void Start()
    {
        if (counter < 11)
        {
            counter = counter + 1;
        }
        else
        {
            Application.Quit();
        }

        if (counter == 1)
        {
            con.SetBias(); con.InputToOutput(); 
            con2.SetBias(); con2.InputToOutput();
            con3.SetBias(); con3.InputToOutput();
            con4.SetBias(); con4.InputToOutput();
            con5.SetBias(); con5.InputToOutput();
            con6.SetBias(); con6.InputToOutput();
            con7.SetBias(); con7.InputToOutput();
            con8.SetBias(); con8.InputToOutput();
            con9.SetBias(); con9.InputToOutput();
            con10.SetBias(); con10.InputToOutput();


        }
    }

    void Update()
    {

        Debug.DrawRay(cube.transform.position, forward * distance, Color.white);
        Debug.DrawRay(cube.transform.position, back * distance, Color.white);
        Debug.DrawRay(cube.transform.position, up * distance, Color.white);
        Debug.DrawRay(cube.transform.position, down * distance, Color.white);
        Debug.DrawRay(cube.transform.position, northEast * distance, Color.white);
        Debug.DrawRay(cube.transform.position, northWest * distance, Color.white);
        Debug.DrawRay(cube.transform.position, southEast * distance, Color.white);
        Debug.DrawRay(cube.transform.position, southWest * distance, Color.white);

        if (col)
        {

            if (Physics2D.Raycast(cube.transform.position,
                northEast, distance, ((1 << 9) | (1 << 10) | (1 << 11) | (1 << 12))))
            {
                first = 1;
            }
            else
            {
                first = 0;
            }

            if (Physics2D.Raycast(cube.transform.position,
              forward, distance, ((1 << 9) | (1 << 10) | (1 << 11) | (1 << 12))))
            {
                second = 1;
            }
            else
            {
                second = 0;
            }

            if (Physics2D.Raycast(cube.transform.position,
              southEast, distance, ((1 << 9) | (1 << 10) | (1 << 11) | (1 << 12))))
            {
                third = 1;
            }
            else
            {
                third = 0;
            }

            if (Physics2D.Raycast(cube.transform.position,
              down, distance, ((1 << 9) | (1 << 10) | (1 << 11) | (1 << 12))))
            {
                fourth = 1;
            }
            else
            {
                fourth = 0;
            }

            if (Physics2D.Raycast(cube.transform.position,
              southWest, distance, ((1 << 9) | (1 << 10) | (1 << 11) | (1 << 12))))
            {
                fifth = 1;
            }
            else
            {
                fifth = 0;
            }

            if (Physics2D.Raycast(cube.transform.position,
              back, distance, ((1 << 9) | (1 << 10) | (1 << 11) | (1 << 12))))
            {
                sixth = 1;
            }
            else
            {
                sixth = 0;
            }

            if (Physics2D.Raycast(cube.transform.position,
              northWest, distance, ((1 << 9) | (1 << 10) | (1 << 11) | (1 << 12))))
            {
                seventh = 1;
            }
            else
            {
                seventh = 0;
            }

            if (Physics2D.Raycast(cube.transform.position,
              up, distance, ((1 << 9) | (1 << 10) | (1 << 11) | (1 << 12))))
            {
                eighth = 1;
            }
            else
            {
                eighth = 0;
            }

            input[0] = first;
            input[1] = second;
            input[2] = third;
            input[3] = fourth;
            input[4] = fifth;
            input[5] = sixth;
            input[6] = seventh;
            input[7] = eighth;

            firstNetwork = new InitialNeuralNetwork(input, con);
            secondNetwork = new InitialNeuralNetwork(input, con2);
            thirdNetwork = new InitialNeuralNetwork(input, con3);
            fourthNetwork = new InitialNeuralNetwork(input, con4);
            fifthNetwork = new InitialNeuralNetwork(input, con5);
            sixthNetwork = new InitialNeuralNetwork(input, con6);
            seventhNetwork = new InitialNeuralNetwork(input, con7);
            eighthNetwork = new InitialNeuralNetwork(input, con8);
            ninthNetwork = new InitialNeuralNetwork(input, con9);
            tenthNetwork = new InitialNeuralNetwork(input, con10);

            switch (counter)
            {
                case 1:
                    network = firstNetwork;
                    RunNN(network);
                    break;
                case 2:
                    network = secondNetwork;
                    RunNN(network);
                    break;
                case 3:
                    network = thirdNetwork;
                    RunNN(network);
                    break;
                case 4:
                    network = fourthNetwork;
                    RunNN(network);
                    break;
                case 5:
                    network = fifthNetwork;
                    RunNN(network);
                    break;
                case 6:
                    network = sixthNetwork;
                    RunNN(network);
                    break;
                case 7:
                    network = seventhNetwork;
                    RunNN(network);
                    break;
                case 8:
                    network = eighthNetwork;
                    RunNN(network);
                    break;
                case 9:
                    network = ninthNetwork;
                    RunNN(network);
                    break;
                case 10:
                    network = tenthNetwork;
                    RunNN(network);
                    break;
            }
        }

    }

    private void RunNN(InitialNeuralNetwork net)
    {
        if (net.outNodes[0] >= 4)
        {
            cube.Translate(Vector2.right * 4f * Time.deltaTime);
        }

        if (net.outNodes[1] >= 5)
        {;
            cube.Translate(Vector2.left * 2f * Time.deltaTime);
        }

        if (grounded == true && net.outNodes[2] >= 2)
        {
            grounded = false;
            GetComponent<Rigidbody2D>().velocity = new Vector2
                    (GetComponent<Rigidbody2D>().velocity.x, 12.5f);
        }

        fitness = cube.position.x;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        col = true;
        grounded = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        grounded = false;
    }
    private void OnDestroy()
    {
        //Debug.Log("Game ended.");
        if (network != null)
        {
            Agent a = new Agent(network.connections, fitness);
            agents.Add(a);

        }

        if (counter == 10)
        {
            //Debug.Log("Will dump all fitnesses");
            pop = new Population(agents);
        }
    }
}
