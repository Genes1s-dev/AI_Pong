using UnityEngine;

public class Ball : MonoBehaviour
{
    private new Rigidbody2D rigidbody;
    [SerializeField] private float speed = 200.0f;
    private float speedAccelerationCoef = 1f;
    [SerializeField, Range(0f, 1f)] private float minSpeedChange;
    [SerializeField, Range(0f, 1f)] private float maxSpeedChange;

    // Вызывается при изменении значений в редакторе Unity. Реализуем согласование между мин. и макс. значениями
    private void OnValidate()
    {
        float temp;
        if (minSpeedChange > maxSpeedChange)
        {
            temp = maxSpeedChange;
            maxSpeedChange = minSpeedChange;
            minSpeedChange = temp;
        } 
    }

    private void Awake() {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start() {
        ResetPosition();
        AddStartingForce();
    }
    
    public void AddStartingForce() {
        float x = Random.value < 0.5f ? -1.0f : 1.0f;  // случайно определяем направление движения шарика по обеим осям
        float y = Random.value < 0.5f ? Random.Range(-1.0f, -0.5f) :   //не ставим значения близкие к 0.0f, чтобы мяч не летел строго по горизонтали к игрокам, при его первом запуске
                                        Random.Range(0.5f, 1.0f);
        Vector2 direction = new Vector2(x, y);
        rigidbody.AddForce(direction * this.speed);
        Debug.Log(direction);

    }

    public void AddForce(Vector2 force) {
        speedAccelerationCoef += Random.Range(minSpeedChange, maxSpeedChange);
        rigidbody.AddForce(force * speedAccelerationCoef);
    }

    public void ResetPosition() {
        rigidbody.position = Vector2.zero;  //при повышении счёта, обнуляем положение мяча, а также его скорость, ну и коэффициент ускорения
        rigidbody.velocity = Vector2.zero;
        speedAccelerationCoef = 1f;
    }
}
