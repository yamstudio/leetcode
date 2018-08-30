import java.util.Arrays;
import java.util.Comparator;
import java.util.HashMap;
import java.util.Map;
import java.util.Set;

class Solution {
    public String shortestCompletingWord(String licensePlate, String[] words) {
        Map<Character, Integer> map = new HashMap<>();
        for (char c : licensePlate.toCharArray()) {
            if (Character.isLetter(c)) {
                char l = Character.toLowerCase(c);
                map.put(l, map.getOrDefault(l, 0) + 1);
            }
        }
        Set<Character> set = map.keySet();
        Map<Character, Integer> tmp = new HashMap<>();
        
        Arrays.sort(words, Comparator.comparingInt(String::length));
        
        for (String word : words) {
           
            for (char c : word.toCharArray()) {
                if (set.contains(c)) {
                    tmp.put(c, tmp.getOrDefault(c, 0) + 1);
                }
            }
            
            boolean ok = true;
            for (Character c : set) {
                if (tmp.getOrDefault(c, 0) < map.get(c)) {
                    tmp.clear();
                    ok = false;
                    break;
                }
            }
            
            if (ok)
                return word;
        }
        
        return "";
    }
}