using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BirdMovement : MonoBehaviour {
	[Min(0.0001f)]
	public float moveAcc = 5000f;
	[Min(0.0001f)]
	public float maxMove = 1000f;
	private float currMove = 0f;

	[Min(0.0001f)]
	public float turnAcc = 1000f;
	[Min(0.0001f)]
	public float maxTurn = 100f;
	private float currTurn = 0f;

	[Min(0.0001f)]
	public float jumpForce = 100f;
	private bool holdJump = false;
	private bool canJump = true;

	[Min(0.0001f)]
	public float speedLimit = 25f;

	public GameObject spriteObj;

	private float moveAccMult = 1f;

	public KeyCode playerLeft;
	public KeyCode playerRight;
	public KeyCode playerJump;

	[SerializeField]
	private uint lapsDone = 1;
	public TextMeshProUGUI lapsUI;



	int PlayerGetTurn() {
		return (Input.GetKey(playerRight) ? 1 : 0) - (Input.GetKey(playerLeft) ? 1 : 0);
	}
	bool PlayerGetJump() {
		return Input.GetKey(playerJump);
	}



	// Start is called before the first frame update
	void Start() {

	}

	private void FixedUpdate() {
		var rigidbody = GetComponent<Rigidbody>();

		if (CloseTo(PlayerGetTurn(), 0f)) {
			if (CloseTo(currTurn, 0f) == false) {
				float turnSign = Mathf.Sign(currTurn);
				currTurn -= Mathf.Sign(currTurn) * turnAcc * Time.fixedDeltaTime;
				currTurn = Limit(currTurn, 0f, turnSign);
			}

			currMove += moveAcc * moveAccMult * Time.fixedDeltaTime;
			currMove = Mathf.Min(currMove, maxMove);
		}
		else {
			currTurn += PlayerGetTurn() * turnAcc * Time.fixedDeltaTime;
			currTurn = Mathf.Clamp(currTurn, -maxTurn, maxTurn);

			currMove -= moveAcc * Time.fixedDeltaTime * 0.01f;
			currMove = Mathf.Max(currMove, 1000f);

			spriteObj.transform.localScale = new Vector3(
				Mathf.Abs(spriteObj.transform.localScale.x) * -Mathf.Sign(PlayerGetTurn()),
				spriteObj.transform.localScale.y,
				spriteObj.transform.localScale.z
			);
		}

		rigidbody.AddForce(rigidbody.transform.forward * currMove * Time.fixedDeltaTime, ForceMode.Force);
		rigidbody.AddTorque(0f, currTurn * Time.fixedDeltaTime, 0f, ForceMode.Force);



		bool onGround = Physics.Raycast(rigidbody.transform.position, -rigidbody.transform.up, 1.0f, LayerMask.NameToLayer("Ground"));

		if (onGround) {
			rigidbody.drag = 10f;
			holdJump = false;
		}
		else {
			rigidbody.AddForce(-rigidbody.transform.up * jumpForce * jumpForce * Time.fixedDeltaTime, ForceMode.Force);
		}

		if (PlayerGetJump()) {
			if (onGround && canJump) {
				rigidbody.AddForce(rigidbody.transform.up * jumpForce, ForceMode.Impulse);
				holdJump = true;
				canJump = false;

				rigidbody.drag = 10f;
				CancelInvoke("JumpPhysics");
				Invoke("JumpPhysics", 0.3f);
				Invoke("StopJumpHold", 0.5f);
			}
			else if (holdJump) {
				rigidbody.AddForce(rigidbody.transform.up * Mathf.Pow(jumpForce, 2) * Time.fixedDeltaTime, ForceMode.Force);
			}
		}
		else {
			if (onGround) {
				canJump = true;
			}
			CancelInvoke("JumpPhysics");
			holdJump = false;
		}



		rigidbody.velocity = Vector3.ClampMagnitude(new Vector3(rigidbody.velocity.x, 0f, rigidbody.velocity.z), speedLimit) + new Vector3(0f, rigidbody.velocity.y, 0f);
		spriteObj.transform.localRotation = Quaternion.Euler(Vector3.Lerp(
			Vector3.zero,
			new Vector3(0f, 0f, PlayerGetTurn() * 400f),
			rigidbody.angularVelocity.magnitude / rigidbody.maxAngularVelocity
		));
	}

	private void JumpPhysics() {
		GetComponent<Rigidbody>().drag = 0.5f;
	}
	private void StopJumpHold() {
		holdJump = false;
	}
	private void HitFlag() {
		GetComponent<Rigidbody>().drag = 10f;
		moveAccMult = 1f;
	}

	private void OnTriggerEnter(Collider other) {
		if (other != null && other.gameObject.CompareTag("Obstacle")) {
			var rigibody = GetComponent<Rigidbody>();

			rigibody.drag = 0.5f;
			moveAccMult = 0.1f;
			CancelInvoke("HitFlag");
			Invoke("HitFlag", 1f);

			rigibody.AddForce(-rigibody.transform.forward * 500f, ForceMode.Impulse);
			currMove = 0f;
		} else if (other != null && other.gameObject.CompareTag("Border")) {
			var rigibody = GetComponent<Rigidbody>();

			rigibody.drag = 0.5f;
			moveAccMult = 0.1f;
			CancelInvoke("HitFlag");
			Invoke("HitFlag", 1f);

			rigibody.AddForce(-rigibody.transform.forward * 1000f, ForceMode.Impulse);
			currMove = 0f;
		} else if (other != null && other.gameObject.CompareTag("FinishBlock")) {
			lapsDone += (uint)Mathf.Sign(Vector3.Dot(GetComponent<Rigidbody>().transform.forward, other.gameObject.transform.forward));
			lapsUI.text = "Lap " + Mathf.Clamp(lapsDone, 1, 3).ToString();
			if (lapsDone == 4) {
				Application.Quit();
                Debug.Log(gameObject.name + " wins!");
                if (gameObject.name == "Birb 1") GameManagerTTT.instance.AddWinningPlayer("Cyan");
                else GameManagerTTT.instance.AddWinningPlayer("Red");
                SceneManager.LoadScene("Grid");
            }
		}
	}



	public bool CloseTo(float a, float b, float epsilon = 0.01f) {
		if (a > b - epsilon && a < b + epsilon) {
			return true;
		}
		return false;
	}
	public float Limit(float a, float limit, float sign) {
		if (Mathf.Sign(sign) < 0f) {
			return Mathf.Min(a, limit);
		}
		return Mathf.Max(a, limit);
	}
	public Vector3 MinMag(Vector3 vector, float min) {
		return vector.normalized * Mathf.Max(vector.magnitude, min);
	}
}
