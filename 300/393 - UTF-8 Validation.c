bool validUtf8(int* data, int dataSize) {
    int rem = 0, i, d;
    
    for (i = 0; i < dataSize; ++i) {
        d = data[i];
        if (rem) {
            if ((d >> 6) != 0b10)
                return 0;
            --rem;
            continue;
        }
        
        if ((d >> 3) == 0b11110)
            rem = 3;
        else if ((d >> 4) == 0b1110)
            rem = 2;
        else if ((d >> 5) == 0b110)
            rem = 1;
        else if (d >> 7)
            return 0;
    }
    
    return ! rem;
}
