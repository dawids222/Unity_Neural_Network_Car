using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutonomicCarController : CarController
{
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
        if (difference > 1)
            TurnRight();
        else if (difference < -1)
            TurnLeft();
    }

    private void neuralNetworkSteer()
    {
        var networkOutput = Brain.Compute(DistanceToLeftWall, DistanceToRightWall);
        if (networkOutput > turnRightCondition)
            TurnRight();
        else if (networkOutput < turnLeftCondition)
            TurnLeft();
    }
}
