using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_3._2
{
    internal class Program
    {
        /*Очко, также называемое двадцать одно очко, или просто двадцать одно (21) —
         * русский вариант карточной игры, известной во многих странах. Эта игра похожа
         * на вариант игры блэкджек, в который возможно играть стандартной советской колодой
         * (36 карт) вместо полной стандартной колоды (52 карты), так как в те времена была 
         * распространена колода из 36 карт, а колоды из 52 и 54 карт были редкостью. В отличие
         * от блэкджека, значения карт J (валет), Q (дама) и K (король) не 10, а 2, 3 и 4 соответственно,
         * чем частично восполняется отсутствие карт от двойки до пятёрки. Но, так как количество карт,
         * имеющих значение 10, существенно меньше, чем в блэкджеке, то игровой баланс сильно отличается.
         * Так что есть 2 решения выполение ДЗ: 1)-добавить в блок кейс еще номинал карт от 2 до 5;
         * 2)-изменить кол-во очков с карт "картинок". Я склоняюсь ко 2ому варианту.
         */
        static void Main(string[] args)
        {
            byte totalSum=0;
            bool ace = false;
            byte countCards;
            Console.WriteLine("Привет игрок это игра <<21>>. " +
                "\nВ поле ввода пиши только корректные обозначения: " +
                "\nT-туз, K-король, Q-дама, J-валет, " +
                "\n числовые карты-целым числом");
            Console.WriteLine("Введи количество карт, которые у тебя на руках: ");
            countCards=byte.Parse(Console.ReadLine());
            for (int i = 0; i < countCards; i++)
            {
                Console.WriteLine($"Введите {i+1}-ю вашу карту(T,K,Q,J или числовые значения): ");
                string inputNumber = Console.ReadLine();
                switch (inputNumber)
                {
                    case "J":
                        totalSum += 2;
                        break;
                    case "Q":
                        totalSum += 3;
                        break;
                    case "K":
                        totalSum += 4;
                        break;
                    case "T":
                        totalSum += 11;
                        ace=true;
                        break; 
                    default:
                        if (byte.TryParse(inputNumber, out byte result) && (result >= 6 && result <= 10))
                        {
                            totalSum += byte.Parse(inputNumber);
                        }
                        else
                        {
                            Console.WriteLine("Введите корректно номинал карты!!");
                            i--;
                        }
                        break;
                }
            }
            if (totalSum > 21)
            {
                if (ace)
                {
                    totalSum -= 10;
                    if (totalSum == 21)
                    {
                        Console.WriteLine("У вас <<Двадцать одно очко>>!!");
                    }
                    else 
                    {
                        Console.WriteLine($"Ваши очки - {totalSum}");
                    }
                }
                else
                {
                    Console.WriteLine("У вас перебор!");
                }
            } 
            else 
            {
                Console.WriteLine($"Ваши очки - {totalSum}");
            }
            Console.ReadKey();  
        }
    }
}
