using System;
using UnityEngine;

public class ClickTrigger : MonoBehaviour
{
   public event Action Clicked;

    private void OnMouseUpAsButton()
    {
        Clicked?.Invoke();
    }
}