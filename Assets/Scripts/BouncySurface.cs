using UnityEngine;

public class BouncySurface : MonoBehaviour
{
    public float bounceStrength;

    private void OnCollisionEnter2D(Collision2D collision){  //когда объект соприкасается с чем-либо 
         Ball ball = collision.gameObject.GetComponent<Ball>(); //а конкретно с мячом
         if (ball != null) {
             Vector2 normal = collision.GetContact(0).normal;  //берём нормаль первого контакта объекта, т.е. вектор будет направлен перпендикулярно к поверхности, в точке столкновения. 
             ball.AddForce(-normal * this.bounceStrength); //берём отрицательный вектор, т.к. после столкновения мяч движется в обратную сторону от препятствия (/\)
         }
    }
}
