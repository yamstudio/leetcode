bool makesquare(int* nums, int numsSize) {
    int i, j, k, sum = 0, target, *masks, *valid_half, masks_size = 32, masks_count = 0, curr_sum, all, mask, ret = 0, combined;
    
    if (numsSize < 4)
        return 0;
    for (i = 0; i < numsSize; ++i)
        sum += nums[i];
    if (sum == 0 || sum % 4)
        return false;
    
    target = sum / 4;
    valid_half = (int *)calloc((1 << numsSize), sizeof(int));
    masks = (int *)malloc(masks_size * sizeof(int));
    all = (1 << numsSize) - 1;
    
    for (i = 0; i <= all; ++i) {
        curr_sum = 0;
        
        for (j = 0; j < 15; ++j) {
            if (i & (1 << j))
                curr_sum += nums[j];
        }
        
        if (curr_sum == target) {
            ret = 0;
            for (k = 0; k < masks_count && ! ret; ++k) {
                mask = masks[k];
                if (mask & i)
                    continue;
                
                combined = mask | i;
                valid_half[combined] = 1;
                
                if (valid_half[all ^ combined])
                    ret = 1;
            }
            
            if (ret)
                break;
            
            if (masks_count == masks_size) {
                masks_size += 32;
                masks = (int *)realloc(masks, masks_size * sizeof(int));
            }
            
            masks[masks_count++] = i;
        }
    }
    
    free(masks);
    free(valid_half);
    
    return ret;
}
