using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour {

    public GameObject SSFood;
    int i=0;
	void Start () {
        InvokeRepeating("ShowFood", 1, 4);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void ShowFood()
    {
        int x = Random.Range(-30, 30);
        int y = Random.Range(-22, 22);
        Instantiate(SSFood, new Vector2(x,y), Quaternion.identity);
        i++;
        Debug.Log(i);
    }
}
