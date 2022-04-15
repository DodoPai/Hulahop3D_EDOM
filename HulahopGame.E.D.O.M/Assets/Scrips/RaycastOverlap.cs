using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastOverlap : MonoBehaviour
{
    public GameObject[] itemsToPickFrom;
    public float raycastDistance = 1f;
    public float overlapTestBoxSize = 1f;
    public LayerMask spawnedObjectLayer;

    private void Update()
    {
        PositionRaycast();
    }
    void PositionRaycast()
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position,Vector3.down,out hit,raycastDistance))
        {
            Quaternion spawnRotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
            Vector3 overlapTestBoxScale = new Vector3(overlapTestBoxSize,overlapTestBoxSize,overlapTestBoxSize);
            Collider[] collidersInsideOverlapBox = new Collider[1];
            int numberOfCollidersFound = Physics.OverlapBoxNonAlloc(hit.point, overlapTestBoxScale, collidersInsideOverlapBox, spawnRotation, spawnedObjectLayer);

            if (numberOfCollidersFound == 0)
            {
                Pick(hit.point, spawnRotation);
            }
            

        }
      
    }
    void Pick(Vector3 positionToSpawn,Quaternion rotationToSpawn)
    {
        int randomIndex = Random.Range(0, itemsToPickFrom.Length);
        GameObject clone = Instantiate(itemsToPickFrom[randomIndex], positionToSpawn, rotationToSpawn);
    }


}
