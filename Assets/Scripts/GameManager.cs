using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _food;
    [SerializeField] private GameObject _dog;
    [SerializeField] private GameObject _normalCat;
    [SerializeField] private GameObject _fatCat;
    [SerializeField] private GameObject _pirateCat;
    [SerializeField] private GameObject _retryBtn;
    [SerializeField] private Text _levelText;
    [SerializeField] private GameObject _levelFront;

    public static GameManager Instance { get; private set; }

    private int level = 0;
    private int cat = 0;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        InvokeRepeating("MakeFood", 0.0f, 0.1f);
        InvokeRepeating("MakeCat", 0.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MakeFood()
    {
        float x = _dog.transform.position.x;
        float y = _dog.transform.position.y + 2.0f;
        Instantiate(_food, new Vector3(x, y, 0), Quaternion.identity);
    }
    
    void MakeCat()
    {
        Instantiate(_normalCat);
        if (level == 1)
        {
            float p = Random.Range(0, 10);
            if (p < 2) Instantiate(_normalCat);
        }
        else if (level == 2)
        {
            float p = Random.Range(0, 10);
            if (p < 4) Instantiate(_normalCat);
        }
        else if (level == 3)
        {
            float p = Random.Range(0, 10);
            if (p < 6)
            {
                Instantiate(_normalCat);
            }
            else
            {
                Instantiate(_fatCat);
            }
        }
        else if (level >= 4)
        {
            float p = Random.Range(0, 10);
            if (p < 4)
            {
                Instantiate(_normalCat);
            }
            else if(p < 7)
            {
                Instantiate(_fatCat);
            }
            else
            {
                Instantiate(_pirateCat);
            }
        }
    }

    public void GameOver()
    {
        _retryBtn.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void AddCat()
    {
        cat += 1;
        level = cat / 5;
        Debug.Log("cat"+cat.ToString());
        Debug.Log("level"+level.ToString());

        _levelText.text = level.ToString();
        _levelFront.transform.localScale = new Vector3((cat - level * 5) / 5.0f, 1.0f, 1.0f);
    }
}
