using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    Vector3 oriPos;
    public float XZLimit = 50;
    public float YLimit = 30;
    AudioManager audio;
    public string splashWater;
    // int UIchildCount;

    // Start is called before the first frame update
    void Start()
    {
        oriPos = transform.position;
        audio = FindObjectOfType<AudioManager>();
        // UIchildCount = GameObject.Find("life").transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -XZLimit || transform.position.x > XZLimit || transform.position.z < -XZLimit || transform.position.z > XZLimit || transform.position.y < -YLimit)
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            GetComponent<CapsuleCollider>().enabled = true;
            transform.SetPositionAndRotation(oriPos, Quaternion.Euler(0, 0, 0));
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "water")
        {
            audio.Play(splashWater);
            GetComponent<CapsuleCollider>().enabled = false;

            int UIchildCount = GameObject.Find("life").transform.childCount;
            if (UIchildCount > 0)
            {
                Destroy(GameObject.Find("love" + UIchildCount));
                if (UIchildCount == 1)
                    SceneManager.LoadScene("End");
            }
        }
    }
}
