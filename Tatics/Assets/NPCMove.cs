using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngineInternal;

public class NPCMove : TacticsMove
{
    GameObject target;

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
            FindNearestTarget();
            CalculatePath();
            FindSelectableTiles();
            actualTargetTile.target = true;
        }
        else
        {
            Move();
        }

	      if (attackMode)
	      {
	          FindNearestTarget();
            FindSelectableTiles();
            CheckNPCAttack();
	      }
	}

  private void CheckNPCAttack()
  {
      GameObject[] targets = GameObject.FindGameObjectsWithTag("Player");

      GameObject nearest = null;
      float distance = Mathf.Infinity;

      foreach (GameObject obj in targets)
      {
        float d = Vector3.Distance(transform.position, obj.transform.position);

        if (d < distance)
        {
            distance = d;
            nearest = obj;
        }

        if (d <= attackPoints)
        {
          RaycastHit ray = new RaycastHit();
          HBIndicatorScript PlayerHB = ray.collider.GetComponent<HBIndicatorScript>();

          if (ray.collider.CompareTag("Player"))
          {
              PlayerHB.BarValue.fillAmount -= 0.2f;
              TurnManager.EndTurn();
          }
        } else {
          TurnManager.EndTurn();
        }
      }
  }

  void CalculatePath()
    {
        Tile targetTile = GetTargetTile(target);
        FindPath(targetTile);
    }

    void FindNearestTarget()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Player");

        GameObject nearest = null;
        float distance = Mathf.Infinity;

        foreach (GameObject obj in targets)
        {
            float d = Vector3.Distance(transform.position, obj.transform.position);

            if (d < distance)
            {
                distance = d;
                nearest = obj;
            }
        }

        target = nearest;
    }
}
