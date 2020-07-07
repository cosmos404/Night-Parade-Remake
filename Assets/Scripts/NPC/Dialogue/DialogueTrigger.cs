﻿using UnityEngine;

public class DialogueTrigger : MonoBehaviour {
    [HideInInspector] public GameObject player;
    [SerializeField] private bool triggerOnCollision; // trigger without pressing interact
    [SerializeField] private Dialogue dialogue;
    public float triggerRange;
    public MeshRenderer textPrompt;

    void Start () {
        player = GameObject.FindGameObjectWithTag ("Player");
    }
    public virtual void Update () {
        bool isTalking = FindObjectOfType<DialogueManager> ().isTalking;
        if (textPrompt == null || player == null || triggerOnCollision) return;
        
        if (!isTalking && !triggerOnCollision && Vector2.Distance (player.transform.position, transform.position) <= triggerRange) {
            textPrompt.enabled = true;
            if (Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.DownArrow)) TriggerDialogue ();
        } else {
            textPrompt.enabled = false;
        }
    }

    private void OnTriggerEnter2D (Collider2D other) {
        if (triggerOnCollision && other.CompareTag ("Player")) {
            TriggerDialogue ();
        }
    }

    public void TriggerDialogue () { // Trigger random dialogue for now, TODO: later maybe generalize and make it possible to pick a bool flag in inspector to choose dailogue
        FindObjectOfType<DialogueManager> ().StartDialogue (dialogue);
    }

}