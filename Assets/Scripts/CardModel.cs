using System.IO;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class CardModel : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    
    public Sprite face;
    public Sprite cardBack;
    public bool isFaceUp;
    
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    public void ToggleFace()
    {
        isFaceUp = !isFaceUp;
        _spriteRenderer.sprite = isFaceUp ? face : cardBack;
    }
    
    public void ToggleFace(bool showFace)
    {
        isFaceUp = showFace;
        _spriteRenderer.sprite = isFaceUp ? face : cardBack;
    }

    public void RemoveCard()
    {
        Destroy(gameObject);
    }
}