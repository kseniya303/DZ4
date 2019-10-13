using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dz4
{
    public class Money
    {
        private int rub { get; set; }
        private int kop { get; set; }
        //{ get => kop;
        //    set
        //    {
        //        if (kop < 0 || kop > 99) throw new IndexOutOfRangeException(nameof(kop));
        //        kop = value;
        //    }
        //}
         public Money(int _rub, int _kop)
        {
            rub = _rub;
            kop = _kop;
        }
        public override string ToString()
           => $"{rub},{kop:00}";

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
                    Console.WriteLine("Банкрот");
                }
                else
                {
                    ostatok_rub = m1.rub - m2.rub - 1;
                    ostatok_kop = 100 + (minus_kop % 100);
                    Console.WriteLine(ostatok_rub+","+ ostatok_kop);
                    return new Money(ostatok_rub, ostatok_kop);
                }
                return null;
            }
            else
            {
                min_rub = m1.rub - m2.rub;
                Console.WriteLine(min_rub + "," + minus_kop);
                return new Money(min_rub, minus_kop);
            }
        }
        public static Money operator / (Money m1, Money m2)
        {
            var n = m1 + m2;

            return null;
        }
        public static Money operator * (Money m1, Money m2)
        {
            var n = m1 + m2;

            return null;
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
        //public bool Equals(Money money) => money != null && rub == money.rub && kop == money.kop;

        public override int GetHashCode() => rub ^ kop;

        public static bool operator ==(Money m1, Money m2) => object.Equals(m1, m2);
        public static bool operator !=(Money m1, Money m2) => !object.Equals(m1, m2);
    }
}
