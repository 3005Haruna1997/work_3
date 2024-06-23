// блок основных переменных
string? enteredValue = "";
string? menuSelection = "";
int points = 100;
// блок вспомогательных переменных
int technicalIntValue_1 = 0;
int technicaIntlValue_2 = 0;
int technicalIntValue_3 = 0;

string techicalStringValue_1 = "-";

bool technicalBoolValue_1 = false;
bool technicalBoolValue_2 = false;
bool technicalBoolValue_3 = false;
bool technicalBoolValue_4 = false;

string[] searchingIcons = {".  ", ".. ", "...",};//для анимации

techicalStringValue_1 = string.Join("-",Enumerable.Repeat(techicalStringValue_1,35));//для пунктирной строчки 

void demarcationLine()
{
    // Разделяющая линия
    Console.WriteLine(techicalStringValue_1);
}
void backToMenu()
{
    // Метод для плавного возвращения в меню через анимацию
    for (int j = 3; j > -1 ; j--)
    {
        foreach (string icon in searchingIcons)
        {
            Console.Write($"\rBack to menu{icon}");
            Thread.Sleep(350);
        }                    
        Console.Write($"\r{new String(' ', Console.BufferWidth)}");
    }
    //techicalValue_2 = true;
}
void notEoughPoints() 
{
    // Метод сообщающий о недостатке очков для продолжения игры
    Console.WriteLine($"You have {points} points " +
                      "\nIt's not enough for the game."+
                      "\n(Press \"Enter\" to contine)");
    Console.ReadKey();                  
    //techicalValue_2 = true;
}
void IncorrectData()
{
    demarcationLine();
    Console.WriteLine("Incorrect Data. Please try again.");
    //enteredValue = Console.ReadLine();
    //enteredValueToLower();
}
void notEnterANumder()
{
    // 
    demarcationLine();
    Console.WriteLine("You didn't enter a number. "+
    "Please try again.");
    //techicalValue_2 = false;
}
void enteredValueToLower()
{
//Метод для определение введеных данных игнорирую регистр. И для устранения проблемы возможного нулевого референса.
    if (enteredValue != null)    
    {
        enteredValue = enteredValue.ToLower();
    }
}
void enteredValueToUpper()
{
    if (enteredValue != null)    
    {
        enteredValue = enteredValue.ToUpper();
    }
}
void ZeroingValueS()
{
    //Метод для возврата используемых значений в исходное состояние. 
    //Нужен для корректной работы приложения при многократном воспроизведении в рамках одного рабочего цикла.
    technicalIntValue_1 = 0;
    technicalIntValue_3 = 0;
    technicaIntlValue_2 = 0;
    technicalBoolValue_1 = false;
    technicalBoolValue_2 = false;
    technicalBoolValue_3 = false;
    enteredValue = "";
}
void tryParseEnteredValue()
{
    int a = 0;
    if (int.TryParse(enteredValue, out a) == false || enteredValue == "")
    {
        enteredValueToLower();
        technicalBoolValue_4 = false;
    }
    else 
    {
        technicaIntlValue_2 = Convert.ToInt32(enteredValue);
        technicalBoolValue_4 = true;
    }
}
do
{
    //блок стартового меню
    ZeroingValueS();
    Console.Clear();

    Console.WriteLine("Welcome to the Skillbox Work 3 app. Your main menu options are:");
    demarcationLine();
    Console.WriteLine(" 1. Task №1 Finding the party of the number");
    Console.WriteLine(" 2. Task №2 Calculate the sum of cards in the O.C.H.K.O. game");
    Console.WriteLine(" 3. Task №3 Сhecking a prime number");
    Console.WriteLine(" 4. Task №4 Сalculating the smallest number in a sequence");
    Console.WriteLine(" 5. Task #5 \"Guess the number\" game");
    demarcationLine();
    Console.WriteLine("Enter your selection number (or type \"Exit\" to exit the program)");
    
    enteredValue = Console.ReadLine();
    
    enteredValueToLower();
    
    demarcationLine();
    Console.WriteLine($"You selected menu option >{enteredValue}<.");
    demarcationLine();

    switch(enteredValue)
    {
        case "1":
            do
            {
                ZeroingValueS();
                Console.WriteLine("Please, enter a number "+
                "(or enter \"Back\" to return to the menu)");
                enteredValue = Console.ReadLine();

                enteredValueToLower();

                if (enteredValue != "")
                {
                    if ((int.TryParse(enteredValue, out technicalIntValue_1) == false) 
                    && (enteredValue != "back"))
                    {
                        notEnterANumder();
                    }

                    else if ((int.TryParse(enteredValue, out technicalIntValue_1) == false) 
                    && (enteredValue.ToLower() == "back"))
                    {
                        demarcationLine();
                        backToMenu();
                        technicalBoolValue_1 = true;
                    }

                    else if (int.TryParse(enteredValue, out technicalIntValue_1) == true)   
                    {
                        demarcationLine();
                        technicalIntValue_1 = int.Parse(enteredValue); 
                        Console.WriteLine($"You entered a number {technicalIntValue_1}");

                        if (technicalIntValue_1%2 ==0)
                        {
                            Console.WriteLine($"Number {technicalIntValue_1} is even");
                            demarcationLine();
                        }
                        
                        else
                        {
                            Console.WriteLine($"Number {technicalIntValue_1} is odd");
                            demarcationLine();
                        }    
                        technicalBoolValue_1 = false;
                    }
                }
                else
                {
                    notEnterANumder();
                }
            } while (technicalBoolValue_1 == false);
        break;
    
        case "2":
            //если мы играем в 21, то номиналы для валета(J) дамы(Q) и короля(К) равняются 2 ,3 и 4 соответственно
            //колода 36 карт
            //туз(T) = 10//  
            do
            {
                ZeroingValueS();
                Console.WriteLine
                ("Hotite li vy' sy'grat v O.C.H.K.O.? "+
                "Tapni \"Yes\" ili \"No\".");
                enteredValue = Console.ReadLine();

                enteredValueToLower();

                switch (enteredValue)
                {
                    case "yes":
                        enteredValue = "";
                        Console.WriteLine("Dobro pozhalovat' v nash kazinakich.");
                        demarcationLine();
                        //int cardSuit = 0;
                        int sumOfCards = 0; 
                        int cardValue = -1;
                        string [] acceptableValuesOfPlayingCards = {"6","7","8","9","10","J","Q","K","T"};
                        int[] CostOfCardsInPoints = {6,7,8,9,10,2,3,4,10}; // 
                        /*
                        foreach(string card in playedCards)
                        {
                            Console.Write("0");
                            //playedCards[1,1] = " 0 ";
                        }
                        */
                        //Random roll_1 = new Random();
                        //int cardSuit = roll_1.Next(1, 5);//масть
                        //int cartValue = roll_1.Next(1, 10);//значение кар;
                        do 
                        {
                            
                            Console.WriteLine("Vvedite znachenie karty");
                            enteredValue = Console.ReadLine();
                            enteredValueToUpper();
                            do 
                            {
                                cardValue = -1;//с -1 для верной работы
                                technicalBoolValue_3 = false;
                                foreach (string valueOfCard in acceptableValuesOfPlayingCards) 
                                {
                                    cardValue += 1;
                                    if(enteredValue == valueOfCard)
                                    {
                                        technicalBoolValue_3 = true;
                                        sumOfCards += CostOfCardsInPoints[cardValue];
                                        break;
                                    }   
                                }
                                if (technicalBoolValue_3 == false)
                                {
                                    //cardValue = 0;
                                    Console.WriteLine("Ty' mne vtiraech kakuetu dich'..."+
                                    "\nPoprobuy echyo raz.");
                                    demarcationLine();
                                    enteredValue = Console.ReadLine();
                                    enteredValueToUpper();     
                                }
                            } while (technicalBoolValue_3 == false);
                            Console.WriteLine ("Karta prinyata."+
                            $"\nStoimost' karty' v ochkach :{CostOfCardsInPoints[cardValue]}"+
                            $"\nSumma vachy'x kart :{sumOfCards}");
                            demarcationLine();
                            if (sumOfCards == 21)
                            {
                                Console.WriteLine("Pozdravlyayu ty' pobedil.");
                                demarcationLine();
                                technicalBoolValue_2 = true;
                            }
                            else if (sumOfCards > 21)
                            {
                                Console.WriteLine("Ne povezlo");
                                demarcationLine();
                                technicalBoolValue_2 = true;
                            }
                        } while (technicalBoolValue_2 == false);
                    break;

                    case "no":
                        Console.WriteLine("Nu i zrya.");
                        backToMenu();
                        technicalBoolValue_1 = true;
                    break;

                    default:
                        Console.WriteLine("Napishi po chelovecheski !!1!");
                        demarcationLine();
                    break;
                }
            } while (technicalBoolValue_1 == false);
        break;

        case "3":
            do {            
                ZeroingValueS();
                enteredValue = "";
                Console.WriteLine("Please, enter a number "+
                "(or enter \"Back\" to return to the menu)");
                enteredValue = Console.ReadLine();
                
                enteredValueToLower();

                if (enteredValue != "")
                {
                    if ((int.TryParse(enteredValue, out technicalIntValue_1) == false) 
                    && (enteredValue != "back"))
                    {
                        notEnterANumder();
                    }

                    else if ((int.TryParse(enteredValue, out technicalIntValue_1) == false) 
                    && (enteredValue == "back"))
                    {
                        demarcationLine();
                        backToMenu();
                        technicalBoolValue_1 = true;
                    }

                    else if (int.TryParse(enteredValue, out technicalIntValue_1) == true)   
                    {
                        demarcationLine();
                        technicalIntValue_1 = int.Parse(enteredValue); 
                        Console.WriteLine($"You entered a number {technicalIntValue_1}");

                        do 
                        {
                            if (technicalIntValue_1 == 0 || technicalIntValue_1 == 1) 
                            {
                                Console.WriteLine("It is impossible to determine whether a given number is prime or not.");
                                break;
                            }
                            else 
                            {

                                do {
                                    for (int i = 1; i < technicalIntValue_1-1; i++)
                                    {
                                        if (technicalIntValue_1%(i+1) == 0)
                                        {
                                            technicalBoolValue_3 = true;
                                            break;
                                        }
                                    }
                                    if ((technicalBoolValue_3 == true) || (technicalIntValue_1 < 0) ) 
                                    {
                                        Console.WriteLine($"{technicalIntValue_1} - not a simple number.");
                                        technicalBoolValue_2 = true;
                                    }
                                    else if (technicalBoolValue_3 == false)
                                    {
                                        Console.WriteLine($"{technicalIntValue_1} - is a simple number");
                                        technicalBoolValue_2 = true;
                                    }
                                } while (technicalBoolValue_2 == false);
                            }
                        } while (technicalBoolValue_2 == false);  
                    }
                }
                else
                {
                    notEnterANumder();
                }
            } while (technicalBoolValue_1 == false);

            //Console.WriteLine("Please enter the length of the sequence");
            //Console.ReadKey();
        break;

        case "4":
            do
            {
                ZeroingValueS();
                Console.WriteLine("Please enter the length of the sequence," +
                " or enter \"Back\" to return to the menu");
                enteredValue = Console.ReadLine();

                enteredValueToLower();

                if (enteredValue != "")
                {
                    if ((int.TryParse(enteredValue, out technicalIntValue_1) == false) 
                    && (enteredValue != "back"))
                        {
                            notEnterANumder();
                        }
                    else if ((int.TryParse(enteredValue, out technicalIntValue_1) == false) 
                    && (enteredValue == "back"))
                        {
                            demarcationLine();
                            backToMenu();
                            technicalBoolValue_1 = true;
                        }    
                    else 
                    {
                        technicalIntValue_3 = int.Parse(enteredValue); 
                        int [] sequenceLength = new int [technicalIntValue_1];    

                        for (int i = 0;  i < technicalIntValue_3; i++)
                        {                            
                            Console.WriteLine($"Enter number № {i+1}");
                            enteredValue = Console.ReadLine();
                            do
                            {
                                if ((enteredValue != "") && (int.TryParse(enteredValue, out technicalIntValue_1) == true))
                                {
                                    sequenceLength[i] = int.Parse(enteredValue);
                                    technicalBoolValue_2 = true;
                                }
                                else
                                {
                                    while ((enteredValue == "") || (int.TryParse(enteredValue, out technicalIntValue_1) == false))
                                    {
                                        notEnterANumder();
                                        Console.WriteLine($"Enter number № {i+1}");
                                        enteredValue = Console.ReadLine();
                                    }
                                    sequenceLength[i] = int.Parse(enteredValue);
                                    technicalBoolValue_2 = true;
                                }
                            } while (technicalBoolValue_2 == false);          
                        }

                        Array.Sort(sequenceLength);
                        Console.Write("The sorted sequence: ");

                        foreach (int sequence in sequenceLength)
                        {
                            Console.Write(sequence + ", ");
                        }
                        
                        Console.WriteLine($"\nMinimum value in the sequence: {sequenceLength[0]}");
                        demarcationLine();
                    }   
                }
                else
                {
                    notEnterANumder();
                }
            } while (technicalBoolValue_1 == false);    
            //enteredValue = "";
        break;

        case "5":

        do
        {
            ZeroingValueS();
            Console.WriteLine("Welcome to the \"Guess the number\" game." + 
            $"\nYou have {points} points");
            demarcationLine();
            Console.WriteLine("We have three variants to play the game"+
                             "\n\t 1. (1/3) Three numbers, one try - Cost 15 points with 60 prize points." +
                             "\n\t 2. (2/5) Fife numbers, two  try's - Cost 25 points with 50 prize points." +
                             "\n\t 3. (100/100) One hundred numbers with one hundred try's - Cost 80 points"+
                             "\n\t The prize points ranges from 200 to 10 depending on the number of your attempts.");
            demarcationLine();                  
            Console.WriteLine("Choose your play option, or enter \"Back\" to return to the menu");

            menuSelection = Console.ReadLine();
            if (menuSelection != null)       
            {
                menuSelection = menuSelection.ToLower();
            }
            //enteredValueToLower();

            Console.WriteLine($"You selected game option {menuSelection}.");

            do
            {
                switch (menuSelection)
                {
                    
                    case "1":
                    
                    ZeroingValueS();

                    if (points <16)
                    {
                        notEoughPoints();
                        technicalBoolValue_2 = true;
                    }

                    else
                    {   
                        Console.WriteLine("Guess the number from \"1\" to \"3\"" + 
                        "or enter \"Back\" to return to the game menu");
                        demarcationLine();
                        points -= 15;
                        Random dice_1 = new Random();
                        int roll_1 = dice_1.Next(1, 4);
                        enteredValue = Console.ReadLine();

                        enteredValueToLower();
                        
                        do 
                        {
                            if(int.TryParse(enteredValue, out technicalIntValue_1) == true)
                            {
                                technicalIntValue_1 = Convert.ToInt32(enteredValue);
                                if (roll_1 == technicalIntValue_1)
                                {
                                    points +=60;
                                    Console.WriteLine(">>>You win !<<<" + 
                                    $"\nCurrent point's: {points}"+
                                    "\n(Press \"Enter\" to contine)");
                                    Console.ReadKey();
                                    technicalBoolValue_2 = true;
                                    break;
                                }
                                else 
                                {
                                    Console.WriteLine(">>>You Lose !<<<" +
                                    $"\nCurrent point's: {points}"+
                                    "\n(Press \"Enter\" to contine)");
                                    Console.ReadKey();
                                    technicalBoolValue_2 = true;
                                    break;
                                }
                            }
                            
                            else if (enteredValue == "back") 
                            {
                                technicalBoolValue_2 = true;
                                points +=15;
                            }
                            
                            else
                            {
                                IncorrectData();
                                enteredValue = Console.ReadLine();
                            }
                        } while(technicalBoolValue_2 == false); 
                    }   
                    break;
                        
                    case "2":

                    ZeroingValueS();

                    if (points < 26)
                    {
                        notEoughPoints();
                        technicalBoolValue_2 = true;
                    }
                    else 
                    {
                        Console.WriteLine("Guess the number from \"1\" to \"5\"" + 
                        "or enter \"Back\" to return to the game menu");
                        demarcationLine();
                        points -= 25;
                        Random dice_2 = new Random();
                        int roll_2 = dice_2.Next(1, 6);
                        technicalIntValue_3 = 2 ;

                        do 
                        {
                            enteredValue = Console.ReadLine();
                            tryParseEnteredValue();
                                
                            switch (technicalBoolValue_4)
                            {
                                case (true):
                                if (technicaIntlValue_2 == roll_2)
                                {
                                    points +=50;
                                    Console.WriteLine(">>>You win !<<<" + 
                                    $"\nCurrent point's: {points}"+
                                    "\n(Press \"Enter\" to contine)");
                                    Console.ReadKey();
                                    technicalBoolValue_2 = true;   
                                }
                                else
                                {
                                    
                                    if (technicalIntValue_1 < 1)
                                        for (int i = 0; i < 1; i++)
                                        {
                                            Console.WriteLine("Wrong answer, you have one more try.");
                                            technicalIntValue_1 +=1;    
                                        }
                                    else
                                    {
                                        Console.WriteLine(">>>You Lose !<<<" +
                                        $"\nCurrent point's: {points}"+
                                        "\n(Press \"Enter\" to contine)");
                                        Console.ReadKey();
                                        technicalBoolValue_2 = true;
                                    }                              
                                }
                                break;
                                
                                case (false):
                                if (enteredValue == "back")
                                {
                                    points +=25;
                                    technicalBoolValue_2 = true;
                                    backToMenu();
                                }
                                else
                                {
                                    IncorrectData();
                                }
                                break;
                            }
                            
                        } while (technicalBoolValue_2 == false);
                    }
                    
                    
                    break;
                    
                    case "3":

                    ZeroingValueS();

                    if (points <36)
                    {
                        notEoughPoints();
                        technicalBoolValue_2 = true;
                    }

                    else 
                    {
                        Console.WriteLine("Guess the number from \"1\" to \"100\"");
                        demarcationLine();
                        technicalIntValue_3 = 1;
                        int prizePoints = 210;
                        points -= 80;
                        Random dice_3 = new Random();
                        int roll_3 = dice_3.Next(1, 101);

                        do
                        {
                            enteredValue = Console.ReadLine();
                            tryParseEnteredValue();

                            switch(technicalBoolValue_4)
                            {
                            case (true):
                            if (technicaIntlValue_2 == roll_3)
                                {
                                    prizePoints -=10;
                                    Console.WriteLine(">>>You win !<<<" + 
                                    $"\nCurrent point's: {points + prizePoints}"+
                                    "\n(Press \"Enter\" to contine)");
                                    points += prizePoints;
                                    Console.ReadKey();
                                    technicalBoolValue_2 = true;   
                                }
                            else
                            {
                                
                                while (technicalIntValue_1 < 101)
                                {
                                    Console.WriteLine("Wrong answer, you have one more try.");
                                    Console.WriteLine(prizePoints);
                                    Console.WriteLine(technicalIntValue_3);
                                    technicalIntValue_1 += 1;
                                    break;
                                }
                                switch(technicalIntValue_3)
                                    {
                                        case(1):
                                        prizePoints -=5;
                                        break;
                                        case(2):
                                        prizePoints -=1;
                                        break;
                                    }
                                if(technicalIntValue_1 > 1)
                                    {
                                        technicalIntValue_3 = 1;
                                        if(technicalIntValue_1 > 25)
                                        {
                                            technicalIntValue_3 = 2;
                                        }
                                    }
                            }    
                            break;
                            case(false):
                            if (enteredValue == "back")
                                {
                                    points +=80;
                                    technicalBoolValue_2 = true;
                                    backToMenu();
                                }
                                else
                                {
                                    IncorrectData();
                                }
                            break;
                            }
                        }while (technicalBoolValue_2 == false);
                    }    
                    break;              
                    
                    case "back":
                    backToMenu();
                    technicalBoolValue_1 = true;
                    technicalBoolValue_2 = true;
                    break;
                    
                    
                    default:
                    Console.WriteLine("Not entered numder ! Please try again.");
                    demarcationLine();
                    menuSelection = Console.ReadLine();
                    break;         
                }
            } while (technicalBoolValue_2 == false);
        }while(technicalBoolValue_1 == false);
    break;    
    }    
}while (enteredValue != "exit");
enteredValue = Console.ReadLine();