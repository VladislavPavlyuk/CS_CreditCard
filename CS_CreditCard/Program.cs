/*
    Делегаты и события
Создайте класс «Кредитная карточка».
Класс должен содержать:
• Номер карты;
• ФИО владельца;
• Срок действия карты;
• PIN;
• Кредитный лимит;
• Сумма денег.
Создайте необходимый набор методов класса.
Реализуйте события для следующих ситуаций:
• Пополнение счёта;
• Расход денег со счёта;
• Старт использования кредитных денег;
• Достижение заданной суммы денег;
• Смена PIN.
В клиентской части программы продемонстрируйте работу с классом «Кредитная карточка».
 */

using CS_CreditCard;
using System;

namespace Delegate
{
 
    public delegate void CreditCardStateHandler(string message);

    class Program
    {
        static void Main(string[] args)
        {
            CreditCard card = new CreditCard("1111 2222 3333 4444", "Vladislav Pavlyuk", "01/01/2024", null, 0, 50);

            card.del += Color_Message;

            card.Put(150);

            card.Withdraw(100);

            card.Put(50);

            card.Withdraw(150);

            card.Withdraw(50);

            card.Put(150);
        }

        private static void Color_Message(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}

