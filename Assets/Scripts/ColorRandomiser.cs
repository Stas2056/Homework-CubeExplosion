using UnityEngine;

public class ColorRandomiser : MonoBehaviour
{
    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
    }

    private void Awake()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.color = Random.ColorHSV();
    }
}