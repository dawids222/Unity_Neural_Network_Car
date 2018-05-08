using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WeightedSumFunction : IInputFunction
{
    public double CalculateInput(List<ISynapse> inputs)
    {
        return inputs.Select(x => x.Weight * x.GetOutput()).Sum();
    }
}
