using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using JetBrains.Annotations;

public class ClickableObject : MonoBehaviour, IPointerClickHandler
{
    public delegate void ButtonAction();
    private ButtonAction LeftAction;
    private ButtonAction RightAction;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
            LeftAction();
        else if (eventData.button == PointerEventData.InputButton.Right)
            RightAction();
    }

    public void SetUpLeftButtonAction(ButtonAction callback)
    {
        LeftAction = callback;
        Debug.Log(LeftAction);
    }

    public void SetUpRightButtonAction(ButtonAction callback)
    {
        RightAction = callback;
    }
}
