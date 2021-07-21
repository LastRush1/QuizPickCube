using UnityEngine;

public class GameBehavior : MonoBehaviour
{
    public virtual bool GameAwake() => true;

    public virtual bool GameStart() => true;
    public virtual bool GameUpdate() => true;

}
