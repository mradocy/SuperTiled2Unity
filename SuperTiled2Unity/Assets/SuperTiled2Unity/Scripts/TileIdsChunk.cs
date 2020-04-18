using System.Collections.Generic;

namespace SuperTiled2Unity {

    [System.Serializable]
    public struct TileIdsChunk {
        public int _x;
        public int _y;
        public int _width;
        public int _height;

        public List<uint> _tileIds;
    }
}