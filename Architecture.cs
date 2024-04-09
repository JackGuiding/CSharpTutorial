using System;

// UI 高层 class Panel
// UI 低层 class Button
// 底层 struct Int32(int)
// 原则: 低层不能知道高层(完全不知它的class), 高层可以知道低层
public class Panel {

    public int playerLevel;
    public Button startGameBtn;

    public void Inject(Button btn) {
        startGameBtn = btn;
        // 用法2
        // startGameBtn.OnGetPlayerLevelHandle = () => {
        //     return playerLevel;
        // };
        startGameBtn.OnGetPlayerLevelHandle = GetPlayerLevel;
    }

    int GetPlayerLevel() {
        return playerLevel;
    }

    // 低层调高层的方法之一: 访问低层字段
    public void Update() {
        if (startGameBtn.isClicked) {
            startGameBtn.LogPlayerLevel(playerLevel);
        }
    }

}

public class Button {

    public bool isClicked;

    public Func<int/*playerLevel*/> OnGetPlayerLevelHandle;

    public Button() { }

    // 不要这么做
    // 但它知道了高层的存在, 所以在架构中非常不好
    // 因为低层依赖了高层
    // public void LogPlayerLevel(Panel panel) {
    //     System.Console.WriteLine(panel.playerLevel);
    // }

    // 正确用法1
    public void LogPlayerLevel(int playerLevel) {
        System.Console.WriteLine(playerLevel);
    }

    // 正确用法2
    public void LogPlayerLevel() {
        int level = OnGetPlayerLevelHandle.Invoke();
        System.Console.WriteLine(level);
    }

    public void OnClick() {
        LogPlayerLevel();
    }

}

public static class Architecture {

    public static void Entry() {

        Button btn = new Button();

        Panel panel = new Panel();
        panel.playerLevel = 999;
        panel.Inject(btn);

        // 通过委托, 从低层获取到高层的某个值
        btn.OnClick();

    }

}