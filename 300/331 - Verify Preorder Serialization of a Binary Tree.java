import java.util.ArrayList;

public class Solution {
    public boolean isValidSerialization(String preorder) {
        String[] words = preorder.split(",");
        ArrayList<Boolean> list = new ArrayList<Boolean>();
        int len;
        
        for (String s : words) {
            list.add(s.equals("#"));
            while ((len = list.size()) >= 3 && list.get(len - 1) && list.get(len - 2) && ! list.get(len - 3)) {
                list.remove(len - 1);
                list.remove(len - 2);
                list.remove(len - 3);
                list.add(true);
            }
        }
        
        return list.size() == 1 && list.get(0);
    }
}
