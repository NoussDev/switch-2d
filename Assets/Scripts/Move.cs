using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    private float m_actualCouloir = 1;
    protected float ActualCouloir
    {
        get { return m_actualCouloir; }
        set { m_actualCouloir = value; }
    }

    // Start is called before the first frame update
    protected void MoveObject(string direction, Rigidbody2D rb)
    {
        if (direction == "right")
        {
            Couloir newCouloir = MapManager.couloirs.Find(x => x.num == ActualCouloir + 1);
            rb.transform.position = new Vector3((newCouloir.posStart + newCouloir.posEnd) / 2,
                rb.transform.position.y, rb.transform.position.z);
            ActualCouloir += 1;
        }

        if (direction == "left")
        {
            Couloir newCouloir = MapManager.couloirs.Find(x => x.num == ActualCouloir - 1);
            rb.transform.position = new Vector3((newCouloir.posStart + newCouloir.posEnd) / 2,
                rb.transform.position.y, rb.transform.position.z);
            ActualCouloir -= 1;
        }
    }

    protected bool RightMovement()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow) && ActualCouloir < MapManager.couloirs.Count - 1)
        {
            return true;
        }
        return false;
    }

    protected bool LeftMovement()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow) && ActualCouloir > 0)
        {
            return true;
        }
        return false;
    }
}
