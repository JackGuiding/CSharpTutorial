using System;
using System.Collections.Generic;

namespace CollectionGeneric {

    public class Human {
        public Human next;
    }

    public static class Sample {

        public static void Entry() {

            // ==== 基础 ====
            {
                // 数组
                int[] array = new int[10];
            }


            // 链表
            {
                // cur = root
                // cur -> h0
                // cur = h0

                // cur(h0) -> h1
                // cur = h1
                Human root = new Human();
                Human cur = root;
                for (int i = 0; i < 10; i += 1) {
                    Human human = new Human();
                    cur.next = human;
                    cur = human;
                }
            }

            // ==== 扩展实现 ====
            {
                // List 可扩容有序数组, 内部是数组
                List<int> list = new List<int>(100);
                list.Add(1); // 内部不够就会扩容
                list.Add(0); // 内部不够就会扩容
                list.Add(5); // 内部不够就会扩容
                             // 1, 0, 5, null, null ...
                             // 每次Add不会排序, 复杂度 O(1)
            }

            {
                // SortedList 有序字典, 内部是两个数组, 一个存 key[], 一个存 value[]
                // 它会排序
                SortedList<int, string> sortedList = new SortedList<int, string>();
                sortedList.Add(1, "yo");
                sortedList.Add(0, "h");
                // 结果: 0, 1
                // 每次Add都会排序, 复杂度 O(n)
            }

            {
                // HashSet 集合, 内部是数组+链表
                // 哈希表(数组, 散列-散数组) HashEntry[]
                // 查找复杂度 O(1)
                // 添加复杂度 O(1)
                // 删除复杂度 O(1)

                // Dictionary 字典, 内部是数组+链表, 原理同HashSet
                // 哈希字典
                Dictionary<int, string> dict = new Dictionary<int, string>(1000);
                dict.Add(1, "yo");
                dict.Add(0, "h");
                dict.Add(5, "h");
                // 长度为1000时, 结果: 0, 1, null, null, null, 5, .... *1000个
                // 长度为4时, 结果: 0, 1 -> 5
            }

            {
                // Stack 栈, 内部用数组(或链表)
                // LIFO(Last In First Out)
                Stack<int> stack = new Stack<int>();
                stack.Push(0);
                stack.Push(1);
                stack.Push(2);

                int top = stack.Pop(); // 2, 变成 0, 1
                int peek = stack.Peek(); // 查看最后加入的. 返回1, 内部还是 0, 1
            }

            {
                // Queue 队列(排队), 内部是链表(或数组)
                // FIFO(First In First Out)
                // Enqueue 入列: 1, 结果: 1
                // 入列: 2, 结果: 1, 2
                Queue<int> queue = new Queue<int>();
                queue.Enqueue(0);
                queue.Enqueue(1);
                queue.Enqueue(2);

                int head = queue.Dequeue(); // 0, 变成 1, 2
                int peek = queue.Peek(); // 查看目前最先加入的. 返回1, 内部还是 1, 2

                int[] queueArray = new int[10];
                queueArray[0] = 1; // 先加入
                queueArray[1] = 2;
                queueArray[2] = 3;

                // 出列 原理
                head = queueArray[0]; // 1
                for (int i = 1; i < 10; i += 1) {
                    queueArray[i - 1] = queueArray[i];
                }
            }

            {
                // SortedSet 有序集合, 内部是二叉树
                SortedSet<int> sortedSet = new SortedSet<int>();

                // SortedList 对应 List, 它是有序数组实现
                // 插入O(n), n=100, n=100
                // 移除O(n), n=100, n=100
                // 查找O(logn), n=100, logn=7

                // SortedSet 对应 HashSet, 但它是二叉树实现
                // 插入O(logn), n=100, logn=7
                // 移除O(logn), n=100, logn=7
                // 查找O(logn), n=100, logn=7

                // SortedDictionary 对应 Dictionary, 它是二叉树实现

            }

        }

    }
}