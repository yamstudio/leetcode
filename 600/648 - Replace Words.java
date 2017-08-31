class Solution {
    public String replaceWords(List<String> dict, String sentence) {
        Trie trie = new Trie();
        String[] split = sentence.split(" ");
        int i;
        
        for (String s : dict)
            trie.add(s);
        
        for (i = 0; i < split.length; ++i)
            split[i] = trie.search(split[i]);
        
        return String.join(" ", split);
    }
    
    private class TrieNode {
        boolean isWord;
        TrieNode[] children;

        public TrieNode() {
            isWord = false;
            children = new TrieNode[26];
        }
    }
    
    private class Trie {
        Solution.TrieNode root;
        
        public Trie() {
            root = new Solution.TrieNode();    
        }
        
        public void add(String s) {
            Solution.TrieNode curr = root, child;
            
            for (char c : s.toCharArray()) {
                child = curr.children[c - 'a'];
                
                if (child == null) {
                    child = new Solution.TrieNode();
                    curr.children[c - 'a'] = child;
                }
                
                curr = child;
            }
            
            curr.isWord = true;
        }
        
        public String search(String s) {
            StringBuilder sb = new StringBuilder();
            Solution.TrieNode curr = root;
            
            for (char c : s.toCharArray()) {
                curr = curr.children[c - 'a'];
                if (curr == null)
                    break;
                sb.append(c);
                if (curr.isWord)
                    return sb.toString();
            }
            
            return s;
        }
    }
}
