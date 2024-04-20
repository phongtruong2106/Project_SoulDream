using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPiano : NewMonoBehaviour
{
    [SerializeField] protected SO_Piano sO_Piano;
    private MusicNote musicNote;
    private Animator animator;
    private string namePiano;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnimator();
        this.LoadMusicNote();
    }
    protected virtual void LoadAnimator()
    {
        if(this.animator != null) return;
        this.animator = transform.parent.GetComponent<Animator>();
        Debug.Log(transform.name + ": LoadAnimator()", gameObject);
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
       animator.SetTrigger(namePiano);
       this.musicNote.Note_Play();
    }

    // private IEnumerator InputPiano()
    // {
    //     yield return new WaitForSeconds(0.01f);
    // }
}
