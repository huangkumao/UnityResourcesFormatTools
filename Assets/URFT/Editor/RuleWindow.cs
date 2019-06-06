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
                sRule = new TextureRule();
                sNew = true;
            }
            else
            {
                sRule = Rule;
                sNew = false;
            }

            sWnd = GetWindowWithRect<RuleWindow>(new Rect(0, 0, 600, 500), false, sNew ? "CreateRule" : sRule.RuleName, true);
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
            GUILayout.BeginArea(new Rect(4, 16, 592, 440));
            GUILayout.Label("-----------------------------------------------------------------------------------------------------------------------------");
            GUI.color = Color.blue;
            m_ScrollPosition = GUILayout.BeginScrollView(m_ScrollPosition);
            GUI.color = Color.white;

            //规则名
            GUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("规则名(RuleName) : ", EditorStyles.boldLabel, GUILayout.Width(120));
            sRule.RuleName = EditorGUILayout.TextField(sRule.RuleName);
            GUILayout.EndHorizontal();

            //类型
            GUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("类型(RuleType) : ", EditorStyles.boldLabel, GUILayout.Width(120));
            sRule.RuleType = (RuleType)EditorGUILayout.EnumPopup("", sRule.RuleType);
            GUILayout.EndHorizontal();

            //路径
            GUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("路径(RulePath) : ", EditorStyles.boldLabel, GUILayout.Width(120));
            sRule.RulePath = EditorGUILayout.TextField(sRule.RulePath);
            GUILayout.EndHorizontal();
            if (GUILayout.Button("...选择路径(SelectPath)"))
            {
                if (string.IsNullOrEmpty(sRule.RulePath))
                    sRule.RulePath = Application.dataPath;
                sRule.RulePath = EditorUtility.OpenFolderPanel("选择路径(SelectPath)", sRule.RulePath, "");
            }

            //导入生效
            GUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("导入生效(EffectOnImport) : ", EditorStyles.boldLabel, GUILayout.Width(180));
            sRule.EffectOnImport = EditorGUILayout.Toggle("", sRule.EffectOnImport);
            GUILayout.EndHorizontal();

            //过滤类型
            GUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("过滤类型(FilterType) : ", EditorStyles.boldLabel, GUILayout.Width(120));
            sRule.FilterType = (EFilterType)EditorGUILayout.EnumPopup("", sRule.FilterType);
            GUILayout.EndHorizontal();

            if (sRule.FilterType != EFilterType.All)
            {
                //过滤关键字
                GUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("过滤关键字(Filter) : ", EditorStyles.boldLabel, GUILayout.Width(120));
                sRule.Filter = EditorGUILayout.TextField(sRule.Filter);
                GUILayout.EndHorizontal();
            }

            //包含子目录
            GUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("包含子目录(IncludeSubDir) : ", EditorStyles.boldLabel, GUILayout.Width(180));
            sRule.IncludeSubDir = EditorGUILayout.Toggle("", sRule.IncludeSubDir);
            GUILayout.EndHorizontal();

            GUILayout.Label("-----------------------------------------------------------------------------------------------------------------------------");

            if (sRule.RuleType == RuleType.Tex)
                ShowTextureRule();
            else if (sRule.RuleType == RuleType.Model)
                ShowModelRule();

            GUILayout.EndScrollView();
            GUI.color = Color.blue;
            GUILayout.Label("-----------------------------------------------------------------------------------------------------------------------------");
            GUILayout.EndArea();

            GUI.color = Color.cyan;
            //Btn
            GUILayout.BeginArea(new Rect(4, 450, 592, 50));
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("确定/关闭(Confirm)", GUILayout.Height(50)))
            {
                if(sNew)
                    BaseRule.SaveRule(sRule);
                Close();
            }
            GUILayout.EndHorizontal();
            GUILayout.EndArea();

            EditorGUILayout.EndVertical();
            this.Repaint();
        }

        private void ShowTextureRule()
        {
//            sRule.
//            //过滤关键字
//            GUILayout.BeginHorizontal();
//            EditorGUILayout.LabelField("过滤关键字(Filter) : ", EditorStyles.boldLabel, GUILayout.Width(120));
//            sRule.Filter = EditorGUILayout.TextField(sRule.Filter);
//            GUILayout.EndHorizontal();
        }

        private void ShowModelRule()
        {

        }
    }
}
