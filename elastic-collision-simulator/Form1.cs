using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.Diagnostics;
using System.Threading;

namespace elastic_collisions
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private bool terminate = false;
    private delegate void startDelegate();

    private void startButton_Click(object sender, EventArgs e)
    {
      startButton.Enabled = false;
      backgroundWorker.RunWorkerAsync();
    }

    private void stopButton_Click(object sender, EventArgs e)
    {
      stopButton.Enabled = false;
      backgroundWorker.CancelAsync();
    }

    private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    {
      int fps = 0, counter = 0;
      long lastUpdate = 0;
      BufferedGraphicsContext graphicsContext = new BufferedGraphicsContext();
      Random random = new Random();
      List<Entity> entities = new List<Entity>();
      CollisionManager<Entity> collisionManager = new CollisionManager<Entity>(
        animationPanel.DisplayRectangle, Math.Max(25, (int)maxRadiusNumericUpDown.Value * 2));
      Stopwatch stopwatch = new Stopwatch();
      Bitmap collisionGrid = collisionManager.Grid;

      Invoke(new startDelegate(start));
      collisionManager.Init();

      for (int i = 0; entities.Count < entitesNumericUpDown.Value; i++)
      {
        int radius = random.Next((int)minRadiusNumericUpDown.Value, (int)maxRadiusNumericUpDown.Value);
        
        entities.Add(new Entity(animationPanel.DisplayRectangle,
          new System.Windows.Point(
            random.Next(radius, animationPanel.DisplayRectangle.Width - radius),
            random.Next(radius, animationPanel.DisplayRectangle.Height - radius)),
          new Vector(
            random.Next((int)minVelocityNumericUpDown.Value, (int)maxVelocityNumericUpDown.Value),
            random.Next((int)minVelocityNumericUpDown.Value, (int)maxVelocityNumericUpDown.Value)),
          radius, (double)lossFactorNumericUpDown.Value, (double)gravityNumericUpDown.Value));
      }

      stopwatch.Start();

      while (!backgroundWorker.CancellationPending)
      {
        BufferedGraphics graphicsBuffer =
          graphicsContext.Allocate(animationPanel.CreateGraphics(), animationPanel.DisplayRectangle);
        bool firstEntity = true;
        List<Entity> firstEntitityCandidates = null, candidates;

        graphicsBuffer.Graphics.Clear(Color.White);
        graphicsBuffer.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

        if (showCollisionGridCheckBox.Checked)
        {
          graphicsBuffer.Graphics.DrawImage(collisionGrid, 0, 0);
        }

        collisionManager.Init();

        foreach (Entity entity in entities)
        {
          collisionManager.Add(entity);
        }

        foreach (Entity entity in entities)
        {
          SolidBrush solidBrush = new SolidBrush(Color.Black);

          if (firstEntity && showCollisionCandidatesCheckBox.Checked)
          {
            firstEntitityCandidates = collisionManager.Candidates(entity);
            candidates = firstEntitityCandidates;
            solidBrush.Color = Color.Blue;
          }
          else
          {
            candidates = collisionManager.Candidates(entity);
            if (showCollisionCandidatesCheckBox.Checked && firstEntitityCandidates.Contains(entity))
            {
              solidBrush.Color = Color.Green;
            }
          }

          entity.Update(candidates, stopwatch.ElapsedMilliseconds / 1000.0);

          if (fillEntitiesCheckBox.Checked)
          {
            graphicsBuffer.Graphics.FillEllipse(solidBrush, entity.BoundingBox);
          }
          else
          {
            graphicsBuffer.Graphics.DrawEllipse(new Pen(solidBrush), entity.BoundingBox);
          }

          firstEntity = false;
        }

        if (stopwatch.ElapsedMilliseconds - lastUpdate >= 1000)
        {
          fps = counter;
          counter = 0;
          lastUpdate = stopwatch.ElapsedMilliseconds;
        }

        if (showFPSCheckBox.Checked)
        {
          graphicsBuffer.Graphics.DrawString("FPS: " + Convert.ToString(fps),
            new Font(FontFamily.GenericMonospace, 8, FontStyle.Regular),
            new SolidBrush(Color.Black), new PointF(0, 0));
        }

        graphicsBuffer.Render();
        graphicsBuffer.Dispose();
        counter++;
      }
    }

    private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      startButton.Enabled = true;
      enableControls(true);
      FormBorderStyle = FormBorderStyle.Sizable;

      if (terminate)
      {
        Close();
      }
    }

    private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (backgroundWorker.IsBusy)
      {
        terminate = true;
        backgroundWorker.CancelAsync();
        e.Cancel = true;
      }
    }

    private void start()
    {
      stopButton.Enabled = true;
      enableControls(false);
      FormBorderStyle = FormBorderStyle.FixedSingle;
    }

    private void enableControls(bool value)
    {
      entitesNumericUpDown.Enabled = value;
      minRadiusNumericUpDown.Enabled = value;
      maxRadiusNumericUpDown.Enabled = value;
      minVelocityNumericUpDown.Enabled = value;
      maxVelocityNumericUpDown.Enabled = value;
      lossFactorNumericUpDown.Enabled = value;
      gravityNumericUpDown.Enabled = value;
      fillEntitiesCheckBox.Enabled = value;
      showFPSCheckBox.Enabled = value;
      showCollisionGridCheckBox.Enabled = value;
      showCollisionCandidatesCheckBox.Enabled = value;
      MinimizeBox = value;
      MaximizeBox = value;
    }
  }
}
