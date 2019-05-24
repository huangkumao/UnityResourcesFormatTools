using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

namespace URFT
{
    public class RuleManager
    {
        public static string SavePath = @"Assets/Editor/URFT/SaveAssets/";
        private static string _SavePath = @"/Editor/URFT/SaveAssets/";
        public static List<BaseRule> sRules = new List<BaseRule>(8);

        public static void LoadAllRules()
        {
            sRules.Clear();
            var R = Directory.GetFiles(Application.dataPath + _SavePath, "*.asset");
            foreach (var s in R)
            {
                string file = s.Substring(s.LastIndexOf("/") + 1);
                sRules.Add(BaseRule.LoadRule(file));
            }
        }
    }
}
