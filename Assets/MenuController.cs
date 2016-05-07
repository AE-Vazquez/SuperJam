using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray toMouse = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rhInfo;
            bool didHit = Physics.Raycast(toMouse, out rhInfo, 500.0f);
            if(didHit)
            {
                if(rhInfo.collider.GetComponent<MenuButton>()!=null)
                {
                    rhInfo.collider.GetComponent<MenuButton>().Click();
                }
            }
        }
    }
}
