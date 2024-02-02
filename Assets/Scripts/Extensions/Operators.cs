using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Operators
{
    public static IEnumerable<T> Once<T>(this IEnumerable<T> sequence) =>
        new SinglePassSequence<T>(sequence);

    public static IEnumerable<string> ToGrid<T>(
        this IEnumerable<T> sequence, int width, int gap) =>
        new GridFormatter<T>(sequence).Format(width, gap);

    public static void WriteLines(this IEnumerable<string> lines)
    {
        foreach (string line in lines)
        {
            Debug.Log(line);
        }
    }
}