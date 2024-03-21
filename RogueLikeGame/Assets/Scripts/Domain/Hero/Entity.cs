public class Hero
{
  private float speed;
  private float[] position;

  public Hero(float speed, float posX, float posY)
  {
    this.speed = speed;
    position = new float[2];
    position[0] = posX;
    position[1] = posY;
  }

  public float getSpeed()
  {
    return speed;
  }
  public void setSpeed(float speed)
  {
    this.speed = speed;
  }

  public float[] getPosition()
  {
    return position;
  }
  public void setPositon(float posX, float posY)
  {
    position[0] = posX;
    position[1] = posY;
  }
  public void Move(float x, float y, float deltaTime)
  {
    position[0] += x * speed;
    position[1] += y * speed;
  }
}