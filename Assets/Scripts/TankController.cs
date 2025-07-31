using UnityEditor.Tilemaps;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public float moveSpeed = 3f;

    public GameObject bulletPrefab;
    public Transform barrelTip;         //This ensure the bullet spawns at the tip of the barrel not inside it causing overlapping.
    public float bulletSpeed = 10f;
    public AudioSource shootSound;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(bulletPrefab, barrelTip.position, barrelTip.rotation);      //Both position and rotation of the barrel is mapped onto where the bullet will spawn
                                                                                                        //So that the bullet won't spawn at a fixed location and now following the barrel.

            bullet.GetComponent<BulletMover>().bulletTravelSpeed = bulletSpeed;

            if(shootSound != null)
            {
                shootSound.Play();
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }
    }
}
