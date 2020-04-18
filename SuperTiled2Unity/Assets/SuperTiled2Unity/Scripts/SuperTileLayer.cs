using System.Collections.Generic;
using UnityEngine;

namespace SuperTiled2Unity
{
    public class SuperTileLayer : SuperLayer
    {
        // Flip flags from tiled
        private const uint _tiledHexagonal120Flag = 0x10000000;
        private const uint _tiledDiagonalFlipFlag = 0x20000000;
        private const uint _tiledVerticalFlipFlag = 0x40000000;
        private const uint _tiledHorizontalFlipFlag = 0x80000000;

        /// <summary>
        /// Gets the imported id of the tile at the given coordinates.  Will contain transform flags if sprite was flipped or rotated.
        /// Returns 0 if the id could not be found.
        /// </summary>
        /// <param name="x">x coordinate</param>
        /// <param name="y">y coordinate</param>
        /// <returns>Tile id</returns>
        public uint GetImportedTileId(int x, int y) {
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

        /// <summary>
        /// Gets the id of the tile at the given coordinates, without the transform flags.
        /// Returns 0 if the id could not be found.
        /// </summary>
        /// <param name="x">x coordinate</param>
        /// <param name="y">y coordinate</param>
        /// <returns>Tile id</returns>
        public int GetTileId(int x, int y) {
            uint importedId = this.GetImportedTileId(x, y);
            return (int)(importedId & ~(_tiledHorizontalFlipFlag | _tiledVerticalFlipFlag | _tiledDiagonalFlipFlag | _tiledHexagonal120Flag));
        }

        public void InternalAddTileIdsChunk(TileIdsChunk chunk) {
            _chunks.Add(chunk);
        }

        [SerializeField, HideInInspector]
        private List<TileIdsChunk> _chunks = new List<TileIdsChunk>();
    }
}
