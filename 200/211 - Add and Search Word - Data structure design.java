public class WordDictionary {
    
    private class TrieNode {
        private boolean isWord;
        private TrieNode[] children;
        
        public TrieNode() {
            this.children = new TrieNode[26];
            this.isWord = false;
        }
        
        public void setWord() {
            this.isWord = true;
        }
        
        public boolean isWord() {
            return this.isWord;
        }
        
        public void setChild(int index) {
            this.children[index] = new TrieNode();
        }
        
        public TrieNode getChild(int index) {
            return this.children[index];
        }
    }

    private TrieNode root;
    
    /** Initialize your data structure here. */
    public WordDictionary() {
        this.root = new TrieNode();
    }
    
    /** Adds a word into the data structure. */
    public void addWord(String word) {
        TrieNode p = this.root;
        int i;
        
        for (char c : word.toCharArray()) {
            i = (int)(c - 'a');
            if (p.getChild(i) == null)
                p.setChild(i);
            p = p.getChild(i);
        }
        
        p.setWord();
    }
    
    /** Returns if the word is in the data structure. A word could contain the dot character '.' to represent any one letter. */
    public boolean search(String word) {
        return searchRecursive(word, this.root, 0);
    }
    
    private boolean searchRecursive(String word, TrieNode curr, int i) {
        char c;
        int j;
        TrieNode next;
        
        if (i == word.length())
            return curr.isWord();
        c = word.charAt(i);
        
        if (c == '.') {
            for (j = 0; j < 26; ++j) {
                next = curr.getChild(j);
                if (next != null && searchRecursive(word, next, i + 1))
                    return true;
            }
            return false;
        } else {
            next = curr.getChild((int)(c - 'a'));
            if (next == null)
                return false;
            else
                return searchRecursive(word, next, i + 1);
        }
    }
}

/**
 * Your WordDictionary object will be instantiated and called as such:
 * WordDictionary obj = new WordDictionary();
 * obj.addWord(word);
 * boolean param_2 = obj.search(word);
 */
 