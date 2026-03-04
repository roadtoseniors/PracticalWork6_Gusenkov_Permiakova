using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Bank;

namespace BankTests
{
    [TestClass]
    public class BankAccountTests
    {

        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Roman Abramovich", beginningBalance);

            // Act
            account.Debit(debitAmount);

            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        [TestMethod]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = -100.00;
            BankAccount account = new BankAccount("Mr. Roman Abramovich", beginningBalance);

            // Act and assert
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => account.Debit(debitAmount));
        }

        [TestMethod]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 20.0;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act
            try
            {
                account.Debit(debitAmount);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                // Assert
                StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
                return;
            }

            Assert.Fail("The expected exception was not thrown.");
        }

        /// <summary>
        /// Тест 4: Проверяет корректное зачисление при допустимой сумме кредита.
        /// Ожидание: баланс увеличивается на указанную сумму.
        /// </summary>
        [TestMethod]
        public void Credit_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            double beginningBalance = 11.99;
            double creditAmount = 5.77;
            double expected = 17.76;
            BankAccount account = new BankAccount("Mr. Roman Abramovich", beginningBalance);

            // Act
            account.Credit(creditAmount);

            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not credited correctly");
        }

        /// <summary>
        /// Тест 5: Проверяет выброс исключения при сумме кредита меньше нуля.
        /// Ожидание: метод выбрасывает ArgumentOutOfRangeException.
        /// </summary>
        [TestMethod]
        public void Credit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 11.99;
            double creditAmount = -50.00;
            BankAccount account = new BankAccount("Mr. Roman Abramovich", beginningBalance);

            // Act and Assert
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() =>
                account.Credit(creditAmount));
        }

        /// <summary>
        /// Тест 6: Проверяет, что зачисление нулевой суммы не изменяет баланс.
        /// Ожидание: баланс остаётся прежним.
        /// </summary>
        [TestMethod]
        public void Credit_WithZeroAmount_BalanceUnchanged()
        {
            // Arrange
            double beginningBalance = 11.99;
            double creditAmount = 0.0;
            BankAccount account = new BankAccount("Mr. Roman Abramovich", beginningBalance);

            // Act
            account.Credit(creditAmount);

            // Assert
            Assert.AreEqual(beginningBalance, account.Balance, 0.001, "Balance should remain unchanged after crediting zero");
        }

    }
}
