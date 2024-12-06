using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PerspOrthoBlend))]
public class PerspOrthoEditor : Editor {
	public override void OnInspectorGUI() {
		DrawDefaultInspector();

		PerspOrthoBlend script = (PerspOrthoBlend)target;
		if (Application.isPlaying) {
			if (GUI.changed) {
				if (script != null && script.originalCameraMatrix != null) {
					script.UpdateCamera();
				}
				EditorUtility.SetDirty(target);
			}
		}
	}
}
