using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutonomicCarController : CarController
{	
	// Update is called once per frame
	protected override void Update ()
    {
        base.Update();
        MoveForward();
        steer();
	}

    private void steer()
    {
        var difference = DistanceToRightWall - DistanceToLeftWall;
        if (difference > 1)
            TurnRight();
        else if (difference < -1)
            TurnLeft();
    }
}
