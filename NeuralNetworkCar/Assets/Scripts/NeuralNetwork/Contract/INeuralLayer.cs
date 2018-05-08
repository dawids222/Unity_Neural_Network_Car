using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface INeuralLayer
{
    List<INeuron> Neurons { get; set; }
    void ConnectLayers(INeuralLayer inputLayer);
}
