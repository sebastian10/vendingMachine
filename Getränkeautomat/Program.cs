using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getränkeautomat
{
    class Program
    {
        // Bevarages
        static string[,] beverages = new string[4, 3] {
            { "32", "Cola", "1,00" },
            { "42", "Mineralwasser", "0,90" },
            { "48", "Red Bull", "2,50" },
            { "60", "Leitungswasser", "0,10" }
        };

        // Coins
        static double[] coins = new double[5] { 0.10, 0.20, 0.50, 1.00, 2.00 };


        static void Main(string[] args)
        {
            vendingMachine();

            Console.ReadKey();
        }

        static void vendingMachine()
        {
            Console.WriteLine( "Willkommen! Bitte wähle ein Getränk!" );
            Console.WriteLine();

            string tab = "\t";

            for ( int x = 0; x < beverages.GetLength( 0 ); x++ )
            {
                for ( int y = 0; y < beverages.GetLength(1); y++ )
                {
                    if ( beverages[x, y].Length < 8 && y == 1 ) tab += "\t";

                    if ( y == 2 ) Console.Write(beverages[x, y] + " Euro");
                    else Console.Write( beverages[x, y] + tab );

                    tab = "\t";
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            getInput();

        }

        static void getInput()
        {
            Console.Write( "Getränk: " );
            string num = Console.ReadLine();

            for ( int x = 0; x < beverages.GetLength(0); x++ )
            {
                if ( beverages[x, 0] == num )
                {
                    Console.WriteLine( "Dein ausgewähltes Getränk: {0} \n", beverages[x, 1] );
                    

                    pay( beverages[x, 1], Convert.ToDouble( beverages[x, 2] ) );
                    return;
                }
            }

            backToStart();
        }

        static void pay( string name, double price )
        {
            double received = 0;

            while (received < price)
            {
                Console.Write( "Bitte {0:0.00} Euro einwerfen! ", price );

                try
                {
                    double number = Convert.ToDouble(Console.ReadLine());

                    if ( !coins.Contains(number) ) throw new Exception();

                    price -= number;

                }
                catch
                {
                    Console.WriteLine("Es werden nur Münzen akzeptiert!");
                }
            }

            Console.WriteLine("\nRestgeld: {0:0.00} Euro", price * -1);
            Console.WriteLine("\nVielen Dank! Lass dir dein {0} gut schmecken!", name);
        }

        static void backToStart()
        {
            Console.Clear();
            Console.WriteLine("Falsche Eingabe!");
            vendingMachine();
        }
    }
}
