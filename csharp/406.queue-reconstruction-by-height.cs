/*
 * @lc app=leetcode id=406 lang=csharp
 *
 * [406] Queue Reconstruction by Height
 */

using System;
using System.Collections.Generic;

public class Solution {
    public int[][] ReconstructQueue(int[][] people) {
        Array.Sort(people, Comparer<int[]>.Create((a, b) => a[0] == b[0] ? a[1].CompareTo(b[1]) : b[0].CompareTo(a[0])));
        List<int[]> ret = new List<int[]>(people.Length);
        foreach (var person in people) {
            ret.Insert(person[1], person);
        }
        return ret.ToArray();
    }
}

