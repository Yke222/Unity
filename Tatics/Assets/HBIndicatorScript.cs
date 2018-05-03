using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HBIndicatorScript : MonoBehaviour {

	public Image BarValue;
	public float fill;

	// Use this for initialization
	void Start () {
	  fill = 1f;
	}

	// Update is called once per frame
	void Update () {

		BarValue.fillAmount = fill;
	}
}
