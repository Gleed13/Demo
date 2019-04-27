using System.IO;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class CardModel : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private Card _card;

    public Card GetCard => _card;
    
    public Sprite face;
    public Sprite cardBack;
    public bool isFaceUp;
    public int cardIndex;
    
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _card = new Card(cardIndex);
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

    public void SetFace(int index)
    {
        cardIndex = index;
        face = AllCards.Instance.cardFaces[index];
        _card = new Card(index);
    }

    public void RemoveCard()
    {
        Destroy(gameObject);
    }
}