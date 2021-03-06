﻿using SuperTiled2Unity;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TestScript : MonoBehaviour {

    /// <summary>
    /// Called by Unity when the script instance is being loaded.
    /// </summary>
    private void Awake() {
            
    }

    /// <summary>
    /// Called by Unity on the frame when a script is enabled just before any of the Update methods are called the first time.
    /// </summary>
    private void Start() {

        SuperTileLayer[] superTileLayers = FindObjectsOfType<SuperTileLayer>();
        SuperTileLayer testTileIdLayer = superTileLayers.FirstOrDefault(stl => stl.gameObject.name == "TestTileId");
        int tileId = testTileIdLayer.GetTileId(0, 0);
        Debug.Log(tileId);
        SuperTile customTile = testTileIdLayer.SuperMap.GetCustomTile(tileId);
        string propVal = customTile.GetPropertyValueAsString("testProp");
        Debug.Log(propVal);
    }

    /// <summary>
    /// Called by Unity every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update() {
            
    }
}