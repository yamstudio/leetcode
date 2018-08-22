class Solution {
    public boolean canPlaceFlowers(int[] flowerbed, int n) {
        boolean pv = true;
        int len = flowerbed.length;

        for (int i = 0; n > 0 && i < len - 1; ++i) {
            if (pv && flowerbed[i] == 0 && flowerbed[i + 1] == 0) {
                pv = false;
                --n;
            } else {
                pv = flowerbed[i] == 0;
            }
        }
        
        if (pv && n > 0 && flowerbed[len - 1] == 0) {
            --n;
        }
        
        return n == 0;
    }
}