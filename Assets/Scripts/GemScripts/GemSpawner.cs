using UnityEngine;

public class GemSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _normalGemLists;
    [SerializeField] private GameObject[] _crashGemLists;
    [SerializeField] private GameObject _diamond;

    public GameObject SpawnPoint;

    public GameBoard Board;

    public SpriteRenderer GemPreview_Top;
    public SpriteRenderer GemPreview_Down;

    private byte _diamondGemCount = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
            SpawnGem(Board);
    }

    public void SpawnGem(GameBoard board)
    {
        GameObject gem_1 = RandomGem(SpawnPoint.transform.position, true);
        GameObject gem_2 = RandomGem(new Vector2(SpawnPoint.transform.position.x, SpawnPoint.transform.position.y + 0.5f), false);

        gem_2.transform.SetParent(gem_1.transform, true);

        gem_1.AddComponent<GemController>();

        GemFallingHandler gem_1Falling = gem_1.GetComponent<GemFallingHandler>();
        gem_1Falling.Spawner = this;

        GemFallingHandler gem_2Falling = gem_2.GetComponent<GemFallingHandler>();
        gem_2Falling._isChildren = true;
        gem_2Falling.enabled = false;
        gem_2Falling.Spawner = this;

        gem_1.GetComponent<Gem>().boardID = board.BoardID;
        gem_2.GetComponent<Gem>().boardID = board.BoardID;

        board.CurrentGem_1 = gem_1;
        board.CurrentGem_2 = gem_2;

        gem_1.GetComponent<GemController>().Board = board;

        GemPreview_Down.sprite = gem_1.GetComponent<SpriteRenderer>().sprite;
        GemPreview_Top.sprite = gem_2.GetComponent<SpriteRenderer>().sprite;
    }

    private GameObject RandomGem(Vector2 position, bool isFirstGem)
    {
        if (_diamondGemCount >= 25 && isFirstGem)
        {
            _diamondGemCount = 0;
            return Instantiate(_diamond, position, Quaternion.identity);
        }

        _diamondGemCount++;

        int rnd = Random.Range(0, 100);

        return rnd < 80 ?
            Instantiate(_normalGemLists[Random.Range(0, _normalGemLists.Length)], position, Quaternion.identity) :
            Instantiate(_crashGemLists[Random.Range(0, _crashGemLists.Length)], position, Quaternion.identity);
    }
}
