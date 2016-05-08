using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour {

    // Subete al puto repo
    public GameObject[] insideLives;
    public GameObject[] outsideLives;

    public Text insidePoints;
    public Text outsidePoints;

    public Image insideBoosterImage;
    public Image outsideBoosterImage;


    public Canvas outsideCanvas;
    // Use this for initialization
    void Start()
    {
        if (insidePoints != null)
            insidePoints.text = "0";
        if (outsidePoints != null)
            outsidePoints.text = "0";
        if (PlayerPrefs.GetString("gameMode").Equals("VR"))
        {
            outsideCanvas.gameObject.SetActive(false);
        }
        else
        {
            foreach(GameObject go in insideLives)
            {
                Destroy(go);

            }
            if(insidePoints!=null)
                insidePoints.enabled = false;
            if (insideBoosterImage != null)
                insideBoosterImage.enabled = false;

        }

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void UpdateLives(int amount)
    {
        if(insideLives.Length>amount && insideLives[amount]!=null)
        Destroy(insideLives[amount]);
        if (outsideLives.Length > amount && outsideLives[amount] != null)
            Destroy(outsideLives[amount]);
    }

    public void UpdatePoints(int amount)
    {
        if(insidePoints!=null)
        insidePoints.text = amount.ToString();
        if (outsidePoints != null)
            outsidePoints.text = amount.ToString();
    }

    public void UpdateBooster(float amount)
    {
        if (insideBoosterImage != null)
            insideBoosterImage.fillAmount = amount;
        if (outsideBoosterImage != null)
            outsideBoosterImage.fillAmount = amount;
        if(amount<1)
        {
            if (insideBoosterImage != null)
                insideBoosterImage.color = Color.yellow;
            if (outsideBoosterImage != null)
                outsideBoosterImage.color = Color.yellow;
        }
        else
        {
            if (insideBoosterImage != null)
                insideBoosterImage.color = Color.green;
            if (outsideBoosterImage != null)
                outsideBoosterImage.color = Color.green;
        }
    }


}
