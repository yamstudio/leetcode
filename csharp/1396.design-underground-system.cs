/*
 * @lc app=leetcode id=1396 lang=csharp
 *
 * [1396] Design Underground System
 */

using System.Collections.Generic;

// @lc code=start
public class UndergroundSystem {

    private IDictionary<(string StartStation, string EndStation), (long Time, int Count)> Times;

    private IDictionary<int, (string StartStation, int Time)> Customers;

    public UndergroundSystem() {
        Times = new Dictionary<(string StartStation, string EndStation), (long Time, int Count)>();
        Customers = new Dictionary<int, (string StartStation, int Time)>();
    }
    
    public void CheckIn(int id, string stationName, int t) {
        Customers[id] = (StartStation: stationName, Time: t);
    }
    
    public void CheckOut(int id, string stationName, int t) {
        var p = Customers[id];
        var key = (StartStation: p.StartStation, EndStation: stationName);
        if (Times.TryGetValue(key, out var val)) {
            Times[key] = (Time: val.Time + (long)(t - p.Time), Count: val.Count + 1);
        } else {
            Times[key] = (Time: (long)(t - p.Time), Count: 1);
        }
    }
    
    public double GetAverageTime(string startStation, string endStation) {
        if (!Times.TryGetValue((StartStation: startStation, EndStation: endStation), out var val)) {
            return -1;
        }
        return (double)val.Time / (double)val.Count;
    }
}

/**
 * Your UndergroundSystem object will be instantiated and called as such:
 * UndergroundSystem obj = new UndergroundSystem();
 * obj.CheckIn(id,stationName,t);
 * obj.CheckOut(id,stationName,t);
 * double param_3 = obj.GetAverageTime(startStation,endStation);
 */
// @lc code=end

