#include <stdlib.h>

typedef struct {
    int *nums;
    int *rand;
    int size;
} Solution;

Solution* solutionCreate(int* nums, int size) {
    Solution *ret = (Solution *)malloc(sizeof(Solution));
    ret->nums = nums;
    ret->size = size;
    ret->rand = (int *)malloc(size * sizeof(int));
    
    memcpy(ret->rand, nums, size * sizeof(int));
    
    return ret;
}

/** Resets the array to its original configuration and return it. */
int* solutionReset(Solution* obj, int *returnSize) {
    *returnSize = obj->size;
    return obj->nums;
}

/** Returns a random shuffling of the array. */
int* solutionShuffle(Solution* obj, int *returnSize) {
    int i, r, temp;
    
    for (i = 0; i < obj->size; ++i) {
        r = rand() % obj->size;
        temp = obj->rand[i];
        obj->rand[i] = obj->rand[r];
        obj->rand[r] = temp;
    }
    
    *returnSize = obj->size;
    return obj->rand;    
}

void solutionFree(Solution* obj) {
    free(obj->rand);
    free(obj);
}

/**
 * Your Solution struct will be instantiated and called as such:
 * struct Solution* obj = solutionCreate(nums, size);
 * int* param_1 = solutionReset(obj);
 * int* param_2 = solutionShuffle(obj);
 * solutionFree(obj);
 */
 