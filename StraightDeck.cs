namespace Deck{

        //  Depends on:
        //      Classes:            found in
        //          Card            Card.cs
        //          Random          System class
        //          
        //      Enums:
        //          Ranks           DeckNamespaceBase.cs
        //          Suits           DeckNamespaceBase.cs
            public class StraightDeck{
        
        public List<Card> Shuffled = [];
        public List<Card> Unshuffled = [
            new Card(Ranks.A, Suits.Clubs),
            new Card(Ranks.Two, Suits.Clubs),
            new Card(Ranks.Three, Suits.Clubs),
            new Card(Ranks.Four, Suits.Clubs),
            new Card(Ranks.Five, Suits.Clubs),
            new Card(Ranks.Six, Suits.Clubs),
            new Card(Ranks.Seven, Suits.Clubs),
            new Card(Ranks.Eight, Suits.Clubs),
            new Card(Ranks.Nine, Suits.Clubs),
            new Card(Ranks.Ten, Suits.Clubs),
            new Card(Ranks.J, Suits.Clubs),
            new Card(Ranks.Q, Suits.Clubs),
            new Card(Ranks.K, Suits.Clubs),

            new Card(Ranks.A, Suits.Diamonds),
            new Card(Ranks.Two, Suits.Diamonds),
            new Card(Ranks.Three, Suits.Diamonds),
            new Card(Ranks.Four, Suits.Diamonds),
            new Card(Ranks.Five, Suits.Diamonds),
            new Card(Ranks.Six, Suits.Diamonds),
            new Card(Ranks.Seven, Suits.Diamonds),
            new Card(Ranks.Eight, Suits.Diamonds),
            new Card(Ranks.Nine, Suits.Diamonds),
            new Card(Ranks.Ten, Suits.Diamonds),
            new Card(Ranks.J, Suits.Diamonds),
            new Card(Ranks.Q, Suits.Diamonds),
            new Card(Ranks.K, Suits.Diamonds),

            new Card(Ranks.A, Suits.Hearts),
            new Card(Ranks.Two, Suits.Hearts),
            new Card(Ranks.Three, Suits.Hearts),
            new Card(Ranks.Four, Suits.Hearts),
            new Card(Ranks.Five, Suits.Hearts),
            new Card(Ranks.Six, Suits.Hearts),
            new Card(Ranks.Seven, Suits.Hearts),
            new Card(Ranks.Eight, Suits.Hearts),
            new Card(Ranks.Nine, Suits.Hearts),
            new Card(Ranks.Ten, Suits.Hearts),
            new Card(Ranks.J, Suits.Hearts),
            new Card(Ranks.Q, Suits.Hearts),
            new Card(Ranks.K, Suits.Hearts),
            
            new Card(Ranks.A, Suits.Spades),
            new Card(Ranks.Two, Suits.Spades),
            new Card(Ranks.Three, Suits.Spades),
            new Card(Ranks.Four, Suits.Spades),
            new Card(Ranks.Five, Suits.Spades),
            new Card(Ranks.Six, Suits.Spades),
            new Card(Ranks.Seven, Suits.Spades),
            new Card(Ranks.Eight, Suits.Spades),
            new Card(Ranks.Nine, Suits.Spades),
            new Card(Ranks.Ten, Suits.Spades),
            new Card(Ranks.J, Suits.Spades),
            new Card(Ranks.Q, Suits.Spades),
            new Card(Ranks.K, Suits.Spades),
            

        ];

        public StraightDeck(){
            Reshuffle();
            
        }

        public void Reshuffle(){
            Random rnd = new Random();
            List<Card> tempDeck = [];
            foreach(Card newCard in Unshuffled) tempDeck.Add(newCard);
            while(tempDeck.Count > 0){
                int cardIndex = rnd.Next(0,tempDeck.Count);
                Shuffled.Add(tempDeck[cardIndex]);
                tempDeck.Remove(tempDeck[cardIndex]);
            }

        }

        public Card? Deal(){
            if(Shuffled.Count == 0) return null;
            else{
                Card result = Shuffled[0];
                Shuffled.Remove(Shuffled[0]);
                return result;
            }            
        }
    }


}