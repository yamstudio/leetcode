bool isPerfectSquare(int num) {
    long right = num / 2, left, i;
    
    while (right * right > num)
        right /= 2;
    
    left = right;
    right = right * 2 + 1;
    for (i = left; i <= right; ++i) {
        if (i * i == num)
            return 1;
    }
    
    return 0;
}
