/*
 * @lc app=leetcode id=1146 lang=java
 *
 * [1146] Snapshot Array
 */

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

// @lc code=start
class SnapshotArray {

    private int version = 0;
    private final Map<Integer, List<Snapshot>> indexToSnapshots;

    public SnapshotArray(int length) {
        indexToSnapshots = new HashMap<>();
    }
    
    public void set(int index, int val) {
        var snapshots = indexToSnapshots.computeIfAbsent(index, ignored -> new ArrayList<>());
        if (!snapshots.isEmpty() && snapshots.getLast().version() == version) {
            snapshots.removeLast();
        }
        snapshots.add(new Snapshot(version, val));
    }
    
    public int snap() {
        return version++;
    }
    
    public int get(int index, int snapId) {
        var snapshots = indexToSnapshots.get(index);
        if (snapshots == null) {
            return 0;
        }
        int l = 0, r = snapshots.size() - 1;
        while (l < r - 1) {
            int m = (l + r) / 2;
            if (snapId >= snapshots.get(m).version()) {
                l = m;
            } else {
                r = m - 1;
            }
        }
        while (r >= 0 && snapshots.get(r).version() > snapId) {
            --r;
        }
        if (r < 0) {
            return 0;
        }
        return snapshots.get(r).value();
    }

    private record Snapshot(int version, int value) {}
}

/**
 * Your SnapshotArray object will be instantiated and called as such:
 * SnapshotArray obj = new SnapshotArray(length);
 * obj.set(index,val);
 * int param_2 = obj.snap();
 * int param_3 = obj.get(index,snap_id);
 */
// @lc code=end

