using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface INeuralLayerFactory
{
    INeuralLayer CreateNeuralLayer(int numberOfNeurons, IActivationFunction activationFunction, IInputFunction inputFunction);
}
