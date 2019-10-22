using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;  

namespace Dz4
{
    public  class Money
    {
        private int rub { get; set; }
        private int kop { get; set; } 
        public Money(int _rub, int _kop)
        {
            rub = _rub;
            kop = _kop;
        }
        public override string ToString() => $"{rub},{kop:00}";
        
        public override int GetHashCode() => ToString().GetHashCode();
        
        public static Money operator + (Money m1, Money m2)
        {
            int sum_rub;
            int ostatok_rub;
            int ostatok_kop;
            int sum_kop = m1.kop + m2.kop;
            if (sum_kop > 99)
            {
                ostatok_kop = sum_kop % 100;
                ostatok_rub = sum_kop / 100;
                sum_rub = m1.rub + m2.rub + ostatok_rub; 
                return new Money(sum_rub, ostatok_kop);
            }
            else
            {
                sum_rub = m1.rub + m2.rub; 
                return new Money(sum_rub, sum_kop);
            } 
        }

        public static Money operator - (Money m1, Money m2)
        {
            int min_rub;
            int ostatok_rub;
            int ostatok_kop;
            int minus_kop = m1.kop - m2.kop;
            if (minus_kop <0)
            {
                if((m1.rub - m2.rub) < 0 || (m1.rub - m2.rub) == 0)
                {
                    throw new Exep($"Банкрот!");
                }
                else
                {
                    ostatok_rub = m1.rub - m2.rub - 1;
                    ostatok_kop = 100 + (minus_kop % 100);
                    Console.Write("Результат вычитания: ");
                    Console.WriteLine(ostatok_rub+","+ ostatok_kop);
                    return new Money(ostatok_rub, ostatok_kop);
                } 
            }
            else
            {
                min_rub = m1.rub - m2.rub;
                Console.WriteLine(min_rub + "," + minus_kop);
                return new Money(min_rub, minus_kop);
            }
        }
        public static Money operator / (Money m, int num)
        { 
            var delRub = m.rub / num;
            double converter = (m.kop / num) + (Convert.ToDouble(m.rub) / Convert.ToDouble(num)) * 100;
            var delKop = Convert.ToInt32(converter);
            if (new Money(delRub, delKop) < 0)
            {
                throw new Exep($"Банкрот!");
            }
            else
            return new Money(delRub, delKop);
        }
        public static Money operator *(Money m, int num)
        {
            if (m.kop >= 10)
            {
                var u = (m.rub * 100) + m.kop;
                var pro = u * num;
                var znam = pro % 100;
                var r = pro / 100;
                return new Money(r, znam);
            }
            else
            {
                var r = m.rub * num;
                var k = m.kop * num;
                return new Money(r, k);
            }
        } 

        // public override bool Equals(object obj) => Equals(obj as Money);
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            Money m = obj as Money; // возвращает null если объект нельзя привести к типу Money
            if (m as Money == null)
            {
                return false;
            }
            return m.rub == this.rub && m.kop == this.kop;
        }
        
        public static bool operator ==(Money m1, Money m2) => object.Equals(m1, m2);
        public static bool operator !=(Money m1, Money m2) => !object.Equals(m1, m2);
         
        // Перегружаем унарный оператор ++
        public static Money operator ++(Money m)
        {
            if(m.kop == 99)
            {
                m.rub += 1;
                m.kop = 0;
                return m;
            }
            else
            {
                m.kop += 1;
                return m;
            } 
        }

        // Перегружаем унарный оператор --
        public static Money operator --(Money m)
        {
            if (m.kop == 0)
            {
                m.rub -= 1;
                if(m.rub<0)
                {
                    throw new Exep($"Банкрот!");
                }
                m.kop = 99;
                return m;
            }
            else
            {
                m.kop -= 1;
                return m;
            }
        }

        public static bool operator <(Money m, int num)
        {
            if (m.rub < num)
                return true;
            else
                return false;
        }
        public static bool operator >(Money m, int num)
        {
            if (m.rub < num)
                return false;
            else
                return true;
        }
    }
}
