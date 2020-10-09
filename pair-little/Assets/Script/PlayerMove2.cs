using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;



	public class PlayerMove2 : MonoBehaviour
	{
	public PhotonView myPV;
	public PhotonTransformView myPTV;

	private Camera mainCam;

		
		// 前進速度
		public float forwardSpeed = 7.0f;
		// 後退速度
		public float backwardSpeed = 2.0f;


		public float moveSpeed = 3f;

		// 旋回速度
		public float rotateSpeed = 2.0f;
		// ジャンプ威力
		public float jumpPower = 3.0f;
		// キャラクターコントローラ（カプセルコライダ）の参照
		private CapsuleCollider col;
		private Rigidbody rb;
		// キャラクターコントローラ（カプセルコライダ）の移動量
		private Vector3 velocity;
		private Vector3 velocity1;

		public GameObject pivot;
		private Vector3 Pivotforward;
		private Vector3 ido;


		// 初期化
		void Start()
		{
        if (myPV.IsMine)
        {
			mainCam = Camera.main;
			//mainCam.GetComponent<CCameraScript>().target = this.gameObject.transform;
		}	

			// CapsuleColliderコンポーネントを取得する（カプセル型コリジョン）
			col = GetComponent<CapsuleCollider>();
			rb = GetComponent<Rigidbody>();


		}


		// 以下、メイン処理.リジッドボディと絡めるので、FixedUpdate内で処理を行う.
		void FixedUpdate()
		{
		if (!myPV.IsMine)
		{
			return;
		}

		float h = Input.GetAxis("Horizontal");// 入力デバイスの水平軸をhで定義
			float v = Input.GetAxis("Vertical"); // 入力デバイスの垂直軸をvで定義

			// Joy-Con
			float h2 = Input.GetAxis("Horizontal2");
			float v2 = Input.GetAxis("Vertical2");

			rb.useGravity = true;//ジャンプ中に重力を切るので、それ以外は重力の影響を受けるようにする

			// 以下、キャラクターの移動処理
			velocity = new Vector3(0, 0, v2);
			velocity = transform.TransformDirection(velocity);


			velocity1 = new Vector3(h, 0, v);
			velocity1 = transform.TransformDirection(velocity1);



			//以下のvの閾値は、Mecanim側のトランジションと一緒に調整する
			if (v > 0.1)
			{
				var cameraForward = Vector3.Scale(pivot.transform.forward, new Vector3(1, 0, 1)).normalized;
				velocity1 = cameraForward * v + pivot.transform.right * h;
				velocity1 *= forwardSpeed;       // 移動速度を掛ける
			}
			else if (v < -0.1)
			{
				var cameraForward = Vector3.Scale(pivot.transform.forward, new Vector3(1, 0, 1)).normalized;
				velocity1 = cameraForward * v + pivot.transform.right * h;
				velocity1 *= forwardSpeed;  // 移動速度を掛ける
			}

			if (h > 0.1)
			{
				var cameraForward = Vector3.Scale(pivot.transform.forward, new Vector3(1, 0, 1)).normalized;
				velocity1 = cameraForward * v + pivot.transform.right * h;
				velocity1 *= forwardSpeed;       // 移動速度を掛ける
			}
			else if (h < -0.1)
			{
				var cameraForward = Vector3.Scale(pivot.transform.forward, new Vector3(1, 0, 1)).normalized;
				velocity1 = cameraForward * v + pivot.transform.right * h;
				velocity1 *= forwardSpeed;  // 移動速度を掛ける
			}



			if (h2 != 0 || v2 != 0)
			{

				var cameraForward = Vector3.Scale(pivot.transform.forward, new Vector3(1, 0, 1)).normalized;
				velocity = cameraForward * v2 + pivot.transform.right * h2;
				velocity *= forwardSpeed;
			}

			// 上下のキー入力でキャラクターを移動させる
			transform.localPosition += velocity * Time.fixedDeltaTime;

			transform.localPosition += velocity1 * Time.fixedDeltaTime;


			if (Input.GetButtonDown("Jump"))
			{   // スペースキーを入力したら
				rb.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
			}
		}

		/*
		void OnGUI()
		{
			GUI.Box(new Rect(Screen.width - 260, 10, 250, 150), "Interaction");
			GUI.Label(new Rect(Screen.width - 245, 30, 250, 30), "Up/Down Arrow : Go Forwald/Go Back");
			GUI.Label(new Rect(Screen.width - 245, 50, 250, 30), "Left/Right Arrow : Turn Left/Turn Right");
			GUI.Label(new Rect(Screen.width - 245, 70, 250, 30), "Hit Space key while Running : Jump");
			GUI.Label(new Rect(Screen.width - 245, 90, 250, 30), "Hit Spase key while Stopping : Rest");
			GUI.Label(new Rect(Screen.width - 245, 110, 250, 30), "Left Control : Front Camera");
			GUI.Label(new Rect(Screen.width - 245, 130, 250, 30), "Alt : LookAt Camera");
		}
		*/

	}

