using System;
using UnityEditor;
using UnityEngine;

namespace Pathfinding {
	public class AstarUpdateWindow : EditorWindow {
		static GUIStyle largeStyle;
		static GUIStyle normalStyle;
		Version version;
		string summary;
		bool setReminder;

		public static AstarUpdateWindow Init (Version version, string summary) {
			// Get existing open window or if none, make a new one:
			AstarUpdateWindow window = EditorWindow.GetWindow<AstarUpdateWindow>(true, "", true);

			window.position = new Rect(Screen.currentResolution.width/2 - 300, Mathf.Max(5, Screen.currentResolution.height/3 - 150), 600, 400);
			window.version = version;
			window.summary = summary;
#if UNITY_4_6 || UNITY_5_0
			window.title = "New Version of the A* Pathfinding Project";
#else
			window.titleContent = new GUIContent("New Version of the A* Pathfinding Project");
#endif
			return window;
		}

		public void OnDestroy () {
			if (version != null && !setReminder) {
				Debug.Log("Closed window, reminding again tomorrow");
				
			}
		}

		void OnGUI () {
			if (largeStyle == null) {
				largeStyle = new GUIStyle(EditorStyles.largeLabel);
				largeStyle.fontSize = 32;
				largeStyle.alignment = TextAnchor.UpperCenter;
				largeStyle.richText = true;

				normalStyle = new GUIStyle(EditorStyles.label);
				normalStyle.wordWrap = true;
				normalStyle.richText = true;
			}

			if (version == null) {
				return;
			}

			GUILayout.Label("New Update Available!", largeStyle);
			GUILayout.Label("There is a new version of the <b>A* Pathfinding Project</b> available for download.\n" +
				"The new version is <b>" + version + "</b> you have <b>" + AstarPath.Version + "</b>\n\n"+
				"<i>Summary:</i>\n"+summary, normalStyle
				);

			GUILayout.FlexibleSpace();

			GUILayout.BeginHorizontal();
			GUILayout.FlexibleSpace();

			GUILayout.BeginVertical();

			Color col = GUI.color;
			GUI.backgroundColor *= new Color(0.5f,  1f, 0.5f);
			if (GUILayout.Button("Take me to the download page!", GUILayout.Height(30), GUILayout.MaxWidth(300))) {
			}
			GUI.backgroundColor = col;


			if (GUILayout.Button("What's new? (full changelog)")) {
			}

			GUILayout.EndVertical();

			GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();

			GUILayout.FlexibleSpace();

			GUILayout.BeginHorizontal();

			if (GUILayout.Button("Skip this version", GUILayout.MaxWidth(100))) {
				setReminder = true;
				Close();
			}


			GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();
		}
	}
}
