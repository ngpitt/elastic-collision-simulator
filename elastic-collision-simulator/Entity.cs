using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows;

namespace elastic_collisions
{
  class Entity : ICollisionManager
  {
    public Entity(Rectangle display, System.Windows.Point position, Vector velocity, int radius, double loss, double gravity)
    {
      this.display = display;
      this.position = position;
      this.velocity = velocity;
      this.radius = radius;
      this.loss = loss;
      this.gravity = gravity;
      mass = Math.PI * Math.Pow(radius, 2);
    }

    public Rectangle BoundingBox
    {
      get
      {
        return new Rectangle((int)(position.X - radius), (int)(position.Y - radius), (int)(radius * 2), (int)(radius * 2));
      }
    }

    public void Update(List<Entity> entities, double time)
    {
      double timeElapsed = time - lastUpdate;
      System.Windows.Point newPosition = position + velocity * timeElapsed;

      velocity.Y += gravity;
      if (newPosition.X - radius > 0 && newPosition.X + radius < display.Width)
      {
        position.X = newPosition.X;
      }
      else
      {
        velocity.X = -velocity.X * (1 - loss);
      }
      if (newPosition.Y - radius > 0 && newPosition.Y + radius < display.Height)
      {
        position.Y = newPosition.Y;
      }
      else
      {
        velocity.Y = -velocity.Y * (1 - loss);
      }

      foreach (Entity entity in entities)
      {
        double distance = (position - entity.position).Length,
          nextDistance = ((position + velocity * timeElapsed) - (entity.position + entity.velocity * timeElapsed)).Length;

        if (distance <= radius + entity.radius && nextDistance < distance)
        {
          double v1 = velocity.Length, v2 = entity.velocity.Length,
            theta1 = Math.Atan2(velocity.Y, velocity.X),
            theta2 = Math.Atan2(entity.velocity.Y, entity.velocity.X),
            phi = Math.Atan2(position.Y - entity.position.Y, position.X - entity.position.X);

          velocity.X = collisionDx(v1, v2, mass, entity.mass, theta1, theta2, phi) * (1 - loss / 2);
          velocity.Y = collisionDy(v1, v2, mass, entity.mass, theta1, theta2, phi) * (1 - loss / 2);
          entity.velocity.X = collisionDx(v2, v1, entity.mass, mass, theta2, theta1, phi) * (1 - loss / 2);
          entity.velocity.Y = collisionDy(v2, v1, entity.mass, mass, theta2, theta1, phi) * (1 - loss / 2);
        }
      }

      lastUpdate = time;
    }

    private readonly Rectangle display;
    private System.Windows.Point position;
    private Vector velocity;
    private readonly int radius;
    private readonly double mass, loss, gravity;
    private double lastUpdate;

    private double collisionDx(double v1, double v2, double m1, double m2, double theta1, double theta2, double phi)
    {
      return (v1 * Math.Cos(theta1 - phi) * (m1 - m2) + 2 * m2 * v2 * Math.Cos(theta2 - phi)) / (m1 + m2) * Math.Cos(phi)
        + v1 * Math.Sin(theta1 - phi) * Math.Cos(phi + Math.PI / 2);
    }

    private double collisionDy(double v1, double v2, double m1, double m2, double theta1, double theta2, double phi)
    {
      return (v1 * Math.Cos(theta1 - phi) * (m1 - m2) + 2 * m2 * v2 * Math.Cos(theta2 - phi)) / (m1 + m2) * Math.Sin(phi)
        + v1 * Math.Sin(theta1 - phi) * Math.Sin(phi + Math.PI / 2);
    }
  }
}
