using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthIcon : MonoBehaviour
{
    public Image myImageComponent;
    public Sprite SpriteOne;
    public Sprite SpriteTwo;
    public Sprite SpriteThree;
    public Sprite SpriteFour;
    public Sprite SpriteFive;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetImageOne()
    {
        myImageComponent.sprite = SpriteOne;
    }
    public void SetImageTwo()
    {
        myImageComponent.sprite = SpriteTwo;
    }
    public void SetImageThree()
    {
        myImageComponent.sprite = SpriteThree;
    }
    public void SetImageFour()
    {
        myImageComponent.sprite = SpriteFour;
    }
    public void SetImageFive()
    {
        myImageComponent.sprite = SpriteFive;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
