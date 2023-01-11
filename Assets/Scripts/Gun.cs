using UnityEngine;
using UnityEngine.EventSystems;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float offset;
    [SerializeField] private Transform GunPoint;
    [SerializeField] private GameObject projetil;
    private float time =0;
    [SerializeField] private float timebts;
    public ObjectPool pool;

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        bool canShoot = true;
        if (hit) {
            if (hit.collider.tag == "Plot") {
                canShoot = false;
            }
        }
        Mira();
        if (Time.time > time)
        {
            if (Input.GetMouseButtonDown(0) && InventorySystem.Instance.selectedBullet && !EventSystem.current.IsPointerOverGameObject() && canShoot)
            {
                timebts = InventorySystem.Instance.selectedBullet.fireRate;
                GameObject bullet = pool.GetPooledObject();
                bullet.transform.position = GunPoint.position;
                bullet.transform.rotation = transform.rotation;
                bullet.gameObject.SetActive(true);
                InventorySystem.Instance.UseBullet();
                time = Time.time + timebts;
            }
            
        }
    }

    public Vector3 GetMouseWorldPosition() {
        Vector3 vec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        vec.z = 0f;
        return vec;
    }

    private void Mira()
    {
        Vector3 mousePosition = GetMouseWorldPosition();
        Vector3 aimDirection = (mousePosition - player.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle);

        //posi��o
        Vector3 playermo = Camera.main.ScreenToWorldPoint(Input.mousePosition)- player.position;
        playermo.z= 0;
        transform.position = player.position+ (offset*playermo.normalized);

        //girar
        Vector3 scale = Vector3.one;
        if(angle>90|| angle < -90)
        {
            scale.y = -1;
        }
        else
        {
            scale.y = 1;
        }
        transform.localScale = scale;
    }
}
