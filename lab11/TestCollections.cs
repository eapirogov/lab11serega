using lab10;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace lab11
{
    public class TestCollections
    {
        public Dictionary<BankCard, CreditCard> DictionaryKeyValue {  get; set; }

        public SortedDictionary<BankCard, CreditCard> SortedDictionaryKeyValue { get; set; }

        public static BankCard FirstElementKey { get; set; }

        public static CreditCard FirstElementValue { get; set; }

        public static BankCard MiddleElementKey { get; set; }

        public static CreditCard MiddleElementValue { get; set; }

        public static BankCard LastElementKey { get; set; }

        public static CreditCard LastElementValue { get; set; }

        public static BankCard NotInCollectionKey { get; set; }

        public static CreditCard NotInCollectionValue { get; set; }

        const int Length = 1000;

        public TestCollections()
        {
            DictionaryKeyValue = new Dictionary<BankCard, CreditCard>();
            SortedDictionaryKeyValue = new SortedDictionary<BankCard, CreditCard>();

            for(int i = 0; i < Length; i++)
            {
                BankCard bankCard = new BankCard();
                bankCard.RandomInit();
                CreditCard creditCard = new CreditCard();
                creditCard.RandomInit();

                if(i == 0)
                {
                    FirstElementKey = bankCard.Clone() as BankCard;
                    FirstElementValue = creditCard.Clone() as CreditCard;
                }
                else if (i == 499)
                {
                    MiddleElementKey = bankCard.Clone() as BankCard;
                    MiddleElementValue = creditCard.Clone() as CreditCard;
                }
                else if ( i == 999)
                {
                    LastElementKey = bankCard.Clone() as BankCard;
                    LastElementValue = creditCard.Clone() as CreditCard;
                }

                try
                {
                    DictionaryKeyValue.Add(bankCard, creditCard);
                    SortedDictionaryKeyValue.Add(bankCard, creditCard);
                }
                catch (Exception)
                {
                    i--;
                }
            }
            NotInCollectionKey = new BankCard(1234, "22.12.2026", "Егор Токарев", 123);
            NotInCollectionValue = new CreditCard(1234, "22.12.2026", "Егор Токарев", 123, 12, 1000);
            
        }
        //Измерение времени
        private void MeasureTime(string element, BankCard key, CreditCard value)
        {
            Console.WriteLine($"Поиск элемента");

            Stopwatch sw = Stopwatch.StartNew();
            bool foundKey = DictionaryKeyValue.ContainsKey(key);
            sw.Stop();
            Console.WriteLine($"Коллекция Dictionary<>: Найденный ключ = {foundKey}, Время = {sw.ElapsedTicks} тиков");
            sw.Restart();
            bool foundValue = DictionaryKeyValue.ContainsValue(value);
            sw.Stop();
            Console.WriteLine($"Коллекция Dictionary<>: Значение найдено = {foundValue}, Время = {sw.ElapsedTicks} тиков");

            sw.Restart();
            foundKey = SortedDictionaryKeyValue.ContainsKey(key);
            sw.Stop();
            Console.WriteLine($"Коллекция SortedDictionary<>: Найденный ключ = {foundKey}, Время = {sw.ElapsedTicks} тиков");
            sw.Restart();
            foundValue = SortedDictionaryKeyValue.ContainsValue(value);
            sw.Stop();
            Console.WriteLine($"Коллекция SortedDictonary<>: Значение найдено = {foundValue}, Время = {sw.ElapsedTicks} тиков");

            Console.WriteLine();
        }
        public void MeasureSearhTime()
        {
            MeasureTime("Первый элемент", FirstElementKey, FirstElementValue);
            MeasureTime("Средний элемент", MiddleElementKey, MiddleElementValue);
            MeasureTime("Последний элемент", LastElementKey, LastElementValue);
            MeasureTime("Не в коллекции", NotInCollectionKey, NotInCollectionValue);
        }
    }
}
