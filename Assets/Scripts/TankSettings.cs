
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
        speedSlider.onValueChanged.AddListener(SetTankSpeed);       //Setting up Speed Slider. For onValueChanged and AddListener I used the same reference as the one in assignment 2
        tankController.moveSpeed = speedSlider.value;               //https://www.youtube.com/watch?v=JoMb2rbYEnk

        redButton.onClick.AddListener(() => SetTankColor(Color.red));           //Button logic
        greenButton.onClick.AddListener(() => SetTankColor(Color.green));       //I'm using AddListener because it works for me very well, I like how simple it is to make different UI elements function with it
        blueButton.onClick.AddListener(() => SetTankColor(Color.blue));


        UpdateBulletType(bulletToggle.isOn);                            //Setting up the bullet switching logic

        bulletToggle.onValueChanged.AddListener(UpdateBulletType);                  
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetTankSpeed(float newSpeed)
    {
        tankController.moveSpeed = newSpeed;        //Here I'm setting up the tank speed to match the slider speed. I have the maximum value on the slider set to 5
    }

    void SetTankColor(Color color)   
    {
        if (tankBodySprite != null)
            tankBodySprite.color = color;

        if (tankBarrelSprite != null)
            tankBarrelSprite.color = color;

        if(tankTracksSprite != null)
            tankTracksSprite.color = color;
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
