using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {

    private GM GM;
    private Ball ball;
    private string type;

    void Start () {
        GM = GameObject.Find("GM").GetComponent<GM>();
        ball = GameObject.Find("Ball").GetComponent<Ball>();

        // Para ignorar las colisiones con la pelota, no funciona!!!!!!!!!
        Physics.IgnoreCollision(ball.GetComponent<Collider>(), GetComponent<Collider>());
    }

	void Update () {
	
	}

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "Paddle")
        {
            applyPowerUp();
            Destroy(gameObject);
        }
    }

    private void applyPowerUp()
    {
        switch(type)
        {
            case "velMax":
                ball.speedUp(1200);
                break;

            case "velMin":
                ball.speedDown(1200);
                break;

            case "increasePaddle":
                break;

            case "decreasePaddle":
                break;

            case "multipleBalls":
                break;

            case "machineGun":
                break;

            case "extraLife":
                GM.extraLive();
                break;

            default:
                break;
        }
    }

    public void setType(string t)
    {
        type = t;
    }
}
