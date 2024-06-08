using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtFusionStudio.Utility
{
    public class ErrorMessages
    {
        public const string NO_BLANK_SPACE    = "Трябва да въведете име на елемента.";
        public const string NO_CHOSEN_ID      = "Изберете номера на елемента, с който да свържете по-горното свойство.";
        public const string REGEX_AZ_ONLY     = "Името трябва да съдържа само символи на латиница";
        public const string REGEX_AND_NUMS    = REGEX_AZ_ONLY + " и цифрите от 0 до 9.";
        public const string OUT_OF_RANGE      = "Текстът трябва да бъде с брой символи между";
        public const string INVALID_HEX_CODE  = "HEX кодът трябва да започва с '#', последван от до 6 символа [0-9a-fA-F].";
        public const string INVLID_DATE       = "Датата трябва да бъде между 01.01.2000г. и днес";
        public const string OUT_OF_RANGE_NUM  = "Стойността на полето трябва да е между";
        public const string NOT_NEGATIVE_NUM  = "Стойността на полето трябва да е положително число и по-малко от";
        public const string INVALID_DECIMAL   = "Елементът трябва да има до 2 цифри преди и след десетичната запетая.";
        public const string INVALID_END_DATE  = "Крайната дата трябва да бъде след началната";
        public const string INVALID_SCORE     = "Резултатът трябва да е по-голям от броя гласове и\n" 
                                              + "по-малък от 5 пъти броя на гласовете";
 

    }
}
