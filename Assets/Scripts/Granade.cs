using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granade : MonoBehaviour
{
    [SerializeField]
    private GameObject explosion;
    GameObject obj;
    private void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if(InventorySystem.Instance.selectedBullet == null)
        {
            return;
        }
        if(obj != null || InventorySystem.Instance.selectedBullet.areaOfEffect == 0)
        {
            return;
        }
       
        obj = Instantiate(explosion);
        obj.SetActive(true);
        obj.transform.position = this.transform.position;
        obj.transform.rotation = Quaternion.identity;
        Destroy(obj, 3f);
    }

}
