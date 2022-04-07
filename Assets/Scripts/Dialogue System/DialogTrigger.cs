using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    [SerializeField] private TextAsset _text;

    private void OnMouseDown()
    {
        DialogueManager.GetInstance().EnterDialogueMode(_text);
    }
}

