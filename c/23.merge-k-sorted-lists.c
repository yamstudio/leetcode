/*
 * @lc app=leetcode id=23 lang=c
 *
 * [23] Merge k Sorted Lists
 *
 * autogenerated using scripts/convert.py
 */
typedef struct ListNode node_t;

node_t *helper(node_t *f, node_t *s) {
    node_t *h, **pp = &h;
    
    while (f && s) {
        if (f->val < s->val) {
            *pp = f;
            pp = &f->next;
            f = f->next;
        } else {
            *pp = s;
            pp = &s->next;
            s = s->next;
        }
    }
    *pp = f ? f : s;
    return h;
}

/**
 * Definition for singly-linked list.
 * struct ListNode {
 *     int val;
 *     struct ListNode *next;
 * };
 */
node_t* mergeKLists(node_t** lists, int listsSize) {
    int start, end;
    
    if (! listsSize)
        return NULL;
    
    end = listsSize - 1;
    while (end > 0) {
        start = 0;
        while (start < end) {
            lists[start] = helper(lists[start], lists[end]);
            ++start;
            --end;
        }
    }
    return lists[0];
}
