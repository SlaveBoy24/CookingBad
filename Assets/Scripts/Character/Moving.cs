using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    [SerializeField] private Animator _character;
    [SerializeField] private float _speed;

    private void Start()
    {
        _character = GameObject.FindGameObjectWithTag("Character").GetComponent<Animator>();
    }

    public bool MoveTo(GameObject obj)
    {
        if (this.transform.position.x < obj.transform.position.x)
            this.transform.rotation = Quaternion.Euler(0, 180, 0);
        else
            this.transform.rotation = Quaternion.Euler(0, 0, 0);

        _character.SetBool("Walk", true);

        Vector3 waypoint = new Vector3(obj.transform.position.x, this.transform.position.y, 1);

        if (Mathf.Abs(obj.transform.position.x - this.transform.position.x) >= 0.01f)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, waypoint, _speed * Time.deltaTime);
        }
        else
        {
            _character.SetBool("Walk", false);
            return false;
        }

        return true;
    }
}
