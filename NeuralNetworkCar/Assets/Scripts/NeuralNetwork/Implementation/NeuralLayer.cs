using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NeuralLayer : INeuralLayer
{
    public List<INeuron> Neurons { get; set; }

    public NeuralLayer()
    {
        Neurons = new List<INeuron>();
    }

    /// <summary>
    /// Connecting two layers.
    /// </summary>
    public void ConnectLayers(INeuralLayer inputLayer)
    {
        var combos = Neurons.SelectMany(neuron => inputLayer.Neurons,
        (neuron, input) => new { neuron, input });
        combos.ToList().ForEach(x => x.neuron.AddInputNeuron(x.input));
    }
}
