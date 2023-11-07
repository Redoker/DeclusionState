using System;

namespace GenerativeDeclension
{
  internal class Program
  {
    string[] result;

    static void Main(string[] args)
    {
      Console.WriteLine("Введите число:");
      int readNumber = Convert.ToInt32(Console.ReadLine());
      int number = readNumber; // хочу оставить оригинальное число

      string num = "";
      if (number < 0)
      {
        num = string.Concat(num, "минус ");
        number = number * -1;
      }
      if (number == 0)
        num = string.Concat(num, "ноль ");
      else
      {
        if (number >= 1000000000) // миллиард
        {
          if (number >= 2000000000)
          {
            num = string.Concat(num, "два миллиарда ");
          }
          else
            num = string.Concat(num, "один миллиард ");
          number = number % 1000000000;
        }
        if (number >= 1000000) //миллион
        {
          ProccesNumber(ref num, number / 1000000);
          if ((number / 1000000) % 10 < 5)
          {
            if (number / 1000000 > 1)
              num = string.Concat(num, " миллиона ");
            else num = string.Concat(num, " миллион ");
          }
          else num = string.Concat(num, " миллионов ");
          number = number % 1000000;
        }
        if (number >= 1000)//тысяча
        {
          if (number / 1000 == 1)
            num = string.Concat(num, " одна тысяча ");
          else
          {
            ProccesNumber(ref num, number / 1000);
            if ((number / 1000) % 10 < 5)
            {
              if ((number / 1000) == 1)
                num = string.Concat(num, " тысяча ");
              else num = string.Concat(num, " тысячи ");
            }
            else num = string.Concat(num, " тысяч ");
          }
          number = number % 1000;
        }

        ProccesNumber(ref num, number);
        num = string.Concat(num, " ");
      }
      Console.WriteLine(num);
    }

    static void ProccesNumber(ref string num, int value)
    {
      //////////////////
      if (value >= 100)
      {
        int degree = value / 100;
        if (degree == 1 || degree == 2)
        {
          if (degree == 1)
            num = string.Concat(num, "сто ");
          else num = string.Concat(num, "двести ");
        }
        else
        {
          ProccesNumber(ref num, degree);
          if (degree == 9)
            num = string.Concat(num, "сот ");
          else if (degree >= 5)
            num = string.Concat(num, "сот ");
          else
            num = string.Concat(num, "ста ");
        }
        value = value % 100;
      }

      ////////////////////
      if (value >= 20)
      {
        int degree = value / 10;
        if (degree == 4 || degree == 1 || degree == 9)
        {
          if (degree == 9)
            num = string.Concat(num, "девяноста ");
          else
            num = string.Concat(num, "сорок ");
        }
        else
        {
          ProccesNumber(ref num, degree);

          if (degree > 4)
            num = string.Concat(num, "десят ");
          else
            num = string.Concat(num, "дцать ");
        }
        value = value % 10;
      }

      num = ConcatNumber(ref num, value);
    }

    static string ConcatNumber(ref string num, int value)
    {
      return value switch
      {
        1 => string.Concat(num, "один"),
        2 => string.Concat(num, "два"),
        3 => string.Concat(num, "три"),
        4 => string.Concat(num, "четыре"),
        5 => string.Concat(num, "пять"),
        6 => string.Concat(num, "шесть"),
        7 => string.Concat(num, "семь"),
        8 => string.Concat(num, "восемь"),
        9 => string.Concat(num, "девять"),
        10 => string.Concat(num, "десять"),
        11 => string.Concat(num, "одиннадцать"),
        12 => string.Concat(num, "двенадцать"),
        13 => string.Concat(num, "тринадцать"),
        14 => string.Concat(num, "четырнадцать"),
        15 => string.Concat(num, "пятнадцать"),
        16 => string.Concat(num, "шестнадцать"),
        17 => string.Concat(num, "семнадцать"),
        18 => string.Concat(num, "восемнадцать"),
        19 => string.Concat(num, "девятнадцать"),
        _ => string.Empty
      };
    }
  }
}