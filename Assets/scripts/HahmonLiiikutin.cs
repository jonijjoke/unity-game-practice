using UnityEngine;

public class HahmonLiikutin : MonoBehaviour
{
    
    [SerializeField]
    bool aNappiPainettu = false;

    [SerializeField]
    bool sNappiPainettu = false;

    [SerializeField]
    bool wNappiPainettu = false;

    [SerializeField]
    bool dNappiPainettu = false;

    [SerializeField]
    float hyppyVoima = 10f;

    [SerializeField]
    float nopeus = 10f;

    [SerializeField]
    float kiertonopeus = 0.5f;

    private Rigidbody fysiikkaVartalo;
    private bool onkoMaassa = true;
    private Vector3 aloitusSijainti;
    private Transform kannettavaEsine = null;
    //private Rigidbody kannettavaEsineRb = null;

    void Start()
    {
        fysiikkaVartalo = GetComponent<Rigidbody>();
        aloitusSijainti = transform.position;

        Debug.Log("Peli aloitettu! Etsi leiri.");
    }

    void Update()
    {
        aNappiPainettu = Input.GetKey("a");
        sNappiPainettu = Input.GetKey("s"); 
        wNappiPainettu = Input.GetKey("w");
        dNappiPainettu = Input.GetKey("d");
        
        if (Input.GetKeyDown("space"))
        {
            hyppaa();
        }

        if (kannettavaEsine != null)
        {
            Vector3 uusiSijainti = transform.position + Vector3.up * 2.5f;
            kannettavaEsine.position = uusiSijainti;
        }

        if (Input.GetKeyDown("q") && kannettavaEsine != null)
        {   
            Vector3 uusiSijainti = transform.position + transform.forward * 1.5f;
            kannettavaEsine.position = uusiSijainti;
            //kannettavaEsineRb.isKinematic = false;
            kannettavaEsine = null;
            //kannettavaEsineRb = null;
            

        }   
    }

    void FixedUpdate()
    {

        if (wNappiPainettu == true)
        {
            fysiikkaVartalo.AddRelativeForce(Vector3.forward * nopeus);
        }

        if (dNappiPainettu == true)
        {
            fysiikkaVartalo.AddTorque(Vector3.up * kiertonopeus);
        }

        if (sNappiPainettu == true)
        {
            fysiikkaVartalo.AddRelativeForce(Vector3.back * nopeus);
        }

        if (aNappiPainettu == true)
        {
            fysiikkaVartalo.AddTorque(Vector3.up * -kiertonopeus);
        }

    }

    void OnCollisionEnter(Collision osumaKohta)
    {
        string osumaKohdanNimi = osumaKohta.gameObject.name;
        GameObject osuttuObjekti = osumaKohta.gameObject;

        if (osumaKohdanNimi.Contains("Bear"))
        {
            Debug.Log("Menit liian lähelle karhua ja se hyökkäsi.");
            transform.position = aloitusSijainti;


        }

        if (osumaKohdanNimi.Contains("Terrain"))
        {
            onkoMaassa = true;
        }

        if (osuttuObjekti.CompareTag("KannettavaKivi") && kannettavaEsine == null)
        {   
            kannettavaEsine = osuttuObjekti.transform;
           /* kannettavaEsineRb = osuttuObjekti.GetComponent<Rigidbody>();
            
            if (kannettavaEsineRb != null)
            {
                kannettavaEsineRb.isKinematic = true;
            }*/
        }
    }

    void hyppaa()   
    {
        if (onkoMaassa == true)
        {
            fysiikkaVartalo.AddForce(Vector3.up * hyppyVoima, ForceMode.Impulse);
            onkoMaassa = false;
        }
    }
}
