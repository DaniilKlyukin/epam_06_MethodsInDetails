# Methods in details_06
**Задание 1.**
Расширить функциональную возможность типа System.Double, реализовав возможность получения строкового представления вещественного числа в формате IEEE 754. Готовые классы-конверторы не использовать. Разработать модульные тесты. 
<br/>[Решение](https://github.com/KaBaN4iK357/epam_06_MethodsInDetails/blob/master/TasksLibrary/TasksLibrary/DoubleExtensions.cs)
[Тесты](https://github.com/KaBaN4iK357/epam_06_MethodsInDetails/blob/master/MethodsInDetailsTests/DoubleExtensionsTests.cs)
<br/>
**Задание 2.**
Разработать класс, позволяющий выполнять вычисления НОД по алгоритму Евклида для двух, трех и т.д. целых чисел (http://en.wikipedia.org/wiki/Euclidean_algorithm , https://habrahabr.ru/post/205106/, https://habrahabr.ru/post/205106/ ). Методы класса помимо вычисления НОД должны предоставлять дополнительную возможность определения значение времени, необходимое для выполнения расчета. Добавить к разработанному классу методы, реализующие алгоритм Стейна (бинарный алгоритм Евклида) для расчета НОД двух, трех и т.д. целых чисел (http://en.wikipedia.org/wiki/Binary_GCD_algorithm, https://habrahabr.ru/post/205106/ ), а также методы, предоставляющие дополнительную возможность определения значение времени, необходимое для выполнения расчета. Рассмотреть различные возможности реализации методов, возвращающих время вычисления НОД. Разработать модульные тесты.
<br/>[Решение](https://github.com/KaBaN4iK357/epam_06_MethodsInDetails/blob/master/TasksLibrary/TasksLibrary/GreatestCommonDivisor.cs)
<br/>[Тесты алгоритма Евклида](https://github.com/KaBaN4iK357/epam_06_MethodsInDetails/blob/ababe2b52fd6e4cdba398d5fb02e93a58e9063a9/MethodsInDetailsTests/GreatestCommonDivisorTests.cs#L11)
<br/>
[Тесты алгоритма Стейна](https://github.com/KaBaN4iK357/epam_06_MethodsInDetails/blob/ababe2b52fd6e4cdba398d5fb02e93a58e9063a9/MethodsInDetailsTests/GreatestCommonDivisorTests.cs#L25)
<br/>
**Задание 3.**
Реализовать для null-able типов, дополнительную возможность определения - является ссылка null или нет. Разработать модульные тесты.
<br/>[Решение](https://github.com/KaBaN4iK357/epam_06_MethodsInDetails/blob/master/TasksLibrary/TasksLibrary/NullableTypesExtensions.cs)
[Тесты](https://github.com/KaBaN4iK357/epam_06_MethodsInDetails/blob/master/MethodsInDetailsTests/NullableTypesExtensionsTests.cs)
