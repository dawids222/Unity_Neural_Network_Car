using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutonomicCarController : CarController
{
    [Header("Neural network holder")]
    // Odwołanie do obiektu z siecią neuronową
    public BrainController Brain;

    private const double turnRightCondition = 2f / 3f;
    private const double turnLeftCondition = 1f / 3f;

    // Update is called once per frame
    protected override void Update ()
    {
        base.Update();
        MoveForward();
        steer();
	}

    private void steer()
    {
        neuralNetworkSteer();
    }

    private void simpleSteer()
    {
        var difference = DistanceToRightWall - DistanceToLeftWall;
        makeDecision(difference, 1, -1);
    }

    private void neuralNetworkSteer()
    {
        var networkOutput = Brain.Compute(DistanceToLeftWall, DistanceToRightWall);
        makeDecision(networkOutput, turnRightCondition, turnLeftCondition);
    }

    private void makeDecision(double value, double turnRightCondition, double turnLeftCondition)
    {
        if (value > turnRightCondition)
            TurnRight();
        else if (value < turnLeftCondition)
            TurnLeft();
    }
}
