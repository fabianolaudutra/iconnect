using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace CORS.CitroxDecompiled
{
    public class CardConverter
    {
        private static Regex wiegandPattern;

        private static Regex numberPattern;

        static CardConverter()
        {
            CardConverter.wiegandPattern = new Regex("[0-9]{1,3}[,.\\s]{1}[0-9]{5}");
            CardConverter.numberPattern = new Regex("^[0-9]*$");
        }

        public CardConverter()
        {
        }

        public static string Convert(string cardId)
        {
            if (CardConverter.IsWiegandFormat(cardId))
            {
                return CardConverter.ConvertWiegandToDecimal(cardId);
            }
            if (!CardConverter.IsDecimalFormat(cardId))
            {
                throw new InvalidCardFormat("O formato do cartão fornecido não é suportado.");
            }
            return long.Parse(cardId).ToString();
        }

        public static string ConvertDecimalToWiegand(string decimalCard)
        {
            if (!CardConverter.IsDecimalFormat(decimalCard))
            {
                throw new InvalidCardFormat("O cartão fornecido não está no formato decimal.");
            }
            long num = long.Parse(decimalCard);
            long num1 = num >> 16 & (long)255;
            long num2 = num & (long)65535;
            return string.Concat(num1.ToString(), ",", num2.ToString());
        }

        public static string ConvertWiegandToDecimal(string wiegandCard)
        {
            wiegandCard = wiegandCard.Trim();
            if (!CardConverter.IsWiegandFormat(wiegandCard))
            {
                throw new InvalidCardFormat("O cartão fornecido não está no formato Wiegand.");
            }
            string[] strArrays = wiegandCard.Split(new char[] { ',', '.' });
            int num = int.Parse(strArrays[0]);
            int num1 = int.Parse(strArrays[1]);
            if (num > 255 || num1 > 65535)
            {
                throw new InvalidCardFormat("Formato do cartão Wiegand fornecido está inválido.");
            }
            long num2 = ((long)num << 16) + (long)num1;
            wiegandCard = num2.ToString();
            return wiegandCard;
        }

        public static bool IsDecimalFormat(string decimalCard)
        {
            return CardConverter.numberPattern.IsMatch(decimalCard);
        }

        public static bool IsWiegandFormat(string wiegandCard)
        {
            return CardConverter.wiegandPattern.IsMatch(wiegandCard);
        }
    }
}