﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RevealHiddenArea : MonoBehaviour {

    public Tilemap tilemapToHide;
    public GameObject lightToTurnOff;
    public float fadingTime;
    public bool hideFromLeft;

    void OnTriggerEnter2D (Collider2D other) {
        if (other.CompareTag ("Player")) {
            Vector3 dir = other.transform.position - gameObject.transform.position;
            if (hideFromLeft && dir.x < 0 || !hideFromLeft && dir.x > 0) { // Reveal and fade out tilemap
                StartCoroutine (FadeTilemap (0f));
            } else { // Fade tilemap back in
                StartCoroutine (FadeTilemap (0.7f));
            }
        }
    }

    IEnumerator FadeTilemap (float alphaToFadeTo) {
        lightToTurnOff.SetActive (false);
        float alpha = tilemapToHide.color.a;
        for (float t = 0f; t < 1f; t += Time.deltaTime / fadingTime) {
            tilemapToHide.color = new Color (1, 1, 1, Mathf.Lerp (alpha, alphaToFadeTo, t));
            yield return null;
        }
    }
}