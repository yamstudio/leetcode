#include <stdlib.h>

static int comp(const void *p1, const void *p2) {
    return *(int *)p1 - *(int *)p2;
}

int findContentChildren(int* g, int gSize, int* s, int sSize) {
    int i = 0, j = 0;
    
    qsort(g, gSize, sizeof(int), &comp);
    qsort(s, sSize, sizeof(int), &comp);
    
    while (i < gSize && j < sSize) {
        if (s[j] >= g[i])
            ++i;
        ++j;
    }
    
    return i;
}
