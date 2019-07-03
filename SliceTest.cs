using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;

public class SliceTest : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }


    public SlicedHull SliceObject(GameObject obj, Material crossSectionMaterial = null)
    {
        return obj.Slice(transform.position, transform.up, crossSectionMaterial);
    }
    public void SliceObject(GameObject target)
    {
        SlicedHull hull = SliceObject(target,null);
        if (hull != null)
        {
            GameObject lowerObj = hull.CreateLowerHull(target, null);
            GameObject upperObj = hull.CreateUpperHull(target, null);

            Rigidbody lowerrd = lowerObj.AddComponent<Rigidbody>();
            Rigidbody uprd = upperObj.AddComponent<Rigidbody>();

            lowerObj.AddComponent<MeshCollider>().convex = true;
            upperObj.AddComponent<MeshCollider>().convex = true;

            lowerrd.AddExplosionForce(500f,-transform.right,5f);
            uprd.AddExplosionForce(500f, transform.right, 5f);

            target.SetActive(false);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        SliceObject(other.gameObject);
    }

}
