using System;
using System.Collections.Generic;
using UnityEngine;

public class VisibleCardDeck : MonoBehaviour
{
    private const int NumberOfCards = 52;
    private const float DiviationX = 0.002f;
    private const float DiviationY = 0.0008f;
    [SerializeField] private GameObject cardToInit;
    private Vector3 _parentPosition;
    
    public List<GameObject> Deck { get; private set; }

    private void Awake()
    {
        _parentPosition = cardToInit.transform.position;
    }

    private void Start()
    {
        InitAllCards();
    }

    private void InitAllCards()
    {
        List<GameObject> list = new List<GameObject>();
        for (var i = 0; i < NumberOfCards; i++)
        {
            var vector = new Vector3(
                _parentPosition.x + DiviationX*i,
                _parentPosition.y + DiviationY*i,
                _parentPosition.z - 1f*i);
            var anotherCard = Instantiate(cardToInit, vector, Quaternion.identity, gameObject.transform);
            list.Add(anotherCard);
        }
        Deck = list;
        cardToInit.SetActive(false);
    }

    public void AddCards(int quantity)
    {
        if (quantity <= 0) return;
        var c = Deck.Count;
        cardToInit.SetActive(true);
        for (var i = c; i < c + quantity; i++)
        {
            var vector = new Vector3(
                _parentPosition.x + DiviationX*i,
                _parentPosition.y + DiviationY*i,
                _parentPosition.z - 1f*i);
            var anotherCard = Instantiate(cardToInit, vector, Quaternion.identity, gameObject.transform);
            Deck.Add(anotherCard);
        }
        cardToInit.SetActive(false);
    }

    public void RemoveCards(int quantity)
    {
        if (quantity <= 0) return;
        if (quantity >= Deck.Count)
        {
            foreach (var c in Deck)
            {
                Destroy(c);
            }
            Deck.Clear();
        }
        else
        {
            for (var i = 0; i < quantity; i++)
            {
                var g = Deck[Deck.Count - 1];
                Deck.RemoveAt(Deck.Count - 1);
                Destroy(g);
            }
        }
    }
}