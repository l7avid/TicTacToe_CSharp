namespace TicTacToe
{
    internal class Program
    {

        //The playfield
        static char[,] playField =
        {
            {'1', '2', '3' },
            {'4', '5', '6' },
            {'7', '8', '9' }
        };

        static int turns = 0;

        static void Main(string[] args)
        {
            int player = 2; //player 1
            int input = 0;
            bool isInputCorrect = true;

            do
            {
                if(player == 2)
                {
                    player = 1;
                    EnterXorO(input, 'X');
                }
                else if(player == 1)
                {
                    player = 2;
                    EnterXorO(input, 'O');
                }

                SetField();

                #region
                //Check winning condition
                char[] playerChars = { 'X', 'O' };

                foreach(char playerChar in playerChars)
                {
                    if (((playField[0,0] == playerChar) && (playField[0,1] == playerChar) && (playField[0,2] == playerChar)) //horizontal
                        || ((playField[1, 0] == playerChar) && (playField[1, 1] == playerChar) && (playField[1, 2] == playerChar)) //horizontal
                        || ((playField[2, 0] == playerChar) && (playField[2, 1] == playerChar) && (playField[2, 2] == playerChar)) //horizontal
                        || ((playField[0, 0] == playerChar) && (playField[1, 0] == playerChar) && (playField[2, 0] == playerChar)) //vertical
                        || ((playField[0, 1] == playerChar) && (playField[1, 1] == playerChar) && (playField[2, 1] == playerChar)) //vertical
                        || ((playField[0, 2] == playerChar) && (playField[1, 2] == playerChar) && (playField[2, 2] == playerChar)) //vertical
                        || ((playField[0, 0] == playerChar) && (playField[1, 1] == playerChar) && (playField[2, 2] == playerChar)) //diagonal
                        || ((playField[0, 2] == playerChar) && (playField[1, 1] == playerChar) && (playField[2, 0] == playerChar))) //diagonal
                    {
                        if(playerChar == 'O')
                        {
                            Console.WriteLine("\nPlayer 1 is the winner!");
                        }
                        else
                        {
                            Console.WriteLine("\nPlayer 2 is the winner!");
                        }

                        Console.WriteLine("\nPlease press any key to reset the game!");
                        Console.ReadKey();
                        player = 1;
                        ResetField();
                        break;
                    }
                    else if(turns == 10)
                    {
                        Console.WriteLine("Draw!\n");
                        Console.WriteLine("Please press any key to reset the game");
                        Console.ReadKey();
                        player = 1;
                        ResetField();
                        break;
                    }
                }

                #endregion

                #region
                //test if field is already taken
                do
                {
                    Console.WriteLine($"\nPlayer {player}: Choose your field!\n");
                    try
                    {
                        input = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("\nPlease enter a number!");
                    }

                    if((input == 1 && (playField[0,0] == '1')))
                    {
                        isInputCorrect = true;
                    }
                    else if ((input == 2 && (playField[0, 1] == '2')))
                    {
                        isInputCorrect = true;
                    }
                    else if ((input == 3 && (playField[0, 2] == '3')))
                    {
                        isInputCorrect = true;
                    }
                    else if ((input == 4 && (playField[1, 0] == '4')))
                    {
                        isInputCorrect = true;
                    }
                    else if ((input == 5 && (playField[1, 1] == '5')))
                    {
                        isInputCorrect = true;
                    }
                    else if ((input == 6 && (playField[1, 2] == '6')))
                    {
                        isInputCorrect = true;
                    }
                    else if ((input == 7 && (playField[2, 0] == '7')))
                    {
                        isInputCorrect = true;
                    }
                    else if ((input == 8 && (playField[2, 1] == '8')))
                    {
                        isInputCorrect = true;
                    }
                    else if ((input == 9 && (playField[2, 2] == '9')))
                    {
                        isInputCorrect = true;
                    }
                    else
                    {
                        Console.WriteLine("\nIncorrect input, please use another field!");
                        isInputCorrect= false;
                    }
                } while(!isInputCorrect);

                #endregion

            } while (true);
        }

        public static void ResetField()
        {
            char[,] initialPlayField =
            {
                {'1', '2', '3' },
                {'4', '5', '6' },
                {'7', '8', '9' }
            };

            playField = initialPlayField;
            SetField();
            turns = 0;
        }

        public static void SetField()
        {
            Console.Clear();
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", playField[0,0], playField[0,1], playField[0,2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", playField[1, 0], playField[1, 1], playField[1, 2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", playField[2, 0], playField[2, 1], playField[2, 2]);
            Console.WriteLine("     |     |     ");
            turns++;
        }

        public static void EnterXorO(int input, char playerSign)
        {

            switch (input)
            {
                case 1:
                    playField[0, 0] = playerSign; break;
                case 2:
                    playField[0, 1] = playerSign; break;
                case 3:
                    playField[0, 2] = playerSign; break;
                case 4:
                    playField[1, 0] = playerSign; break;
                case 5:
                    playField[1, 1] = playerSign; break;
                case 6:
                    playField[1, 2] = playerSign; break;
                case 7:
                    playField[2, 0] = playerSign; break;
                case 8:
                    playField[2, 1] = playerSign; break;
                case 9:
                    playField[2, 2] = playerSign; break;
            }
        }
    }
}