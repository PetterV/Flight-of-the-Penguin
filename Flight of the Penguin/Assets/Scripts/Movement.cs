
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Movement : MonoBehaviour {
	
	private float Acceleration = 36.0f;
	private int startBoost = 20;
	private float MaxVelocity = 100;
	private float MaxCrash = 30;
	public float Fuel = 1000;
	public float Gravity = 32;
	private float MouseProx = 0.3f;
	public Image image;
	float timeLeft = 3.0f; // hvor lenge det tar før rakten sprenger når den er tom for bensin
	public float maxFuel;
	private bool fuelPlaySound = false;
	public bool detectable = true;
	float percent;
	public int minFuel = 9;
	//VARIABLES ADDED BY PETTER
	//Gravity stuff
	private float Gincrease = 0.45f;
	public float GravityStart = 20.0f;
	private float GincreaseReal = 900f;
	private float GravityFactor = 32f;
	private float GravityDivision = 30f;
	private float maxGravity = 50f;
	//Drag changes mid-gameplay allows more flexibility of adjustment.
	private float drag = 1.6f;
	private float dragFall = 0.4f;
	//Animation variables
	private float AnimCrazy = 2.53f;
	private Animator animator;
	private int screamLength = 50;
	public int screamTimer = 0;
	public int animStateTracker = 0;
	//Counting speed for the sake of animation
	private float speed = 0;
	public float speedCounter = 0f;
	Vector3 lastPosition = Vector3.zero;
	//Debug mode. Prevents Dead from becoming true.
	public bool debug = false;
	public Camera mainCamera;
	//??? Brukes ikke til noe i dette scriptet, men muligens i et annet, så ikke slett.
	public int touchTimer;
	public bool surfaceTouched;
	//Eksplosjonsjusteringer
	public Material explosionMaterial;
	public Light explosionLight;
	//Physicsobjekter
	Rigidbody2D pObjectToActivate;
	float torqueToAdd = 5f;

	//DONE WITH VARIABLES ADDED BY PETTER

	int deathTime = 100;
	bool goalHit;
	Vector3 direction;
	private bool jetpackActive = false;
	private bool mouseAway = false;
	public bool dead = false;
	public bool jetpackOn = false;
	bool inCannon = false;
	public int jetpackOnTime = 0; //for extra boost at start
	// Use this for initialization
	void Start () {
		
		rigidbody2D.interpolation = RigidbodyInterpolation2D.Extrapolate;
		image = GameObject.FindWithTag ("FuelImage").GetComponent<Image>();
		image.fillAmount = 1;
		percent = maxFuel / 100;
		dead = false;
		//Debug.Log (percent + "%");
		animator = GetComponent<Animator> ();
	}
	
	// FixedUpdate is called at a fixed rate not once per frame, physics here
	void FixedUpdate ()
	{
		//Added by Petter
		speed = (transform.position - lastPosition).magnitude;
		lastPosition = transform.position;
		//End of addition


		direction = rigidbody2D.velocity.normalized;
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);

		if (dead == false && goalHit == false){
		//Rotation of the sprite using Quaternion.LookRotation
		Quaternion rot = Quaternion.LookRotation (transform.position - new Vector3 (mousePosition.x, mousePosition.y, -100), Vector3.forward);
		transform.rotation = rot;
		}
		//Strip away x and y rotation of the character
		transform.eulerAngles = new Vector3 (0, 0, transform.eulerAngles.z);

		if (!inCannon)
			jetpackActive = Input.GetButton ("Fire1");
		else
			jetpackActive = false;
		
		//mosue not close to pingu
		if ((mousePosition.x < rigidbody2D.position.x - MouseProx || mousePosition.x > rigidbody2D.position.x + MouseProx ||
			mousePosition.y < rigidbody2D.position.y - MouseProx || mousePosition.y > rigidbody2D.position.y + MouseProx))   
			mouseAway = true;
		else
			mouseAway = false;
		

		
		if (jetpackActive && Fuel > 0 && mouseAway && dead == false && goalHit == false) {
			if (!jetpackOn) {
				jetpackOn = true;
				Fuel -= minFuel;
				jetpackOnTime = 0;
			}
			Fuel -= 1;
			fuelPlaySound = true;
			float accel = Acceleration;
			if (jetpackOnTime < 10){ //for extra boost at start
				accel += startBoost;
				mainCamera.GetComponent<LaunchShake>().launch = true;
			}
			if (jetpackOnTime >= 10){
				accel = Acceleration;
			}
			Vector3 force = new Vector3 (mousePosition.x - rigidbody2D.position.x, mousePosition.y - rigidbody2D.position.y, 0).normalized;
			//image.fillAmount =image.fillAmount - (1/(percent*100));
			if (rigidbody2D.velocity.x <= MaxVelocity && gameObject.transform.up.x * Acceleration > -0.1) {
				rigidbody2D.AddForce (new Vector3 (force.x * accel, 0, 0));
				//print (MaxVelocity);
				//Debug.Log (rigidbody2D.velocity.x);
			} else if (rigidbody2D.velocity.x >= -MaxVelocity && gameObject.transform.up.x * Acceleration < 0.1) {
				rigidbody2D.AddForce (new Vector3 (force.x * accel, 0, 0));
				//print (MaxVelocity);
			}
			
			if (rigidbody2D.velocity.y <= MaxVelocity && gameObject.transform.up.y * Acceleration > -0.1) {
				rigidbody2D.AddForce (new Vector3 (0, force.y * accel, 0));
				//Debug.Log (rigidbody2D.velocity.y);
			} else if (rigidbody2D.velocity.y >= -MaxVelocity && gameObject.transform.up.y * Acceleration < 0.1) {
				rigidbody2D.AddForce (new Vector3 (0, force.y * accel, 0));
				//Debug.Log (rigidbody2D.velocity.y);
			}

			
			jetpackOnTime++;
		} else if (inCannon) {
			//rigidbody2D.velocity = new Vector2(0,0); //this is gonna fuck me over :< else gravity ?
			fuelPlaySound = false;
			jetpackOn = false;
			jetpackOnTime = 0;

		}

		//Uncomment to return gravity to normal!
		else {
			if (rigidbody2D.velocity.y <= maxGravity && dead == false) {
				rigidbody2D.AddForce (new Vector3 (0, -Gravity, 0));
				fuelPlaySound = false;
				jetpackOn = false;
				jetpackOnTime = 0;
			}
		}


		//Increases Gravity as player falls
		{
			GravityFactor = Gravity / GravityDivision;
		}
		{
			GincreaseReal = Gincrease * GravityFactor;
		}
		if (jetpackOn == false && rigidbody2D.velocity.y <= -0.02) {
			Gravity = Gravity + GincreaseReal;
		}
		if (jetpackOn == true) {
			Gravity = GravityStart;
		}
		//Sets linear drag depending on whether player is flying or not
		if (jetpackOn == false) {
			rigidbody2D.drag = dragFall;
		}
		if (jetpackOn == true && jetpackOnTime > 100) {
			rigidbody2D.drag = drag;
		}
		//Acceleration øker over tid
//		if (jetpackOn == false) {
//			Acceleration = StartAcceleration;
//		}
//		if (Acceleration <= StartAcceleration) {
//			Acceleration = StartAcceleration;
//		}
//		if (jetpackOn == true && Acceleration <= MaxAcceleration ) {
//			Acceleration = AccelGrowth * AccelFactor;
//		}
		//Sign: Petter (bare slett ting mellom disse to)
		
	}
	
	// Update is called once per frame
	void Update () {

		//ADDED BY PETTER:
		//Animation
		speedCounter = speed * 10;
		if (speedCounter <= 0.01f) {
			animator.SetInteger ("FlySpeed", 0);
			animStateTracker = 0;
		}
		if (jetpackActive && speedCounter < AnimCrazy && animStateTracker == 0 && Fuel > 0){
			animator.SetInteger("FlySpeed", 1);
			animStateTracker = 1;
		}
		if (jetpackActive && speedCounter >= AnimCrazy) {
			animator.SetInteger ("FlySpeed", 2);
			animStateTracker = 2;
			screamTimer++;
		}
		if (dead == true){
			animator.SetInteger("FlySpeed", 4);
			deathTime -= 1;
		}
		if (deathTime < 0){
			Application.LoadLevel (Application.loadedLevelName);
		}
		//This one is currently the cause of a lot of the quick-switching.
		if (!jetpackActive && speedCounter >= 2 * AnimCrazy) {
			animator.SetInteger ("FlySpeed", 2);
			animStateTracker = 2;
			screamTimer++;
		}
		else if (!jetpackActive && speedCounter >= AnimCrazy && animStateTracker == 0) {
			animator.SetInteger ("FlySpeed", 1);
			animStateTracker = 1;
		}
		else if (!jetpackActive && speedCounter >= AnimCrazy && animStateTracker == 2 && screamTimer >= screamLength) {
			animator.SetInteger ("FlySpeed", 1);
			animStateTracker = 1;
			screamTimer = 0;
		}
		if (screamTimer > 1 && speedCounter <= AnimCrazy) {
			screamTimer++;
		}

		//Shake while flying
		if (jetpackOn == true && speedCounter >= 2.5f * AnimCrazy) {
			mainCamera.GetComponent<FlyShake>().fly = true;
		} else {
			mainCamera.GetComponent<FlyShake>().fly = false;
		}


		//update fuelbar
		image.fillAmount = Fuel/maxFuel;

		if (Input.GetKeyDown(KeyCode.P))
		{
			if (Time.timeScale == 1)
			{
				Time.timeScale = 0;
			}
			else
			{
				Time.timeScale = 1;
			}
		}

		if (Input.GetKey (KeyCode.Q)) {
			print("fking Quit");
			Application.Quit();
		}


		if (Input.GetKey("escape") && Application.loadedLevelName != "Meny")
			Application.LoadLevel("Meny");
		else if	(Input.GetKey("escape") && Application.loadedLevelName == "Meny")
			Application.Quit();

		if(Fuel < 1)
		{
			timeLeft -= Time.deltaTime;
//DEAD DEBUG BELOW
			if(timeLeft < 0 && debug == false)
			{
				Dead();
			}
		}
		//DEBUG RESET BUTTON
		if( Input.GetKey(KeyCode.Space))
			Application.LoadLevel(Application.loadedLevelName);

		if (goalHit){
			Vector3 vectorZero = new Vector3(0, 0, 0);
			rigidbody2D.velocity = vectorZero;
			rigidbody2D.isKinematic = true;
			animator.SetInteger("FlySpeed", 5);
		}
		
	}
	public Vector3 getDir()
	{
		return direction;
	}
	
	void OnCollisionEnter2D(Collision2D coll) {

		if (coll.gameObject.tag == "Wall" && debug == false) {
			if (coll.relativeVelocity.y < -MaxCrash) {
				Dead();
				//spriteChanger.ChangeTheDamnSprite (deathSprite);
				//rigidbody2D.velocity = new Vector2(0,0);
				//debug crash
//				GameObject cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
//				cube.transform.position = new Vector3 (coll.contacts [0].point.x, coll.contacts [0].point.y, 0);
//				// set "game over" screen?
				//Application.LoadLevel(Application.loadedLevelName);
			} else if (coll.relativeVelocity.y > MaxCrash) {
				Dead();
				// set "game over" screen?
				//Application.LoadLevel(Application.loadedLevelName);
				
				//debug crash
//				GameObject cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
//				cube.transform.position = new Vector3 (coll.contacts [0].point.x, coll.contacts [0].point.y, 0);
//				
			}
			if (coll.relativeVelocity.x < -MaxCrash) {
				//spriteChanger.ChangeTheDamnSprite (deathSprite);
				//rigidbody2D.velocity = new Vector2(0,0);
				Dead();
				// set "game over" screen?
				//Application.LoadLevel(Application.loadedLevelName);
				
				//debug crash
//				GameObject cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
//				cube.transform.position = new Vector3 (coll.contacts [0].point.x, coll.contacts [0].point.y, 0);
				
			}
			if (coll.relativeVelocity.x > MaxCrash) {
				Dead();

				
			}
			
		}
		//DEAD DEBUG BELOW
		if (coll.gameObject.tag == "Mine" && debug == false) {
			GameObject explodingMine = coll.gameObject;
			//play explosions and 2 sec later restart? feels nice with insta restart. mby sound
			if (explodingMine.GetComponent<Rigidbody2D>() != null){
				explodingMine.rigidbody2D.isKinematic = true;
			}
			explodingMine.GetComponent<Animator>().SetInteger("Explode", 1);
			Destroy (explodingMine, 0.3f);
			//add explosion for mines
			Dead();
		}
	}
	void OnTriggerEnter2D(Collider2D other) {
		//DEAD DEBUG BELOW
		if (other.gameObject.tag == "Goal") {
			goalHit=true;
			GameObject.FindWithTag("Timer").GetComponent<Timer>().Stop();
		}
		if (other.gameObject.tag == "Laser" && debug == false) {
			//play explosions and 2 sec later restart? feels nice with insta restart. mby sound
			Dead();
			
		}

		//Activate Physics objects
		if (other.gameObject.tag == "PhysicsObject" && other.GetComponent<Rigidbody2D>().isKinematic == true) {
			pObjectToActivate = other.GetComponent<Rigidbody2D>();
			pObjectToActivate.isKinematic = false;
			torqueToAdd = UnityEngine.Random.Range(-7f, 7f);
			pObjectToActivate.AddTorque(torqueToAdd, ForceMode2D.Force);
		}
		
		if (other.gameObject.tag == "Fuel") {		
			Fuel += 100;
			Destroy (other.gameObject);
			print ("FEUL DAMNIT");

			if (Fuel > maxFuel)
				Fuel = maxFuel;
		} 
		if (other.gameObject.tag == "ZoneHide") {
			detectable = false;
			print("HIDE");
		}/*
		else if (other.gameObject.tag == "Bouncer") {
			//bounces pingu
			Vector2 pos= new Vector2(0,0);
			pos.x = Mathf.Abs(rigidbody2D.position.x) - Mathf.Abs(other.transform.position.x);
			pos.y = Mathf.Abs(rigidbody2D.position.y) - Mathf.Abs(other.transform.position.y);
			
			if(Mathf.Abs(pos.x)<Mathf.Abs(pos.y)){
				print ("ByttY");
				print (rigidbody2D.velocity.y);
				Vector2 v =rigidbody2D.velocity;
				v.y = Mathf.Round(rigidbody2D.velocity.y);
				v.y = -v.y;
				if(v.y>0 && v.y<7.0f)
					v.y=8.3f;
				else if(v.y<0 && v.y>-7.0f)
					v.y=-8.3f;
				rigidbody2D.velocity = v;
				
				print (rigidbody2D.velocity.y);
			}

			else if(Mathf.Abs(pos.x)>Mathf.Abs(pos.y)){
				Vector2 v = rigidbody2D.velocity;
				v.x = Mathf.Round(rigidbody2D.velocity.x);
				v.x = -v.x;
				if(v.x>0 && v.x<7.0f)
					v.y=8.3f;
				else if(v.x<0 && v.x>-7.0f)
					v.y=-8.3f;
				rigidbody2D.velocity = v;
				print ("ByttX");
			}
			else{
				Vector2 v = rigidbody2D.velocity;
				v = -v;
				rigidbody2D.velocity = v;
			}
		}*/
	}
	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.tag == "ZoneHide") {
			detectable = true;
		}
	}

	public void OnCollisionStay2D( Collision2D coll)
	{
		if (coll.gameObject.tag == "Wall" || coll.gameObject.tag == "MovingBlock") {
			ContactPoint2D[] kContactPoints = coll.contacts;
			Vector2 kCenter = gameObject.rigidbody2D.position;
		
			ContactPoint2D kContactPoint = kContactPoints [0];
			Vector2 kNormal = kContactPoint.point - new Vector2(gameObject.transform.position.x,gameObject.transform.position.y);
			RaycastHit2D kHitInfo = Physics2D.Raycast (kCenter, kNormal);
			//Debug.DrawRay (kCenter, kNormal, Color.red, kHitInfo.distance, true);

			if (kHitInfo.distance < 0.1f)
			{
				if(kCenter!=new Vector2(0.0f,0.0f)){
					//spriteChanger.ChangeTheDamnSprite (deathSprite);
					//gameObject.rigidbody2D.collider2D.enabled=false;
					Dead();
					print ("squashed player!!!");
				}
				//print ("Depth: " + kHitInfo.distance + coll.gameObject.name+"out"+transform.position + "hit" + kHitInfo.point+ " speed: "+ rigidbody2D.velocity);
			}
		}
	}

	void CannonOn() {
//		print("On");
		jetpackOn = false;
		inCannon = true;
		gameObject.renderer.enabled = false;
	}

	void CannonOff() {
		print("off");
		jetpackOn = true;
		inCannon = false;
		gameObject.renderer.enabled = true;
	}


	void Dead() {
		if (!goalHit) {
			print ("dead Player");
			dead = true;
			rigidbody2D.velocity = new Vector2 (0, 0);
			Gravity = 0;
			Gincrease = 0;
			GincreaseReal = 0;
			rigidbody2D.velocity = new Vector3 (0, 0, 0);
			mainCamera.GetComponent<PerlinShake> ().testDead = true;
			Destroy (GetComponent<Collider2D> ());
			Destroy (GetComponent<BoxCollider2D> ());
			Destroy (GetComponent<CircleCollider2D> ());
			renderer.material = explosionMaterial;
			explosionLight.enabled = true;
			jetpackOn = false;
			jetpackActive = false;
			GameObject.FindWithTag("Timer").GetComponent<Timer>().Stop();
		}
	}
}

