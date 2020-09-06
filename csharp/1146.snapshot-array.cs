/*
 * @lc app=leetcode id=1146 lang=csharp
 *
 * [1146] Snapshot Array
 */

using System.Collections.Generic;

// @lc code=start
public class SnapshotArray {

    private int Snapshots;
    private IList<(int Snapshot, int Value)>[] Array;

    public SnapshotArray(int length) {
        Snapshots = 0;
        Array = new IList<(int Snapshot, int Value)>[length];
    }
    
    public void Set(int index, int val) {
        var list = Array[index];
        if (list == null) {
            list = new List<(int Snapshot, int Value)>();
            Array[index] = list;
        }
        if (list.Count > 0) {
            var last = list[list.Count - 1];
            if (last.Value == val) {
                return;
            }
            if (last.Snapshot == Snapshots) {
                list.RemoveAt(list.Count - 1);
            }
        }
        list.Add((Snapshot: Snapshots, Value: val));
    }
    
    public int Snap() {
        return Snapshots++;
    }
    
    public int Get(int index, int snap_id) {
        var list = Array[index];
        if (list == null) {
            return 0;
        }
        int l = 0, r = list.Count - 1;
        while (l < r - 1) {
            int m = l + (r - l) / 2;
            if (list[m].Snapshot > snap_id) {
                r = m - 1;
            } else {
                l = m;
            }
        }
        while (r >= 0 && list[r].Snapshot > snap_id) {
            --r;
        }
        if (r < 0) {
            return 0;
        }
        return list[r].Value;
    }
}

/**
 * Your SnapshotArray object will be instantiated and called as such:
 * SnapshotArray obj = new SnapshotArray(length);
 * obj.Set(index,val);
 * int param_2 = obj.Snap();
 * int param_3 = obj.Get(index,snap_id);
 */
// @lc code=end

