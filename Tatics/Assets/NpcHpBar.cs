using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcHpBar : MonoBehaviour {

  public Image BarValue;
  public float fills;

  // Use this for initialization
  void Start () {
    fills = 1f;
  }

  // Update is called once per frame
  void Update () {
    BarValue.fillAmount = fills;
  }
}
