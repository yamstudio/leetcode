class Solution {
    public int deleteAndEarn(int[] nums) {
        int[] total = new int[10001];
        int ja = 0, nein = 0;        

        for (int num : nums) {
            total[num] += num;
        }
        
        for (int i = 0; i < 10001; ++i) {
            int jetztJa = nein + total[i];
            int jetztNein = Math.max(ja, nein);
            
            ja = jetztJa;
            nein = jetztNein;
        }
        
        return Math.max(ja, nein);
    }
}