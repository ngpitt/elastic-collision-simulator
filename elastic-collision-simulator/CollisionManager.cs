using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows;

namespace elastic_collisions
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
    public CollisionManager(Rectangle screen, int boxSize)
    {
      this.screen = screen;
      this.boxSize = boxSize;
      cols = (int)Math.Ceiling((double)screen.Width / boxSize);
      rows = (int)Math.Ceiling((double)screen.Height / boxSize);
    }

    public Bitmap Grid
    {
      get
      {
        Bitmap bitmap = new Bitmap(screen.Width, screen.Height);
        Graphics graphics = Graphics.FromImage(bitmap);

        graphics.Clear(Color.White);

        for (int i = 0; i < screen.Width; i += boxSize)
        {
          graphics.DrawLine(new Pen(new SolidBrush(Color.Red)), i, 0, i, screen.Height); 
        }

        for (int i = 0; i < screen.Height; i += boxSize)
        {
          graphics.DrawLine(new Pen(new SolidBrush(Color.Red)), 0, i, screen.Width, i);
        }

        return bitmap;
      }
    }

    public void Init()
    {
      boxes = new Dictionary<int, List<T>>();

      for (int i = 0; i < cols * rows; i++)
      {
        boxes.Add(i, new List<T>());
      }
    }

    public void Add(T obj)
    {
      foreach (int id in ids(obj))
      {
        boxes[id].Add(obj);
      }
    }

    public List<T> Candidates(T obj)
    {
      List<T> candidates = new List<T>();

      foreach (int id in ids(obj))
      {
        candidates.AddRange(boxes[id]);
      }

      return candidates;
    }

    private readonly Rectangle screen;
    private readonly int boxSize, cols, rows;
    private Dictionary<int, List<T>> boxes;

    private HashSet<int> ids(T obj)
    {
      Rectangle boundingBox = obj.BoundingBox;
      System.Drawing.Point topLeft = boundingBox.Location,
        bottomRight = boundingBox.Location + boundingBox.Size;
      HashSet<int> hashes = new HashSet<int>();

      hashes.Add(hash(topLeft));
      hashes.Add(hash(new System.Drawing.Point(topLeft.X, bottomRight.Y)));
      hashes.Add(hash(new System.Drawing.Point(bottomRight.X, topLeft.Y)));
      hashes.Add(hash(bottomRight));

      return hashes;
    }

    private int hash(System.Drawing.Point point)
    {
      return (int)(Math.Floor((double)point.X / boxSize)
        + Math.Floor((double)point.Y / boxSize) * cols);
    }
  }
}
