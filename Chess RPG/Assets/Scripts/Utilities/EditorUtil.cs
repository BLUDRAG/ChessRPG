#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;
using System.IO;
using System.Reflection;

namespace Gamify
{
	public static class EditorUtil
    {
        public static T CreateAsset<T>(string pathOverride = null, bool selectNewAsset = true) where T : ScriptableObject
        {
            T asset = ScriptableObject.CreateInstance<T>();

            string path = (pathOverride != null) ? "Assets/" + pathOverride : AssetDatabase.GetAssetPath(Selection.activeObject);

            if(path == "")
                path = "Assets";
            else if(Path.GetExtension(path) != "")
                path = path.Replace(Path.GetFileName(AssetDatabase.GetAssetPath(Selection.activeObject)), "");

            string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath(path + "/New " + typeof(T).Name + ".asset");
            string dir = Application.dataPath + "/" + path.TrimStart("Assets/".ToCharArray());

            if(!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            AssetDatabase.CreateAsset(asset, assetPathAndName);
            AssetDatabase.SaveAssets();

            if(selectNewAsset)
            {
                EditorUtility.FocusProjectWindow();
                Selection.activeObject = asset;
            }

            return asset;
        }
	}
}
#endif
