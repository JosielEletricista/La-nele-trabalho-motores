using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using System;
public class Player : MonoBehaviour
{
    public int velocidade = 10;
    public int forcaPulo = 7;
    Rigidbody rb;
    public bool noChao;
    
    void Start()
    {

        TryGetComponent(out rb);

    }

        private void OnCollisionEnter(Collision collision)
        {
            if (!noChao && collision.gameObject.tag == "Chão")
            {
                noChao = true;
            }
        }

    void Update()
    {
       
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 direcao = new Vector3(x:h, y:0, z:v) * velocidade * Time.deltaTime;
        //rb.AddForce(direcao * velocidade * Time.deltaTime, ForceMode.Impulse);
        rb.velocity = new Vector3(direcao.x, rb.velocity.y, direcao.z);
        if (transform.position.y < -5)
         //if (Input.GetKeyDown(KeyCode.Space) && noChao)
         {
            rb.AddForce(Vector3.up * forcaPulo, ForceMode.Impulse);
            noChao = false;
         }

                if(transform.position.y <= -7)
                 {

                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);

                 }
    }
}
