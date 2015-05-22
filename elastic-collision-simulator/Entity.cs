using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows;

namespace elastic_collisions
{
  class Entity
  {
    public Entity(System.Windows.Point position, Vector velocity, int radius, double mass, double loss, Entity orbiting)
    {
      this.position = position;
      this.velocity = velocity;
      this.radius = radius;
      this.mass = mass;
      this.loss = loss;
      this.orbiting = orbiting;
      brush = new SolidBrush(Color.Black);
    }

    public void setOrbiting(Entity orbiting)
    {
      this.orbiting = orbiting;
    }

    public void move(Rectangle display, List<Entity> entities, double time)
    {
      double timeElapsed = time - lastTime;
      System.Windows.Point newPosition = (position + velocity * timeElapsed);

      if (newPosition.X / 1e9 - radius > 0 && newPosition.X / 1e9 + radius < display.Width)
      {
        position.X = newPosition.X;
      }
      else
      {
        velocity.X = -velocity.X * (1 - loss);
        if (position.X / 1e9 - radius < 0)
        {
          position.X = radius;
        }
        else if (position.X / 1e9 + radius > display.Width)
        {
          position.X = display.Width * 1e9 - radius;
        }
      }
      if (newPosition.Y / 1e9 - radius > 0 && newPosition.Y / 1e9 + radius < display.Height)
      {
        position.Y = newPosition.Y;
      }
      else
      {
        velocity.Y = -velocity.Y * (1 - loss);
        if (position.Y / 1e9 - radius < 0)
        {
          position.Y = radius;
        }
        else if (position.Y / 1e9 + radius > display.Height)
        {
          position.Y = display.Height * 1e9 - radius;
        }
      }

      if (orbiting != null)
      {
        double G = 6.674e-11;
        Vector distance = (orbiting.position - position);
        Vector normalized = distance;
        normalized.Normalize();
        Vector force = -G * (orbiting.mass * mass) / Math.Pow(distance.Length, 2) * normalized;

        velocity -= force / mass * timeElapsed;

        lastTime = time;
      }
    }

    public void render(Graphics graphics)
    {
      Rectangle shape = new Rectangle((int)(position.X / 1e9 - radius), (int)(position.Y / 1e9 - radius), (int)(radius * 2), (int)(radius * 2));

      graphics.FillEllipse(brush, shape);
    }

    private System.Windows.Point position;
    private Vector velocity;
    private readonly int radius;
    private readonly double mass, loss;
    private SolidBrush brush;
    private double lastTime;
    private Entity orbiting;

    private double collisionDx(double v1, double v2, double m1, double m2, double theta1, double theta2, double phi)
    {
      return (v1 * Math.Cos(theta1 - phi) * (m1 - m2) + 2 * m2 * v2 * Math.Cos(theta2 - phi)) / (m1 + m2) * Math.Cos(phi) + v1 * Math.Sin(theta1 - phi) * Math.Cos(phi + Math.PI / 2);
    }

    private double collisionDy(double v1, double v2, double m1, double m2, double theta1, double theta2, double phi)
    {
      return (v1 * Math.Cos(theta1 - phi) * (m1 - m2) + 2 * m2 * v2 * Math.Cos(theta2 - phi)) / (m1 + m2) * Math.Sin(phi) + v1 * Math.Sin(theta1 - phi) * Math.Sin(phi + Math.PI / 2);
    }
  }
}
