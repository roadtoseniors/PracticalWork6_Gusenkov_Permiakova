# Практическая работа №6 — Создание автоматизированных Unit-тестов

> **Метод:** «Белого ящика»  
> **Среда разработки:** Microsoft Visual Studio  
> **Язык:** C# (.NET)  
> **Часть:** 1
> **Выполнили:** Пермякова М.И. Гусенков В.А.
> **Группа:** 3ИСИП-323
> **Преподаватель:** Аксенова Т.Г.

---

## Цель работы

Провести тестирование разработанных программных модулей с использованием средств автоматизации Microsoft Visual Studio методом «белого ящика».

---

## Структура решения

```
Bank.sln
├── Bank/
│   └── BankAccount.cs        # Тестируемый класс банковского счёта
└── BankTests/
    └── BankAccountTests.cs   # Класс с модульными тестами
```

---
## Результаты обозревателя тестов

```
✅ Debit_WithValidAmount_UpdatesBalance
✅ Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange
✅ Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange
✅ Credit_WithValidAmount_UpdatesBalance
✅ Credit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange
✅ Credit_WithZeroAmount_BalanceUnchanged

Итого: 6 / 6 тестов пройдено успешно
```

---

## Вывод

В ходе практической работы был реализован набор из 6 автоматизированных unit-тестов для класса `BankAccount` методом «белого ящика».

Тест `Debit_WithValidAmount_UpdatesBalance` первоначально завершался с **ошибкой**, поскольку в исходном коде метода `Debit` строка `m_balance += amount` прибавляла сумму к балансу вместо вычитания. Тест обнаружил несоответствие ожидаемого результата (`7.44`) фактическому (`16.54`), что указало на баг. После исправления на `m_balance -= amount` тест был пройден успешно.

Тесты с проверкой исключений (`ShouldThrowArgumentOutOfRange`) подтвердили, что метод `Debit` корректно разграничивает два случая ошибки — превышение баланса и отрицательная сумма — благодаря использованию констант `DebitAmountExceedsBalanceMessage` и `DebitAmountLessThanZeroMessage`.

Методы для `Credit` реализованы самостоятельно и охватывают три сценария: корректное зачисление, зачисление отрицательной суммы и зачисление нуля. Все тесты пройдены успешно, что подтверждает корректность реализации обоих методов.

---
