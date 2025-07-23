using UnityEngine;

public class Utils : MonoBehaviour
{
    private static System.Random s_random = new System.Random();

    public static int GenerateRandomNumber(int min, int max)
    {
        return s_random.Next(min, max + 1);
    }
}