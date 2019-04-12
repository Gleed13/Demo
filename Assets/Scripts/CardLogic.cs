using Enum;

public static class CardLogic
{
    
    public static bool CanAttack(Card attacker, Card defender)
    {
        Suit sA = attacker.CardSuit;
        Suit sD = defender.CardSuit;
        
        int iA = attacker.InitialPower;
        int iD = defender.InitialPower;
        
        switch (sA)
        {
            case Suit.Heart:
                if (sD == Suit.Club) return true;
                else if (sD == Suit.Spade) return false;
                break;
            case Suit.Diamond:
                if (sD == Suit.Spade) return true;
                else if (sD == Suit.Club) return false;
                break;
            case Suit.Club:
                if (sD == Suit.Diamond) return true;
                else if (sD == Suit.Heart) return false;
                break;
            case Suit.Spade:
                if (sD == Suit.Heart) return true;
                else if (sD == Suit.Diamond) return false;
                break;
        }
        
        if (iA == 1 && iD == 15) return true;
        if (iA == 15 && iD == 1) return false;
        
        return iA > iD;
    }
}