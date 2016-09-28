using UnityEngine;
using UnityEditor;
using System;

public class FBX_Import : AssetPostprocessor {

    public const float importScale = 10.0f;

    void OnPreprocessModel()
    {
        ModelImporter importer = assetImporter as ModelImporter;
        importer.globalScale = importScale;
    }
    
}
