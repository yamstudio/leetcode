/*
 * @lc app=leetcode id=460 lang=csharp
 *
 * [460] LFU Cache
 */

using System.Collections.Generic;

public class LFUCache {

    private IDictionary<int, LinkedListNode<int>> Loc;
    private IDictionary<int, LinkedList<int>> Freq;
    private IDictionary<int, (int, int)> Map;
    private int Capacity;
    private int MinFreq;


    public LFUCache(int capacity) {
        Capacity = capacity;
        MinFreq = 0;
        Loc = new Dictionary<int, LinkedListNode<int>>(capacity);
        Freq = new Dictionary<int, LinkedList<int>>(capacity);
        Map = new Dictionary<int, (int, int)>(capacity);
    }
    
    public int Get(int key) {
        if (!Map.ContainsKey(key)) {
            return -1;
        }
        int val = Map[key].Item1, freq = Map[key].Item2;
        Freq[freq].Remove(Loc[key]);
        if (Freq[freq].Count == 0) {
            if (freq == MinFreq) {
                ++MinFreq;
            }
            Freq.Remove(freq);
        }
        ++freq;
        if (!Freq.ContainsKey(freq)) {
            Freq[freq] = new LinkedList<int>();
        }
        Loc[key] = Freq[freq].AddLast(key);
        Map[key] = (val, freq);
        return val;
    }
    
    public void Put(int key, int value) {
        if (Capacity == 0) {
            return;
        }
        if (Get(key) != -1) {
            Map[key] = (value, Map[key].Item2);
            return;
        }
        if (Map.Count >= Capacity) {
            var minList = Freq[MinFreq];
            int removeKey = minList.First.Value;
            if (minList.Count == 1) {
                Freq.Remove(MinFreq);
            } else {
                minList.RemoveFirst();
            }
            Loc.Remove(removeKey);
            Map.Remove(removeKey);
        }
        if (!Freq.ContainsKey(1)) {
            Freq[1] = new LinkedList<int>();
        }
        Loc[key] = Freq[1].AddLast(key);
        Map[key] = (value, 1);
        MinFreq = 1;
    }
}

/**
 * Your LFUCache object will be instantiated and called as such:
 * LFUCache obj = new LFUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */

