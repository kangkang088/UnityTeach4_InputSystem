using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DataMgr
{
    private static DataMgr instance = new DataMgr();
    public static DataMgr Instance => instance;
    private InputInfo inputInfo;
    public InputInfo InputInfo => inputInfo;
    private string jsonStr;
    private DataMgr() {
        inputInfo = new InputInfo();
        jsonStr = Resources.Load<TextAsset>("Lesson17").text;
    }
    public InputActionAsset GetActionAsset() {
        string str = jsonStr.Replace("<up>",inputInfo.up);
        str = str.Replace("<down>",inputInfo.down);
        str = str.Replace("<left>",inputInfo.left);
        str = str.Replace("<right>",inputInfo.right);
        str = str.Replace("<jump>",inputInfo.jump);
        str = str.Replace("<fire>",inputInfo.fire);
        return InputActionAsset.FromJson(str);
    }
}
