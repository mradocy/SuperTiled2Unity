using System.Collections.Generic;
using UnityEngine;

namespace SuperTiled2Unity
{
    public class SuperTileLayer : SuperLayer
    {
        /// <summary>
        /// Gets the id of the tile at the given coordinates.
        /// Returns 0 if the id could not be found.
        /// </summary>
        /// <param name="x">x coordinate</param>
        /// <param name="y">y coordinate</param>
        /// <returns>Tile id</returns>
        public uint GetTileId(int x, int y) {
            foreach (TileIdsChunk chunk in _chunks) {
                if (x < chunk._x || x >= chunk._x + chunk._width ||
                    y < chunk._y || y >= chunk._y + chunk._height)
                    continue;

                int chunkX = x - chunk._x;
                int chunkY = y - chunk._y;
                return chunk._tileIds[chunkY * chunk._width + chunkX];
            }

            return 0;
        }

        public void InternalAddTileIdsChunk(TileIdsChunk chunk) {
            _chunks.Add(chunk);
        }

        [SerializeField, HideInInspector]
        private List<TileIdsChunk> _chunks = new List<TileIdsChunk>();
    }
}
