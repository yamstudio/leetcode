static int helper(int n, int from_left) {
    if (n == 1)
        return 1;
    if (from_left)
        return 2 * helper(n / 2, 0);
    else
        return 2 * helper(n / 2, 1) - 1 + n % 2;
}

int lastRemaining(int n) {
    return helper(n, 1);
}
