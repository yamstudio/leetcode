bool isOneBitCharacter(int* bits, int bitsSize) {
    int i = 0;
    
    while (i < bitsSize - 1) {
        i += bits[i] + 1;
    }
    
    return i == bitsSize - 1;
}