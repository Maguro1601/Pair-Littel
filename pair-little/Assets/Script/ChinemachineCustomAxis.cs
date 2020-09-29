using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChinemachineCustomAxis : MonoBehaviour
{
	public bool xInversion, yInversion;



	void Start()
	{
		Cinemachine.CinemachineCore.GetInputAxis = GetAxisCustom;
		
	}

	public float GetAxisCustom(string axisName)
	{
		float h1 = Input.GetAxis("Horizontal1");
		float v1 = Input.GetAxis("Vertical1");

		if (h1 != 0)
		{
			return h1 * (xInversion ? -1f : 1f);
		}

		if(v1 != 0)
        {
			return v1 * (yInversion ? -1f : 1);
		}

		return 0;
	}
}
