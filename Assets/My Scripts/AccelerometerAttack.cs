using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerometerAttack : MonoBehaviour
{
    Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Input.acceleration);
        if (Input.acceleration.z < -2.0)
        {
            _animator.SetTrigger("Hit");
            EnemyAttackCheck();
        }
    }

    void EnemyAttackCheck()
    {
        // DEBUG: Draw lines pointing in front of the camera
        /*
        GameObject myLine = new GameObject();
        myLine.transform.position = origin;
        myLine.AddComponent<LineRenderer>();
        LineRenderer lr = myLine.GetComponent<LineRenderer>();
        //lr.material = new Material(Shader.Find("Custom/Bright Texture"));
        lr.startColor = Color.yellow;
        lr.endColor = Color.yellow;
        lr.startWidth = 0.005f;
        lr.endWidth = 0.005f;
        lr.SetPosition(0, origin);
        lr.SetPosition(1, fwd);
        GameObject.Destroy(myLine, 1.0f);
        */

        Ray ray = Camera.main.ScreenPointToRay(new Vector2(540.0f,960.0f));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            Debug.Log("GOT A HIT");
            GameObject.Destroy(hit.transform.gameObject, 0.25f);
        }
    }
}
