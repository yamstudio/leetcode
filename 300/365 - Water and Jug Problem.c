static int gcd(int x, int y) {
    return y ? gcd(y, x % y) : x;
}

bool canMeasureWater(int x, int y, int z) {
    return z == 0 || (x + y >= z && z % gcd(x, y) == 0);
}
