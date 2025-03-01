/*
 * @lc app=leetcode id=1396 lang=java
 *
 * [1396] Design Underground System
 */

import java.util.HashMap;
import java.util.Map;

// @lc code=start

class UndergroundSystem {

    private final Map<Integer, CheckIn> idToCheckIn;
    private final Map<String, Total> stationNameToTotal;

    public UndergroundSystem() {
        idToCheckIn = new HashMap<>();
        stationNameToTotal = new HashMap<>();
    }
    
    public void checkIn(int id, String stationName, int t) {
        idToCheckIn.put(id, new CheckIn(stationName, t));
    }
    
    public void checkOut(int id, String stationName, int t) {
        CheckIn checkIn = idToCheckIn.remove(id);
        String key = "%s-%s".formatted(checkIn.stationName(), stationName);
        Total existing = stationNameToTotal.get(key);
        if (existing == null) {
            stationNameToTotal.put(key, new Total(t - checkIn.t(), 1));
        } else {
            stationNameToTotal.put(key, new Total(t - checkIn.t() + existing.time(), existing.count() + 1));
        }
    }
    
    public double getAverageTime(String startStation, String endStation) {
        String key = "%s-%s".formatted(startStation, endStation);
        Total existing = stationNameToTotal.get(key);
        return existing.time() / existing.count();
    }

    private record CheckIn(String stationName, int t) {}
    private record Total(double time, int count) {}
}

/**
 * Your UndergroundSystem object will be instantiated and called as such:
 * UndergroundSystem obj = new UndergroundSystem();
 * obj.checkIn(id,stationName,t);
 * obj.checkOut(id,stationName,t);
 * double param_3 = obj.getAverageTime(startStation,endStation);
 */
// @lc code=end

