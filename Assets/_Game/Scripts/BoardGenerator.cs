using UnityEngine;

public class BoardGenerator : MonoBehaviour
{
    public GameObject tilePrefab;
    public int gridSizeX = 4;
    public int gridSizeZ = 4;
    public float tileSpacing = 0.21f;

    void Start()
    {
        GenerateBoard();
    }

    void GenerateBoard()
    {
        for (int x = 0; x < gridSizeX; x++)
        {
            for (int z = 0; z < gridSizeZ; z++)
            {
                Vector3 position = new Vector3(x * tileSpacing, 0, z * tileSpacing);
                GameObject tile = Instantiate(tilePrefab, transform.position + position, Quaternion.identity, transform);
                tile.name = $"Tile_{x}_{z}";

                Tile tileScript = tile.GetComponent<Tile>();
                if (tileScript != null)
                {
                    tileScript.SetCoordinates(x, z);
                }
            }
        }
    }
}
