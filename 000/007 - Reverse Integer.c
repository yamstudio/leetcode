int reverse(int x) {
    int neg;
    unsigned long long u, ret = 0;
    neg = (x < 0);
    if (neg)
        u = (unsigned long long)(-x);
    else
        u = (unsigned long long)x;
    while (u) {
        ret *= 10;
        ret += u % 10;
        u /= 10;
        if ((neg && ret > (unsigned long long)-INT_MIN) || ret > (unsigned long long)INT_MAX)
            return 0;
    }
    return neg ? -(signed int)ret : (signed int)ret;
}
