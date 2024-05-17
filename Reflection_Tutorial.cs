using System;
using System.Reflection;

// 用途:
// 1. 标记代码, 以便于特殊处理
// 2. 校验代码
//     - 比如一整个程序集里禁止使用 float 类型
// 3. Hack 非 public 的字段与方法

// 反射功能:
// 1. 可以取到非 public 的字段与方法
// 2. 同样可以设置其字段的值
// 3. 调用函数
// 4. 特性
//      - 标记
// 5. 查看继承(类)
// 只要是源代码有写的, 都能访问到
// 可处理所有未知类型

namespace ReflectionSample {

    [AttributeUsage(AttributeTargets.All)]
    public class JackAttribute : Attribute { }

    public class Human : MyMonoBehaviour {

        int value;
        public int Value {
            get { return value; }
        }

        [Jack]
        public string name;

        public Human() {
            value = 99;
        }

        public void Awake() {
            System.Console.WriteLine("Human Awake");
        }

        void Update() {

        }

        void CallLog() {
            System.Console.WriteLine("HumanJump");
        }

        int Add(int a, int b) {
            return a + b;
        }

    }

    public static class Reflection_Tutorial {

        public static void Entry() {

            Human human = new Human();
            ReflectGet(human);
            ReflectCall(human);
            // DebugTypeName<Human>(human);
            ReflectAttr(human);

            Type type = Type.GetType("ReflectionSample.MyVector");
            object myVec = Activator.CreateInstance(type);

            ReflectSet(myVec);
            ReflectGet(myVec);
            ReflectCall(myVec);
            ReflectAttr(myVec);

            ReflectAssembly();

        }

        static void DebugTypeName<T>(T obj) {
            Type type = typeof(T);
            Console.WriteLine(type.Namespace);
            Console.WriteLine(type.Name);
            Console.WriteLine(type.FullName);
        }

        // ==== 赋值 ====
        static void ReflectSet(object obj) {
            Type type = obj.GetType();
            FieldInfo info = type.GetField("value", BindingFlags.NonPublic | BindingFlags.Instance);
            info.SetValue(obj, 80);
        }

        // ==== 取值 ====
        static void ReflectGet(object obj) {

            // 获取类型
            Type type = obj.GetType(); // 命名空间.类名

            // 获取字段
            FieldInfo info = type.GetField("value", BindingFlags.NonPublic | BindingFlags.Instance);
            int value = (int)info.GetValue(obj);
            System.Console.WriteLine($"{type.Name} value: " + value);

        }

        // ==== 调用函数 ====
        static void ReflectCall(object obj) {
            Type type = obj.GetType();
            MethodInfo method = type.GetMethod("CallLog", BindingFlags.NonPublic | BindingFlags.Instance);
            object returnValue = method.Invoke(obj, new object[0] { }); // 后面是函数参数

            MemberInfo[] allMethods = type.GetMethods(BindingFlags.Public | BindingFlags.Static);
            foreach (var m in allMethods) {
                System.Console.WriteLine($"Method: {m.Name}");
            }

            MethodInfo addMethod = type.GetMethod("Add", BindingFlags.NonPublic | BindingFlags.Instance);
            ParameterInfo[] parms = addMethod.GetParameters();
            for (int i = 0; i < parms.Length; i += 1) {
                var par = parms[i];
                System.Console.WriteLine($"Par: {par.ParameterType} {par.Name}");
            }
            int value = (int)addMethod.Invoke(obj, new object[2] { 5, 6 });
            System.Console.WriteLine($"{type.Name} Add: " + value);
        }

        // ==== 特性 ====
        static void ReflectAttr(object obj) {
            // Has JackAttribute
            Type type = obj.GetType();
            // Class
            // Fields
            // Methods
            // Property(属性, 相当于函数)
            FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            for (int i = 0; i < fields.Length; i += 1) {
                FieldInfo field = fields[i];
                JackAttribute attr = field.GetCustomAttribute<JackAttribute>();
                // JackAttribute attr = (JackAttribute)field.GetCustomAttribute(typeof(JackAttribute));
                if (attr != null) {
                    System.Console.WriteLine($"Field: {field.Name}");
                }
            }
        }

        // ==== 程序集 ====
        static void ReflectAssembly() {
            // .cs 编译 -> .dll
            // Assembly -> .dll
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            for (int i = 0; i < assemblies.Length; i += 1) {

                Assembly assembly = assemblies[i];
                if (assembly.GetName().Name == "CSharpTutorial") {

                    // 程序集里的所有类型
                    Type[] types = assembly.GetTypes();

                    // 排序: 按特性, 名字长度, 名字首字母
                    for (int j = 0; j < types.Length; j += 1) {
                        Type type = types[j];
                        if (type.BaseType != null && type.BaseType.Name == "MyMonoBehaviour") {
                            MethodInfo awakeMethod = type.GetMethod("Awake", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                            if (awakeMethod != null) {
                                // 此处只是演示, 所以创建一个对象.
                                // 但Unity里不需要创建,而是直接从Scene里传入
                                awakeMethod.Invoke(Activator.CreateInstance(type), new object[0] { });
                            }
                        }
                    }
                }
            }
        }

    }
}