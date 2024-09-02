using System.Collections.Generic;
using System.Diagnostics;

public static class Program {

    public static void Main() {

        ListTest();
        DictionaryTest();

        // GenericMethod.Entry();
        // GenericClass.Entry();
        // DelegateTutorial.Entry();
        // Sample.Entry();
        // Architecture.Entry();

        // Collection_List_App.Entry();
        // Collection_Dictionary_App.Entry();
        // ReflectionSample.Reflection_Tutorial.Entry();

    }

    static void ListTest() {

        // 空间
        int[] array = new int[1000000];
        List<int> list = new List<int>(1000000); // 4 和 1000000 有区别
        Stopwatch sw = new Stopwatch();

        // 开方
        double value = 2;
        double min = 0;
        double max = 2;
        double current = 0;
        int count = 0;
        while (count < 1000000) {
            current = (min + max) / 2f;
            if (current * current == value) {
                break;
            } else if (current * current > value) {
                max = current;
            } else {
                min = current;
            }
            count++;
        }
        System.Console.WriteLine("current: " + current);

        // 时间
        for (int i = 0; i < 100_0000; i++) {
            list.Add(i);
        }

        int index = list.FindIndex(value => value == 1000_0000);
        sw.Start();
        list.BinarySearch(810000);
        sw.Stop();

        double ms = sw.Elapsed.TotalMicroseconds;
        System.Console.WriteLine("List: " + ms);
        // List Find: 1800

        // malloc(sizeof(int) * 1000000);
    }

    static void DictionaryTest() {

        Dictionary<int, int> dict = new Dictionary<int, int>(4);
        for (int i = 0; i < 100_0000; i++) {
            dict.Add(i, i);
        }
        bool has = dict.TryGetValue(100_0000, out int value);

        Stopwatch sw = new Stopwatch();
        sw.Start();
        foreach (var item in dict) {

        }
        sw.Stop();

        double ms = sw.Elapsed.TotalMicroseconds;
        System.Console.WriteLine("Dictionary: " + ms);

    }

}