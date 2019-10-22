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
            bool flag = true;
            //var num1 = new Money(1, 3);
            //var num2 = new Money(2, 4);
            Console.WriteLine("Введите рубли первой суммы:");
            int rub1 = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Введите копейки первой суммы:");
            int kop1 = Int32.Parse(Console.ReadLine());
            var money1 = new Money(rub1, kop1);
            Console.WriteLine("Введите рубли второй суммы:");
            int rub2 = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Введите копейки второй суммы:");
            int kop2 = Int32.Parse(Console.ReadLine());
            var money2 = new Money(rub2, kop2);
            var sum = money1 + money2;
            try
            {
                if(money1<0 || money2<0)
                {
                    throw new Exep($"Банкрот");
                }
                else
                {

                    while (flag)
                    {
                        //Console.Clear();
                        Console.WriteLine($"Первая сумма: {money1.ToString()}");
                        Console.WriteLine($"Вторая сумма: {money2.ToString()}");
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
                                Console.Clear(); 
                                Console.WriteLine($"Общая сумма: {sum.ToString()}");
                                break;
                            case '2':
                                Console.Clear();
                                var minus = money1 - money2;
                                break;
                            case '3':
                                Console.Clear();
                                Console.WriteLine("Введите целое число:");
                                int val = Convert.ToInt32(Console.ReadLine());
                                var pr1 = (sum / val); //
                                Console.Write("Результат: ");
                                Console.WriteLine(pr1.ToString());
                                break;
                            case '4':
                                Console.Clear();
                                Console.WriteLine("Введите целое число:");
                                int values = Convert.ToInt32(Console.ReadLine());
                                var pr = (sum * values);
                                Console.Write("Результат: ");
                                Console.WriteLine(pr.ToString());
                                break;
                            case '5':
                                Console.Clear();
                                sum++;
                                Console.Write("Результат: ");
                                Console.WriteLine(sum.ToString());
                                break;
                            case '6':
                                Console.Clear();
                                sum--;
                                Console.Write("Результат: ");
                                Console.WriteLine(sum.ToString());
                                break;
                            case '7':
                                Console.Clear();
                                Console.Write("Результат: ");
                                Console.WriteLine(money1 == money2);
                                break;
                            case '8':
                                flag = false;
                                break;
                            default:
                                Console.WriteLine("Не верный ввод");
                                break;
                        }
                    } 
                }
            }
            catch
            {
                Console.WriteLine("Банкрот");
            }
        }
    }
}

