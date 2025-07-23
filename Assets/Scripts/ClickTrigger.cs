using System;
using UnityEngine;

public class ClickTrigger : MonoBehaviour
{
   public event Action clicked;

    private void OnMouseUpAsButton()
    {
        clicked?.Invoke();
    }
}