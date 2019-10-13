using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dz4
{
    class Program
    {
        static void Main(string[] args)
        {
            int input ;
            var num1 = new Money(0, 40);
            var num2 = new Money(0, 60);

            Console.WriteLine(num1.ToString());
            Console.WriteLine(num2.ToString());

            do
            {
                Console.WriteLine();
                Console.WriteLine("Меню:");
                Console.WriteLine("1. Cложение денежных сумм ");
                Console.WriteLine("2. Вычитание сумм ");
                Console.WriteLine("3. Деление суммы на целое число");
                Console.WriteLine("4. Умножение суммы на целое число ");
                Console.WriteLine("5. Сумма увеличивается на 1 копейку");
                Console.WriteLine("6. Сумма уменьшается на 1 копейку");
                Console.WriteLine("7. ==");
                Console.WriteLine("8. Выход");

                Console.Write("Ввод: ");
                String s = Console.ReadLine();

                input = s.Length > 0 ? s[0] : ' ';

                switch (input)
                {
                    case '1':
                        var sum = num1 + num2;
                        Console.WriteLine(sum.ToString());
                        break;
                    case '2':
                        var minus = num1 - num2;
                        break;
                    case '3':
                        Console.WriteLine();
                        break;
                    case '4':
                        Console.WriteLine();
                        break;
                    case '5':
                        Console.WriteLine();
                        break;
                    case '6':
                        Console.WriteLine();
                        break;
                    case '7':
                        
                        Console.WriteLine(num1 == num2);
                        break;
                    case '8':
                        Console.WriteLine("Выход..");
                        break;
                    default:
                        Console.WriteLine("Не верный ввод");
                        break; 
                }
            }
            while (input != '8');
        }
    }
}
    
