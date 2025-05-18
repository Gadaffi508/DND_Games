using UnityEngine;

public class Cells : MonoBehaviour
{
    private GameObject currentObject;
    public GameObject CurrentSoldier
    {
        get { return currentObject; }
        set
        {
            currentObject = value;
            if (value != null)
            {
                currentObject.transform.position = CellPosition();
            }
        }
    }

    public Vector3 CellPosition()
    {
        return new Vector3(transform.position.x, transform.position.y, transform.position.z);

    }
    public void Atack()
    {
        if (currentObject != null)
        {
            Soliders soliders = currentObject.GetComponent<Soliders>();
            soliders.Attack();
        }
    }
}
