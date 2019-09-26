/*
 * @lc app=leetcode id=458 lang=csharp
 *
 * [458] Poor Pigs
 */

using System;

public class Solution {
    public int PoorPigs(int buckets, int minutesToDie, int minutesToTest) {
        return (int) Math.Ceiling(Math.Log(buckets, minutesToTest / minutesToDie + 1));
    }
}

