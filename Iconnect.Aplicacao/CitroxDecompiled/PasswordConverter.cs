using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CORS.CitroxDecompiled
{
    public class PasswordConverter
    {
        public PasswordConverter()
        {
        }

        public static string ConvertCardIdToPassword(string cardId)
        {
            if (!CardConverter.IsDecimalFormat(cardId))
            {
                throw new InvalidCardFormat("O formato do cartão fornecido não é suportado.");
            }
            return string.Format("{0:x}", long.Parse(cardId));
        }

        public static string ConvertPasswordToCardId(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new InvalidCardFormat("O formato da senha fornecida não é suportada.");
            }
            return string.Format("{0}", Convert.ToUInt64(password, 16));
        }
    }
}