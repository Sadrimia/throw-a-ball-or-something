using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner spawner;
    [Header("Ball Settings")]
    [SerializeField] private GameObject _ball;
    [SerializeField] private Transform _ballSpawnPoint;
    [Header("Basket Settings")]
    [SerializeField] private GameObject _bin;
    [SerializeField] private Transform _basketSpawnPoint;
    [SerializeField] private Transform _leftCorner;
    [SerializeField] private Transform _rightCorner;
    [Header("Coin Settings")]
    [SerializeField] private GameObject _coin;
    private Transform _spawnPointPosition;
    [SerializeField] private int _spawnCoinAfterScore = 3;

    private GameObject _ballInGame;
    private GameObject _basketInGame;
    
    private void Awake()
    {
        if(spawner == null){
            spawner = this;
        }
        else{
            Destroy(gameObject);
        }
        _ballInGame = Instantiate(_ball, _ballSpawnPoint.position, Quaternion.identity);
        _basketInGame = Instantiate(_bin, new Vector3(Random.Range(_leftCorner.position.x, _rightCorner.position.x), _basketSpawnPoint.position.y, 0), Quaternion.identity);
    }

    public void SpawnBall()
    {
        Destroy(_ballInGame);
        _ballInGame = Instantiate(_ball, _ballSpawnPoint.position, Quaternion.identity);
    }

    public void SpawnBasket()
    {
        Destroy(_basketInGame);
        _basketInGame = Instantiate(_bin, new Vector3(Random.Range(_leftCorner.position.x, _rightCorner.position.x), _basketSpawnPoint.position.y, 0), Quaternion.identity);
        if(GameManager.gm.scoreThrows % _spawnCoinAfterScore == 0){
            _spawnPointPosition = _basketInGame.transform.GetChild(2);
           Instantiate(_coin, _spawnPointPosition.position, Quaternion.identity);
        }
    }
}
