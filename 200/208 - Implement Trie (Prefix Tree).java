public class Trie {
    
    private class TrieNode {
        
        private TrieNode[] children;
        private boolean isWord;
        
        public TrieNode() {
            this.children = new TrieNode[26];
            this.isWord = false;
        }
        
        public boolean isWord() {
            return this.isWord;
        }
        
        public void setWord() {
            this.isWord = true;
        }
        
        public TrieNode getChild(int index) {
            return this.children[index];
        }
        
        public void setChild(int index) {
            this.children[index] = new TrieNode();
        }
    }
    
    private TrieNode root;

    /** Initialize your data structure here. */
    public Trie() {
        this.root = new TrieNode();
    }
    
    /** Inserts a word into the trie. */
    public void insert(String word) {
        int i;
        TrieNode p = root;
        
        for (char c : word.toCharArray()) {
            i = (int)(c - 'a');
            if (p.getChild(i) == null)
                p.setChild(i);
            p = p.getChild(i);
        }
        
        p.setWord();
    }
    
    /** Returns if the word is in the trie. */
    public boolean search(String word) {
        TrieNode p = root;
        
        for (char c : word.toCharArray()) {
            if ((p = p.getChild((int)(c - 'a'))) == null)
                return false;
        }
        
        return p.isWord;
    }
    
    /** Returns if there is any word in the trie that starts with the given prefix. */
    public boolean startsWith(String prefix) {
        TrieNode p = root;
        
        for (char c : prefix.toCharArray()) {
            if ((p = p.getChild((int)(c - 'a'))) == null)
                return false;
        }
        
        return true;
    }
}

/**
 * Your Trie object will be instantiated and called as such:
 * Trie obj = new Trie();
 * obj.insert(word);
 * boolean param_2 = obj.search(word);
 * boolean param_3 = obj.startsWith(prefix);
 */
 