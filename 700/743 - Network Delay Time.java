class Solution {
    public int networkDelayTime(int[][] times, int N, int K) {
        int[] dist = new int[N + 1];
        int ret = 0;
        
        for (int i = 1; i <= N; ++i) {
            dist[i] = Integer.MAX_VALUE;
        }
        dist[K] = 0;
        
        for (int i = 1; i < N; ++i) {
            for (int[] edge : times) {
                int u = edge[0], v = edge[1], w = edge[2];
                
                if (dist[u] != Integer.MAX_VALUE && dist[v] > dist[u] + w) {
                    dist[v] = dist[u] + w;
                }
            }
        }
        
        for (int i = 1; i <= N; ++i) {
            ret = Math.max(ret, dist[i]);
        }
        
        return ret == Integer.MAX_VALUE ? -1 : ret;
    }
}