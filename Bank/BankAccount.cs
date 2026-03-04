using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace Bank
{
    /// <summary>
    /// Демонстрационный класс банковского счёта.
    /// Позволяет выполнять операции дебета и кредита.
    /// </summary>
    public class BankAccount
    {
        private readonly string m_customerName;
        private double m_balance;

        /// <summary>
        /// Сообщение об ошибке: сумма дебета превышает баланс.
        /// </summary>

        public const string DebitAmountExceedsBalanceMessage = "Debit amount exceeds balance";

        /// <summary>
        /// Сообщение об ошибке: сумма дебета меньше нуля.
        /// </summary>

        public const string DebitAmountLessThanZeroMessage = "Debit amount is less than zero";


        private BankAccount() { }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="BankAccount"/>.
        /// </summary>
        /// <param name="customerName">Имя владельца счёта.</param>
        /// <param name="balance">Начальный баланс счёта.</param>

        public BankAccount(string customerName, double balance)
        {
            m_customerName = customerName;
            m_balance = balance;
        }

        /// <summary>
        /// Возвращает имя владельца счёта.
        /// </summary>
        /// <value>Имя клиента в виде строки.</value>

        public string CustomerName
        {
            get { return m_customerName; }
        }

        /// <summary>
        /// Возвращает текущий баланс счёта.
        /// </summary>
        /// <value>Баланс в виде числа с плавающей точкой.</value>

        public double Balance
        {
            get { return m_balance; }
        }

        /// <summary>
        /// Снимает указанную сумму со счёта (операция дебета).
        /// </summary>
        /// <param name="amount">Сумма для списания. Должна быть положительной и не превышать баланс.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Выбрасывается, если <paramref name="amount"/> превышает баланс или меньше нуля.
        /// </exception>

        public void Debit(double amount)
        {
            if (amount > m_balance)
            {
                throw new System.ArgumentOutOfRangeException("amount", amount, DebitAmountExceedsBalanceMessage);
            }

            if (amount < 0)
            {
                throw new System.ArgumentOutOfRangeException("amount", amount, DebitAmountLessThanZeroMessage);
            }


            m_balance -= amount;
        }

        /// <summary>
        /// Зачисляет указанную сумму на счёт (операция кредита).
        /// </summary>
        /// <param name="amount">Сумма для зачисления. Должна быть положительной.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Выбрасывается, если <paramref name="amount"/> меньше нуля.
        /// </exception>

        public void Credit(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount");
            }

            m_balance += amount;
        }

        /// <summary>
        /// Точка входа приложения. Демонстрирует работу класса <see cref="BankAccount"/>.
        /// </summary>
        public static void Main()
        {
            BankAccount ba = new BankAccount("Mr. Roman Abramovich", 11.99);

            ba.Credit(5.77);
            ba.Debit(11.22);
            Console.WriteLine("Current balance is ${0}", ba.Balance);
            Console.ReadLine();
        }
    }
}
