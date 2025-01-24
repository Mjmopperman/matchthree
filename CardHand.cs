namespace Deck
{
       public class CardHand{

        public int Score = 0;
        public List<Card> InHand = new();

        public void PrintCardInHandOptions(){
            int Option = 1;
            Console.WriteLine("Avaible cards to play: ");
            foreach(Card card in InHand){
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("["+Option.ToString()+"] ");
                card.PrintStyledCard();
                Console.Write("   ");
                Option++;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("");
        }

        public void AddCard(StraightDeck deck){
            Card? tempCard = deck.Deal();
            if(tempCard != null) InHand.Add(tempCard);        
        }
        
        public int GetValidCardOption(){
            
            
            while(true){
                string UserInput = Console.ReadLine();
                if(CheckInteger(UserInput)){
                    int Result = int.Parse(UserInput)-1;
                    if(Result > -1 && Result < InHand.Count) return Result;

                }
                Console.Write("Invalid option. Please try again?");
                PrintCardInHandOptions();

            }
            return -1;


        }

         public bool CheckInteger(string InputString){
            return int.TryParse(InputString,out int OutValue);
        }




    }

}