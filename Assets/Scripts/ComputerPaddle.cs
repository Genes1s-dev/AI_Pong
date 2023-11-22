using UnityEngine;

public class ComputerPaddle : Paddle
{
    public Rigidbody2D ball;
    //реализуем ИИ для бота
    private void FixedUpdate() {
        if (this.ball.velocity.x > 0.0f) {  //если мяч движется в сторону игрока-компьютера
            if (this.ball.position.y > this.transform.position.y) { //если мяч находится выше игрока-компьютера
                rigidbody.AddForce(Vector2.up * this.speed);  //то двигаем бота вверх
            } else if (this.ball.position.y < this.transform.position.y) //в противном случае вниз
               {rigidbody.AddForce(Vector2.down * this.speed);}
        } else {             //если мяч движется от бота, то двигаем последнего к центру по игреку (в зависимости от его положения)
            if (this.transform.position.y > 0.0f) {
                rigidbody.AddForce(Vector2.down * this.speed);
            } else if (this.transform.position.y < 0.0f) {
                rigidbody.AddForce(Vector2.up * this.speed);
            }
        }
        
    }
}
