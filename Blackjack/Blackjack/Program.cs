using System;
 
namespace Blackjack
{
    class Blackjack
    {
        static string[] playerCards = new string[11];
        static string hitOrStay = "";
        static int total = 0, count = 1, dealerTotal = 0;
        static Random cardRandomizer = new Random();
 
        static void Main(string[] args)
        {
            Console.Title = "BLACKJACK!!!";
            Start();
        }
 
        static void Start()
        {
            
            dealerTotal = cardRandomizer.Next(16, 22);
            playerCards[0] = Deal();
            playerCards[1] = Deal();
            do
            {
                Console.WriteLine("Welcome to Blackjack! You were dealt " + playerCards[0] + " and " + playerCards[1] + ". \nYour total is " + total + "." +
                    "\nDealer has " + dealerTotal + "\nWould you like to (h)hit or (s)stay?");
                hitOrStay = Console.ReadLine().ToLower();
            } while (!hitOrStay.Equals("h") && !hitOrStay.Equals("s"));
            Game();
        }
 
        static void Game()
        {
            if (hitOrStay.Equals("h"))
            {
                Hit();
            }
            else if (hitOrStay.Equals("s"))
            {
                if (total > dealerTotal && total <= 21)
                {
                    Console.WriteLine("\nCongrats! YOU WIN! The dealer's total is " + dealerTotal + ".\nWould you like to test your luck again? y/n");
                    PlayAgain();
                }
                else if (total<dealerTotal)
                {
                    Console.WriteLine("\nYOU LOSE! The dealer's total is " + dealerTotal + ".\nWould you like to test your luck again? y/n");
                    PlayAgain();
                }
 
            }
            Console.ReadLine();
        }
 
        static string Deal()
        {
            string Card = "";
            int cards = cardRandomizer.Next(1, 14);
            switch (cards)
            {
                case 1: Card = "Two"; total += 2;
                    break;
                case 2: Card = "Three"; total += 3;
                    break;
                case 3: Card = "Four"; total += 4;
                    break;
                case 4: Card = "Five"; total += 5;
                    break;
                case 5: Card = "Six"; total += 6;
                    break;
                case 6: Card = "Seven"; total += 7;
                    break;
                case 7: Card = "Eight"; total += 8;

                    break;

                case 8: Card = "Nine"; total += 9;
                    break;
                case 9: Card = "Ten"; total += 10;
                    break;
                case 10: Card = "Jack"; total += 10;
                    break;
                case 11: Card = "Queen"; total += 10;
                    break;
                case 12: Card = "King"; total += 10;
                    break;
                case 13: Card = "Ace"; total += 11;
                    break;
                default: Card = "2"; total += 2;
                    break;
            }
            return Card;
        }
        static void Hit()

        {

            count += 1;

            playerCards[count] = Deal();

            Console.WriteLine("\nYou were dealt a(n) " + playerCards[count] + ".\nYour new total is " + total + ".");

            if (total.Equals(21))

            {

                Console.WriteLine("\nBLACKJACK! The dealer's total is " + dealerTotal + ".\nWould you like to play again?");

                PlayAgain();

            }
            else if (total > 21)
            {
                Console.WriteLine("\nBUST YOU LOSE! The dealer's total is " + dealerTotal + ".\nWould you like to play again? y/n");
                PlayAgain();
            }
            else if (total< 21)
            {
                do
                {
                    Console.WriteLine("\nWould you like to hit or stay?");
                    hitOrStay = Console.ReadLine().ToLower();
                } while (!hitOrStay.Equals("h") && !hitOrStay.Equals("s"));
                Game();
            }
        }
 
        static void PlayAgain()
        {
            string playAgain = "";
            do
            {
                playAgain = Console.ReadLine().ToLower();
            } while (!playAgain.Equals("y") && !playAgain.Equals("n"));
            if (playAgain.Equals("y"))
            {
                Console.WriteLine("\nPress enter to restart the game!");
                Console.ReadLine();
                Console.Clear();
                dealerTotal = 0;
                count = 1;
                total = 0;
                Start();
            }
            else if (playAgain.Equals("n"))
            {
                Console.WriteLine("\nPress enter to close Blackjack.");
                Console.ReadLine();
                Environment.Exit(0);
            }
        
        }
    }
}
