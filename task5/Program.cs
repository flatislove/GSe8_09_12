//Напишите программу, которая заполнит спирально массив 4 на 4. 

Console.Clear();

int[,] array = new int[ReadNumber("(Строки)"), ReadNumber("Столбцы")];
int countNumbers = array.GetLength(0) * array.GetLength(1);
int currentValue = 1;
int iCursor = 0;
int jCursor = 0;
int fillRow = 0;
int fillColumn = 0;
int direction = 0;
PrintArray(FillArray(array));

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

int[,] FillArray(int[,] array)
{
    while (currentValue <= countNumbers)
    {
        switch (ChangeDirection(direction))
        {
            case 0:
                for (int j = jCursor; j < array.GetLength(1) - fillColumn; j++)
                {
                    array[iCursor, j] = currentValue;
                    currentValue++;
                    jCursor = j;
                }
                iCursor++;
                direction++;
                break;
            case 1:
                for (int i = iCursor; i < array.GetLength(0) - fillRow; i++)
                {
                    array[i, jCursor] = currentValue;
                    currentValue++;
                    iCursor = i;
                }
                jCursor--;
                direction++;
                fillRow++;
                break;
            case 2:
                for (int j = jCursor; j >= fillColumn; j--)
                {
                    array[iCursor, j] = currentValue;
                    currentValue++;
                    jCursor = j;
                }
                iCursor--;
                direction++;
                break;
            case 3:
                for (int i = iCursor; i >= fillRow; i--)
                {
                    array[i, jCursor] = currentValue;
                    currentValue++;
                    iCursor = i;
                }
                jCursor++;
                direction++;
                fillColumn++;
                break;
        }
    }
    return array;
}
int ChangeDirection(int direction)
{
    return direction % 4;
}

void PrintArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if (array[i, j] > 9 && array[i, j] < 100)
            {
                Console.Write(array[i, j] + "  ");
            }
            else if (array[i, j] > 99)
            {
                Console.Write(array[i, j] + " ");
            }
            else Console.Write(array[i, j] + "   ");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}