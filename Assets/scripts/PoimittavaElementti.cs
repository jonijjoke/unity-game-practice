using UnityEngine;

public class PoimittavaElementti : MonoBehaviour
{

    [SerializeField]
    float ylösNousuAikaMuuttuja = 1.0f;
    [SerializeField]
    float alasMenoAikaMuuttuja = 1.0f;
    [SerializeField]
    float ylosMenoVoima = 10.0f;
    
    Rigidbody poimittavanElementinFysiikka;

    float ylosNousuAika = 0f;
    float alhaallaoloAika = 0f;
    bool laskeuduAlas = false;



    void Start()
    {
        poimittavanElementinFysiikka = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ylosNousuAika += Time.deltaTime;
        Debug.Log(ylosNousuAika);
        if (ylosNousuAika > 3f)
        {
            laskeuduAlas = true;
        } if (laskeuduAlas == true)
        {
            alhaallaoloAika += Time.deltaTime;

            if (alhaallaoloAika > 2f)
            {
                laskeuduAlas = false;
                alhaallaoloAika = 0f;
                ylosNousuAika = 0f;
                
            }
        }
    }

    void FixedUpdate()
    {
        if (laskeuduAlas == false)
        {
            poimittavanElementinFysiikka.AddForce(Vector3.up * 10f);
        }
    }
}
