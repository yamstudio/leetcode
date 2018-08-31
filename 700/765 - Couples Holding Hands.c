int minSwapsCouples(int* row, int rowSize) {
    int ret = 0;
    for (int i = 0; i < rowSize; i += 2) {
        int x = row[i] ^ 1;
        if (row[i + 1] == x) {
            continue;
        }
        ++ret;
        
        for (int j = i + 1; j < rowSize; ++j) {
            if (row[j] == x) {
                row[j] = row[i + 1];
                row[i + 1] = x;
                break;
            }
        }
    }
    return ret;
}