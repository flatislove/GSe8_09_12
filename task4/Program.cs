//Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. 
//Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.

int ReadNumber(string str)
{
    int number = 0;
    while (true)
    {
        Console.WriteLine("Введите размерность массива " + str);
        if (!int.TryParse(Console.ReadLine(), out number))
        {
            Console.WriteLine("Некорректный ввод");
        }
        else break;
    }
    return number;
}

int[,,] CreateArray(int rows, int columns, int depht)
{
    int[,,] array = new int[rows, columns, depht];
    return array;
}

int[,,] FillArray(int[,,] array, int min, int max)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
            {
                int value = 0;
                while (true)
                {
                    if (!isContains(array, value = new Random().Next(min, max + 1)))
                    {
                        array[i, j, k] = value;
                        break;
                    }
                }
            }
        }
    }
    return array;
}

void PrintArray(int[,,] array)
{
    Console.WriteLine();
    for (int k = 0; k < array.GetLength(2); k++)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                Console.Write($"{array[i, j, k]}({i},{j},{k})  ");
            }
            Console.WriteLine();
        }
    }
    Console.WriteLine();
}

bool isContains(int[,,] array, int value)
{
    bool contains = false;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
            {
                if (array[i, j, k] == value)
                {
                    contains = true;
                    break;
                }
            }
        }
    }
    return contains;
}

Console.Clear();
PrintArray(FillArray(CreateArray(ReadNumber("x"), ReadNumber("y"), ReadNumber("z")), 10, 99));