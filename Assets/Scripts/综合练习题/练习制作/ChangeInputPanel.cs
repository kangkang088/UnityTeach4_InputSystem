using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.UI;

public enum E_Button_Type {
    Up, Down, Left, Right, Fire, Jump
}
public class ChangeInputPanel : MonoBehaviour {
    public Text up;
    public Text down;
    public Text left;
    public Text right;
    public Text jump;
    public Text fire;
    public Button btnUp;
    public Button btnDown;
    public Button btnLeft;
    public Button btnRight;
    public Button btnJump;
    public Button btnFire;

    //记录当前要被改的键
    private InputInfo inputInfo;
    private E_Button_Type nowType;
    public PlayerLesson17 player;
    void Start() {
        inputInfo = DataMgr.Instance.InputInfo;
        UpdateButtonInfo();
        btnUp.onClick.AddListener(() => {
            ChangeButton(E_Button_Type.Up);
        });
        btnDown.onClick.AddListener(() => {
            ChangeButton(E_Button_Type.Down);
        });
        btnLeft.onClick.AddListener(() => {
            ChangeButton(E_Button_Type.Left);
        });
        btnRight.onClick.AddListener(() => {
            ChangeButton(E_Button_Type.Right);
        });
        btnJump.onClick.AddListener(() => {
            ChangeButton(E_Button_Type.Jump);
        });
        btnFire.onClick.AddListener(() => {
            ChangeButton(E_Button_Type.Fire);
        });
    }
    private void UpdateButtonInfo() {
        up.text = inputInfo.up;
        down.text = inputInfo.down;
        left.text = inputInfo.left;
        right.text = inputInfo.right;
        fire.text = inputInfo.fire;
        jump.text = inputInfo.jump;
    }
    private void ChangeButton(E_Button_Type type) {
        nowType = type;
        InputSystem.onAnyButtonPress.CallOnce(ChangeButtonReally);
    }
    private void ChangeButtonReally(InputControl control) {
        string[] strs = control.path.Split('/');
        string path = "<" + strs[1] + ">/" + strs[2];
        switch(nowType) {
            case E_Button_Type.Up:
                inputInfo.up = path;
                break;
            case E_Button_Type.Down:
                inputInfo.down = path;
                break;
            case E_Button_Type.Left:
                inputInfo.left = path;
                break;
            case E_Button_Type.Right:
                inputInfo.right = path;
                break;
            case E_Button_Type.Fire:
                inputInfo.fire = path;
                break;
            case E_Button_Type.Jump:
                inputInfo.jump = path;
                break;
        }
        UpdateButtonInfo();
        player.ChangeInput();
    }
    void Update() {

    }
}
