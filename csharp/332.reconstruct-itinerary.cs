/*
 * @lc app=leetcode id=332 lang=csharp
 *
 * [332] Reconstruct Itinerary
 */

using System.Collections.Generic;

public class Solution {

    private void FindItineraryRecurse(string curr, IDictionary<string, SortedList<string, int>> map, IList<string> ret) {
        if (map.ContainsKey(curr)) {
            var sorted = map[curr];
            while (sorted.Count > 0) {
                string next = sorted.Keys[0];
                --sorted[next];
                if (sorted[next] == 0) {
                    sorted.Remove(next);
                }
                FindItineraryRecurse(next, map, ret);
            }
        }
        ret.Add(curr);
    }

    public IList<string> FindItinerary(IList<IList<string>> tickets) {
        List<string> ret = new List<string>(tickets.Count + 1);
        IDictionary<string, SortedList<string, int>> map = new Dictionary<string, SortedList<string, int>>(tickets.Count);
        foreach (IList<string> edge in tickets) {
            string from = edge[0], to = edge[1];
            SortedList<string, int> sorted;
            if (!map.ContainsKey(from)) {
                sorted = new SortedList<string, int>();
                map[from] = sorted;
            } else {
                sorted = map[from];
            }
            if (sorted.ContainsKey(to)) {
                sorted[to]++;
            } else {
                sorted.Add(to, 1);
            }
        }
        FindItineraryRecurse("JFK", map, ret);
        ret.Reverse();
        return ret;
    }
}

