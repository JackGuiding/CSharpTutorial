using System;

// public delegate void Action(); // 官方委托, 所有返回值为 void, 且无参数的 delegate 都可以用 Action
// public delegate void MyAction(); 没必要使用 
// public delegate void YoAction(); 没必要使用

public delegate void Dele2(int a);
public delegate int Dele3(float f);

public static class DelegateTutorial {

    public static void Entry() {

        Action a1 = Func1;
        a1.Invoke();

        Action d1 = Func1;
        d1.Invoke();
        // Func1();

        Dele2 d2 = Func2;
        d2.Invoke(5);
        // Func2(5);

        Dele3 d3 = Func3;
        int v3 = d3.Invoke(2.5f);
        System.Console.WriteLine("v3: " + v3);
        // int v3 = Func3(2.5f);

    }

    static void Func1() {
        Console.WriteLine("Func1");
    }

    static void Func2(int val) {
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