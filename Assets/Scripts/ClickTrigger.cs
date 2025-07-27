using System;
using UnityEngine;

public class ClickTrigger : MonoBehaviour
{
   public event Action �licked;

    private void OnMouseUpAsButton()
    {
        �licked?.Invoke();
    }
}