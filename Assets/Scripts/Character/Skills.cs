using UnityEngine;

public class Skills : MonoBehaviour
{ 
    [SerializeField] private int _skill;

    public float GetSkill()
    {
        switch (Mathf.Round(_skill / 25))
        {
            case 1: return Random.Range(30, 35);
            case 2: return Random.Range(20, 25);
            case 3: return Random.Range(10, 15);
            case 4: return Random.Range(0, 10);

            default: return Random.Range(40, 45);
        }
    }

    public void SetSkill(int skill)
    {
        if (skill < 0)
            return;

        _skill += skill;

        if (_skill >= 100)
            _skill = 100;
    }
}
