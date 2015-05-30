using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows;

namespace elastic_collision_simulator
{
  interface ICollisionManager
  {
    Rectangle BoundingBox
    {
      get;
    }
  }

  class CollisionManager<T> where T : ICollisionManager
  {
    public void DrawBoxes(Graphics graphics, T obj)
    {
      List<int> ids = calculateIds(obj);

      for (int i = 0; i < _screen.Width; i += _boxSize)
      {
        for (int j = 0; j < _screen.Height; j += _boxSize)
        {
          if (ids.Contains(calculateId(new System.Drawing.Point(i, j))))
          {
            using (SolidBrush brush = new SolidBrush(Color.Yellow))
            {
              graphics.FillRectangle(brush, i, j, _boxSize, _boxSize);
            }
          }

          using (Pen pen = new Pen(Color.Red))
          {
            graphics.DrawRectangle(pen, i, j, _boxSize, _boxSize);
          }
        }
      }
    }

    public CollisionManager(Rectangle screen, int boxSize)
    {
      _screen = screen;
      _boxSize = boxSize;
      _cols = (int)Math.Ceiling((double)screen.Width / boxSize);
      _rows = (int)Math.Ceiling((double)screen.Height / boxSize);
    }

    public void Init()
    {
      _boxes = new Dictionary<int, List<T>>();

      for (int i = 0; i < _cols * _rows; i++)
      {
        _boxes.Add(i, new List<T>());
      }
    }

    public void Add(T obj)
    {
      calculateIds(obj).ForEach(id =>
      {
        lock (_boxes[id])
        {
          _boxes[id].Add(obj);
        }
      });
    }

    public List<T> Candidates(T obj)
    {
      List<T> candidates = new List<T>();

      calculateIds(obj).ForEach(id =>
        _boxes[id].ForEach(candidate =>
          addToList<T>(candidates, candidate)));
      candidates.Remove(obj);

      return candidates;
    }

    private readonly Rectangle _screen;
    private readonly int _boxSize, _cols, _rows;
    private Dictionary<int, List<T>> _boxes;

    private List<int> calculateIds(T obj)
    {
      Rectangle boundingBox = obj.BoundingBox;
      System.Drawing.Point topLeft = boundingBox.Location,
        bottomRight = boundingBox.Location + boundingBox.Size;
      List<int> ids = new List<int>();

      addToList<int>(ids, calculateId(topLeft));
      addToList<int>(ids, calculateId(new System.Drawing.Point(topLeft.X, bottomRight.Y)));
      addToList<int>(ids, calculateId(new System.Drawing.Point(bottomRight.X, topLeft.Y)));
      addToList<int>(ids, calculateId(bottomRight));

      return ids;
    }

    private int calculateId(System.Drawing.Point point)
    {
      return (int)(Math.Floor((double)point.X / _boxSize)
        + Math.Floor((double)point.Y / _boxSize) * _cols);
    }

    private void addToList<U>(List<U> list, U value)
    {
      if (!list.Contains(value))
      {
        list.Add(value);
      }
    }
  }
}
