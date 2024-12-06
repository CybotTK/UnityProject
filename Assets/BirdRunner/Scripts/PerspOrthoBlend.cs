using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class PerspOrthoBlend : MonoBehaviour {
	[Range(0f, 1f)]
	public float blend;
	[Min(1f)]
	public float orthoSize;
	[HideInInspector]
	public Matrix4x4? originalCameraMatrix = null;

	public Rect viewRectangle;



	// Start is called before the first frame update
	void Start() {
		GetComponent<Camera>().rect = viewRectangle;
		originalCameraMatrix = GetComponent<Camera>().projectionMatrix;
		UpdateCamera();
	}

	// Update is called once per frame
	void Update() {

	}



	public void UpdateCamera() {
		var camera = GetComponent<Camera>();

		float left = -orthoSize * camera.aspect;
		float right = orthoSize * camera.aspect;
		float bottom = -orthoSize;
		float top = orthoSize;
		float nearClip = camera.nearClipPlane;
		float farClip = camera.farClipPlane;

		Matrix4x4 orthoMatrix = Matrix4x4.Ortho(left, right, bottom, top, nearClip, farClip);
		//BlendToMatrix(orthoMatrix, 2.0f);
		GetComponent<Camera>().projectionMatrix = MatrixLerp(
			(Matrix4x4)originalCameraMatrix,
			orthoMatrix,
			blend
		);
	}

	public static Matrix4x4 MatrixLerp(Matrix4x4 from, Matrix4x4 to, float t) {
		Matrix4x4 ret = new Matrix4x4();
		for (int i = 0; i < 16; i++) {
			ret[i] = Mathf.Lerp(from[i], to[i], t);
		}
		return ret;
	}

	private IEnumerator LerpFromTo(Matrix4x4 src, Matrix4x4 dest, float duration) {
		float startTime = Time.time;
		while (Time.time - startTime < duration) {
			GetComponent<Camera>().projectionMatrix = MatrixLerp(src, dest, (Time.time - startTime) / duration);
			yield return null;
		}
		GetComponent<Camera>().projectionMatrix = dest;
	}

	public Coroutine BlendToMatrix(Matrix4x4 targetMatrix, float duration) {
		StopAllCoroutines();
		return StartCoroutine(LerpFromTo(GetComponent<Camera>().projectionMatrix, targetMatrix, duration));
	}
}
