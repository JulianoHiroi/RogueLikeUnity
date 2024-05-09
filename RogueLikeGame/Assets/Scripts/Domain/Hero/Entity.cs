using System;

public class Hero
{
  private string id;
  private float moveSpeed;
  private float attackSpeed;
  private float[] position;
  private float life;
  private float demage;
  private int level;
  private Item[] itens;


  public Hero(float speed, float posX, float posY)
  {
    this.moveSpeed = speed;
    position = new float[2];
    position[0] = posX;
    position[1] = posY;
  }

  public float getSpeed()
  {
    return moveSpeed;
  }
  public void setSpeed(float speed)
  {
    this.moveSpeed = speed;
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
  public void Move(float inputX, float inputY, float deltaTime)
  {
    position[0] += inputX * moveSpeed * deltaTime;
    position[1] += inputY * moveSpeed * deltaTime;
  }
  public void Atack(Enemy[] enemies)
  {
    foreach (Enemy enemy in enemies)
    {
      enemy.takeDemage(demage);
    }
  }
}