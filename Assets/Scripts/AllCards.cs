using UnityEngine;

public class AllCards : MonoBehaviour
{
    public static AllCards Instance { get; private set; }
    
    public Sprite[] cardFaces;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
    }
}
