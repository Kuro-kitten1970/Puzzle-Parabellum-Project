using System.Collections.Generic;
using UnityEngine;
public enum BoardID { BoardPlayer1, BoardPlayer2 };

public class GameBoard : MonoBehaviour
{
    [SerializeField] private BoardID ID;

    public BoardID BoardID { get => ID; }
    public byte DiamondGemCount { get => _diamondGemCount; set => _diamondGemCount = value; }

    public readonly int Width = 6;
    public readonly int Height = 15;
    public readonly float CellSize = 0.5f;
    public Vector2 GridOrigin = new Vector2(-5.75f, 0.25f);

    public GameObject[,] _grid;

    public GameObject CurrentGem_1;
    public GameObject CurrentGem_2;

    private byte _diamondGemCount = 0;

    void Start()
    {
        _grid = new GameObject[Width, Height];
    }

    public bool IsValidPosition(Vector2 position)
    {
        int x = Mathf.FloorToInt((position.x - GridOrigin.x) / CellSize);
        int y = Mathf.FloorToInt((position.y - GridOrigin.y) / CellSize);

        if (x >= 0 && x < Width && y >= 0 && y < Height)
        {
            if (_grid[x, y] != null) return false;

            return true;
        }

        return false;
    }

    public void AddToGrid(GameObject gem, Vector2 position)
    {
        if (IsValidPosition(position))
        {
            int x = Mathf.FloorToInt((position.x - GridOrigin.x) / CellSize);
            int y = Mathf.FloorToInt((position.y - GridOrigin.y) / CellSize);

            _grid[x, y] = gem;
            gem.transform.position = new Vector3(position.x, position.y, 0f);
        }
    }

    public void RemoveFromGrid(GameObject gem, Vector2 position)
    {
        int x = Mathf.FloorToInt((position.x - GridOrigin.x) / CellSize);
        int y = Mathf.FloorToInt((position.y - GridOrigin.y) / CellSize);

        _grid[x, y] = null;
    }

    public int GetWidthOfGrid(Vector2 position) => Mathf.FloorToInt((position.x - GridOrigin.x) / CellSize);

    #region  DFS Algorithm

    private void FindAndDestroy(int x, int y, bool[,] visited, string tag)
    {
        if (x < 0 || x >= Width || y < 0 || y >= Height)
            return;

        if (visited[x, y] || _grid[x, y] == null || _grid[x, y].tag != tag)
            return;

        visited[x, y] = true;

        Destroy(_grid[x, y]);
        _grid[x, y] = null;

        FindAndDestroy(x + 1, y, visited, tag);
        FindAndDestroy(x - 1, y, visited, tag);
        FindAndDestroy(x, y + 1, visited, tag);
        FindAndDestroy(x, y - 1, visited, tag);
    }

    public void DestroyConnectedGem(GameObject startPoint)
    {
        int x = Mathf.FloorToInt((startPoint.transform.position.x - GridOrigin.x) / CellSize);
        int y = Mathf.FloorToInt((startPoint.transform.position.y - GridOrigin.y) / CellSize);

        bool[,] visited = new bool[Width, Height];
        FindAndDestroy(x, y, visited, startPoint.tag);
    }

    #endregion
}
