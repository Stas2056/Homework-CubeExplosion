using System;
using UnityEngine;

public class RaycastTrigger : MonoBehaviour
{  
    public event Action<Cube> CubeClicked;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.TryGetComponent(out Cube cube))
                {
                    CubeClicked?.Invoke(cube);
                }
            }
        }
    }
}