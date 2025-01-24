using System.Threading.Tasks.Dataflow;

namespace Deck
{
       public class Combination{       
        
        public int Score = 0;
        public Card CardPlayed {get; set;}        
        public int GridPos = -1;
        public bool AlreadyScored = false;
        public bool ComboActive = false;
        public List<Card?> GridAtPresent = [];
        public List<bool> curEmptySpaces  = [];
        public List<Card> tempGrid = [];


        public Combination(Card inputCard, int inputGridPos, CardGrid inputGrid){
            CardPlayed = inputCard;
            GridPos = inputGridPos;
            
            foreach(Card card in inputGrid.CardSpaces) GridAtPresent.Add(card);
            foreach(bool space in inputGrid.EmptySpaces) curEmptySpaces.Add(space);
            GridAtPresent[inputGridPos] = CardPlayed;

            for(int combo=0; combo<10; combo++){               
                if(inputGrid.PositionCombos[inputGridPos,combo]){
                    int combPos1 = GridPos+inputGrid.MasterCombos[combo,0];
                    int combPos2 = GridPos+inputGrid.MasterCombos[combo,1];
                    int combPos3 = GridPos+inputGrid.MasterCombos[combo,2];

                 
                    
                    if(!curEmptySpaces[combPos1] && !curEmptySpaces[combPos2] && !curEmptySpaces[combPos3])
                    {
                        Card c1 = GridAtPresent[combPos1];
                        Card c2 = GridAtPresent[combPos2];
                        Card c3 = GridAtPresent[combPos3];
                        Console.WriteLine(c1.CardString+c2.CardString+c3.CardString);
                    Score += CalcCombination(c1,c2,c3);
                    }
                    
                    
                }
            }
        }


        public static int GetGridPosScore(int GridPos, CardGrid grid){
            int result = 0;
            for(int cc=0;cc<10;cc++){
                if(grid.PositionCombos[GridPos,cc]){
                    int Pos1=GridPos + grid.MasterCombos[cc,0];
                    int Pos2=GridPos + grid.MasterCombos[cc,1];
                    int Pos3=GridPos + grid.MasterCombos[cc,2];
                    if(!grid.EmptySpaces[Pos1] && !grid.EmptySpaces[Pos2] && !grid.EmptySpaces[Pos3]){
                        result+= Combination.CalcCombination(grid.CardSpaces[Pos1],grid.CardSpaces[Pos2],grid.CardSpaces[Pos3]);
                    }
                    

                }
                    
            }
           
            return result;
        }
        public static int CalcCombination(Card Card1, Card Card2, Card Card3){

            // 1 1 0
            // 1 0 1
            // 0 1 1
            int Score = 0;
            if(Card1.CardRank == Card2.CardRank && Card1.CardRank != Card3.CardRank) Score+= 10;
            if(Card1.CardRank == Card3.CardRank && Card1.CardRank != Card2.CardRank) Score+= 10;
            if(Card1.CardRank != Card2.CardRank && Card2.CardRank == Card3.CardRank) Score+= 10;

            if(Card1.CardRank == Card2.CardRank && Card2.CardRank == Card3.CardRank) Score += 100;
            if(Card1.CardSuit == Card2.CardSuit && Card2.CardSuit == Card3.CardSuit) Score += 20;
            List<string> RankList = [Card1.CardRank.ToString(), Card2.CardRank.ToString(),Card3.CardRank.ToString()];
            RankList.Sort();
            string RankString = "";
            foreach(string cRank in RankList) RankString += cRank;
            
            switch(RankString){
                case "ATwoThree":
                case "FourThreeTwo":
                case "FiveFourThree":
                case "FiveFourSix":
                case "FiveSevenSix":
                case "EightSevenSix":
                case "EightNineSeven":
                case "EightNineTen":
                case "JNineTen":
                case "JQTen":
                case "JKQ":
                case "AKQ":
                    Score += 40;
                    break;
                default:
                    break;
            }               
            return Score;
        }




    }

}