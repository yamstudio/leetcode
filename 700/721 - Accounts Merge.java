import java.util.ArrayList;
import java.util.Collections;
import java.util.HashMap;
import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.Set;

class Solution {
    private static String findRoot(String s, Map<String, String> roots) {
        String root = roots.get(s);
        return root == s ? root : findRoot(root, roots);
    }
    
    public List<List<String>> accountsMerge(List<List<String>> accounts) {
        Map<String, String> roots = new HashMap<>();
        Map<String, String> names = new HashMap<>();
        Map<String, Set<String>> merged = new HashMap<>();
        List<List<String>> ret = new ArrayList<>();
        
        for (List<String> account : accounts) {
            String name = account.get(0);
            
            for (int i = 1; i < account.size(); ++i) {
                String email = account.get(i);
                roots.put(email, email);
                names.put(email, name);
            }
        }
        
        for (List<String> account : accounts) {
            String root = findRoot(account.get(1), roots);
            
            for (int i = 2; i < account.size(); ++i) {
                roots.put(findRoot(account.get(i), roots), root);
            }
        }
        
        for (List<String> account : accounts) {
            for (int i = 1; i < account.size(); ++i) {
                String curr = account.get(i);
                String root = findRoot(curr, roots);
                if (!merged.containsKey(root)) {
                    merged.put(root, new HashSet<>());
                }
                
                merged.get(root).add(curr);
            }
        }
        
        for (Map.Entry<String, Set<String>> entry : merged.entrySet()) {
            String name = names.get(entry.getKey());
            List<String> emails = new ArrayList<>();
            emails.addAll(entry.getValue());
            Collections.sort(emails);
            emails.add(0, name);
            ret.add(emails);
        }
        
        return ret;
    }
}