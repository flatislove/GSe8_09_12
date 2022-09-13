//Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию 
//элементы каждой строки двумерного массива.

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

int[,] SortRowArray(int[,] array)
{
    int[] sortArray = new int[array.GetLength(1)];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            sortArray[j] = array[i, j];
        }
        Array.Sort(sortArray);
        array = InsertSortRow(array, i, sortArray);
    }
    return array;
}

int[,] InsertSortRow(int[,] array, int numberRow, int[] rowArray)
{
    for (int i = 0; i < array.GetLength(1); i++)
    {
        array[numberRow, i] = rowArray[i];
    }
    return array;
}

Console.Clear();
int[,] array = FillArray(CreateArray(ReadNumber(), ReadNumber()), 0, 10);
PrintArray(array);
PrintArray(SortRowArray(array));