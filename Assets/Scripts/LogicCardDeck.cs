using System.Collections.Generic;

public class LogicCardDeck
{
    public List<Card> CardDeck { get; private set; }

    public LogicCardDeck()
    {
        InitDeck();
    }

    private void InitDeck()
    {
        List<Card> list = new List<Card>();
        for (var i = 0; i < 52; i++)
        {
            var c = new Card(i);
            list.Add(c);
        }

        CardDeck = list;
    }

    public void Shuffle()
    {
        System.Random random = new System.Random();
        var n = CardDeck.Count;
        while (n > 1)
        {
            n--;
            var rng = random.Next(n+1);
            var c = CardDeck[rng];
            CardDeck[rng] = CardDeck[n];
            CardDeck[n] = c;
        }
    }

    public Card GetTopDeck()
    {
        var c = CardDeck[CardDeck.Count - 1];
        CardDeck.RemoveAt(CardDeck.Count - 1);
        return c;
    }

    public bool RemoveCard(Card card)
    {
        foreach (var c in CardDeck)
        {
            if (c.InitialPower != card.InitialPower) continue;
            if (c.CardSuit != card.CardSuit) continue;
            CardDeck.Remove(c);
            return true;
        }
        return false;
    }
}
