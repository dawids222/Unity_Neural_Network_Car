using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrainController : MonoBehaviour {

    public SimpleNeuralNetwork NeuralNetwork { get; private set; }

	// Use this for initialization
	void Start () {
        NeuralNetwork = new SimpleNeuralNetwork(3);

        var layerFactory = new NeuralLayerFactory();
        NeuralNetwork.AddLayer(layerFactory.CreateNeuralLayer(3, new TangensHyperbolicusActivationFunction(), new WeightedSumFunction()));
        NeuralNetwork.AddLayer(layerFactory.CreateNeuralLayer(2, new TangensHyperbolicusActivationFunction(), new WeightedSumFunction()));
        NeuralNetwork.AddLayer(layerFactory.CreateNeuralLayer(1, new TangensHyperbolicusActivationFunction(), new WeightedSumFunction()));

    //    NeuralNetwork.PushExpectedValues(
    //new double[][] {
    //    new double[] { 0 },
    //    new double[] { 1 },
    //    new double[] { 1 },
    //    new double[] { 0 },
    //    new double[] { 1 },
    //    new double[] { 0 },
    //    new double[] { 0 },
    //});

    //    NeuralNetwork.Train(
    //        new double[][] {
    //    new double[] { 150, 2, 0 },
    //    new double[] { 1002, 56, 1 },
    //    new double[] { 1060, 59, 1 },
    //    new double[] { 200, 3, 0 },
    //    new double[] { 300, 3, 1 },
    //    new double[] { 120, 1, 0 },
    //    new double[] { 80, 1, 0 },
    //        }, 10000);

    //    NeuralNetwork.PushInputValues(new double[] { 1054, 54, 1 });
    //    var outputs = NeuralNetwork.GetOutput();

    //    foreach (var val in outputs)
    //    {
    //        Debug.Log(val);
    //    }
    }
}
