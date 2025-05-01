using UnityEngine;

public class Tile : MonoBehaviour
{
    public int x, z;

    public void SetCoordinates(int x, int z)
    {
        this.x = x;
        this.z = z;
    }
}
