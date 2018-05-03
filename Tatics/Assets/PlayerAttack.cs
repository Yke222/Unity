using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : TacticsMove
{
  private void Update()
  {
    Debug.DrawRay(transform.position, transform.forward);


    //if (!turn2)
    //{
    //  return;
    //}

    if (attackPoints > 0)
    {
      attackPoints -= 1;
    }

    if (!moving)
    {
      FindSelectableTiles();
      CheckMouse();
    }

 }

  private void CheckMouse()
  {

      if (Input.GetMouseButtonUp(0))
      {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
          if (hit.collider.CompareTag("NPC"))
          {
            GameObject NPC = hit.collider.GetComponent<GameObject>();

            if (NPC)
            {
             //NpcHpBar.fills -= 0.2f;
            }
          }
        }
      }
  }

}

