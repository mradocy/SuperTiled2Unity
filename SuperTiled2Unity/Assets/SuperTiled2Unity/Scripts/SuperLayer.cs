using UnityEngine;

namespace SuperTiled2Unity
{
    public class SuperLayer : MonoBehaviour
    {
        [ReadOnly]
        public string m_TiledName;

        [ReadOnly]
        public float m_OffsetX;

        [ReadOnly]
        public float m_OffsetY;

        [ReadOnly]
        public float m_Opacity;

        [ReadOnly]
        public bool m_Visible;

        /// <summary>
        /// Gets a reference to the parent's SuperMap.
        /// </summary>
        public SuperMap SuperMap {
            get {
                if (_superMap == null) {
                    _superMap = this.GetComponentInParent<SuperMap>();
                }

                return _superMap;
            }
        }

        public float CalculateOpacity()
        {
            float opacity = 1.0f;

            foreach (var layer in gameObject.GetComponentsInParent<SuperLayer>())
            {
                opacity *= layer.m_Opacity;
            }

            return opacity;
        }

        private SuperMap _superMap = null;
    }
}
