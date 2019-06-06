using System;
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
        public static string AssetsSavedPath = @"Assets/URFT/SaveAssets/";
        private static string LoadPath = Application.dataPath + @"/URFT/SaveAssets/";
        public static List<BaseRule> sRules = new List<BaseRule>(8);

        public static void LoadAllRules()
        {
            sRules.Clear();
            var R = Directory.GetFiles(LoadPath, "*.asset");
            foreach (var s in R)
            {
                string file = s.Substring(s.LastIndexOf("/", StringComparison.Ordinal) + 1);
                var _Rule = BaseRule.LoadRule(file);
                if(_Rule != null)
                    sRules.Add(_Rule);
            }
        }
    }
}
