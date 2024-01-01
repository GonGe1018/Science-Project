using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Test2Manager : MonoBehaviour
{
    public Rigidbody Ball1;
    public Rigidbody Ball2;

    public GameObject Ball1Trace;
    public GameObject Ball2Trace;

    public Transform Ball1Tran;
    public Transform Ball2Tran;

    public Text Ball1Rec;
    public Text Ball2Rec;

    public InputField Ball1Fow;
    public InputField Ball2Fow;


    int Ball1F;
    int Ball2F;
    bool isRec1 = false;
    bool isRec2 = false;
    float time1;
    float time2;

    void Awake()
    {
        Ball1Fow.text = "1";
        Ball2Fow.text = "1";
        
        isRec1 = false;
        isRec2 = false;
        time1 = 0;
        time2 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(isRec1)
        {
            time1 += Time.deltaTime;
        }
        if(isRec2)
        {
            time2 += Time.deltaTime;
        }
    }

    public void TestStart()
    {
        Ball1F=int.Parse(Ball1Fow.text);
        Ball2F=int.Parse(Ball2Fow.text);
        isRec1=true;
        isRec2=true;
        Ball1.isKinematic = false;
        Ball1.AddForce(Vector3.left * 10 * Ball1F) ;
        Ball2.isKinematic = false;
        Ball2.AddForce(Vector3.right * 10 * Ball2F);
        StartCoroutine("CreateTrace");
    }
    public void Restart()
    {
        SceneManager.LoadScene("Test2");
    }

    public void Menu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Ball1"))
        {
            isRec1 = false;
            Ball1.isKinematic = true;
            Ball1Rec.text = "빨간 공:" + time1.ToString()+"초";
        }
        if (collision.transform.CompareTag("Ball2"))
        {
            isRec2 = false;
            Ball2.isKinematic = true;
            Ball2Rec.text = "파란 공:" + time2.ToString()+"초";
        }
    }

    IEnumerator CreateTrace()
    {
        while (isRec1&&isRec2)
        {
            Instantiate(Ball1Trace, Ball1Tran.position, Ball1Tran.rotation);
            Instantiate(Ball2Trace, Ball2Tran.position, Ball2Tran.rotation);
            yield return new WaitForSecondsRealtime(0.1f);
        }
    }
}
