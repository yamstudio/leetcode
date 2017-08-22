class Solution {
    public String findLongestWord(String s, List<String> d) {
        String ret = "";
        char[] array = s.toCharArray();
        int i;
        
        for (String word : d) {
            i = 0;
            
            for (char c : array) {
                if (i < word.length() && c == word.charAt(i))
                    ++i;
                
                if (i == word.length())
                    break;
            }
            
            if (i == word.length() && (word.length() > ret.length() || (word.length() == ret.length() && word.compareTo(ret) < 0)))
                ret = word;
        }
        
        return ret;
    }
}
