using System;

namespace ReflectionSample {

    public interface MyMonoBehaviour {
        void Awake();
    }

    [ObsoleteAttribute("I love potato")]
    class MyVector : MyMonoBehaviour {

        int value; // BindingFlag: instance
        static int statiValue; // BindingFlag: static

        [Jack]
        int y;

        public MyVector() {
            value = 5;
        }

        public void Awake() {
            System.Console.WriteLine("MyVector Awake");
        }

        int Add(int a, int b) {
            return a + b;
        }

        void CallLog() {
            System.Console.WriteLine("MyVector.Call");
        }

    }

}