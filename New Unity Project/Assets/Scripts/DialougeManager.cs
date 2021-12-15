using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialougeManager : MonoBehaviour
{
    public Text nameText;
    public Text dialougeText;

    public Animator myAnimator;

    public AudioClip typeSound;
    public AudioSource audioSource;
    
    private Queue<string> sentences;
   
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        sentences = new Queue<string>();
        audioSource.Stop();
    }

    public void StartDialouge (Dialouge dialouge)
    {
        myAnimator.SetBool("IsOpen", true);
        Debug.Log("Starting Conversation with " + dialouge.name);
        nameText.text = dialouge.name;
        sentences.Clear();
        foreach (string sentence in dialouge.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialouge();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        audioSource.Play();
        dialougeText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialougeText.text += letter;
            yield return null;
        }
        audioSource.Stop();
    }

    void EndDialouge()
    {
        myAnimator.SetBool("IsOpen", false);
        audioSource.Stop();
        Debug.Log("End of conversation");
    }

}
