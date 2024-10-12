using System;
using System.Collections.Generic;
namespace CardWar
{
    internal class Program
    {
        static int round = 0;
        static List<string> values = new List<string>() { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"};
        static Queue<string> deck1 = new Queue<string>();
        static Queue<string> deck2 = new Queue<string>();
        public static void GenerateDecks()
        {
            string currentCard;
            Random r = new Random();
            int length = r.Next(1, 52);
            for (int i = 0; i < length; i++)
            {
                if (values.Count == 1)
                {
                    deck1.Enqueue(values[0]);
                    break;
                }
                currentCard = values[r.Next(0, values.Count)];
                deck1.Enqueue(currentCard);
                values.Remove(currentCard);
            }
            //deck2.Enqueue("A");
            while (values.Count > 0)
            {
                if (values.Count == 1)
                {
                    deck2.Enqueue(values[0]);
                    break;
                }
                currentCard = values[r.Next(0, values.Count)];
                deck2.Enqueue(currentCard);
                values.Remove(currentCard);
            }

            Print();

            Console.WriteLine(deck1.Count);
            Console.WriteLine(deck2.Count);
        }
        public static void GenerateGame()
        {
            string a, b, a3, b3;
            values = new List<string>() { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            List<string> list = new List<string>();
        Initiation:
            {
                round++;
                while (deck1.Count > 0 && deck2.Count > 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Round {0}", round);
                    a = deck1.Dequeue();
                    b = deck2.Dequeue();
                    if (values.IndexOf(a) > values.IndexOf(b))
                    {
                        //deck1.Enqueue(a);
                        //deck1.Enqueue(b);
                        EnqueeRandom(a, b, deck1);
                        Console.WriteLine("{0} - {1}", a, b);
                        Print();
                    }
                    else if (values.IndexOf(a) < values.IndexOf(b))
                    {
                        //deck2.Enqueue(b);
                        //deck2.Enqueue(a);
                        EnqueeRandom(a, b, deck2);
                        Console.WriteLine("{0} - {1}", a, b);
                        Print();
                    }
                    else
                    {
                        Console.WriteLine("WAR!!!");

                        //Equal cards
                        list.Add(a);
                        list.Add(b);
                        Console.WriteLine("{0} - {1}", a, b);
                        Print();

                        if (deck1.Count == 0)
                        {
                            Console.WriteLine("The following hand goes to Player 1:");
                            Console.WriteLine(string.Join(", ", list));
                            ListEnqueeRandom(list, deck1);
                            Print();
                            goto Initiation;
                        }
                        else if (deck2.Count == 0)
                        {
                            Console.WriteLine("The following hand goes to Player 2:");
                            Console.WriteLine(string.Join(", ", list));
                            ListEnqueeRandom(list, deck2);
                            Print();
                            goto Initiation;
                        }

                        if (deck1.Count >= 3 && deck2.Count >= 3)
                        {
                            while (deck1.Count >= 3 && deck2.Count >= 3)
                            {
                                Console.WriteLine("War cards:");

                                //First pair war cards
                                a3 = deck1.Dequeue();
                                b3 = deck2.Dequeue();
                                Console.WriteLine("{0} - {1}", a3, b3);
                                list.Add(a3);
                                list.Add(b3);

                                //Second pair war cards
                                a3 = deck1.Dequeue();
                                b3 = deck2.Dequeue();
                                Console.WriteLine("{0} - {1}", a3, b3);
                                list.Add(a3);
                                list.Add(b3);

                                //Third pair war cards - !!!
                                Console.WriteLine("Duel cards:");
                                a3 = deck1.Dequeue();
                                b3 = deck2.Dequeue();
                                list.Add(a3);
                                list.Add(b3);
                                Console.WriteLine("{0} - {1}", a3, b3);

                                if (values.IndexOf(a3) > values.IndexOf(b3))
                                {
                                    Console.WriteLine("The following hand goes to Player 1:");
                                    Console.WriteLine(string.Join(", ", list));
                                    ListEnqueeRandom(list, deck1);
                                    Print();
                                    Console.WriteLine();
                                    goto Initiation;
                                }
                                else if (values.IndexOf(a3) < values.IndexOf(b3))
                                {
                                    Console.WriteLine("The following hand goes to Player 2:");
                                    Console.WriteLine(string.Join(", ", list));
                                    ListEnqueeRandom(list, deck2);
                                    Print();
                                    Console.WriteLine();
                                    goto Initiation;
                                }
                                //If even the last pair of cards are the same, we favour the underdog.
                                else
                                {
                                    if (deck1.Count < 3 || deck2.Count < 3)
                                    {
                                        goto EqCardsLessThanThree;
                                    }
                                    else
                                    {
                                        Console.WriteLine("ONCE AGAIN WAR!!!");
                                        continue;
                                    }
                                }
                            }
                        }
                        else
                            goto EqCardsLessThanThree;

                        //When in one of the decks there are <3 cards left
                        EqCardsLessThanThree:
                        {
                            while (deck1.Count > 0 && deck2.Count > 0)
                            {
                                //Third pair war cards - !!!
                                Console.WriteLine("Duel cards:");
                                a3 = deck1.Dequeue();
                                b3 = deck2.Dequeue();
                                list.Add(a3);
                                list.Add(b3);
                                Console.WriteLine("{0} - {1}", a3, b3);

                                if (values.IndexOf(a3) > values.IndexOf(b3))
                                {
                                    Console.WriteLine("The following hand goes to Player 1:");
                                    Console.WriteLine(string.Join(", ", list));
                                    ListEnqueeRandom(list, deck1);
                                    Print();
                                    goto Initiation;
                                }
                                else if (values.IndexOf(a3) < values.IndexOf(b3))
                                {
                                    Console.WriteLine("The following hand goes to Player 2:");
                                    Console.WriteLine(string.Join(", ", list));
                                    ListEnqueeRandom(list, deck2);
                                    Print();
                                    goto Initiation;
                                }
                                //If even the last pair of cards are the same, we favour the empty deck.
                                else if (deck1.Count == 0 || deck2.Count == 0)
                                {
                                    goto LastCardsEqual;
                                }
                                else
                                {
                                    Console.WriteLine("ONCE AGAIN WAR!!!");
                                    continue;
                                }
                            }

                        LastCardsEqual:
                            {
                                Console.WriteLine("ONCE AGAIN WAR!!!");
                                if (deck1.Count == 0)
                                {
                                    Console.WriteLine("The following hand goes to Player 1:");
                                    Console.WriteLine(string.Join(", ", list));
                                    ListEnqueeRandom(list, deck1);
                                    Print();
                                    goto Initiation;
                                }
                                else if (deck2.Count == 0)
                                {
                                    Console.WriteLine("The following hand goes to Player 2:");
                                    Console.WriteLine(string.Join(", ", list));
                                    ListEnqueeRandom(list, deck2);
                                    Print();
                                    goto Initiation;
                                }
                            }
                        }
                    }
                    round++;
                }

            Termination:
                {
                    if (deck1.Count == 0)
                    {
                        Console.WriteLine("Player 2 wins!");
                        Console.WriteLine(deck2.Count);
                        return;
                    }
                    if (deck2.Count == 0)
                    {
                        Console.WriteLine("Player 1 wins!");
                        Console.WriteLine(deck1.Count);
                        return;
                    }
                }
            }
        }
        private static void Print()
        {
            Console.WriteLine();
            Console.WriteLine("Deck 1: {0}", string.Join(", ", deck1));
            Console.WriteLine("Deck 2: {0}", string.Join(", ", deck2));
            Console.WriteLine();
        }
        private static void ListEnqueeRandom(List<string> s, Queue<string> q)
        {
            string currentValue;
            Random r = new Random();
            while(s.Count > 0)
            {
                currentValue=s[r.Next(0, s.Count)];
                q.Enqueue(currentValue);
                s.Remove(currentValue);
            }
        }
        private static void EnqueeRandom(string a, string b, Queue<string> q)
        {
            List<string> l = new List<string>(){a,b};
            Random r = new Random();
            string helper = l[r.Next(0, 2)];
            l.Remove(helper);
            q.Enqueue(helper);
            q.Enqueue(l[0]);
        }
        private static void ListEnquee(List<string> s, Queue<string> q)
        {
            foreach (string a in s)
            {
                q.Enqueue(a);
            }
            s.Clear();
        }
        static void Main(string[] args)
        {
           GenerateDecks();
           Console.ReadKey(true);
           GenerateGame();
           Console.WriteLine("Hello World!");
        }
    }
}