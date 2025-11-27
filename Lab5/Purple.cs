using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Purple
    {
        public int[] Task1(int[,] matrix)
        {
            int[] answer = new int[matrix.GetLength(1)];

            // code here

            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                int k = 0;
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (matrix[j, i] < 0)
                    {
                        k++;
                    }
                }    
                answer[i] = k;
            }    

            // end

            return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int minIndex = 0;
                int minValue = matrix[i, 0];

                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < minValue)
                    {
                        minValue = matrix[i, j];
                        minIndex = j;
                    }
                }

                if (minIndex == 0) continue;

                int temp = matrix[i, minIndex];

                for (int j = minIndex; j > 0; j--)
                {
                    matrix[i, j] = matrix[i, j - 1];
                }

                matrix[i, 0] = temp;
            }

            // end

        }
        public int[,] Task3(int[,] matrix)
        {
            int[,] answer = null;

            // code here

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int[,] result = new int[rows, cols + 1];

            for (int i = 0; i < rows; i++)
            {
                int maxIndex = 0;
                int maxValue = matrix[i, 0];

                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, j] > maxValue)
                    {
                        maxValue = matrix[i, j];
                        maxIndex = j;
                    }
                }

                for (int j = 0; j <= maxIndex; j++)
                {
                    result[i, j] = matrix[i, j];
                }

                result[i, maxIndex + 1] = maxValue;

                for (int j = maxIndex + 1; j < cols; j++)
                {
                    result[i, j + 1] = matrix[i, j];
                }
            }

            answer = result;  

            return answer;
        }

        public void Task4(int[,] matrix)
        {

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int maxIndex = 0;
                int maxValue = matrix[i, 0];

                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > maxValue)
                    {
                        maxValue = matrix[i, j];
                        maxIndex = j;
                    }
                }

                int sum = 0;
                int count = 0;

                for (int j = maxIndex + 1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                        count++;
                    }
                }

                if (count == 0) continue;

                int average = sum / count;  

                for (int j = 0; j < maxIndex; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        matrix[i, j] = average;
                    }
                }
            }
        }
        public void Task5(int[,] matrix, int k)
        {

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (k < 0 || k >= cols) return;

            int[] maxElements = new int[rows];

            for (int i = 0; i < rows; i++)
            {
                int max = matrix[i, 0];
                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                    }
                }
                maxElements[rows - 1 - i] = max; 
            }

            for (int i = 0; i < rows; i++)
            {
                matrix[i, k] = maxElements[i];
            }
        }
        public void Task6(int[,] matrix, int[] array)
        {

            if (matrix.GetLength(1) == array.Length)
            {
                int k = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    int maximum = int.MinValue;
                    int index = 0;
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        if (matrix[i, j] > maximum)
                        {
                            maximum = matrix[i, j];
                            index = i;
                        }
                    }
                    if (array[k] > maximum)
                    {
                        matrix[index, j] = array[k];
                    }
                    k++;
                }
            }
        }
        public void Task7(int[,] matrix)
        {

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int[] minElements = new int[rows];

            for (int i = 0; i < rows; i++)
            {
                int min = matrix[i, 0];
                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                    }
                }
                minElements[i] = min;
            }

            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = 0; j < rows - 1 - i; j++)
                {
                    if (minElements[j] < minElements[j + 1])
                    {
                        int tempMin = minElements[j];
                        minElements[j] = minElements[j + 1];
                        minElements[j + 1] = tempMin;

                        for (int k = 0; k < cols; k++)
                        {
                            int temp = matrix[j, k];
                            matrix[j, k] = matrix[j + 1, k];
                            matrix[j + 1, k] = temp;
                        }
                    }
                }
            }
        }

        public int[] Task8(int[,] matrix)
        {
            if (matrix == null) return null;

            int n = matrix.GetLength(0);

            if (n != matrix.GetLength(1)) return null;

            int[] result = new int[2 * n - 1];


            for (int d = 0; d < result.Length; d++)
            {
                int sum = 0;


                if (d < n)
                {
                    int startRow = n - 1 - d;
                    int startCol = 0;

                    for (int i = 0; i <= d; i++)
                    {
                        int row = startRow + i;
                        int col = startCol + i;
                        if (row < n && col < n)
                        {
                            sum += matrix[row, col];
                        }
                    }
                }
                else
                {
                    int startRow = 0;
                    int startCol = d - n + 1;

                    for (int i = 0; i < 2 * n - 1 - d; i++)
                    {
                        int row = startRow + i;
                        int col = startCol + i;
                        if (row < n && col < n)
                        {
                            sum += matrix[row, col];
                        }
                    }
                }

                result[d] = sum;
            }

            return result;
        }
        

        public int[,] Task9(int[,] matrix, int k)
        {

            // code here

            if (k >= matrix.GetLength(0) || matrix.GetLength(0) != matrix.GetLength(1) || k < 0)
            {
                return null;
            }

            int maximum = int.MinValue;
            int max_row = 0;
            int max_col = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (Math.Abs(matrix[i, j]) > maximum)
                    {
                        maximum = Math.Abs(matrix[i, j]);
                        max_row = i;
                        max_col = j;
                    }
                }
            }

            int[] row = new int[matrix.GetLength(0)];
            int[] col = new int[matrix.GetLength(0)];

            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                row[j] = matrix[max_row, j];
            }

            for (int i = max_row; i > k; i--)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    matrix[i, j] = matrix[i - 1, j];
                }
            }

            for (int i = max_row; i < k; i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    matrix[i, j] = matrix[i + 1, j];
                }
            }

            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                matrix[k, j] = row[j];
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                col[i] = matrix[i, max_col];
            }

            for (int j = max_col; j > k; j--)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    matrix[i, j] = matrix[i, j - 1];
                }
            }

            for (int j = max_col; j < k; j++)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    matrix[i, j] = matrix[i, j + 1];
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                matrix[i, k] = col[i];
            }

            // end

            return matrix;
        }
        public int[,] Task10(int[,] A, int[,] B)
        {
            if (A == null || B == null) return null;

            int rowsA = A.GetLength(0);
            int colsA = A.GetLength(1);
            int rowsB = B.GetLength(0);
            int colsB = B.GetLength(1);

            if (colsA != rowsB) return null;

            if (rowsA == 0 || colsA == 0 || colsB == 0)
                return new int[rowsA, colsB]; // Пустая матрица

            int[,] result = new int[rowsA, colsB];

            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < colsB; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < colsA; k++)
                    {
                        sum += A[i, k] * B[k, j];
                    }
                    result[i, j] = sum;
                }
            }

            return result;
        }

        public int[][] Task11(int[,] matrix)
        {
            if (matrix == null) return null;

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            // Создаем список для строк результата
            List<int[]> resultList = new List<int[]>();

            for (int i = 0; i < rows; i++)
            {
                int positiveCount = 0;
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        positiveCount++;
                    }
                }

                int[] positiveElements = new int[positiveCount];
                int index = 0;

                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        positiveElements[index++] = matrix[i, j];
                    }
                }

                resultList.Add(positiveElements);
            }

            return resultList.ToArray();
        }
        public int[,] Task12(int[][] array)
        {
            if (array == null) return null;

            int totalElements = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != null)
                {
                    totalElements += array[i].Length;
                }
            }

            if (totalElements == 0) return new int[0, 0];

            int n = (int)Math.Ceiling(Math.Sqrt(totalElements));

            int[,] matrix = new int[n, n];

            int currentRow = 0;
            int currentCol = 0;
            int elementIndex = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != null)
                {
                    for (int j = 0; j < array[i].Length; j++)
                    {
                        if (currentRow < n && currentCol < n)
                        {
                            matrix[currentRow, currentCol] = array[i][j];
                            elementIndex++;

                            currentCol++;
                            if (currentCol >= n)
                            {
                                currentCol = 0;
                                currentRow++;
                            }
                        }
                    }
                }
            }


            return matrix;
        }
    }
}