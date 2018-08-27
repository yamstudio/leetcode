import java.util.TreeMap;

class MyCalendar {

    TreeMap<Integer, Integer> map;
    
    public MyCalendar() {
        map = new TreeMap<>();
    }
    
    public boolean book(int start, int end) {
        Map.Entry<Integer, Integer> left = map.floorEntry(start), right = map.floorEntry(end - 1);
        if ((left != null && left.getValue() > start) || (right != null && right.getValue() > start)) {
            return false;
        } else {
            map.put(start, end);
            return true;
        }
    }
}

/**
 * Your MyCalendar object will be instantiated and called as such:
 * MyCalendar obj = new MyCalendar();
 * boolean param_1 = obj.book(start,end);
 */