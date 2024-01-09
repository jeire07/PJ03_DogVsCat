using UnityEngine;

public class Cat : MonoBehaviour
{
    public int Type;

    private float _full = 5.0f;
    private float _energy = 0.0f;
    private bool _isFull = false;

    // Start is called before the first frame update
    void Start()
    {
        if(Type == 1)
        {
            _full = 10;
        }
        float x = Random.Range(-8.5f, 8.5f);
        float y = 30.0f;
        transform.position = new Vector3(x, y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(_energy < _full)
        {
            if(Type == 0)
            {
                transform.position += new Vector3(0.0f, -0.05f, 0.0f);
            }
            else if(Type == 1)
            {
                transform.position += new Vector3(0.0f, -0.03f, 0.0f);
            }
            else
            {
                transform.position += new Vector3(0.0f, -0.1f, 0.0f);
            }

            if(transform.position.y < -16.0f)
            {
                GameManager.Instance.GameOver();
            }
        }
        else
        {
            if (transform.position.x > 0)
            {
                transform.position += new Vector3(0.05f, 0.0f, 0.0f);
            }
            else
            {
                transform.position += new Vector3(-0.05f, 0.0f, 0.0f);
            }
            Destroy(gameObject, 3.0f);
        }
        
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "food")
        {
            if (_energy < _full)
            {
                //Debug.Log("collision!");
                _energy += 1.0f;
                Debug.Log("energy"+_energy.ToString());
                Destroy(coll.gameObject);
                gameObject.transform.Find("hungry/Canvas/front")
                    .transform.localScale
                    = new Vector3(_energy / _full, 1.0f, 1.0f);
            }

            if (_energy >= _full)
            {
                gameObject.transform.Find("hungry")
                    .gameObject.SetActive(false);
                gameObject.transform.Find("full")
                    .gameObject.SetActive(true);

                if (_isFull == false)
                {
                    GameManager.Instance.AddCat();
                    _isFull = true;
                }
                //Debug.Log("full!");
            }
        }
    }
}
