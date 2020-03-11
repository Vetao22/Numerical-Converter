using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numerical_Converter
{
    public class Converter
    {
        public static string DecToBin(string input)
        {
            string result = "";

            int value = Convert.ToInt32(input);
            int quotient, remain;

            quotient = value;

            do
            {
                remain = (int)(quotient % 2);
                quotient = (int)(quotient / 2);

                result = remain + result;
            }
            while (quotient != 0);

            return result;
        }

        public static string BinToDec(string input)
        {
            int result = 0;
            int power = input.Length - 1;

            for(int x = 0; x < input.Length; x++)
            {
                int value = (int)Char.GetNumericValue(input.ElementAt(x));
                result += (value * (int)Math.Pow(2, power));
                power--;
            }

            return result.ToString();
        }

        public static string DecToHex(string input)
        {
            string result = "";

            int value = Convert.ToInt32(input);
            int quotient, remain;

            quotient = value;

            do
            {
                remain = (int)(quotient % 16);
                quotient = (int)(quotient / 16);

                if(remain > 9 && remain < 16)
                {
                    string temp = "";

                    switch(remain)
                    {
                        case 10:
                            temp = "A";
                            break;

                        case 11:
                            temp = "B";
                            break;

                        case 12:
                            temp = "C";
                            break;

                        case 13:
                            temp = "D";
                            break;

                        case 14:
                            temp = "E";
                            break;

                        case 15:
                            temp = "F";
                            break;
                    }

                    result = temp + result;
                }
                else
                {
                    result = remain + result;
                }

               
            }
            while (quotient != 0);

            return result;
        }

        public static string HexToDec(string input)
        {
            input = input.ToUpper();
            int result = 0;
            int power = input.Length - 1;

            for (int x = 0; x < input.Length; x++)
            {
                char curChar = input[x];
                int value = 0;

                if (!Char.IsNumber(curChar))
                {
                    switch (curChar)
                    {
                        case 'A':
                            value = 10;
                            break;

                        case 'B':
                            value = 11;
                            break;

                        case 'C':
                            value = 12;
                            break;

                        case 'D':
                            value = 13;
                            break;

                        case 'E':
                            value = 14;
                            break;

                        case 'F':
                            value = 15;
                            break;

                        default:
                            return "";                            
                    }

                    result += (int)(value * Math.Pow(16, power));
                }
                else
                {
                    value = (int)Char.GetNumericValue(input.ElementAt(x));
                    result += (int)(value * Math.Pow(16, power));
                }
                
                power--;
            }

            return result.ToString();
        }

        public static string HexToBin(string input)
        {
            input = input.ToUpper();

            string result = HexToDec(input);
            result = DecToBin(result);

            return result;
        }

        public static string BinToHex(string input)
        {
            input = input.ToUpper();

            string result = BinToDec(input);
            result = DecToHex(result);

            return result;
        }
    }
}
