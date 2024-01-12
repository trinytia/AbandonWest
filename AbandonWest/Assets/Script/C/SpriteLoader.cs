using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class SpriteLoader : MonoBehaviour
{
    public Sprite GetSpriteByName(string spriteName)
    {
        string[] guids = UnityEditor.AssetDatabase.FindAssets("t:sprite");
        foreach (string guid in guids)
        {
            string path = UnityEditor.AssetDatabase.GUIDToAssetPath(guid);
            string spriteAssetName = System.IO.Path.GetFileNameWithoutExtension(path);
            if (spriteAssetName == spriteName)
            {
                return UnityEditor.AssetDatabase.LoadAssetAtPath<Sprite>(path);
            }
        }
        return null;
    }
}

public class CustomNode : MonoBehaviour
{
    [UnityEngine.Scripting.Preserve]
    public string spriteName;

    [UnityEngine.Scripting.Preserve]
    public Sprite GetSpriteByName(string spriteName)
    {
        var loader = new SpriteLoader();
        return loader.GetSpriteByName(spriteName);
    }
}
