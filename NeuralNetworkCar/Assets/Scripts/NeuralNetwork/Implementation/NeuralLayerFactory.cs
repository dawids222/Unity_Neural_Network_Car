using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeuralLayerFactory : INeuralLayerFactory
{
    public INeuralLayer CreateNeuralLayer(int numberOfNeurons, IActivationFunction activationFunction, IInputFunction inputFunction)
    {
        var layer = new NeuralLayer();

        for(int i = 0; i < numberOfNeurons; i++)
        {
            layer.Neurons.Add(new Neuron(activationFunction, inputFunction));
        }

        return layer;
    }
}
