using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampaPincho : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Se destruye al tocar el piso.
        if (collision.gameObject.CompareTag("Piso"))
        {
            Destroy(gameObject);
        }
    }
}
