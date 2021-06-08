namespace MoTools
{
    public struct Vector2Int
    {
        public int X;
        public int Y;

        public Vector2Int(int value)
        {
            X = value;
            Y = value;
        }
        public Vector2Int(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public struct Vector3Int
    {
        public int X;
        public int Y;
        public int Z;

        public Vector3Int(int value)
        {
            X = value;
            Y = value;
            Z = value;
        }
        public Vector3Int(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }

    public struct Vector4Int
    {
        public int X;
        public int Y;
        public int Z;
        public int W;

        public Vector4Int(int value)
        {
            X = value;
            Y = value;
            Z = value;
            W = value;
        }
        public Vector4Int(int x, int y, int z, int w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }
    }
}
