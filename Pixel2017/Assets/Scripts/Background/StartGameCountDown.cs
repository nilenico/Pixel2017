using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameCountDown : MonoBehaviour {
    
    public Sprite[] sprites;
    private SpriteRenderer renderer;
    
    // Use this for initialization

    void Start () {
        transform.localScale = new Vector2(2.5f, 2.5f);
		renderer = GetComponent<SpriteRenderer>();
        StartCoroutine(waitStartCountDown());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator waitStartCountDown()
    {

        transform.position = new Vector2(-7.5f, 7.5f);
        renderer.sprite = sprites[0];
        yield return new WaitForSeconds(1.2f);

        transform.position = new Vector2(7.5f, 7.5f);
        renderer.sprite = sprites[1];
        yield return new WaitForSeconds(1.3f);

        transform.position = new Vector2(-7.5f, -7.5f);
        renderer.sprite = sprites[2];
        yield return new WaitForSeconds(1.2f);

        transform.position = new Vector2(7.5f, -7.5f);
        renderer.enabled= false;
    }
}
