class Solution {
    public int[] constructRectangle(int area) {
        int w, l;

        for (l = (int)Math.sqrt(area); l <= area; ++l) {
            if (area % l != 0)
                continue;
            w = area / l;
            if (w > l)
                continue;
            return new int[]{l, w};
        }
        
        return null;
    }
}
