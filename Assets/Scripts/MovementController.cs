using UnityEngine;

public class MovementController : MonoBehaviour
{
    public LayerMask moveObjectLayer;
    public LayerMask groundLayer;
    public LayerMask cellLayer;

    public GameObject moveObject;
    public Cells lastCell;

    CellController cellController;

    private void Start()
    {
        cellController = GetComponent<CellController>();
    }

    private void Update()
    {
        SelectObject();
        MoveObject();
        PlaceObject();
    }

    public void SelectObject()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, float.MaxValue, moveObjectLayer)) //Eger Hit Askere degerse
            {
                if (hit.collider != null)
                {
                    moveObject = hit.collider.gameObject;
                    lastCell = cellController.ContainsCell(moveObject);
                    lastCell.CurrentSoldier = null;
                    return;
                }
            }

            RaycastHit cellHit;
            if(Physics.Raycast(ray, out cellHit, float.MaxValue, cellLayer)) //Eger hit hucreye degerse
            {
                if(cellHit.collider != null)
                {
                    lastCell = cellHit.collider?.GetComponent<Cells>();
                    moveObject = lastCell.CurrentSoldier;
                    lastCell.CurrentSoldier = null;
                }
            }
            else
            {
                if(moveObject != null)
                {
                    lastCell = cellController.ContainsCell(moveObject);
                    lastCell.CurrentSoldier = null; 
                }
            }

        }
    }
    public void MoveObject()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, float.MaxValue, groundLayer))
            {
                if (hit.collider != null && moveObject != null)
                {
                    Vector3 movePosition = new Vector3(hit.point.x, moveObject.transform.position.y, hit.point.z);

                    moveObject.transform.position = movePosition;
                }
            }
        }
    }

    public void PlaceObject()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, float.MaxValue, cellLayer))
            {
                Cells cell = hit.collider?.GetComponent<Cells>();

                if (hit.collider != null && moveObject != null) //Eger mouse hucrede ise ve elimizde asker var ise
                {
                    if (cell.CurrentSoldier == null) //Eger mouse pozisyonundaki hucre bos ise askeri koy
                    {
                        //Asker Limiti asilmadi ise
                        if (cellController.SoldierLimit()) 
                        {
                            lastCell.CurrentSoldier = null;
                            cell.CurrentSoldier = moveObject;
                        }
                        else //Limit dolu ise asker son hucreye donsun
                        {
                            lastCell.CurrentSoldier = moveObject;
                        }
                    }
                    else ////Eger mouse pozisyonundaki hucre bos degil ise yer degis
                    {
                        GameObject cellSoldier = cell.CurrentSoldier;
                        cell.CurrentSoldier = moveObject;
                        lastCell.CurrentSoldier = cellSoldier;
                    }
                }
            }
            else //Eger mouse pozisyonu hucrede degil ise
            {
                if (moveObject != null)
                {
                    moveObject.transform.position = lastCell.CellPosition();
                    lastCell.CurrentSoldier = moveObject;
                }

            }

            moveObject = null;
            lastCell = null;
        }
    }


}
