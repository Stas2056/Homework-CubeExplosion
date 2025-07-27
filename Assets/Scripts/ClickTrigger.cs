using System;
using UnityEngine;

public class ClickTrigger : MonoBehaviour
{
   public event Action Ñlicked;

    private void OnMouseUpAsButton()
    {
        Ñlicked?.Invoke();
    }
}