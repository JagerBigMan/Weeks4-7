
using UnityEngine;
using UnityEngine.UI;

public class TankSettings : MonoBehaviour
{
    //Getting references to the tank
    public TankController tankController;
    public SpriteRenderer tankBodySprite;
    public SpriteRenderer tankBarrelSprite;
    public SpriteRenderer tankTracksSprite;

    //UI Elements
    public Slider speedSlider;
    public Button redButton;
    public Button greenButton;
    public Button blueButton;

    //Bullets
    public Toggle bulletToggle;
    public GameObject normalBulletPrefab;
    public GameObject advancedBulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        UpdateBulletType(bulletToggle.isOn);

        bulletToggle.onValueChanged.AddListener(UpdateBulletType);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void UpdateBulletType(bool useadvancedBullet)
    {
        if (useadvancedBullet)
        {
            tankController.bulletPrefab = advancedBulletPrefab;
        }
        else
        {
            tankController.bulletPrefab = normalBulletPrefab;
        }
    }
}
