using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInputFunction
{
    double CalculateInput(List<ISynapse> inputs);
}
