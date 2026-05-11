using UnityEngine;

public class SlalomFlag : MonoBehaviour
{
    private enum Direction { Left, Right };
    [SerializeField] private Direction direction;
    private bool flagPassed;

    public static event GameManager.TimerEvent RacePenalty;

    [SerializeField] private Material goodMat, badMat;
    void Update()
    {
        if (PlayerControl.player != null && PlayerControl.player.position.z < transform.position.z && flagPassed == false)
        {
            flagPassed = true;
            Direction passingDirection = Direction.Right;
            if (PlayerControl.player.position.x < transform.position.x)
                passingDirection = Direction.Left;
            MeshRenderer renderer = GetComponent<MeshRenderer>();

            if (passingDirection == direction)
            {
                renderer.material = goodMat;
            }
            else
            {
                renderer.material = badMat;
                RacePenalty.Invoke();
            }
        }
    }
}
