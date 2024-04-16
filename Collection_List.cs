using System;
using System.Collections.Generic;

public class MyList {

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

    public MyList(int capacity = 4) {
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
        WhatList();
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
        MyList myList = new MyList();
        for (int i = 0; i < 100; i += 1) {
            myList.Add(i);
        }
        for (int i = 0; i < myList.Count; i += 1) {
            // System.Console.WriteLine($"MyList: {myList.GetValue(i)}");
            System.Console.WriteLine($"MyList: {myList[i]}");
        }

    }

}