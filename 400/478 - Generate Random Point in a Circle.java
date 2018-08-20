import java.util.function.Supplier;

class Solution {

    Supplier<double[]> gen;
    
    public Solution(double radius, double x_center, double y_center) {
        gen = () -> {
            double r = radius * Math.sqrt(Math.random()), d = 2 * Math.PI * Math.random();
            return new double[] {x_center + r * Math.cos(d), y_center + r * Math.sin(d)};
        };
    }
    
    public double[] randPoint() {
        return gen.get();
    }
}

/**
 * Your Solution object will be instantiated and called as such:
 * Solution obj = new Solution(radius, x_center, y_center);
 * double[] param_1 = obj.randPoint();
 */