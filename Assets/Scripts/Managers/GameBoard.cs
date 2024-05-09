using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum BoardID { BoardPlayer1, BoardPlayer2 };

public class GameBoard : MonoBehaviour
{
    [SerializeField] private BoardID ID;

    public BoardID BoardID { get => ID; }

    public readonly int Width = 6;
    public readonly int Height = 15;
    public readonly float CellSize = 0.5f;
    public Vector2 GridOrigin;
    public TMP_Text ScoreText;

    public GameObject[,] _grid;

    public GameObject CurrentGem_1;
    public GameObject CurrentGem_2;

    private int _score;

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

    private void UpdateScore()
    {
        _score += 500;
        GameManager.UpdateScore(ID, _score);
        
        ScoreText.text = GameManager.GetScore(ID).ToString();
    }

    public int GetWidthOfGrid(Vector2 position) => Mathf.FloorToInt((position.x - GridOrigin.x) / CellSize);

    #region  Flood Fill Algorithm

    private void FindAndDestroy(int x, int y, bool[,] visited, string tag)
    {
        if (x < 0 || x >= Width || y < 0 || y >= Height)
            return;

        if (visited[x, y] || _grid[x, y] == null || _grid[x, y].tag != tag)
            return;

        visited[x, y] = true;

        Destroy(_grid[x, y]);
        _grid[x, y] = null;
        UpdateScore();

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

    /*public void DestroyAllGem(GameObject startPoint)
    {
        int x = Mathf.FloorToInt((startPoint.transform.position.x - GridOrigin.x) / CellSize);
        int y = Mathf.FloorToInt((startPoint.transform.position.y - GridOrigin.y) / CellSize);

        string tag = FindAndGetOBJTag(x, y);
        Debug.Log(tag);

        for (int row = 0; row < Width; row++)
        {
            for (int col = 0; col < Height; col++)
            {
                if (_grid[row, col] == null) continue;

                if (_grid[row, col].tag == tag || _grid[row, col].tag == "Diamond")
                {
                    Destroy(_grid[x, y]);
                    _grid[x, y] = null;
                    UpdateScore();
                }
            }
        }
    }

    private string FindAndGetOBJTag(int x, int y)
    {
        if (x < 0 || x >= Width || y < 0 || y >= Height)
            return null;

        if (_grid[x, y - 1] != null)
        {
            return _grid[x, y - 1].gameObject.tag;
        }

        if (_grid[x, y + 1] != null)
        {
            return _grid[x, y + 1].gameObject.tag;
        }

        if (_grid[x + 1, y] != null)
        {
            return _grid[x + 1, y].gameObject.tag;
        }

        if (_grid[x - 1, y] != null)
        {
            return _grid[x - 1, y].gameObject.tag;
        }

        return null;
    }*/

    #endregion
}
