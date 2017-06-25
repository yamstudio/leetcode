int findComplement(int num) {
    int k = 0;
    for (k; num >> k; ++k)
        ;
    return ((~num) & ((1 << k) - 1));
}