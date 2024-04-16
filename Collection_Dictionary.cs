using System.Diagnostics;
using System.Collections.Generic;

// key: int
// value: object
public class MyDict {

    HashEntry[] array;

    public MyDict(int capacity = 100) {
        array = new HashEntry[capacity];
        for (int i = 0; i < capacity; i += 1) {
            array[i] = new HashEntry();
        }
    }

    public void Add(int key, object value) {

        // 设
        // key 1: 1001, index -> 1
        // key 2: 101, index -> 1
        // key 3: 1, index -> 1

        int index = key % array.Length;
        HashEntry entry = array[index];

        // 没碰撞, 直接添加
        if (!entry.hasValue) {
            entry.hasValue = true;
            entry.key = key;
            entry.value = value;
            return;
        }

        // 如果该位置已有值了
        // 称之为"哈希冲突"或"碰撞"
        HashEntry next = new HashEntry();
        next.hasValue = true;
        next.key = key;
        next.value = value;

        while (entry.hasValue) {
            if (entry.next == null) {
                entry.next = next;
            } else {
                entry = entry.next;
            }
        }

    }

    public object Get(int key) {

        int index = key % array.Length;
        HashEntry entry = array[index];
        if (!entry.hasValue) {
            // 找不到
            return null;
        }

        while (entry != null) {
            if (entry.key == key) {
                return entry.value;
            }
            // 链表的下一个
            entry = entry.next;
        }

        return null;

    }

}

public class HashEntry {
    public bool hasValue; // false
    public int key; // 0
    public object value; // null
    public HashEntry next; // null
}

public static class Collection_Dictionary_App {

    public static void Entry() {

        // MyDict myDict = new MyDict(20_0000);
        // Dictionary<int, object> dict = new Dictionary<int, object>(20_0000);
        // for (int i = 0; i < 20_0000; i += 1) {
        //     myDict.Add(i, null);
        //     dict.Add(i, null);
        // }

        // {
        //     Stopwatch sw = new Stopwatch();
        //     sw.Start();
        //     object value = dict[19_5555];
        //     sw.Stop();
        //     System.Console.WriteLine($"MS Time: {sw.Elapsed.Microseconds} mrs");
        // }

        // {
        //     Stopwatch sw = new Stopwatch();
        //     sw.Start();
        //     object value = myDict.Get(19_5555);
        //     sw.Stop();
        //     System.Console.WriteLine($"My Time: {sw.Elapsed.Microseconds} mrs");
        // }

        // QueueWhat();
        StackWhat();

    }

    static void QueueWhat() {

        // 先入先出
        Queue<int> a = new Queue<int>();
        a.Enqueue(3); // [3]
        a.Enqueue(5); // 3 [5]

        int value = a.Peek(); // 查看第一个元素, 但不出列
        System.Console.WriteLine("peek: " + value);

        value = a.Dequeue(); // [3] 5
        System.Console.WriteLine("dq1: " + value);

        value = a.Dequeue(); // [5]
        System.Console.WriteLine("dq2: " + value);

    }

    static void StackWhat() {

        // 后入先出
        Stack<int> a = new Stack<int>();
        a.Push(3); // [3]
        a.Push(5); // 3 [5]

        int value = a.Peek(); // 查看第一个元素, 但不出栈
        System.Console.WriteLine("peek: " + value);

        value = a.Pop(); // [3] 5
        System.Console.WriteLine("pop1: " + value);

        value = a.Pop(); // [5]
        System.Console.WriteLine("pop2: " + value);
    }

}