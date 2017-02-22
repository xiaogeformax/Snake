using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using UnityEngine.SceneManagement;
public class SnakeMove : MonoBehaviour {

    List<Transform> Body = new List<Transform>();
    Vector2 direction = Vector2.up;
    public float velocityTime = 0.1f;
    public GameObject gameObjecgtBody;
    private bool flag = false; //判断是否撞上去
	// Use this for initialization
	void Start ()
    {
        //
        InvokeRepeating("Move", 0.5f, velocityTime);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W)||Input.GetKey("up")&&direction!= Vector2.down)
        {
            direction = Vector2.up;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey("down") && direction != Vector2.up)
        {
            direction = Vector2.down;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey("left") && direction != Vector2.right)
        {
            direction = Vector2.left;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey("right") && direction != Vector2.left)
        {
            direction = Vector2.right;
        }
	
	}
    void Move()
    {
        Vector3 VPosition = transform.position;
        transform.Translate(direction);
        if (flag)
        {
            GameObject bodyPrefab = (GameObject)Instantiate(gameObjecgtBody, VPosition, Quaternion.identity);
            Body.Insert(0, bodyPrefab.transform);
            flag = false;
        }
        else if (Body.Count > 0)
        {
            Body.Last().position = VPosition;
            Body.Insert(0, Body.Last());
            Body.RemoveAt(Body.Count - 1);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            Debug.Log("撞上了!");
            Destroy(other.gameObject);
            flag = true;

        }
        else
        {
            //SceneManager.LoadScene(0)
            Application.LoadLevel(1);
        }
    }
}
