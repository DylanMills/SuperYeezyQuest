using UnityEngine;

[System.Serializable]
public class Board : MonoBehaviour
{
    private Vector2[] _tilePositions = new Vector2[89];
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
        for (n = 1; n <= 88; n++)
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

            if (id == 5 || id == 11 || id == 75 || id == 76 || id == 84 || id == 85)
            {
                current = prev + new Vector2(0f, 1f); //north
            }
            else if (id == 24 || id == 25 || id == 26)
            {
                current = prev + new Vector2(1f, 0f); //east
            }
            else if (id == 49 || id == 50 || id == 57 || id == 58 || id == 63 || id == 64 || id == 69 
                            || id == 70 || id == 71 || id == 72 || id == 79 || id == 80 || id == 81)
            {
                current = prev + new Vector2(0f, -1f); //south 49 50 57 58 63 64 69 70 71 72 79 80 81
            }
            else if (id == 30 || id == 31 || id == 32 || id == 33 || id == 34 || id == 59 || id == 60 
                             || id == 61 || id == 62 || id == 73 || id == 74 || id == 77 || id == 78 
                             || id == 82 || id == 83 || id >85)
            {
                current = prev + new Vector2(-1f, 0f); //west 30-34 59 - 62, 73 74, 77,78,82,83,86,87,88
            }
            else if (id >= 1 && id <= 17)
            {
                current = prev + new Vector2(-1f, 0f); //west
            }
            else if (id >= 18 && id <= 38)
            {
                current = prev + new Vector2(0f, 1f); //north
            }
            else if (id >= 39 && id <= 68)
            {
                current = prev + new Vector2(1f, 0f); //east
            }
        }

        public Vector2 Vec()
        {
            Debug.Log(id);
            return current;
        }
    }
}