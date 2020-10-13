using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackTitle : MonoBehaviour
{

	//　スタートボタンを押したら実行する
	public void BacktoTitle()
	{
		SceneManager.LoadScene("Title");
	}

}
