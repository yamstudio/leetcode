import java.util.Map;
import java.util.HashMap;

class WordFilter {
    
    Map<String, Integer> map;

    public WordFilter(String[] words) {
        map = new HashMap<>();
        StringBuilder sb = new StringBuilder();
        
        for (int i = 0; i < words.length; ++i) {
            String word = words[i];
            int len = word.length();
            
            for (int j = 0; j <= 10 && j <= len; ++j) {
                for (int k = 0; k <= 10 && k <= len; ++k) {
                    sb.append(word.substring(0, j));
                    sb.append('#');
                    sb.append(word.substring(len - k));
                    
                    map.put(sb.toString(), i);
                        
                    sb.setLength(0);
                }
            }
        }
    }
    
    public int f(String prefix, String suffix) {
        return map.getOrDefault(prefix + "#" + suffix, -1);
    }
}

/**
 * Your WordFilter object will be instantiated and called as such:
 * WordFilter obj = new WordFilter(words);
 * int param_1 = obj.f(prefix,suffix);
 */