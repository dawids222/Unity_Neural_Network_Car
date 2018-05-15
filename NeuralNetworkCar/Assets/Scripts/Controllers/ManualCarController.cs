using NeuralNetwork.NetworkModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManualCarController : CarController
{
    [Header("Steering")]
    public KeyCode UpKey = KeyCode.W;
    public KeyCode RightKey = KeyCode.D;
    public KeyCode LeftKey = KeyCode.A;

    [Header("Learning Data")]
    public bool CollectLearningData;
    public double CollectiongDataInterval;
    public string LearnignDataFileName;

    private double elapsedTimeSinceLastCollection = 0;
    private const char learningFileDelimiter = ';';


    // Update is called once per frame
    protected override void Update ()
    {
        base.Update();

        move();

        if (CollectLearningData)
        {
            elapsedTimeSinceLastCollection += Time.deltaTime;

            if (elapsedTimeSinceLastCollection >= CollectiongDataInterval)
            {
                collectLearningdata();
                elapsedTimeSinceLastCollection = 0;
            }
        }
    }

    private void move()
    {
        if (Input.GetKey(UpKey))
        {
            MoveForward();
        }

        if (Input.GetKey(RightKey))
        {
            TurnRight();
        }
        if (Input.GetKey(LeftKey))
        {
            TurnLeft();
        }
    }

    private void collectLearningdata()
    {
        using (var writer = File.AppendText(LearnignDataFileName))
        {
            var expectedOutput = Sigmoid.Output(DistanceToRightWall - DistanceToLeftWall);
            Debug.Log(expectedOutput);
            writer.WriteLine(string.Format("{0}{3}{1}{3}{2}", DistanceToLeftWall, DistanceToRightWall, expectedOutput, learningFileDelimiter));
            Debug.Log(DistanceToLeftWall + " " + DistanceToRightWall + " " + expectedOutput);
        }
    }
}
