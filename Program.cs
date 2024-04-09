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

// <T>
public static class Program {

    public static void Main() {

        // ==== Eg: 1 ==== 
        int v = 1;
        // v.ToString(); // "1"

        Log<int>(v);
        // Log(v); // 可省略成这样

        // ==== Eg: 2 ====
        MyType type = new MyType();
        Log(type);

    }

    public static void Log<T>(T obj) {
        string str = obj.ToString();
        Console.WriteLine(str);
    }

}