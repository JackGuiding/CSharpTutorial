using System;

// 官方做的事:
// public delegate void Action();
// public delegate void Action<T>(T t1);
// public delegate void Action<T1, T2>(T1 t1, T2 t2);
// ...... <T1, ..., T16>

// public delegate void Action(); // 官方委托, 所有返回值为 void, 且无参数的 delegate 都可以用 Action
// public delegate void MyAction(); 没必要使用 
// public delegate void YoAction(); 没必要使用

public delegate void Action<T>(T a); // 官方的
public delegate void ActionT<T>(T a); // 可替代下面两个
public delegate void Action1(int a);
public delegate void Action2(float a);

public delegate int Func3(float f);

public static class DelegateTutorial {

    public static void Entry() {

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
        Func3 d3 = Func3;
        int v3 = d3.Invoke(2.5f);
        System.Console.WriteLine("v3: " + v3);
        // int v3 = Func3(2.5f);

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