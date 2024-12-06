using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour {
	private enum BillboardType {
		CameraForward,
		CameraLookAt
	};
	[SerializeField]
	private BillboardType billboardType;

	[Header("Lock rotation")]
	[SerializeField]
	private bool lockX;
	[SerializeField]
	private bool lockY;
	[SerializeField]
	private bool lockZ;

	private Vector3 origRot;



	private void Awake() {
		origRot = transform.rotation.eulerAngles;
	}

	private void LateUpdate() {
		Camera camera = Camera.main;
		foreach (var cam in Camera.allCameras) {
			if (cam.gameObject.CompareTag(LayerMask.LayerToName(this.gameObject.layer))) {
				camera = cam;
				break;
			}
		}

		switch (billboardType) {
			case BillboardType.CameraForward:
				transform.forward = camera.transform.forward;
				break;
			case BillboardType.CameraLookAt:
				transform.LookAt(camera.transform.position, Vector3.up);
				break;
		}

		Vector3 rot = transform.rotation.eulerAngles;
		if (lockX) {
			rot.x = origRot.x;
		}
		if (lockY) {
			rot.y = origRot.y;
		}
		if (lockZ) {
			rot.z = origRot.z;
		}
		transform.rotation = Quaternion.Euler(rot);
	}
}
