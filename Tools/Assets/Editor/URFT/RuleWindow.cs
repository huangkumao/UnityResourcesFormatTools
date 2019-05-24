using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using System.IO;

namespace URFT
{
    public class RuleWindow : EditorWindow
    {
        private static RuleWindow sWnd = null;
        private static BaseRule sRule = null;
        private static bool sNew = false;
        [MenuItem("URFT/Open &1")]
        public static void OpenWnd(BaseRule Rule = null)
        {
            if (sWnd != null)
                return;

            if (Rule == null)
            {
                Rule = new BaseRule();
                sNew = true;
            }
            else
                sNew = false;
        
            RuleManager.LoadAllRules();
            sWnd = GetWindowWithRect<RuleWindow>(new Rect(0, 0, 600, 500), false, sNew ? "CreateRule" : Rule.RuleName, true);
            sWnd.Show();
        }

        private Vector2 m_ScrollPosition = Vector2.zero;
        //窗体渲染
        public void OnGUI()
        {
            GUI.backgroundColor = Color.gray;
            GUI.color = Color.white;
            GUILayout.Label("规则 :", EditorStyles.boldLabel);
            EditorGUILayout.BeginVertical();

            //Scroll
            GUILayout.BeginArea(new Rect(4, 4, 592, 350));
            GUILayout.Label("-----------------------------------------------------------------------------------------------------------------------------");
            GUI.color = Color.blue;
            m_ScrollPosition = GUILayout.BeginScrollView(m_ScrollPosition);

            foreach (var rule in RuleManager.sRules)
            {
                GUILayout.BeginHorizontal();
                GUI.color = Color.white;


                GUILayout.EndHorizontal();
            }
            GUILayout.EndScrollView();
            GUI.color = Color.blue;
            GUILayout.Label("-----------------------------------------------------------------------------------------------------------------------------");
            GUILayout.EndArea();

            GUI.color = Color.cyan;
            //Btn
            GUILayout.BeginArea(new Rect(4, 360, 592, 120));
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("确定(Confirm)", GUILayout.Height(64)))
            {
                Close();
            }
            GUILayout.EndHorizontal();
            GUILayout.EndArea();

            EditorGUILayout.EndVertical();
            this.Repaint();
        }
    }
}
