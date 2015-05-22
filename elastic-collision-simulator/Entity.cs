using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows;

namespace elastic_collision_simulator
{
  class Entity : ICollisionManager
  {
    public Rectangle BoundingBox
    {
      get { return new Rectangle((int)(_position.X - _radius), (int)(_position.Y - _radius), (int)(_radius * 2), (int)(_radius * 2)); }
    }

    public Color Color
    {
      get { return _color; }
      set { _color = value; }
    }

    public Entity(Rectangle display, System.Windows.Point position, Vector velocity, int radius, double loss, double gravity)
    {
      _display = display;
      _position = position;
      _velocity = velocity;
      _radius = radius;
      _loss = loss;
      _gravity = gravity;
      _mass = Math.PI * Math.Pow(_radius, 2);
    }

    public void Update(List<Entity> entities, double time)
    {
      double timeElapsed = time - _lastUpdate;
      System.Windows.Point new_position = _position + _velocity * timeElapsed;

      _velocity.Y += _gravity;
      if (new_position.X - _radius > 0 && new_position.X + _radius < _display.Width)
      {
        _position.X = new_position.X;
      }
      else
      {
        _velocity.X = -_velocity.X * (1 - _loss);
      }
      if (new_position.Y - _radius > 0 && new_position.Y + _radius < _display.Height)
      {
        _position.Y = new_position.Y;
      }
      else
      {
        _velocity.Y = -_velocity.Y * (1 - _loss);
      }

      entities.ForEach(entity =>
      {
        double distance = (_position - entity._position).Length,
          nextDistance = ((_position + _velocity * timeElapsed) - (entity._position + entity._velocity * timeElapsed)).Length;

        if (distance <= _radius + entity._radius && nextDistance < distance)
        {
          double v1 = _velocity.Length, v2 = entity._velocity.Length,
            theta1 = Math.Atan2(_velocity.Y, _velocity.X),
            theta2 = Math.Atan2(entity._velocity.Y, entity._velocity.X),
            phi = Math.Atan2(_position.Y - entity._position.Y, _position.X - entity._position.X);

          _velocity.X = calculateDx(v1, v2, _mass, entity._mass, theta1, theta2, phi) * (1 - _loss / 2);
          _velocity.Y = calculateDy(v1, v2, _mass, entity._mass, theta1, theta2, phi) * (1 - _loss / 2);
          entity._velocity.X = calculateDx(v2, v1, entity._mass, _mass, theta2, theta1, phi) * (1 - _loss / 2);
          entity._velocity.Y = calculateDy(v2, v1, entity._mass, _mass, theta2, theta1, phi) * (1 - _loss / 2);
        }
      });

      _lastUpdate = time;
    }

    private readonly Rectangle _display;
    private System.Windows.Point _position;
    private Vector _velocity;
    private readonly int _radius;
    private readonly double _mass, _loss, _gravity;
    private Color _color;
    private double _lastUpdate = 0;

    private double calculateDx(double v1, double v2, double m1, double m2, double theta1, double theta2, double phi)
    {
      return (v1 * Math.Cos(theta1 - phi) * (m1 - m2) + 2 * m2 * v2 * Math.Cos(theta2 - phi)) / (m1 + m2) * Math.Cos(phi)
        + v1 * Math.Sin(theta1 - phi) * Math.Cos(phi + Math.PI / 2);
    }

    private double calculateDy(double v1, double v2, double m1, double m2, double theta1, double theta2, double phi)
    {
      return (v1 * Math.Cos(theta1 - phi) * (m1 - m2) + 2 * m2 * v2 * Math.Cos(theta2 - phi)) / (m1 + m2) * Math.Sin(phi)
        + v1 * Math.Sin(theta1 - phi) * Math.Sin(phi + Math.PI / 2);
    }
  }
}
