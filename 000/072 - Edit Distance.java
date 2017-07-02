public class Solution {
    public int minDistance(String word1, String word2) {
        int i, j;
        int[][] dist = new int[word1.length() + 1][word2.length() + 1];
        char curr;
        
        for (i = 0; i <= word1.length(); ++i)
            dist[i][0] = i;
        for (j = 0; j <= word2.length(); ++j)
            dist[0][j] = j;
        
        for (i = 0; i < word1.length(); ++i) {
            curr = word1.charAt(i);
            for (j = 0; j < word2.length(); ++j) {
                dist[i + 1][j + 1] = Math.min(Math.min(dist[i][j] + (curr != word2.charAt(j) ? 1 : 0), dist[i][j + 1] + 1), dist[i + 1][j] + 1);
            }
        }
        
        return dist[word1.length()][word2.length()];
    }
}
