using System;

// 官方做的事 Action:
// public delegate void Action();
// public delegate void Action<T>(T t1);
// public delegate void Action<T1, T2>(T1 t1, T2 t2);
// ...... <T1, ..., T16>

// public delegate void Action(); // 官方委托, 所有返回值为 void, 且无参数的 delegate 都可以用 Action
// public delegate void MyAction(); 没必要使用 
// public delegate void YoAction(); 没必要使用

// 官方做的事 Func:
// public delegate TResult Func<TResult>();
// public delegate TResult Func<T1, TResult>(T1 t1);
// public delegate TResult Func<T1, T2, TResult>(T1 t1, T2 t2);

// 官方做的事 Predicate:
// public delegate bool Predicate<T>(T obj);

public delegate void Action<T>(T a); // 官方的
public delegate void ActionT<T>(T a); // 可替代下面两个
public delegate void Action1(int a);
public delegate void Action2(float a);

public delegate int Func1(float f);
public delegate TOut Func2<TIn, TOut>(TIn t);

// public delegate bool Predicate<T>(T obj);

public static class DelegateTutorial {

    static void LogSomething(int a, float b, string str, int[] arr) {

    }

    public static void Entry() {

        Action<int, float, string, int[]> specAction = LogSomething;
        specAction.Invoke(3, 4.0f, "Yo", new int[] { 5, 4, 3 });
        // LogSomething(3, 4.0f, "Yo", new int[] {5, 4, 3});

        // ==== Eg: 1a ====
        Action1 action1 = AMethod1;
        action1.Invoke(5);
        // Func1();

        Action2 action2 = AMethod2;
        action2.Invoke(50.8f);
        // Func2(5);

        // ==== Eg: 1b ====
        ActionT<int> t1 = AMethod1;
        t1.Invoke(6);

        ActionT<float> t2 = AMethod2;
        t2.Invoke(5.3f);

        // ==== Eg: 2 ====
        Func1 d3 = Func3;
        int v3 = d3.Invoke(2.5f);
        System.Console.WriteLine("v3: " + v3);
        // int v3 = Func3(2.5f);

        Func<float, int> f3 = Func3;
        int fout = f3.Invoke(10.3f);
        System.Console.WriteLine("fout: " + fout);

        // ==== Eg: 3 ====
        Predicate<int> pre1 = (int value) => {
            bool isUpper5 = value > 5;
            return isUpper5;
        };
        bool res1 = pre1.Invoke(3);
        System.Console.WriteLine("res1: " + res1.ToString());

        bool res2 = pre1.Invoke(8);
        System.Console.WriteLine("res2: " + res2.ToString());

    }

    static void AMethod1(int val) {
        Console.WriteLine("Func1: " + val);
    }

    static void AMethod2(float val) {
        Console.WriteLine("Func2: " + val);
    }

    static int Func3(float val) {
        // 1.3 -> 1
        // 1.99 -> 1
        // 2 -> 2
        // 2.1 -> 2
        Console.WriteLine("Func3: " + val);
        return (int)val;
    }

}