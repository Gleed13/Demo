using Enum;
using UnityEngine;

public class Card
{
    public Suit CardSuit { get; private set; }
    public int InitialPower { get; private set; }

    public Card(int index)
    {
        DefineCard(index);
    }

    private void DefineCard(int cardIndex)
    {
        if (cardIndex < 13)
        {
            CardSuit = Suit.Heart;
            InitialPower = cardIndex == 0 ? 13 : cardIndex;
        }
        else if (cardIndex < 26)
        {
            CardSuit = Suit.Diamond;
            InitialPower = cardIndex == 13 ? 13 : cardIndex - 13;
        }
        else if (cardIndex < 39)
        {
            CardSuit = Suit.Club;
            InitialPower = cardIndex == 26 ? 13 : cardIndex - 26;
        }
        else if (cardIndex < 52)
        {
            CardSuit = Suit.Spade;
            InitialPower = cardIndex == 39 ? 13 : cardIndex - 39;
        }
        else
        {
            Debug.Log("Index out of range");
        }
    }
}