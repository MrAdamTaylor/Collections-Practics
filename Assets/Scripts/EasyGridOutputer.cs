using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;
using UnityEngine;

public class EasyGridOutputer
{
    [CanBeNull] private static EasyGridOutputer _instance;

    public static EasyGridOutputer Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new EasyGridOutputer();
            }
            return _instance;
        }
    }
    
    public void OutputGrid(IEnumerable<Worker> data, int collumnCount)
    {
        int[] colWidths = GetCollumnWidths(data, collumnCount);
        foreach (string row in FormatGridRows(data, colWidths))
        {
            Debug.Log(row);
        }
    }

    private int[] GetCollumnWidths(IEnumerable<Worker> data, int collumnsCount)
    {
        int[] colWidths = new int[collumnsCount];
        int colIndex = 0;

        foreach (Worker item in data)
        {
            colWidths[colIndex] = Math.Max(item.ToString().Length, colWidths[colIndex]);
            colIndex = (colIndex + 1) % collumnsCount;
        }
        return colWidths;
    }
    
    IEnumerable<string> FormatGridRows(IEnumerable<Worker> data, int[] colWidths)
    {
        StringBuilder row = new();
        int colIndex = 0;
        foreach (Worker item in data)
        {
            row.Append(item.ToString().PadRight(colWidths[colIndex] + 2));
            colIndex = (colIndex + 1) % colWidths.Length;
            if (colIndex == 0)
            {
                yield return row.ToString().TrimEnd();
                row.Clear();
            }
        }
        if (row.Length > 0) yield return row.ToString().TrimEnd();
    }
    
}