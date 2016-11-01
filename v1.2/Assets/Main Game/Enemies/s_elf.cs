using UnityEngine;
using System.Collections;

public class s_elf : MonoBehaviour
{
    public float elf_health = 30f;
    public float timer = 0.0f;
    //snappy movement to fit swiping on phones
    public void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            movement();
        }

    }

    public void movement()
    {
        int choice = (Random.Range(1,4));
        if (choice == 1)
        {
            Vector3 position = this.transform.position;
            position.x--;
            this.transform.position = position;
        }
        if (choice == 2)
        {
            Vector3 position = this.transform.position;
            position.x++;
            this.transform.position = position;
        }
        if (choice == 3)
        {
            Vector3 position = this.transform.position;
            position.y++;
            this.transform.position = position;
        }
        if (choice == 4)
        {
            Vector3 position = this.transform.position;
            position.y--;
            this.transform.position = position;
        }
        
        timer = 2.0f; //resets timer
    }

    public void OnCollisionEnter2D(Collision2D Col)
    {
        float x;
        float y;
        Vector2 pos;

        if (Col.gameObject.tag == "Player")
        {
            elf_health = elf_health - 10.0f; //more proper would be current position + random range
            x = Random.Range(-7.5f, 7.5f);
            y = Random.Range(-4.5f, 4.5f);
            pos = new Vector2(x, y);
            this.transform.position = pos;  
        }
    }
}
