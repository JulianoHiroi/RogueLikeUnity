using System;

public class Enemy
{
    private Hero target;
    private float speed;
    private float[] position;

    public Enemy(float posX, float posY, int speed)
    {
        position = new float[2];
        position[0] = posX;
        position[1] = posY;
        target = null;
        this.speed = speed;
    }

    public void setTarget(Hero target)
    {
        this.target = target;
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
    public float[] GetTargetDirection()
    {
        if (target == null)
        {
            return null;
        }
        else
        {
            float[] targetPosition = target.getPosition();
            float x = targetPosition[0] - position[0];
            float y = targetPosition[1] - position[1];
            if (Math.Abs(x) < 0.1 && Math.Abs(y) < 0.1)
            {
                return null;
            }
            if (Math.Abs(x) > Math.Abs(y))
            {
                return new float[2] { x / Math.Abs(x), y / Math.Abs(x) };
            }
            else if (Math.Abs(x) < Math.Abs(y))
            {
                return new float[2] { x / Math.Abs(y), y / Math.Abs(y) };
            }
            else
            {
                return new float[2] { x / Math.Abs(x), y / Math.Abs(y) };
            }
        }

    }

    public float getSpeed()
    {
        return speed;
    }
}
