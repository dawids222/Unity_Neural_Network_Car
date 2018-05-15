using NeuralNetwork.Helpers;
using NeuralNetwork.NetworkModels;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// Klasa do przechowywania i rządzania instancją sieci nauronowej
/// </summary>
public class BrainController : MonoBehaviour
{
    [Header("Learned")]
    public string LearnedNetworkFileName;

    [Header("Learning")]
    public bool TrainOnInit;
    public string LearningFileName;
    public double MaxError;

    private const char _learningFileDelimiter = ';';

    public NeuralNetwork.NetworkModels.Network NeuralNetwork { get; private set; }

	// Use this for initialization
	void Start ()
    {
        if (TrainOnInit)
            Train();
        else
            Load();
    }

    /// <summary>
    /// Wyciąga z sieci wynik na podstawie odległości od ścian
    /// </summary>
    /// <param name="distanceToLeftWall"></param>
    /// <param name="distanceToRightWall"></param>
    /// <returns></returns>
    public double Compute(double distanceToLeftWall, double distanceToRightWall)
    {
        return NeuralNetwork.Compute(new double[] { distanceToLeftWall, distanceToRightWall })[0];
    }

    /// <summary>
    /// Cwiczy sieć neuronową na podstawie danych ze wskazanego pliku
    /// </summary>
    public void Train()
    {
        NeuralNetwork.Train(getDatasets(), MaxError);
    }

    /// <summary>
    /// Serializuje obecją instancję sieci neuronowej i zapisuje ją do wskazanego pliku
    /// </summary>
    public void Save()
    {
        ExportHelper.ExportNetwork(NeuralNetwork, LearnedNetworkFileName, new XmlSerializer());
    }

    /// <summary>
    /// Odtwarza zserializowaną sieć neuronową z pliku
    /// </summary>
    public void Load()
    {
        NeuralNetwork = ImportHelper.ImportNetwork(LearnedNetworkFileName, new XmlSerializer());
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

    /// <summary>
    /// Pobiera dane ze wskazanego pliku i formuje z nich listę obiektów DataSet
    /// </summary>
    /// <returns></returns>
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
