using UnityEngine;

public class GemDetection : MonoBehaviour
{
    public void GemDetector<T>(T[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                // Check each cell as potential top-left corner of a rectangle
                for (int height = 2; i + height <= rows; height++)
                {
                    for (int width = 2; j + width <= cols; width++)
                    {
                        // Check if all cells within the rectangle have the same value
                        T rectangleValue = matrix[i, j];
                        bool isRectangle = true;

                        for (int x = i; x < i + height; x++)
                        {
                            for (int y = j; y < j + width; y++)
                            {
                                if (matrix[x, y].Equals(rectangleValue))
                                {
                                    isRectangle = false;
                                    break;
                                }
                            }
                            if (!isRectangle) break;
                        }

                        if (isRectangle)
                        {
                            Debug.Log("Rectangle of size " + height + "x" + width + "found at " + i + "," + j);
                            // Optionally, you can perform further actions here
                        }
                    }
                }
            }
        }
    }
}
