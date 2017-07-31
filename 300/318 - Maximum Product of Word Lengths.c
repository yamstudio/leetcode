#define max(a, b) ((a) > (b) ? (a) : (b))

int maxProduct(char** words, int wordsSize) {
    int i, j, *bin, *len, ret = 0;
    
    bin = (int *)malloc(2 * wordsSize * sizeof(int));
    memset((void *)bin, 0, wordsSize * sizeof(int));
    len = bin + wordsSize;
    
    for (i = 0; i < wordsSize; ++i) {
        for (j = 0; words[i][j]; ++j)
            bin[i] |= (1 << (int)(words[i][j] - 'a'));
        len[i] = j;
    }
    
    for (i = 0; i < wordsSize; ++i) {
        for (j = i + 1; j < wordsSize; ++j) {
            if (! (bin[i] & bin[j]))
                ret = max(ret, len[i] * len[j]);
        }
    }
    
    free(bin);
    
    return ret;
}
