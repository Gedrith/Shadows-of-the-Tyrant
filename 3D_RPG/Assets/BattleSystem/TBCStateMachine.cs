using UnityEngine;
using System.Collections;

public class TBCStateMachine : MonoBehaviour{


	private BattleStateStart startScript = new BattleStateStart();
	public string enemy1;
	public string enemy2;
	public string enemy3;
	private int num_enemy;
	private string[] enemy;
	private Olaf_stats Olaf;
	private Luna_stats Luna;
	private Rylai_stats Rylai;
	public string[] turn;
	public static bool GUIFlag = false;
	private Communicator comm = new Communicator ();
	private PlayerAction action = new PlayerAction ();
	private EnemyAction Eaction = new EnemyAction();
	private int i = 0;

	private string[] turnList = new string[6];
	private bool inBattle = false;

	private bool doneWaiting = false;
	private bool playAnim = true;
	private bool playOnce = true;

	public enum BattleStates
	{
		START,
		PLAYERACTION,
		ENEMYACTION,
		AFTERTURN,
		LOSE,
		WIN
	}

	public BattleStates currentState;
	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if(inBattle)
		{
			switch(currentState)
			{
				case(BattleStates.START):
					//Setup battle
					//Spawn enemies, create battle turn list, etc
					startScript.PrepareBattle(enemy);
					turn = startScript.comList;
					num_enemy = num_enemy + 3;
					comm.stuffInCombat(num_enemy);
					comm.set_TurnOrder(turn);
				    if(turn[0].CompareTo("Luna")==0)
					{
						currentState = BattleStates.PLAYERACTION;
						if(!comm.getFlag())
						{
							comm.toggleFlag();
						}
					}
					else
					{
						currentState = BattleStates.ENEMYACTION;
					}
					break;
				case(BattleStates.PLAYERACTION):
					//Take turn, deal damage, check for win/lose, next turn
					if(turn[i].CompareTo("Olaf") == 0)
					{
						if(Olaf.isDead())
						{
							currentState = BattleStates.AFTERTURN;
							break;
						}
					}
					else if(turn[i].CompareTo("Luna") == 0)
					{
						if(Luna.isDead())
						{
							currentState = BattleStates.AFTERTURN;
							break;
						}
					}
					else if(turn[i].CompareTo("Rylai") == 0)
					{
						if(Rylai.isDead())
						{
							currentState = BattleStates.AFTERTURN;
							break;
						}
					}
					comm.set_CurrentPlayer(turn[i]);
					if(comm.get_attack())
					{
						if(comm.get_attacked().CompareTo("") != 0)
						{
							if(comm.get_attack())
							{
								action.start ("attack", turn[i]);
								comm.attackFlag();
								comm.set_attacked("");
							}
						}
					}
					if(comm.get_magic())
					{
						if(comm.get_HealTarget().CompareTo("") != 0)
						{
							action.start ("Magic", turn[i]);
							comm.magicFlag();
							comm.set_HealTarget("");
						}
						if(comm.get_attacked().CompareTo("") != 0)
						{
							action.start ("Magic", turn[i]);
							comm.magicFlag();
							comm.set_attacked("");
						}
					}
					if(comm.get_item())
					{
						if(comm.get_HealTarget().CompareTo("") != 0)
						{
							action.start ("Item", turn[i]);
							comm.itemFlag();
							comm.set_HealTarget("");
						}
					}
					if(comm.get_defend())
					{
						action.start ("defend", turn[i]);
						comm.defendFlag();
					}
					if(comm.get_EndPlayerAction())
					{
						currentState = BattleStates.AFTERTURN;
					}
					break;
				case(BattleStates.ENEMYACTION):
					Eaction.start(turn[i]);
					currentState = BattleStates.AFTERTURN;
					break;
				case(BattleStates.AFTERTURN):

					//Play Animations
					if(playAnim)
					{
						playAnim = false;
						//Death Animations
						if(comm.get_Tyrant() != null)
						{
							if(comm.get_Tyrant().isDead())
							{
								GameObject test = GameObject.Find("Enemy1");
								test.GetComponentInChildren<Animation>().CrossFade("death", 0.0f);
							}
						}
						if(comm.getGob1() != null)
						{
							if(comm.getGob1().isDead())
							{
								if(comm.get_enemy1().CompareTo("Goblin") == 0)
								{
									GameObject test = GameObject.Find("Enemy1");
									if(test.GetComponentInChildren<Animation>().isPlaying)
										test.GetComponentInChildren<Animation>().CrossFade("death", 0.0f);
								}
								else if(comm.get_enemy2().CompareTo("Goblin") == 0)
								{
									GameObject test = GameObject.Find("Enemy2");
									if(test.GetComponentInChildren<Animation>().isPlaying)
										test.GetComponentInChildren<Animation>().CrossFade("death", 0.0f);
								}
								else if(comm.get_enemy3().CompareTo("Goblin") == 0)
								{
									GameObject test = GameObject.Find("Enemy3");
									if(test.GetComponentInChildren<Animation>().isPlaying)
										test.GetComponentInChildren<Animation>().CrossFade("death", 0.0f);
								}
							}
						}
						if(comm.getSpider1() != null)
						{
							if(comm.getSpider1().isDead())
							{
								if(comm.get_enemy1().CompareTo("Spider") == 0)
								{
									GameObject test = GameObject.Find("Enemy1");
									if(test.GetComponentInChildren<Animation>().isPlaying)
										test.GetComponentInChildren<Animation>().CrossFade("Death", 0.0f);
								}
								else if(comm.get_enemy2().CompareTo("Spider") == 0)
								{
									GameObject test = GameObject.Find("Enemy2");
									if(test.GetComponentInChildren<Animation>().isPlaying)
										test.GetComponentInChildren<Animation>().CrossFade("Death", 0.0f);
								}
								else if(comm.get_enemy3().CompareTo("Spider") == 0)
								{
									GameObject test = GameObject.Find("Enemy3");
									if(test.GetComponentInChildren<Animation>().isPlaying)
										test.GetComponentInChildren<Animation>().CrossFade("Death", 0.0f);
								}
							}
						}
						if(comm.getTroll1() != null)
						{
							if(comm.getTroll1().isDead())
							{
								if(comm.get_enemy1().CompareTo("Troll") == 0)
								{
									GameObject test = GameObject.Find("Enemy1");
									if(test.GetComponentInChildren<Animation>().isPlaying)
										test.GetComponentInChildren<Animation>().CrossFade("Die", 0.0f);
								}
								else if(comm.get_enemy2().CompareTo("Troll") == 0)
								{
									GameObject test = GameObject.Find("Enemy2");
									if(test.GetComponentInChildren<Animation>().isPlaying)
										test.GetComponentInChildren<Animation>().CrossFade("Die", 0.0f);
								}
								else if(comm.get_enemy3().CompareTo("Troll") == 0)
								{
									GameObject test = GameObject.Find("Enemy3");
									if(test.GetComponentInChildren<Animation>().isPlaying)
										test.GetComponentInChildren<Animation>().CrossFade("Die", 0.0f);
								}
							}
						}
						if(Olaf.isDead())
						{
							Animator test = GameObject.Find("BattleOlaf").GetComponent<Animator>();
							test.SetTrigger("Death");
						}
						else if(Luna.isDead())
						{
							Animator test = GameObject.Find("BattleLuna").GetComponent<Animator>();
							test.SetTrigger("Death");
						}
						else if(Rylai.isDead())
						{
							Animator test = GameObject.Find("BattleRylai").GetComponent<Animator>();
							test.SetTrigger("Death");
						}
					}
					if(!doneWaiting && playOnce)
						StartCoroutine(wait4Anims(1.5f));

					//Check win/lose condition
					if(doneWaiting)
					{
						doneWaiting = false;
						playAnim = true;
						playOnce = true;
						if(comm.get_EnemyDead())
						{
							currentState = BattleStates.WIN;
							break;
						}
						if(comm.get_PartyDead())
						{
							currentState = BattleStates.LOSE;
						}
						//Get Next Turn
						i++;
						if(i == num_enemy)
						{
							i = 0;
						}
						Debug.Log("Next: " + turn[i]);
						if(turn[i].CompareTo("Olaf")==0 || turn[i].CompareTo("Rylai") == 0 || turn[i].CompareTo("Luna") == 0)
						{
							if(comm.getFlag() == false)
								comm.toggleFlag();
							comm.set_EndPlayerAction(false);
							currentState = BattleStates.PLAYERACTION;
						}
						else
						{
							comm.set_EndPlayerAction(false);
							currentState = BattleStates.ENEMYACTION;
						}
					}
					break;
				case(BattleStates.WIN):
					Debug.Log ("WE WIN!!!!");
					comm.set_battleWon(true);
					if(comm.get_done())
					{
						i = 0;
						enemy1 = "";
						enemy2 = "";
						enemy3 = "";
						comm.ResetComm();
						inBattle = false;
						comm.set_done(false);
						comm.set_battleWon(false);
						SceneController.battleScene.SetActive(false);
						SceneController.mapScene.SetActive(true);
					}
					break;
				case(BattleStates.LOSE):
					comm.set_battleLost(true);
					Debug.Log ("WE LOSE??!?!?!??");
					if(comm.get_done())
					{
						i=0;
						enemy1 = "";
						enemy2 = "";
						enemy3 = "";
						comm.ResetComm();
						inBattle = false;
						comm.set_done(false);
						comm.set_battleLost(false);
						Application.LoadLevel("GameOver");
					}
					break;
			}
		}
	}

	public void StartNewBattle()
	{
		Debug.Log(enemy1 + " " + enemy2 + " " + enemy3);
		comm.set_enemy (enemy1, enemy2, enemy3);
		enemy = new string[3];
		turn = new string[6];
		int i = 0;
		currentState = BattleStates.START;
		Olaf = new Olaf_stats ();
		Luna = new Luna_stats ();
		Rylai = new Rylai_stats ();
		if (enemy1 != "") 
		{
			enemy[i] = enemy1;
			i++;
		}
		if (enemy2 != "") 
		{
			enemy[i] = enemy2;
			i++;
		}
		if (enemy3 != "") 
		{
			enemy[i] = enemy3;
			i++;
		}
		num_enemy = i;
		comm.set_Enemies (enemy);
		inBattle = true;
	}

	private IEnumerator wait4Anims(float seconds)
	{
		playOnce = false;
		yield return new WaitForSeconds(seconds);
		doneWaiting = true;
	}
}