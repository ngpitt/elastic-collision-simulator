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
    public Entity(System.Windows.Point location, Vector velocity, int radius, double loss)
    {
      this.location = location;
      this.velocity = velocity;
      this.radius = radius;
      this.loss = loss;
      mass = Math.PI * Math.Pow(radius, 2);
      brush = new SolidBrush(Color.Black);
    }

    public List<Entity> collidesWith(List<Entity> entities)
    {
      List<Entity> collisions = new List<Entity>();

      foreach (Entity entity in entities)
      {
        if (entity != this && (location - entity.location).Length <= radius + entity.radius)
        {
          collisions.Add(entity);
        }
      }

      return collisions;
    }

    public void move(Rectangle display, List<Entity> entities, double time, double gravity)
    {
      double timeElapsed = time - lastTime;
      System.Windows.Point newLocation = location + velocity * timeElapsed;
      List<Entity> collisions = collidesWith(entities);

      velocity.Y += gravity;
      if (newLocation.X - radius > 0 && newLocation.X + radius < display.Width)
      {
        location.X = newLocation.X;
      }
      else
      {
        velocity.X = -velocity.X * (1 - loss);
        if (location.X - radius < 0)
        {
          location.X = radius;
        }
        else if (location.X + radius > display.Width)
        {
          location.X = display.Width - radius;
        }
      }
      if (newLocation.Y - radius > 0 && newLocation.Y + radius < display.Height)
      {
        location.Y = newLocation.Y;
      }
      else
      {
        velocity.Y = -velocity.Y * (1 - loss);
        if (location.Y - radius < 0)
        {
          location.Y = radius;
        }
        else if (location.Y + radius > display.Height)
        {
          location.Y = display.Height - radius;
        }
      }

      foreach (Entity entity in collisions)
      {
        if (((location + velocity * timeElapsed) - (entity.location + entity.velocity * timeElapsed)).Length < (location - entity.location).Length)
        {
          double v1 = velocity.Length, v2 = entity.velocity.Length,
            theta1 = Math.Atan2(velocity.Y, velocity.X),
            theta2 = Math.Atan2(entity.velocity.Y, entity.velocity.X),
            phi = Math.Atan2(location.Y - entity.location.Y, location.X - entity.location.X);

          velocity.X = collisionDx(v1, v2, mass, entity.mass, theta1, theta2, phi) * (1 - loss / 2);
          velocity.Y = collisionDy(v1, v2, mass, entity.mass, theta1, theta2, phi) * (1 - loss / 2);
          entity.velocity.X = collisionDx(v2, v1, entity.mass, mass, theta2, theta1, phi) * (1 - loss / 2);
          entity.velocity.Y = collisionDy(v2, v1, entity.mass, mass, theta2, theta1, phi) * (1 - loss / 2);
        }
      }

      lastTime = time;
    }

    public void render(Graphics graphics)
    {
      Rectangle shape = new Rectangle((int)(location.X - radius), (int)(location.Y - radius), (int)(radius * 2), (int)(radius * 2));

      graphics.FillEllipse(brush, shape);
    }

    private System.Windows.Point location;
    private Vector velocity;
    private readonly int radius;
    private readonly double mass, loss;
    private SolidBrush brush;
    private double lastTime;

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
