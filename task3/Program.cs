//Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.

int ReadNumber(string str)
{
    int number = 0;
    while (true)
    {
        Console.WriteLine("Введите " + str);
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
            if (array[i, j] > 9 && array[i, j] < 100)
            {
                Console.Write(array[i, j] + "   ");
            }
            else if (array[i, j] >= 100)
            {
                Console.Write(array[i, j] + "  ");
            }
            else Console.Write(array[i, j] + "    ");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

int[,] MultiplicationMatrix(int[,] matrixOne, int[,] matrixTwo)
{
    int[,] resultMatrix = new int[matrixOne.GetLength(0), matrixTwo.GetLength(1)];
    if (matrixOne.GetLength(1) == matrixTwo.GetLength(0))
    {
        for (int i = 0; i < matrixOne.GetLength(0); i++)
        {
            for (int j = 0; j < matrixTwo.GetLength(1); j++)
            {
                for (int k = 0; k < matrixOne.GetLength(1); k++)
                {
                    resultMatrix[i, j] += matrixOne[i, k] * matrixTwo[k, j];
                }
            }
        }
        return resultMatrix;
    }
    else
    {
        Console.WriteLine("Несовместимые матрицы");
        return CreateArray(0, 0);
    }
}

Console.Clear();

int[,] matrixA = FillArray(CreateArray(ReadNumber("количество строк (А)"), ReadNumber("количество столбцов (А)")), 0, 10);
int[,] matrixB = FillArray(CreateArray(ReadNumber("количество строк (B)"), ReadNumber("количество столбцов (B)")), 0, 10);
Console.WriteLine("Матрица А:");
PrintArray(matrixA);
Console.WriteLine("Матрица В:");
PrintArray(matrixB);
Console.WriteLine("Результат:");
PrintArray(MultiplicationMatrix(matrixA, matrixB));