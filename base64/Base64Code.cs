using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace base64
{
    public class Base64Code
    {
        #region 解码
        //base64对照表，转换base64字符成二进制数字
        public static int TransformTable(char letter)
        {
            switch (letter)
            {
                case 'A': return 0;
                case 'B': return 1;
                case 'C': return 2;
                case 'D': return 3;
                case 'E': return 4;
                case 'F': return 5;
                case 'G': return 6;
                case 'H': return 7;
                case 'I': return 8;
                case 'J': return 9;
                case 'K': return 10;
                case 'L': return 11;
                case 'M': return 12;
                case 'N': return 13;
                case 'O': return 14;
                case 'P': return 15;
                case 'Q': return 16;
                case 'R': return 17;
                case 'S': return 18;
                case 'T': return 19;
                case 'U': return 20;
                case 'V': return 21;
                case 'W': return 22;
                case 'X': return 23;
                case 'Y': return 24;
                case 'Z': return 25;
                case 'a': return 26;
                case 'b': return 27;
                case 'c': return 28;
                case 'd': return 29;
                case 'e': return 30;
                case 'f': return 31;
                case 'g': return 32;
                case 'h': return 33;
                case 'i': return 34;
                case 'j': return 35;
                case 'k': return 36;
                case 'l': return 37;
                case 'm': return 38;
                case 'n': return 39;
                case 'o': return 40;
                case 'p': return 41;
                case 'q': return 42;
                case 'r': return 43;
                case 's': return 44;
                case 't': return 45;
                case 'u': return 46;
                case 'v': return 47;
                case 'w': return 48;
                case 'x': return 49;
                case 'y': return 50;
                case 'z': return 51;
                case '0': return 52;
                case '1': return 53;
                case '2': return 54;
                case '3': return 55;
                case '4': return 56;
                case '5': return 57;
                case '6': return 58;
                case '7': return 59;
                case '8': return 60;
                case '9': return 61;
                case '+': return 62;
                case '/': return 63;
                default:  return 0;//任意数字即可，不能太大，以免越界
            } 
        }

        //四个六位二进制数字重新划分成三个八位二进制数字并转换成字符
        public static string TransformUnit(string letters)
        {
            //将base64字符转换成对应的二进制数
            int[] numbers = new int[4];
            //四个数字一组
            for (int i = 0; i < 4; i++)
            {
                numbers[i] = TransformTable(letters[i]);
            }
            //重新分组计算原始的字符
            string firstchar= Convert.ToChar(numbers[0] << 2 | numbers[1]>>4).ToString();
            string secondchar = Convert.ToChar((numbers[1]&0b1111)<<4 | numbers[2] >> 2).ToString();
            string thridchar = Convert.ToChar((numbers[2] & 0b11) << 6 | numbers[3]).ToString();
            return firstchar + secondchar + thridchar;
        } 
        //长串字符输入解码
        public static string Decode(string letters)
        {
            //结果字符
            string transformString = "";
            
            //分组次数
            int i = letters.Length / 4;
            //每次进行处理的小组
            string letterunit = "";
            //判断末尾"="数量
            if (letters.Substring(letters.Length - 2, 1) == "=")
            {
                //每四个一组循环处理base64字符
                for(int j = 0; j < i-1; j++)
                {
                    letterunit = letters.Substring(j * 4, 4);
                    transformString += TransformUnit(letterunit);
                }
                //最后四个仅仅加上有意义的字符此处是两个
                letterunit= letters.Substring(letters.Length-4,4);
                transformString+=TransformUnit(letterunit).Substring(0,1);
                
            }
            else if (letters.Substring(letters.Length - 1, 1) == "=")
            {
                for (int j = 0; j < i-1; j++)
                {
                    letterunit = letters.Substring(j * 4, 4);
                    transformString += TransformUnit(letterunit);
                }
                letterunit = letters.Substring(letters.Length - 4, 4);
                transformString += TransformUnit(letterunit).Substring(0, 2);
            }
            else
            {
                for (int j = 0; j < i; j++)
                {
                    letterunit = letters.Substring(j * 4, 4);
                    transformString += TransformUnit(letterunit);
                }
            }
            return transformString;
           
        }

        public static byte[] DecodeToByte(string letters)
        {
            string transformString = Decode(letters);
            byte[] bytes = new byte[transformString.Length];
            for (int i = 0; i < transformString.Length; i++)
            {
                bytes[i] = Convert.ToByte(transformString[i]);
            }
            return bytes;
        }
        #endregion

        #region 编码
        //base64对照表
        public static string TransformTable(int code)
        {
            switch(code)
            {
                case 0:return "A";
                case 1 :return "B";
                case 2:return "C";
                case 3:return "D";
                case 4:return "E";
                case 5:return "F";
                case 6: return "G";
                case 7: return "H";
                case 8: return "I";
                case 9: return "J";
                case 10: return "K";
                case 11: return "L";
                case 12: return "M";
                case 13: return "N";
                case 14: return "O";
                case 15: return "P";
                case 16: return "Q";
                case 17: return "R";
                case 18: return "S";
                case 19: return "T";
                case 20: return "U";
                case 21: return "V";
                case 22: return "W";
                case 23: return "X";
                case 24: return "Y";
                case 25: return "Z";
                case 26: return "a";
                case 27: return "b";
                case 28: return "c";
                case 29: return "d";
                case 30: return "e";
                case 31: return "f";
                case 32: return "g";
                case 33: return "h";
                case 34: return "i";
                case 35: return "j";
                case 36: return "k";
                case 37: return "l";
                case 38: return "m";
                case 39: return "n";
                case 40: return "o";
                case 41: return "p";
                case 42: return "q";
                case 43: return "r";
                case 44: return "s";
                case 45: return "t";
                case 46: return "u";
                case 47: return "v";
                case 48: return "w";
                case 49: return "x";
                case 50: return "y";
                case 51: return "z";
                case 52: return "0";
                case 53: return "1";
                case 54: return "2";
                case 55: return "3";
                case 56: return "4";
                case 57: return "5";
                case 58: return "6";
                case 59: return "7";
                case 60: return "8";
                case 61: return "9";
                case 62: return "+";
                case 63: return "/";
                default: return "=";
            }
        }
        
        public static string encodeTransformUnit(string letters)
        {
            int[] numbers = new int[4];
            int sumnum = letters[0] << 16 | letters[1] << 8 | letters[2];
            numbers[0] = sumnum>>18;
            numbers[1] = sumnum<<14>>26&(0x0000003f);
            numbers[2] = sumnum<<20>>26 & (0x0000003f);
            numbers[3] = sumnum<<26>>26 & (0x0000003f);
            
            string letterunit = "";
            for(int i=0;i<4;i++)
            {
                letterunit += TransformTable(numbers[i]);
            }
            return letterunit;
        }
        public static string Encode(string letters)
        {
            string encodingString = "";
            string letterunit = "";
            int i = letters.Length / 3;
            if(letters.Length%3==2 )
            {
                for(int j=0;j<i ; j++)
                {
                    letterunit=letters.Substring(j*3,3);
                    encodingString += encodeTransformUnit(letterunit);
                }
                string char1 = TransformTable(letters[letters.Length - 2] >> 2);
                string char2 = TransformTable((letters[letters.Length - 2] << 30 >> 26 & (0x0000003f)) | (letters[letters.Length - 1] >> 4 & (0x0000003f)));
                string char3 = TransformTable(letters[letters.Length - 1] << 28 >> 26 & (0x0000003f));
                encodingString += char1 + char2 + char3 + "=";
            }
            else if(letters.Length%3==1 )
            {
                for (int j = 0; j < i ; j++)
                {
                    letterunit = letters.Substring(j * 3, 3);
                    encodingString += encodeTransformUnit(letterunit);
                }
                string char1 = TransformTable(letters[letters.Length - 1] >> 2);
                string char2 = TransformTable(letters[letters.Length - 1] << 30 >> 26 & (0x0000003f));
                encodingString += char1 + char2 + "=" + "=";
            }
            else
            {
                for (int j = 0; j < i ; j++)
                {
                    letterunit = letters.Substring(j * 3, 3);
                    encodingString += encodeTransformUnit(letterunit);
                }

            }
            return encodingString;
        }
        public static string EncodeByByte(byte[] bytes)
        {
            string letters="";
            for(int i=0;i<bytes.Length;i++)
            {
                letters += Convert.ToChar(bytes[i]).ToString();
                
            }
            return Encode(letters);
        }
        #endregion
    }
}
