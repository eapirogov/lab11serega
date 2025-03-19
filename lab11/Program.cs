using ClassLibraryLab10;
using lab10;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace lab11
{
    public class Program
    {
        static int SummInAllDebetsCards(ArrayList arr)
        {
            int sum = 0;
            foreach (BankCard card in arr)
            {
                if (card is DebetCard dc)
                {
                    sum += dc.Balance;
                }
            }
            return sum;
        }
        static int AverageSummOfCreditCards(ArrayList arr)
        {
            int sum = 0;
            int count = 0;

            foreach (BankCard card in arr)
            {
                if (card is CreditCard cc)
                {
                    sum += cc.Limit / cc.MaturityDate;
                    count++;
                }
            }

            if (count == 0) return 0;

            return sum / count;
        }

        static int SummOfCashBack(ArrayList arr)
        {
            int sum = 0;

            foreach (BankCard card in arr)
            {
                if (card is YouthCard yc)
                {
                    sum += yc.Balance * yc.CashBack / 100;
                }
            }

            return sum;
        }
        static int SummOfCashBackSecond(LinkedList<BankCard> collection)
        {
            int sum = 0;

            foreach (BankCard card in collection)
            {
                if(card is YouthCard yc)
                {
                    sum += yc.Balance * yc.CashBack / 100;
                }
            }

            return sum;
        }
        static int AverageSummOfCreditCardsSecond(LinkedList<BankCard> collection)
        {
            int sum = 0;
            int count = 0;

            foreach (BankCard card in collection)
            {
                if (card is CreditCard cc)
                {
                    sum += cc.Limit / cc.MaturityDate;
                    count++;
                }
            }

            if (count == 0) return 0;

            return sum / count;
        }
        static int SummInAllDebetsCardsSecond(LinkedList<BankCard> collection)
        {
            int sum = 0;
            foreach (BankCard card in collection)
            {
                if (card is DebetCard dc)
                {
                    sum += dc.Balance;
                }
            }
            return sum;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Часть 1");
            ArrayList cardsCollecctions = new ArrayList();

            //Добавление объектов из библиотеки классов лабораторной №10

            BankCard bankCardFirst = new BankCard();
            bankCardFirst.RandomInit();
            BankCard bankCardSecond = new BankCard();
            bankCardSecond.RandomInit();
            DebetCard debetCardFirst = new DebetCard();
            debetCardFirst.RandomInit();
            CreditCard creditCardFirst = new CreditCard();
            creditCardFirst.RandomInit();
            CreditCard creditCardSecond = new CreditCard();
            creditCardSecond.RandomInit();
            BankCard searchingCard = new BankCard(3, "22.12.2026", "Егор Токарев", 228);
            //Добавление элементов в массив
            cardsCollecctions.Add(creditCardFirst);
            cardsCollecctions.Add(bankCardSecond);
            cardsCollecctions.Add(debetCardFirst);
            cardsCollecctions.Add(bankCardFirst);
            cardsCollecctions.Add(searchingCard);
            cardsCollecctions.Add(creditCardSecond);
            //Добавление и удаление объектов из коллекции
            Console.WriteLine("Добавление и удаление объектов");
            Console.WriteLine("Исходная коллекция");
            foreach(BankCard item in cardsCollecctions)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Добавление элементов в коллкекцию");
            YouthCard youthCardFirst = new YouthCard();
            youthCardFirst.RandomInit();
            cardsCollecctions.Add(youthCardFirst);
            Console.WriteLine("После добавления элемента");
            foreach(BankCard item in cardsCollecctions)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Удаление элемента из коллекции");
            Console.WriteLine("После удаления элемента из коллекции");
            cardsCollecctions.Remove(creditCardFirst);
            Console.WriteLine("После удаления элемента");
            foreach(BankCard card in cardsCollecctions)
            {
                Console.WriteLine(card);
            }
            //Реализация запросов в коллекции
            Console.WriteLine("Запросы");
            Console.WriteLine(SummInAllDebetsCards(cardsCollecctions));
            Console.WriteLine(AverageSummOfCreditCards(cardsCollecctions));
            Console.WriteLine(SummOfCashBack(cardsCollecctions));
            //Перебор элментов
            Console.WriteLine("Перебор элементов");
            foreach (object item in cardsCollecctions)
            {
                Console.WriteLine(item.ToString());
            }
            //Клонирование коллекции
            Console.WriteLine("Клонирование объекта");
            ArrayList clonnedArray = new ArrayList();
            foreach (BankCard item in cardsCollecctions)
            {
                clonnedArray.Add(item.Clone());
            }
            ClassLibraryLab10.Comparer comparer = new ClassLibraryLab10.Comparer();
            clonnedArray.Sort(comparer);
            foreach (BankCard card in clonnedArray)
            {
                Console.WriteLine(card);
            }

            int index = clonnedArray.BinarySearch(searchingCard, comparer);
            if (index >= 0)
            {
                Console.WriteLine($"Карта найдена на позиции {index}");
                Console.WriteLine(clonnedArray[index]);
            }
            else
            {
                Console.WriteLine("Карта не найдена");
            }
            //Часть 2
            Console.WriteLine("Часть 2");
            LinkedList<BankCard> list = new LinkedList<BankCard>();
            Console.WriteLine($"Count = {list.Count}");
            //Добавление элементов и поиск
            for (int i = 0; i < 3; i++)
            {
                BankCard card = new BankCard();
                card.RandomInit();
                list.AddLast(new LinkedListNode<BankCard>(card));
            }
            for (int i = 0; i < 3; i++)
            {
                DebetCard card = new DebetCard();
                card.RandomInit();
                list.AddLast(card);
            }
            for (int i = 0; i < 3; i++)
            {
                CreditCard card = new CreditCard();
                card.RandomInit();
                list.AddLast(card);
            }
            for (int i = 0; i < 3; i++)
            {
                YouthCard card = new YouthCard();
                card.RandomInit();
                list.AddLast(card);
            }
            foreach (BankCard card in list)
            {
                Console.WriteLine(card.ToString());
            }
            Console.WriteLine($"Count = {list.Count}");
            //Поиск элемента в массиве
            Console.WriteLine("Поиск элемента");
            BankCard searchingCardSecond = new BankCard(3, "22.12.2026", "Егор Токарев", 228);
            list.AddLast(new LinkedListNode<BankCard>(searchingCardSecond));
            if (list.Contains(searchingCardSecond))
            {
                Console.WriteLine("Карта найдена");
            }
            else
            {
                Console.WriteLine("Не найдена");
            }
            LinkedListNode<BankCard>? node = list.Find(searchingCardSecond);
            if (node != null)
            {
                Console.WriteLine("Удаляем найденный элемент");
                list.Remove(searchingCardSecond);
            }
            if (list.Contains(searchingCardSecond))
            {
                Console.WriteLine("Карта найдена");
            }
            else
            {
                Console.WriteLine("Не найдена");
            }
            Console.WriteLine("Запросы");
            Console.WriteLine(AverageSummOfCreditCardsSecond(list));
            Console.WriteLine(SummOfCashBackSecond(list));
            Console.WriteLine(SummInAllDebetsCardsSecond(list));
            Console.WriteLine("Перебор");
            foreach (BankCard card in list)
            {
                Console.WriteLine(card.ToString());
            }
            Console.WriteLine("Клонирование");
            LinkedList<BankCard> clonnedArraySecond = new LinkedList<BankCard>();
            foreach (BankCard card in list)
            {
                clonnedArraySecond.AddLast(card);
            }
            foreach(BankCard card in clonnedArraySecond) { Console.WriteLine(card); }
            Console.WriteLine("Сортировка по номеру карты");
            List<BankCard> sortedList = clonnedArraySecond.ToList();
            sortedList.Sort();

            LinkedList<BankCard> sortedCollection = new LinkedList<BankCard>(sortedList);

            Console.WriteLine("Отсортированный список");
            foreach (BankCard card in sortedCollection)
            {
                Console.WriteLine(card);
            }
            Console.WriteLine("Бинарный посик в сортированном списке");
            int indexSecond = sortedList.BinarySearch(searchingCardSecond);
            if(index >= 0)
            {
                Console.WriteLine($"Карта найдена в позиции {index}");
                searchingCardSecond.Show();
            }
            else
            {
                Console.WriteLine("Не найдена");
            }
            Console.WriteLine("Часть 3");
            TestCollections testCollections = new TestCollections();

            //Измерения времени поиска
            testCollections.MeasureSearhTime();
        }   
    }
}