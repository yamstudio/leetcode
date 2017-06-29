#include <stdlib.h>

int comp(const void *e1, const void *e2) {
    int f = *(int *)e1, s = *(int *)e2;
    return f > s ? 1 : (f == s ? 0 : -1);
}

int helper(int *cand, int cand_size, int from, int target, int *total_p, int *curr, int curr_size, int **col_sizes_p, int ***ret_p) {
    int i, *next;

    if (target > 0) {
        for (i = from; i < cand_size && cand[i] <= target; ++i) {
            next = malloc((curr_size + 1) * sizeof(int));
            if (curr_size)
                memcpy((void *)next, (const void *)curr, curr_size * sizeof(int));
            next[curr_size] = cand[i];
            if (! helper(cand, cand_size, i, target - cand[i], total_p, next, curr_size + 1, col_sizes_p, ret_p))
                free(next);
        }
    } else if (! target) {
        *ret_p = (int **)realloc(*ret_p, sizeof(int *) * (*total_p + 1));
        (*ret_p)[*total_p] = curr;
        *col_sizes_p = (int *)realloc(*col_sizes_p, sizeof(int) * (*total_p + 1));
        (*col_sizes_p)[*total_p] = curr_size;
        ++*total_p;
        
        return 1;
    }
    return 0;
}

/**
 * Return an array of arrays of size *returnSize.
 * The sizes of the arrays are returned as *columnSizes array.
 * Note: Both returned array and *columnSizes array must be malloced, assume caller calls free().
 */
int** combinationSum(int* candidates, int candidatesSize, int target, int** columnSizes, int* returnSize) {
    int total = 0, *col_sizes, **ret;
    
    qsort(candidates, candidatesSize, sizeof(int), comp);
    
    ret = (int **)malloc(sizeof(int *));
    col_sizes = (int *)malloc(sizeof(int));
    helper(candidates, candidatesSize, 0, target, &total, NULL, 0, &col_sizes, &ret);
    *columnSizes = col_sizes;
    *returnSize = total;
    return ret;
}
