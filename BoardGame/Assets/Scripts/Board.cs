using UnityEngine;

[System.Serializable]
public class Board : MonoBehaviour
{
    private Vector2[] _tilePositions = new Vector2[88];
    private Vector2 _default = new Vector2(8.5f, -6.5f);

    public Vector2[] GetTilePositions()
    {
        return _tilePositions;
    }

    public void InitTilePositions()
    {
        int n = 0;
        Vector2 temp = new Tile(_default).Vec();
        _tilePositions[n] = temp;
        for (n = 1; n <= 87; n++)
        {
            _tilePositions[n] = new Tile(_tilePositions[n - 1]).Vec();
        }
    }

    public class Tile
    {
        public static int id = 0;
        private Vector2 prev;
        private Vector2 current;

        public Tile(Vector2 previous)
        {
            id++;
            prev = previous;

            if ((id >= 1 && id <= 7) || (id >= 10 && id <= 15) || (id >= 19 && id <= 22) || (id >= 43 && id <= 48) || (id >= 68 && id <= 71) || (id >= 82))
            {
                current = prev + new Vector2(-1f, 0f); //west
            }
            else if ((id >= 8 && id <= 9) || (id >= 23 && id <= 32) || (id >= 40 && id <= 42) || (id >= 49 && id <= 50))
            {
                current = prev + new Vector2(0f, 1f); //north
            }
            else if ((id >= 33 && id <= 39) || (id >= 51 && id <= 64) || (id >= 75 && id <= 78))
            {
                current = prev + new Vector2(1f, 0f); //east
            }
            else
            {
                current = prev + new Vector2(0f, -1f); //south
            }
        }

        public Vector2 Vec()
        {
            Debug.Log(id);
            return current;
        }
    }
}