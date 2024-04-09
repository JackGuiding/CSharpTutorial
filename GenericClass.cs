using System.Collections.Generic;

// 数组: int
public class ArrayInt {

    public int[] arr;

    public ArrayInt(int size) {
        arr = new int[size];
    }

    public void Add(int v) {
        for (int i = 0; i < arr.Length; i++) {
            if (arr[i] == 0) {
                arr[i] = v;
                break;
            }
        }
    }

    public void Remove(int v) {
        for (int i = 0; i < arr.Length; i++) {
            if (arr[i] == v) {
                arr[i] = 0;
                break;
            }
        }
    }

    public void ForeachLog() {
        for (int i = 0; i < arr.Length; i++) {
            System.Console.WriteLine(arr[i]);
        }
    }

}

public class ArrayGeneric<T> where T : class {

    public T[] arr;

    public ArrayGeneric(int size) {
        arr = new T[size];
    }

    public void Add(T v) {
        for (int i = 0; i < arr.Length; i++) {
            if (arr[i] == null) {
                arr[i] = v;
                break;
            }
        }
    }

    public void Remove(T v) {
        for (int i = 0; i < arr.Length; i++) {
            if (arr[i] == v) {
                arr[i] = null;
                break;
            }
        }
    }

    public void ForeachLog() {
        for (int i = 0; i < arr.Length; i++) {
            System.Console.WriteLine(arr[i]);
        }
    }

}

public class Any<T> {

    public T value;

    public void Log() {
        System.Console.WriteLine(value.ToString());
    }

}

public class FakeDict<TKey, TValue> {

    public TKey[] keys;
    public TValue[] values;

    public void Add(TKey key, TValue value) {
        for (int i = 0; i < keys.Length; i++) {
            if (keys[i] == null) {
                keys[i] = key;
                values[i] = value;
                break;
            }
        }
    }

    public void Remove(TKey key) {
        for (int i = 0; i < keys.Length; i++) {
            if (keys[i].Equals(key)) {
                keys[i] = default(TKey);
                values[i] = default(TValue);
                break;
            }
        }
    }

}

public static class GenericClass {

    public static void Entry() {

        // ==== Ours ====
        Any<int> anyInt = new Any<int>();
        anyInt.value = 5;
        anyInt.Log();

        Any<string> anyStr = new Any<string>();
        anyStr.value = "s";
        anyStr.Log();

        ArrayInt arrayInt = new ArrayInt(10);
        arrayInt.Add(5);
        arrayInt.Add(6);
        arrayInt.ForeachLog();

        ArrayGeneric<string> arrayStr = new ArrayGeneric<string>(5);
        arrayStr.Add("Yo 1");
        arrayStr.Add("Yo 2");
        arrayStr.ForeachLog();

        // ==== Microsoft ====
        List<int> list = new List<int>();
        List<string> list2 = new List<string>();
        list.Add(3);
        list.Add(5);
        list.ForEach(value => {
            System.Console.WriteLine(value.ToString());
        });

        FakeDict<int, string> fakeDict = new FakeDict<int, string>();
        fakeDict.Add(10, "yo10");
        fakeDict.Add(3, "yo3");

    }

}