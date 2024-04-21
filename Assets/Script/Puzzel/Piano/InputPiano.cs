    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
using UnityEngine.PlayerLoop;

public class InputPiano : NewMonoBehaviour
    {
        [SerializeField] protected SO_Piano sO_Piano;
        private MusicNote musicNote;
        private Animator animator;
        private string namePiano;
        private Piano piano;

        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadAnimator();
            this.LoadMusicNote();
            this.LoadPiano();
        }
        protected virtual void LoadAnimator()
        {
            if(this.animator != null) return;
            this.animator = transform.parent.GetComponent<Animator>();
            Debug.Log(transform.name + ": LoadAnimator()", gameObject);
        }
        protected virtual void LoadPiano()
        {
            if(this.piano != null) return;
            this.piano = transform.parent.parent.GetComponent<Piano>();
            Debug.Log(transform.name + ": LoadPiano()", gameObject);
        }
        protected virtual void LoadMusicNote()
        {
            if(this.musicNote != null) return;
            this.musicNote = GetComponentInChildren<MusicNote>();
            Debug.Log(transform.name + ": LoadMusicNote()", gameObject);
        }
        private void OnMouseDown()
        {
            namePiano = sO_Piano.name;
            piano.AddpressedPianoName(namePiano);
            animator.SetTrigger(namePiano);
            this.musicNote.Note_Play();
        }

        // private IEnumerator InputPiano()
        // {
        //     yield return new WaitForSeconds(0.01f);
        // }
    }
