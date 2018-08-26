import java.util.HashSet;
import java.util.Set;
import java.util.TreeMap;

class RangeModule {

    private TreeMap<Integer, Integer> map;
    
    public RangeModule() {
        map = new TreeMap<>();
    }
    
    private int[] findInsert(int left, int right) {
        Set<Map.Entry<Integer, Integer>> removeEntries = new HashSet<>();
        int l = left, r = right;
        
        Map.Entry<Integer, Integer> lleft = map.floorEntry(left);
        if (lleft != null && lleft.getValue() >= left) {
            removeEntries.add(lleft);
            l = lleft.getKey();
            r = Math.max(lleft.getValue(), r);
        }
        
        for (Map.Entry<Integer, Integer> entry : map.subMap(left, right + 1).entrySet()) {
            r = Math.max(entry.getValue(), r);
            
            removeEntries.add(entry);
        }
        
        map.entrySet().removeAll(removeEntries);

        return new int[] {l, r};
    }
    
    public void addRange(int left, int right) {
        int[] range = findInsert(left, right);
        map.put(range[0], range[1]);
    }
    
    public boolean queryRange(int left, int right) {
        Map.Entry<Integer, Integer> l = map.floorEntry(left);
        return l != null && l.getValue() >= right;
    }
    
    public void removeRange(int left, int right) {
        int[] range = findInsert(left, right);

        if (left > range[0]) {
            map.put(range[0], left);
        }
        
        if (right < range[1]) {
            map.put(right, range[1]);
        }
    }
}

/**
 * Your RangeModule object will be instantiated and called as such:
 * RangeModule obj = new RangeModule();
 * obj.addRange(left,right);
 * boolean param_2 = obj.queryRange(left,right);
 * obj.removeRange(left,right);
 */