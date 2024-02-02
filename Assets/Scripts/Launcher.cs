using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum OutputerType
{
    SimpleOutputer,
    GridOutputer,
    GenericGridOutputer
}

public class Launcher : MonoBehaviour
{
    [SerializeField] private OutputerType _type;

    [SerializeField] private int collumnCount;
    void Start()
    {
        IEnumerable<Worker> data = Workers.TestData;
        if (_type == OutputerType.SimpleOutputer)
        {
            SimpleOutputAllData(data);
        }
        else if (_type == OutputerType.GridOutputer)
        {
            EasyGridOutputer.Instance.OutputGrid(data,collumnCount);   
        }
        else if(_type == OutputerType.GenericGridOutputer)
        {
            data.ToGrid(120, 2).WriteLines();
        }
    }

    private void SimpleOutputAllData(IEnumerable<Worker> data)
    {
        foreach (Worker worker in data)
        {
            Debug.Log(worker);
        }
    }
}