using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour 
{

	public static DialogueManager Instance {get; private set;}
    private void Awake()
    {
        Instance=this;
    }
    public TMP_Text nameText;
	public TMP_Text dialogueText;

	public GameObject diaPanel;
	public int cur_TypeNPC;

	private Queue<string> sentences;
	[SerializeField]private PlayerController playerControl;

	private Dialogue[] dialogues;
	private int cur_Dia;
	private int max_Dia;
    
	// Use this for initialization
	void Start () {
		sentences = new Queue<string>();
	}
	public void StartSomeDialogue(Dialogue[] _dialogues, int _typeNPC)
	{
		cur_TypeNPC=_typeNPC;
		dialogues=_dialogues;
		cur_Dia=0;
		max_Dia=dialogues.Length-1;
		StartDialogue(dialogues[cur_Dia]);
	}
	public void StartDialogue (Dialogue dialogue)
	{
		diaPanel.SetActive(true);
		Time.timeScale=0f;
		nameText.text = dialogue.name;

		sentences.Clear();

		foreach (string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}

		DisplayNextSentence();
	}

	public void DisplayNextSentence ()
	{
		if (sentences.Count == 0)
		{
			if(cur_Dia<max_Dia)
			{
				cur_Dia++;
				StartDialogue(dialogues[cur_Dia]);
			}
			else
			{
				EndDialogue();
				switch(cur_TypeNPC)
				{
					case 2:playerControl.playerUI.ShowShop();break;
					case 3:playerControl.npc_Dialogue.QuestNPCDia();break;
				}
			}
			
			return;
		}

		string sentence = sentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

	IEnumerator TypeSentence (string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return null;
		}
	}

	void EndDialogue()
	{
		diaPanel.SetActive(false);
		Time.timeScale=1f;
	}

}
