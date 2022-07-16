using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{

    private LineRenderer lineRenderer;

    public GameObject shotPosition, camera, player;

    public LayerMask whatIsGrappleable;

    private Vector3 grapplePoint;

    private SpringJoint joint;

    private float maxDistance = 100f;

    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartGrapple();
        } else if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            StopGrapple();
        }
    }

    private void LateUpdate()
    {
        DrawRope();
    }

    void StartGrapple()
    {
        if (joint) return;
        RaycastHit Hit;
        if (Physics.Raycast(camera.transform.position,camera.transform.forward,out Hit, maxDistance)) 
        {
            grapplePoint = Hit.point;
            joint = player.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;

            float distanceFromPoint = Vector3.Distance(player.transform.position, grapplePoint);

            joint.maxDistance = distanceFromPoint * 0.8f; // use to controll the pull position
            joint.minDistance = distanceFromPoint * 0.01f;

            joint.spring = 100f;
            joint.damper = 10f;
            joint.massScale = 1f;

            lineRenderer.positionCount = 2;
        }
    }

    void StopGrapple()
    {
        lineRenderer.positionCount = 0;
        Destroy(joint);
    }

    void DrawRope()
    {
        if (!joint) return;
        lineRenderer.SetPosition(0, shotPosition.transform.position);
        lineRenderer.SetPosition(1, grapplePoint);
    }
}
