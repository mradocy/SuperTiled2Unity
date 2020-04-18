namespace SuperTiled2Unity {

    [System.Serializable]
    public struct IdSuperTilePair {
        public IdSuperTilePair(int id, SuperTile superTile) {
            _id = id;
            _superTile = superTile;
        }
        public int _id;
        public SuperTile _superTile;
    }
}