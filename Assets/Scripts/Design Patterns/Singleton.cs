using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Singleton : MonoBehaviour {

	public Color[] ssHeartColors;
    public GameObject corazon;
	public GameObject robot;
	public GameObject dich;
	public GameObject mono;
	public GameObject trich;
	public GameObject shield;
    public GameObject player;

	public SceneController sceneController;

	public PaddleController playerScript;

    public Canvas HUDGameplay;

	public CameraController cameraScript;
	
	public Transform paddleTransform;

	public BallShot ballShot;

    public BallCode ballCode;

    public LevelSelectionBox ls;
    public GameManager gm;

	public HealthUI healthUI;

    public PlayerLosedTransition transitionToGameOver;
	
	public ObjectPoolerParticles objectParticles;
	
	public GameObject collectableHeart;

	public RobotScreen robotScreen;

	public TimerCount time;

	public RobotAnimControl robotAnim;

    private static Singleton instance;

	


	

	public static Singleton GetInstance{
		get{
			if(instance == null){
				instance = GameObject.FindObjectOfType<Singleton>();
			}
			return instance;
		}
	}
}
