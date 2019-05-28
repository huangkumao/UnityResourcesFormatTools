using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using System.IO;

namespace URFT
{
    public enum RuleType
    {
        None = 0,
        Tex = 1,    //贴图
        Model = 2,  //模型
    }

    public class ResourceFormatWindow : EditorWindow
    {
        private static ResourceFormatWindow sWnd = null;
        public static bool Reload = false;

        [MenuItem("URFT/Open &1")]
        public static void OpenWnd()
        {
            if (sWnd == null)
            {
                RuleManager.LoadAllRules();
                Reload = false;
                sWnd = EditorWindow.GetWindowWithRect<ResourceFormatWindow>(new Rect(0, 0, 650, 400), false, "URFT",
                    true);
                sWnd.Show();
            }
        }

        private Vector2 m_ScrollPosition = Vector2.zero;
        //窗体渲染
        public void OnGUI()
        {
            if (Reload)
            {
                Reload = false;
                RuleManager.LoadAllRules();
            }
            
            GUI.backgroundColor = Color.gray;
            GUI.color = Color.white;
            GUILayout.Label("规则 :", EditorStyles.boldLabel);
            EditorGUILayout.BeginVertical();

            //Scroll
            GUILayout.BeginArea(new Rect(4, 20, 640, 303));
            GUI.color = Color.blue;
            GUILayout.Label("-----------------------------------------------------------------------------------------------------------------------------");
            GUI.color = Color.yellow;
            GUILayout.Label("规则名(RuleName):    路径(EffectPath):            导入生效(EffectImport):   类型(Type):");

            m_ScrollPosition = GUILayout.BeginScrollView(m_ScrollPosition);
            
            foreach (var rule in RuleManager.sRules)
            {
                GUILayout.BeginHorizontal();
                GUI.color = Color.white;

                //选择状态
                rule.Selected = EditorGUILayout.Toggle("", rule.Selected, GUILayout.Width(24));
                //规则名
                EditorGUILayout.LabelField(rule.RuleName, GUILayout.Width(50));
                //路径
                EditorGUILayout.TextField(rule.RulePath, GUILayout.Width(240));
                //导入自动生效
                GUILayout.Label("", GUILayout.Width(18));
                EditorGUILayout.Toggle("", rule.EffectOnImport, GUILayout.Width(30));
                //规则类型
                EditorGUILayout.LabelField(rule.RuleType.ToString(), GUILayout.Width(40));

                GUI.color = Color.green;
                if (GUILayout.Button("修改(Change)", GUILayout.Height(24), GUILayout.Width(100)))
                {
                    RuleWindow.OpenWnd(rule);
                }
                GUI.color = Color.red;
                if (GUILayout.Button("应用(Apply)", GUILayout.Height(24), GUILayout.Width(100)))
                {
                    rule.ApplyRule();
                }

                GUILayout.EndHorizontal();
            }
            GUILayout.EndScrollView();
            GUI.color = Color.blue;
            GUILayout.Label("-----------------------------------------------------------------------------------------------------------------------------");
            GUILayout.EndArea();

            GUI.color = Color.cyan;
            //Btn
            GUILayout.BeginArea(new Rect(6, 328, 640, 70));
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("增加规则(Add Rule)", GUILayout.Height(64)))
            {
                RuleWindow.OpenWnd();
            }
            GUILayout.Button("应用选中(Apply Selected)", GUILayout.Height(64));
            GUILayout.EndHorizontal();
            GUILayout.EndArea();

            EditorGUILayout.EndVertical();
            this.Repaint();
        }
    }
}
