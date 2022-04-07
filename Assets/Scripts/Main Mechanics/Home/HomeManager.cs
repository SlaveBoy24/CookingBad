using UnityEngine;

public class HomeManager : MonoBehaviour
{
    [SerializeField] private GameObject _character;
    [SerializeField] private Transform _spawnPoint;

    private void Start()
    {
        GameObject newCharacter = Instantiate(_character);
        newCharacter.transform.SetParent(null);
        newCharacter.transform.position = _spawnPoint.position;
        newCharacter.transform.localScale = new Vector3(1.35f, 1.35f, 1);
    }
}
