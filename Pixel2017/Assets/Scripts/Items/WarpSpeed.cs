using UnityEngine;
using System.Collections;

public class WarpSpeed : MonoBehaviour {
	public float WarpDistortion;
	public float Speed;
	ParticleSystem particles;
	ParticleSystemRenderer rend;
	bool isWarping;
    private ParticleSystem.MainModule main;

    void Awake()
	{
		particles = GetComponent<ParticleSystem>();
        rend = particles.GetComponent<ParticleSystemRenderer>();
        main = particles.main;
    }

	void Update()
	{
		if(isWarping && !atWarpSpeed())
		{
			rend.velocityScale += WarpDistortion * (Time.deltaTime * Speed);
		}

		if(!isWarping && !atNormalSpeed())
		{
			rend.velocityScale -= WarpDistortion * (Time.deltaTime * Speed);
		}

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Engage();
            main.simulationSpeed = 1.0f;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            Disengage();
            main.simulationSpeed = 0.25f;
        }
	}

	public void Engage()
	{
		isWarping = true;
	}

	public void Disengage()
	{
		isWarping = false;
	}

	bool atWarpSpeed()
	{
		return rend.velocityScale < WarpDistortion;
	}

	bool atNormalSpeed()
	{
		return rend.velocityScale > 0;
	}
}
