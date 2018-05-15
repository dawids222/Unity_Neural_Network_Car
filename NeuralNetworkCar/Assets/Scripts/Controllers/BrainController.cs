using NeuralNetwork.Helpers;
using NeuralNetwork.NetworkModels;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class BrainController : MonoBehaviour
{
    public bool TrainOnInit;
    public string LearningFileName;
    public string LearnedNetworkFileName;
    public int NumberOfEpochs;

    private const char _learningFileDelimiter = ';';

    public NeuralNetwork.NetworkModels.Network NeuralNetwork { get; private set; }

	// Use this for initialization
	void Start () {
        NeuralNetwork = ImportHelper.ImportNetwork(LearnedNetworkFileName, new XmlSerializer());
        //TestNetwork();
    }

    public double Compute(double distanceToLeftWall, double distanceToRightWall)
    {
        return NeuralNetwork.Compute(new double[] { distanceToLeftWall, distanceToRightWall })[0];
    }

    public void Train()
    {
        
    }

    public void Save()
    {

    }

    public void Load()
    {

    }

    public void TestNetwork()
    {
        double l = 14;
        double r = 14;
        Debug.Log (NeuralNetwork.Compute(new double[] { l, r })[0] );

        l = 20;
        r = 10;
        Debug.Log(NeuralNetwork.Compute(new double[] { l, r })[0]);

        l = 10.72468;
        r = 42.37657;
        Debug.Log(NeuralNetwork.Compute(new double[] { l, r })[0]);
    }

    private List<DataSet> getDatasets()
    {
        var result = new List<DataSet>();

        using (var reader = new StreamReader(LearningFileName))
        {
            while(!reader.EndOfStream)
            {
                var elements = reader.ReadLine().Split(_learningFileDelimiter);
                var dataset = new DataSet(new double[] { double.Parse(elements[0]), double.Parse(elements[1]) }, new double[] { double.Parse(elements[2]) });
                result.Add(dataset);
            }
        }

        return result;
    }
}
