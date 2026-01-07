using UnityEngine;
using Unity.Netcode;

public class playerMove : MonoBehaviour
{
    public float speed = 5f;
    private bool IsOwner = true;

    void Start()
    {
        if(IsOwner)
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!IsOwner) return;

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(x, 0, y).normalized;
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
