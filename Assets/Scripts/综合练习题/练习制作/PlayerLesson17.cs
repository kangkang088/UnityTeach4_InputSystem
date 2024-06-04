using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLesson17 : MonoBehaviour
{
    private PlayerInput playerInput;
    void Start()
    {
        playerInput = this.GetComponent<PlayerInput>();
        playerInput.actions = DataMgr.Instance.GetActionAsset();
        playerInput.actions.Enable();
        playerInput.onActionTriggered += PlayerInput_onActionTriggered;
    }

    private void PlayerInput_onActionTriggered(InputAction.CallbackContext context) {
        if(context.phase == InputActionPhase.Performed) {
            switch(context.action.name) {
                case "Fire":
                    print("Fire");
                    break;
                case "Jump":
                    print("Jump");
                    break;
                case "Move":
                    print("Move");
                    break;
                default:
                    break;
            }
        }
    }
    /// <summary>
    /// 让玩家产生改键效果
    /// </summary>
    public void ChangeInput() {
        playerInput.actions = DataMgr.Instance.GetActionAsset();
        playerInput.actions.Enable();
    }

    void Update()
    {
        
    }
}
