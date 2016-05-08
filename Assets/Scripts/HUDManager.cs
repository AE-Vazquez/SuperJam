using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour {


    public GameObject[] insideLives;
    public GameObject[] outsideLives;

    public GUIText insidePoints;
    public GUIText outsidePoints;

    public Image insideBoosterImage;
    public Image outsideBoosterImage;


    public Canvas outsideCanvas;
    // Use this for initialization
    void Start()
    {
        insidePoints.text = "0";
        outsidePoints.text = "0";
        if (PlayerPrefs.GetString("gameMode").Equals("VR"))
        {
            outsideCanvas.gameObject.SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void UpdateLives(int amount)
    {
        Destroy(insideLives[amount]);
        Destroy(outsideLives[amount]);
    }

    public void UpdatePoints(int amount)
    {
        insidePoints.text = amount.ToString();
        outsidePoints.text = amount.ToString();
    }

    public void UpdateBooster(float amount)
    {
        
        insideBoosterImage.fillAmount = amount;
        outsideBoosterImage.fillAmount = amount;
        if(amount<25)
        {
            insideBoosterImage.color = Color.green;
            outsideBoosterImage.color = Color.green;
        }
        else if(amount<75)
        {
            insideBoosterImage.color = Color.yellow;
            outsideBoosterImage.color = Color.yellow;
        }
        else if(amount<100)
        {
            insideBoosterImage.color = Color.red;
            outsideBoosterImage.color = Color.red;
        }
        else
        {
            insideBoosterImage.color = Color.magenta;
            outsideBoosterImage.color = Color.magenta;
        }
    }


}
