using System.Collections.Generic;
using UnityEngine;

public class VisualPlatform : MonoBehaviour
{
//    private SpriteRenderer _spriteRenderer;
    private SpriteRenderer _zoneSpriteRenderer;
    private float _scaleFactor;
    
    public float maxPlatformWidth;

    public GameObject zone;
    public List<GameObject> visibleCards;

    private void Awake()
    {
//        _spriteRenderer = GetComponent<SpriteRenderer>();
        _zoneSpriteRenderer = zone.GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        Rearrange();
        Select(true);
    }

    private const float Half = Util.CardWidth / 2;
    public void Rearrange()
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
//                Debug.Log("strtpoint = " + StartPoint + "\nx = " + pos.x);
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

    public void Select(bool value)
    {
        _zoneSpriteRenderer.enabled = value;
        if (!value) return;
        var scl = zone.transform.localScale;
        scl.x = _scaleFactor + Util.SelectThickness;
        scl.y = 1f + Util.SelectThickness;
        zone.transform.localScale = scl;
    }

    public void ShowCards()
    {
        foreach (var card in visibleCards)
        {
            var model = card.GetComponent<CardModel>();
            model.ToggleFace();
        }
    }

    public void ChangeZoneColor(Color color)
    {
        _zoneSpriteRenderer.color = color;
    }
}