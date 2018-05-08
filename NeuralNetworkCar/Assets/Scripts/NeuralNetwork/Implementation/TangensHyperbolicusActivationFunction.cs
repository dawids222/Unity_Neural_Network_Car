using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TangensHyperbolicusActivationFunction : IActivationFunction
{
    public double CalculateOutput(double input)
    {
        return Math.Tanh(input);
    }
}
