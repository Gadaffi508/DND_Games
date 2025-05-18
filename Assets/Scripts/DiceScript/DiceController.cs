using UnityEngine;

public class DiceController : MonoBehaviour
{
    public bool _rolling = false;
    public int DiceCount;

    private void Start()
    {
        _rolling = false;
    }
    public void DestroyGameObject()
    {
        _rolling = true;
    }
    public void DestroyMe()
    {
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        if (_rolling)
        {
            transform.rotation = Quaternion.identity;
            DiceNumberText.diceNumber = 0;
            float dirX = Random.Range(-90, 90);
            float dirY = Random.Range(-90, 90);
            float dirZ = Random.Range(-90, 90);

            transform.Rotate(dirX , dirY , dirZ);
        }
    }
}
