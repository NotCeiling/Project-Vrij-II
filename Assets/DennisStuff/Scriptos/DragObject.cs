using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    public BoxCollider coll;
    public Rigidbody rb;

    public Vector3 targetPosition;

    private Vector3 originalPos;
    private Vector3 mOffset;
    private float mZCoord;

    private int inPosition;
    public int selected;
    private int roaming;

    public GameObject holder;


    private void Start()
    {
        if (transform.parent)
        {
            holder = transform.parent.gameObject;
            holder.GetComponent<PaintingHolder>().ToHangPainting(gameObject);
        }
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;

        mousePoint.z = mZCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0) && selected == 1)
        {
            if (Physics.Raycast(GetMouseWorldPos() - transform.forward, transform.TransformDirection(Vector3.forward), out RaycastHit hit, 20))
            {
                if (hit.transform.CompareTag("PaintingZone") && hit.transform.gameObject != holder)
                {
                    hit.transform.GetComponent<PaintingHolder>().MovePainting(gameObject, holder);
                }
                else
                {
                    targetPosition = originalPos;
                }
            }
            else
            {
                targetPosition = originalPos;
            }
            StopDragging();
        }
    }

    private void FixedUpdate()
    {
        inPosition = (Vector3.Distance(transform.position, targetPosition) > 0.01f) ? 0 : 1;

        if (inPosition == 1)
        {
            rb.rotation = Quaternion.Euler(new Vector3(0.5f * rb.velocity.y, 0.35f * rb.velocity.x, -0.5f * rb.velocity.x));
            rb.velocity = new Vector3(0, 0, 0);
        }
        else if (roaming == 0)
        {
            MoveToNewPosition();
        }

        if (selected == 1)
        {
            targetPosition = GetMouseWorldPos() + mOffset;
        }
    }

    private void MoveToNewPosition()
    {
        var difference = targetPosition - transform.position;

        rb.velocity = 10 * difference;
    }


    public void StartDragging()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMouseWorldPos();
        originalPos = gameObject.transform.position;

        selected = 1;
    }

    public void StopDragging()
    {
        selected = 0;
    }


    public void TakePainting(Vector3 newPos, GameObject newHolder)
    {
        targetPosition = newPos;
        transform.SetParent(newHolder.transform);
        holder = newHolder;
        rb.rotation = Quaternion.Euler(new Vector3(0, 15, 0));
    }

    public void HangPainting(GameObject newHolder)
    {
        transform.SetParent(newHolder.transform);
        holder = newHolder;
        targetPosition = newHolder.transform.position;
    }

    public void ToggleRoaming()
    {
        if (roaming == 1)
            roaming = 0;
        else
            roaming = 1;
    }

}
