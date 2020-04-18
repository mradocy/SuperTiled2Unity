using System.Collections.Generic;

namespace SuperTiled2Unity.Editor
{
    public class GlobalTileDatabase
    {
        private Dictionary<int, SuperTile> m_Tiles = new Dictionary<int, SuperTile>();
        private List<IdSuperTilePair> m_CustomTiles = new List<IdSuperTilePair>();

        public void RegisterTileset(int firstId, SuperTileset tileset)
        {
            foreach (SuperTile tile in tileset.m_Tiles)
            {
                int id = firstId + tile.m_TileId;
                m_Tiles[id] = tile;

                // keep track of tile if it has custom properties
                if (tile.m_CustomProperties != null && tile.m_CustomProperties.Count > 0) {
                    m_CustomTiles.Add(new IdSuperTilePair(id, tile));
                }
            }
        }

        public bool TryGetTile(int tileId, out SuperTile tile)
        {
            return m_Tiles.TryGetValue(tileId, out tile);
        }

        /// <summary>
        /// Gets a list of all the tiles that have custom properties.
        /// </summary>
        public List<IdSuperTilePair> GetCustomTiles() {
            return m_CustomTiles;
        }
    }
}
