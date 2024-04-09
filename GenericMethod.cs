using System;

// 所有类型都继承自 System.Object
// 自然就有它的成员函数和成员字段
public class MyType : System.Object {

    // 自定义类型如果没有 override ToString() 方法
    // 那么它会打印出类型的名称
    public override string ToString() {
        // 可用 override 重写 父类型的 `virtual` 和 `abstract` 方法
        return "111";
    }

}

public class Human {
    public int age;
    public string name;
}

public class Woman : Human {
    public int height;
}

public class Man : Human {
    public int weight;
}

// <T>
public static class GenericMethod {

    public static void Entry() {

        // ==== Eg: 1 ==== 
        Int32 v = 1;
        // v.ToString(); // "1"

        Log<Int32>(v);
        // Log(v); // 可省略成这样

        // ==== Eg: 2 ====
        MyType type = new MyType();
        Log(type);

        // ==== Eg: 3 ====
        Woman wm = new Woman();
        wm.age = 3;
        LogHuman(wm);

        Man man = new Man();
        man.age = 5;
        LogHuman(man);

        // LogHuman(v); x 不行, 因为不符合 where T : Human

    }

    public static void Log<T>(T obj) {
        string str = typeof(T).Name;
        if (str == "Int32") {
            System.Console.WriteLine("Value");
        } else if (str == "Single") {
            System.Console.WriteLine("Float");
        } else {
            System.Console.WriteLine("Spec Type");
        }
    }

    // where T : struct
    // where T : class
    // where T : AnyType
    public static void LogHuman<T>(T obj) where T : Human {
        System.Console.WriteLine("age: " + obj.age);
    }

    public static void LogWoman(Woman woman) {

    }

    public static void LogMan(Man man) {

    }

}