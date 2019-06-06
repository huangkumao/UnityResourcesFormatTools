using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace URFT
{
    public enum EFilterType
    {
        All = 0,
        StartWith = 1,  //文件名以xxx开始
        EndWith = 2,    //文件名以xxx结尾
        Suffix =3,      //后缀
        Contain = 4,    //文件包含xxx
    }

    public class BaseRule : ScriptableObject
    {
        [NonSerialized]
        public bool Selected = false;
        [NonSerialized]
        public RuleType RuleType = RuleType.Tex;

        [SerializeField]
        public string RuleName = "BaseRule";
        
        [SerializeField]
        public string RulePath = "";

        [SerializeField]
        public bool EffectOnImport = false;

        [SerializeField]
        public EFilterType FilterType = EFilterType.All;

        [SerializeField]
        public string Filter = "";

        [SerializeField]
        public bool IncludeSubDir = false;

        public virtual void ApplyRule()
        {
            var fullPath = Application.dataPath + "/";
            
            var a = AssetImporter.GetAtPath("Assets/Samples/Textures/01.png");
            if (a as TextureImporter)
            {
                Debug.Log(a.assetPath);
            }
        }
        
        public static void SaveRule(BaseRule pRule)
        {
            AssetDatabase.CreateAsset(pRule, RuleManager.AssetsSavedPath + pRule.RuleName + ".asset");
            AssetDatabase.Refresh();
            ResourceFormatWindow.Reload = true;
        }

        public static BaseRule LoadRule(string pRuleFileName)
        {
            BaseRule _Rule = null;
            var _obj = AssetDatabase.LoadAssetAtPath<ScriptableObject>(RuleManager.AssetsSavedPath + pRuleFileName);
            if (_obj as TextureRule)
            {
                _Rule = (TextureRule) _obj;
                _Rule.RuleType = RuleType.Tex;
            }
            else if (_obj as ModelRule)
            {
                _Rule = (ModelRule)_obj;
                _Rule.RuleType = RuleType.Model;
            }

            return _Rule;
        }

        public static List<string> LoadResPath(string pPath, bool pIncludeSubDir)
        {
            List<string> _List = new List<string>();
            return _List;
        }
    }
}
