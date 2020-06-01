using UnityEngine;


internal class Heart : MonoBehaviour
{
    public void Remove()
    {
        Destroy(gameObject);
        print("Ok");
    }
}
