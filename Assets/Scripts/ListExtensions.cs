using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ListExtensions
{
    public static void Shuffle<T>(this List<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int selectedIndex = Random.Range(i, list.Count);
            var temp = list[selectedIndex];
            list[selectedIndex] = list[i];
            list[i] = temp;
        }
    }
}
