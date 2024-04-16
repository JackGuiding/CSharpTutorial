using System;
using System.Collections.Generic;
using System.Diagnostics;

public class MyIntList {

    int[] array;
    int capacity;
    int count;
    public int Count => count;

    // 索引器
    public int this[int index] {
        get {
            return array[index];
        }
        set {
            array[index] = value;
        }
    }

    public int GetValue(int index) {
        return array[index];
    }

    public void SetValue(int index, int value) {
        array[index] = value;
    }

    // public int Count {
    //     get {
    //         return count;
    //     }
    // }

    public int GetCount() {
        return count;
    }

    public void SetCount(int value) {
        count = value;
    }

    public MyIntList(int capacity = 4) {
        this.capacity = capacity;
        this.count = 0;
        this.array = new int[capacity];
    }

    public void Add(int value) {

        array[count] = value;
        count += 1;

        // 扩容
        if (count == capacity) {
            capacity *= 2;
            // 拷贝
            int[] newArray = new int[capacity];
            for (int i = 0; i < count; i += 1) {
                newArray[i] = array[i];
            }
            array = newArray;
        }

    }

    public void Remove(int value) {

        // Plan A: C# 官方做法 O(n^2)
        // value == 1;
        // array: 8 [1] 2 3 5 4
        // index: 0 1   2 3 4 5

        // array: 8 2 3 5 4
        // index: 0 1 2 3 4
        // for (int i = 0; i < count; i += 1) {
        //     if (array[i] == value) {
        //         for (int j = i; j < count - 1; j += 1) {
        //             array[j] = array[j + 1];
        //         }
        //         count -= 1;
        //         break;
        //     }
        // }

        // Plan B: 我的做法 O(n)
        // value == 1;
        // array: 8 [1] 2 3 5 4
        // index: 0 1   2 3 4 5

        // array: 8 4 2 3 5
        // index: 0 1 2 3 4

        for (int i = 0; i < count; i += 1) {
            if (array[i] == value) {
                array[i] = array[count - 1];
                count -= 1;
            }
        }

    }

}

public static class Collection_List_App {

    public static void Entry() {

        // 数据结构的作用:
        // 1. 存储(添加, 删除, 查找, 遍历) CURD
        // 2. 优缺点:
        //      - 添加快, 遍历快, 查找慢: List
        //      - 添加慢, 遍历快, 查找快: SortedList
        //      - 添加快, 遍历慢, 查找快: Dictionary
        //      - 添加快, 遍历快, 查找快: SortedDictionary 但消耗内存
        Queue<int> queue = new Queue<int>();
        Stack<int> stack = new Stack<int>();
        Dictionary<int, object> dict = new Dictionary<int, object>();
        SortedDictionary<int, object> sdict = new SortedDictionary<int, object>();
        HashSet<int> hashset = new HashSet<int>();
        SortedList<int, object> slist = new SortedList<int, object>();
        LinkedList<int> linkedlist = new LinkedList<int>();

        // WhatList();
        WhatSortedList();
    }

    // 1. 什么是List
    static void WhatList() {

        // 作用:
        // 1. 当不知道要存多少数据时
        List<int> list = new List<int>(4);
        for (int i = 0; i < 100; i += 1) {
            list.Add(i);
        }
        for (int i = 0; i < list.Count; i += 1) {
            System.Console.WriteLine($"List: {list[i]}");
        }

        // 原理:
        // 1. List是一个动态数组, 内部是一个数组
        MyIntList myList = new MyIntList();
        for (int i = 0; i < 100; i += 1) {
            myList.Add(i);
        }
        for (int i = 0; i < myList.Count; i += 1) {
            // System.Console.WriteLine($"MyList: {myList.GetValue(i)}");
            System.Console.WriteLine($"MyList: {myList[i]}");
        }

    }

    // 2.
    static void WhatSortedList() {

        Stopwatch sw = new Stopwatch();

        Random rd = new Random(38);

        // ==== LIST ====
        List<int> list = new List<int>(20_0000);

        // SortedList 禁止重复 Key
        SortedList<int, int> slist = new SortedList<int, int>(20_0000);

        Dictionary<int, int> dict = new Dictionary<int, int>(20_0000);

        // 添加
        for (int i = 20_0000 - 1; i >= 0; i -= 1) {
            // int value = rd.Next(0, 100);
            list.Add(i);
            slist.Add(i, i);
            dict.Add(i, i);
        }

        // 手动排序
        // list.Sort();
        // list.Sort((a, b) => {
        //     int smaller = a.CompareTo(b); // 如果 a < b 返回 -1; 如果 a == b 返回 0; 如果 a > b 返回 1;
        //     return smaller;
        // });

        // 显示
        // for (int i = 0; i < list.Count; i += 1) {
        //     System.Console.WriteLine($"List: {list[i]}");
        // }

        // ==== SortedList ====
        // 会以Key作为排序依据
        // 从小到大排
        // for (int i = 0; i < slist.Count; i += 1) {
        //     System.Console.WriteLine($"SortedList: {slist.Values[i]}");
        // }

        // ==== 查找 ====
        {
            sw.Restart();
            int res = slist.IndexOfKey(199999);
            sw.Stop();
            System.Console.WriteLine($"SortedList IndexOfKey: {res}, {sw.Elapsed.TotalMicroseconds}mrs");
        }

        {
            sw.Restart();
            bool has = dict.TryGetValue(199999, out int res);
            sw.Stop();
            System.Console.WriteLine($"Dictionary: {res}, {sw.Elapsed.TotalMicroseconds}mrs");
        }

        {
            sw.Restart();
            int res = list.Find(value => value == 199999);
            sw.Stop();
            System.Console.WriteLine($"List FindIndex: {res}, {sw.Elapsed.TotalMicroseconds}mrs");
        }

    }

}