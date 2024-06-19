using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GamePlayeController : MonoBehaviour
{
    private System.Random random = new System.Random();
    public static GamePlayeController Instance;
    public GameObject[] ObstaclePrefabs;
    public GameObject[] ZombiePrefabs;
    public Transform[] Lanes;
    public float min_ObstacleDelay = 1f, max_ObstacleDelay = 4f;
    private float halfGroundSize;//GroundBlockScript
    private PlayerBasic PlayerControler;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI GameOverText;
    private int Zombie_kill_Count;
    [SerializeField]
    private GameObject PausePanel;
    [SerializeField]
    private GameObject Game_Over_Panel;

    // Start is called before the first frame update
    void Awake()
    {
        MakeInstance();
    }
    void Start()
    {
        halfGroundSize = GameObject.Find("GroundBlock Main").GetComponent<GroundBlockScript>().HalfLenght;
        PlayerControler = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBasic>();
        StartCoroutine("GenerateObstacle");
        scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();

        //StartCoroutine("GenerateObstacles");
    }


    void MakeInstance()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != null)
        {
            Destroy(gameObject);
        }
    }

    
    void CreateObstacle(float zPos)
    {
        int r = Random.Range(0, 10);
        if (0 <= r && r < 7)
        {
            int obstacleLane = Random.Range(0, Lanes.Length);
            AddObstacles(new Vector3(Lanes[obstacleLane].transform.position.x, 0f, zPos), Random.Range(0, ObstaclePrefabs.Length));
            int ZombieLane = 0;
            if (obstacleLane == 0)
            {
                ZombieLane = Random.Range(0, 2) == 1 ? 1 : 2;
                ///this is equal to 
                ///if(Random.Range(0,2)==1){
                ///zombielane=1;}
                ///else{zombieLane=2;}
            }
            else if (obstacleLane == 1)
            {
                ZombieLane = Random.Range(0, 2) == 1 ? 0 : 2;
            }
            else if (obstacleLane == 2)
            {
                ZombieLane = Random.Range(0, 2) == 1 ? 1 : 0;
            }
            AddZombie(new Vector3(Lanes[ZombieLane].transform.position.x, 0.15f, zPos));
        }
    }


    void AddObstacles(Vector3 Position, int type)
    {
        GameObject Obstacle = Instantiate(ObstaclePrefabs[type], Position, Quaternion.identity);
        bool Mirror = Random.Range(0, 2) == 1;
        switch (type)
        {
            case 0:
                Obstacle.transform.rotation = Quaternion.Euler(0f, Mirror ? -20 : 20, 0f);
                break;
            case 1:
                Obstacle.transform.rotation = Quaternion.Euler(0f, Mirror ? -20 : 20, 0f);
                break;
            case 2:
                Obstacle.transform.rotation = Quaternion.Euler(0f, Mirror ? -1 : 1, 0f);
                break;
            case 3:
                Obstacle.transform.rotation = Quaternion.Euler(0f, Mirror ? -170 : 170, 0f);
                break;

        }
        Obstacle.transform.position = Position;

    }

    void AddZombie(Vector3 pos)
    {
        int count = Random.Range(0, 3) + 1;
        for (int i = 0; i < count; i++)
        {
            Vector3 shift = new Vector3(Random.Range(-0.5f, 0.5f), 0f, Random.Range(1f, 10f) * i);
            Instantiate(ZombiePrefabs[Random.Range(0, ZombiePrefabs.Length)], pos + shift * i, Quaternion.identity);
        }
    }


    IEnumerator GenerateObstacle()
    {
        Debug.Log("GenerateObstacle coroutine started");
        int timer = random.Next(1, 5);
        yield return new WaitForSeconds(timer);
        CreateObstacle(PlayerControler.gameObject.transform.position.z + halfGroundSize);
        Debug.Log("GenerateObstacle coroutine restarted");
        StartCoroutine("GenerateObstacle");
    }

    public void IncreaseScore()
    {
        Zombie_kill_Count++;
        scoreText.text = Zombie_kill_Count.ToString();
    }

    public void PauseGame()
    {
        PausePanel.SetActive(true);
        Time.timeScale=0f;
    }

    public void ResumeGame()
    {
        PausePanel.SetActive(false);
        Time.timeScale=1f; 
    }

    public void ExitGame()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
    
    public void GameOver()
    {
        Time.timeScale = 0f;
        Game_Over_Panel.SetActive(true);
        GameOverText = GameObject.Find("Kill_Score").GetComponent<TextMeshProUGUI>();
        GameOverText.text = "Killed: "+scoreText.text;
    }
    public void Restart() 
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainGamePlay");
    }











}//class

