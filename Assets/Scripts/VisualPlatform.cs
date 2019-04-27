using System.Collections.Generic;
using UnityEngine;

public class VisualPlatform : MonoBehaviour
{
//    private SpriteRenderer _spriteRenderer;
    private SpriteRenderer _zoneSpriteRenderer;
    private BoxCollider2D _collider2D;
    private float _scaleFactor;
    
    public float maxPlatformWidth;

    public GameObject zone;
    
    public List<GameObject> visibleCards;

    private void Awake()
    {
//        _spriteRenderer = GetComponent<SpriteRenderer>();
        _zoneSpriteRenderer = zone.GetComponent<SpriteRenderer>();
        _collider2D = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        Rearrange();
        DefineZoneScale(true);
        DefineCollider2DScale(true);
    }

    private const float Half = Util.CardWidth / 2;
    private void Rearrange()
    {
        var startPoint = -maxPlatformWidth / 2 + Half;
        
        var cards = visibleCards.Count;
        var parPos = gameObject.transform.position;
        
        if (cards * Util.CardWidth > maxPlatformWidth)
        {
            _scaleFactor = maxPlatformWidth;
            var step = (maxPlatformWidth - Util.CardWidth) / (cards - 1);
            for (var i = 0; i < cards; i++)
            {
                visibleCards[i].transform.parent = gameObject.transform;
                var pos = visibleCards[i].transform.position;
                pos.x = startPoint + step*i + parPos.x;
                pos.y = parPos.y;
                pos.z = 1f / cards * (i + 1);
//                Debug.Log("startpoint = " + StartPoint + "\nx = " + pos.x);
                visibleCards[i].transform.position = pos;
            }
        }
        else
        {
            _scaleFactor = Util.CardWidth * cards;
            for (var i = 0; i < cards; i++)
            {
                visibleCards[i].transform.parent = gameObject.transform;
                var pos = visibleCards[i].transform.position;
                pos.x = -Half * (cards - 1) + (Util.CardWidth * i) + parPos.x;
                pos.y = parPos.y;
                pos.z = 1f / cards * (i + 1);
                visibleCards[i].transform.position = pos;
            }
        }
    }

    private void DefineZoneScale(bool value)
    {
        _zoneSpriteRenderer.enabled = value;
        if (!value) return;
        var scl = zone.transform.localScale;
        scl.x = _scaleFactor + Util.SelectThickness;
        scl.y = 1f + Util.SelectThickness;
        zone.transform.localScale = scl;
    }

    private void DefineCollider2DScale(bool value)
    {
        _collider2D.enabled = value;
        if (!value) return;
        var vec2 = _collider2D.size;
        vec2.x = _scaleFactor;
        _collider2D.size = vec2;
    }

    public void AddCard(GameObject card)
    {
        card.transform.parent = transform;
        visibleCards.Add(card);
        Rearrange();
        DefineZoneScale(true);
    }
    
    public bool shown;
    public void ShowCards()
    {
        shown = !shown;
        foreach (var card in visibleCards)
        {
            var model = card.GetComponent<CardModel>();
            model.ToggleFace(shown);
        }
    }

    public void ChangeZoneColor(Color color)
    {
        _zoneSpriteRenderer.color = color;
    }
}