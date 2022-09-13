//Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.

int ReadNumber()
{
    int number = 0;
    while (true)
    {
        Console.WriteLine("Введите размерность массива");
        if (!int.TryParse(Console.ReadLine(), out number))
        {
            Console.WriteLine("Некорректный ввод");
        }
        else break;
    }
    return number;
}

int[,] CreateArray(int rows, int columns)
{
    int[,] array = new int[rows, columns];
    return array;
}

int[,] FillArray(int[,] array, int min, int max)
{
    int[,] fillArray = new int[array.GetLength(0), array.GetLength(1)];
    for (int i = 0; i < fillArray.GetLength(0); i++)
    {
        for (int j = 0; j < fillArray.GetLength(1); j++)
        {
            fillArray[i, j] = new Random().Next(min, max + 1);
        }
    }
    return fillArray;
}
void PrintArray(int[,] array)
{
    Console.WriteLine();
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if (array[i, j] > 9)
            {
                Console.Write(array[i, j] + "  ");
            }
            else Console.Write(array[i, j] + "   ");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

int[] GetSumRowsArray(int[,] array)
{
    int[] sumRowsArray = new int[array.GetLength(0)];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            sumRowsArray[i] += array[i, j];
        }
    }
    return sumRowsArray;
}

void PrintResult(int[] sumRowsArray)
{
    for (int i = 0; i < sumRowsArray.Length; i++)
    {
        Console.WriteLine("Сумма строки " + (i + 1) + " = " + sumRowsArray[i]);
    }
    Console.WriteLine($"Минимальная сумма: Строка {Array.IndexOf(sumRowsArray, sumRowsArray.Min()) + 1}");
}

Console.Clear();
int[,] array = FillArray(CreateArray(ReadNumber(), ReadNumber()), 0, 10);
PrintArray(array);
PrintResult(GetSumRowsArray(array));