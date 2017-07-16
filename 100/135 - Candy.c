#include <limits.h>

int candy(int* ratings, int ratingsSize) {
    int ret = 0, prev, curr, desc, i, base;
    
    if (! ratingsSize)
        return 0;
    prev = ratings[0];
    desc = 1;
    base = 1;
    
    for (i = 1; i < ratingsSize; ++i) {
        curr = ratings[i];
        
        if (curr < prev)
            ++desc;
        else {
            ret += base > desc ? base + (desc - 1) * desc / 2 : (desc + 1) * desc / 2;
            
            base = curr == prev ? 1 : (desc == 1 ? base + 1 : 2);
            desc = 1;
        }
        
        prev = curr;
    }
    
    
    return ret + (base > desc ? base + (desc - 1) * desc / 2 : (desc + 1) * desc / 2);
}
