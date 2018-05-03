using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : TacticsMove
{

	// Use this for initialization
	void Start ()
	{
     Init();
	}

	// Update is called once per frame
	void Update ()
	{
        Debug.DrawRay(transform.position, transform.forward);

        if (!turn)
        {
            return;
        }

        if (!moving)
        {
            FindSelectableTiles();
            CheckMouse();
        }
        else
        {
            Move();
        }

        if (attackMode)
        {
           CheckAttack();
        }
	}

    void CheckMouse()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Tile"))
                {
                    Tile t = hit.collider.GetComponent<Tile>();

                    if (t.selectable)
                    {
                        MoveToTile(t);
                    }
                }
            }
        }
    }

  void CheckAttack ()
  {
    if (Input.GetMouseButtonUp(0))
    {
      Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

      RaycastHit hit;
      if (Physics.Raycast(ray, out hit))
      {
        if (hit.collider.CompareTag("NPC"))
        {
          NpcHpBar t = hit.collider.GetComponent<NpcHpBar>();

          if (t.fills > 0)
          {
              t.fills -= 0.2f;
              Debug.Log("Testando euhsduhdd");
              TurnManager.EndTurn();
              attackMode = false;
            attackPoints = 0;
          }
        } else {
          TurnManager.EndTurn();
            attackMode = false;
          attackPoints = 0;
        }
      }
    }
  }
}
