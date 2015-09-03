using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;

using UnityEngine;
using System.Collections;

public class TanqueInimigo : MonoBehaviour
{
    WheelJoint2D[] rodas;
    public float velocidade;
    private int dir=0;
    private float[] ancorasX;
    private ParticleSystem plSystem;


    void Start()
    {
        plSystem = GetComponentInChildren<ParticleSystem>();
        plSystem.emissionRate = 0f;
        rodas = GetComponents<WheelJoint2D>();
        ancorasX = new float[rodas.Length];

        for(int i = 0; i < ancorasX.Length; i++)
        {
            ancorasX[i] = rodas[i].anchor.x;
        }


        StartCoroutine(RotinaUpdate());

        
    }


    bool EnemyInRange()
    {
        if (Mathf.Abs(Vector2.Distance(this.transform.position, GameObject.Find("Player").transform.position)) < 0.9)
        {
            return true;
        }

        return false;
    }


    IEnumerator RotinaUpdate()
    {
        if (EnemyInRange())
        {
            AtirarInimigo();
        }
        else
        {
            Patrol();
        }

        yield return new WaitForSeconds(1f);
        StartCoroutine(RotinaUpdate());
    }

    private void Patrol()
    {
        plSystem.emissionRate = 0f;
        if (this.transform.position.x <= -2f)
        {
            this.transform.rotation = Quaternion.Euler(0,180,0);
            for (int i = 0; i < rodas.Length; i ++)
            {
                rodas[i].anchor = new Vector2((-1) * ancorasX[i],rodas[i].anchor.y);
            }
            dir = -1;
        }
        else if (transform.position.x >= 4f)
        {
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
            for (int i = 0; i < rodas.Length; i++)
            {
                rodas[i].anchor = new Vector2(ancorasX[i], rodas[i].anchor.y);
            }
            dir = 1;
        }
        else
        {
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
            for (int i = 0; i < rodas.Length; i++)
            {
                rodas[i].anchor = new Vector2(ancorasX[i], rodas[i].anchor.y);
            }
            dir = 1;
        }


        JointMotor2D jointMotor = new JointMotor2D {maxMotorTorque = 1000f, motorSpeed = velocidade * dir};

        foreach (var roda in rodas)
        {
            roda.motor = jointMotor;
        }
    }

    private void AtirarInimigo()
    {

        foreach (var roda in rodas)
        {
            roda.motor = new JointMotor2D {maxMotorTorque = 1000f, motorSpeed = 0f};

        }
        Vector2 dir = (GameObject.Find("Player").transform.position - transform.position) / (GameObject.Find("Player").transform.position - transform.position).magnitude;
        int direcao = Mathf.RoundToInt(dir.x);

        if (direcao == -1)
        {
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
            for (int i = 0; i < rodas.Length; i++)
            {
                rodas[i].anchor = new Vector2(ancorasX[i], rodas[i].anchor.y);
            }
        }

        if (direcao == 1)
        {
            this.transform.rotation = Quaternion.Euler(0, 180, 0);
            for (int i = 0; i < rodas.Length; i++)
            {
                rodas[i].anchor = new Vector2((-1) * ancorasX[i], rodas[i].anchor.y);
            }
        }

        plSystem.emissionRate = 1f;



    }

    public void OnParticleCollision(GameObject other)
    {

       
        Debug.Log("Tomou dano");
        Jogador.Vida -= 1;
    }

    

    private void Die()
    {
        Destroy(this.gameObject);
    }
}