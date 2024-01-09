using UnityEngine;

public class Food : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0.0f, 0.1f, 0.0f);
        if (transform.position.y > 26.0f)
        {
            Destroy(gameObject);
        }
    }
}
