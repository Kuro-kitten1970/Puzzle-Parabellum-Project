using UnityEngine;

public class GemSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _gemLists;
    [SerializeField] private GameObject _diamond;
    [SerializeField] private float _crashGemPercentage = 70;

    public GameObject SpawnPoint_1;
    public GameObject SpawnPoint_2;

    public SpriteRenderer GemPreview_P1_Top;
    public SpriteRenderer GemPreview_P1_Down;
    public SpriteRenderer GemPreview_P2_Top;
    public SpriteRenderer GemPreview_P2_Down;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
            SpawnGem(BoardID.BoardPlayer1);
        if (Input.GetKeyDown(KeyCode.X))
            SpawnGem(BoardID.BoardPlayer2);
    }

    public void SpawnGem(BoardID boardID)
    {
        GameObject obj_1 = null;
        GameObject obj_2 = null;

        switch (boardID)
        {
            case BoardID.BoardPlayer1:
                RandomGem(SpawnPoint_1.transform.position, boardID, out obj_1, out obj_2);
                GemPreview_P1_Down.sprite = obj_1.GetComponent<SpriteRenderer>().sprite;
                GemPreview_P1_Top.sprite = obj_2.GetComponent<SpriteRenderer>().sprite;
                break;
            case BoardID.BoardPlayer2:
                RandomGem(SpawnPoint_2.transform.position, boardID, out obj_1, out obj_2);
                GemPreview_P2_Down.sprite = obj_1.GetComponent<SpriteRenderer>().sprite;
                GemPreview_P2_Top.sprite = obj_2.GetComponent<SpriteRenderer>().sprite;
                break;
        }

        BoardManager.GetBoard(boardID).CurrentGem_1 = obj_1;
        BoardManager.GetBoard(boardID).CurrentGem_2 = obj_2;

        BoardManager.GetBoard(boardID).DiamondGemCount++;
        if (BoardManager.GetBoard(boardID).DiamondGemCount >= 25) BoardManager.GetBoard(boardID).DiamondGemCount = 0;
    }

    private void RandomGem(Vector2 position, BoardID boardID, out GameObject obj_1, out GameObject obj_2)
    {
        GameObject gem_1 = (BoardManager.GetBoard(boardID).DiamondGemCount < 25) ?
            Instantiate(_gemLists[Random.Range(0, _gemLists.Length)], position, Quaternion.identity) :
            Instantiate(_diamond, position, Quaternion.identity);

        int rnd = Random.Range(0, 100);

        GameObject gem_2 = (rnd > _crashGemPercentage) ?
            Instantiate(_gemLists[Random.Range(0, 4)], new Vector2(position.x, position.y + 0.5f), Quaternion.identity) :
            Instantiate(_gemLists[Random.Range(4, _gemLists.Length)], new Vector2(position.x, position.y + 0.5f), Quaternion.identity);

        gem_2.transform.SetParent(gem_1.transform, true);

        gem_1.AddComponent<GemController>();

        GemFallingHandler gemFallingHandler = gem_2.GetComponent<GemFallingHandler>();
        gemFallingHandler._isChildren = true;
        gemFallingHandler.enabled = false;

        gem_1.GetComponent<Gem>().boardID = boardID;
        gem_2.GetComponent<Gem>().boardID = boardID;

        obj_1 = gem_1;
        obj_2 = gem_2;
    }
}
