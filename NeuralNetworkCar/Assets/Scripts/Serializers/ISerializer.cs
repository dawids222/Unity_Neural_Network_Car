using NeuralNetwork.Helpers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISerializer
{
    void Serialize(HelperNetwork network, string filename);
    HelperNetwork Deserialize(string filename);
}
