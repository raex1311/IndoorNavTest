using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tween;

public class ArrowSpawner : MonoBehaviour
{
    [SerializeField] MyHandles lineHandles;
    [SerializeField] List<Vector3> tempHandle = new List<Vector3>();
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] GameObject Arrow;
    [SerializeField] GameObject ArrowParent;

    bool canMove = false;

    private void Update()
    {
        SpawnArrows();
    }
    public void SpawnArrows()
    {
        UpdateHandles();
    }
    private void Start()
    {
        lineRenderer.alignment = LineAlignment.TransformZ;
    }

    void UpdateHandles()
    {
        int n = lineRenderer.positionCount;
        tempHandle.Clear();
        for (int i = 0; i < n; i++)
        {
            if (i < n - 1)
            {

                GameObject GO = null;
                Vector3 tempVect;

                tempVect.x = lineRenderer.GetPosition(i).x + (lineRenderer.GetPosition(i + 1).x - lineRenderer.GetPosition(i).x) / 2;
                tempVect.z = lineRenderer.GetPosition(i).z + (lineRenderer.GetPosition(i + 1).z - lineRenderer.GetPosition(i).z) / 2;
                tempVect.y = -1.5f;

                if (Vector3.Distance(lineRenderer.GetPosition(i), lineRenderer.GetPosition(i + 1)) > .4f)
                {
                    if (ArrowParent.transform.childCount < lineRenderer.positionCount)
                    {
                        GO = Instantiate(Arrow, ArrowParent.transform);
                    }
                    if (GO != null)
                    {
                        GO.transform.position = tempVect;
                    }

                }
            }
            tempHandle.Add(lineRenderer.GetPosition(i));
        }
        lineHandles.nodePoints = tempHandle.ToArray();

    }

}
