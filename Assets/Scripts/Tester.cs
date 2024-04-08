using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Tester : MonoBehaviour
{
    [SerializeField] private GameObject _gem;
    private GameObject newObject;
    private List<IGemBehavior> _gemBehaviors = new List<IGemBehavior>();
    public Tilemap tilemap;
    public Tile tile;

    private void Start()
    {
        tilemap.size = new Vector3Int(10, 5, 0);
        tilemap.SetTile(new Vector3Int(0,0,0), tile);
    }

    private void SpawnGem()
    {
        newObject = Instantiate(_gem, new Vector3(-4.5f, 4.75f, 0), Quaternion.identity);

        newObject.AddComponent<Gem>();
        newObject.AddComponent<FirstPlayerController>();
        newObject.AddComponent<ObjectMovements>();

        ApplyGemBehavior();
    }

    private void ApplyGemBehavior()
    {
        _gemBehaviors.Add(newObject.AddComponent<NormalGem>());
        _gemBehaviors.Add(newObject.AddComponent<CrashGem>());

        int index = Random.Range(0, _gemBehaviors.Count);

        newObject.GetComponent<Gem>().ApplyBehavior(_gemBehaviors[index], GemColorType.Red);
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Spawn"))
            SpawnGem();
    }
}
