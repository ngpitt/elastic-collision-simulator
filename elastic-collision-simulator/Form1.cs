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

namespace elastic_collision_simulator
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private bool _terminate = false;
    private delegate void StartDelegate();

    private void minRadiusNumericUpDown_Validating(object sender, CancelEventArgs e)
    {
      if (minRadiusNumericUpDown.Value > maxRadiusNumericUpDown.Value)
      {
        e.Cancel = true;
      }
    }

    private void maxRadiusNumericUpDown_Validating(object sender, CancelEventArgs e)
    {
      if (maxRadiusNumericUpDown.Value < minRadiusNumericUpDown.Value
        || maxRadiusNumericUpDown.Value > animationPanel.DisplayRectangle.Width / 2
        || maxRadiusNumericUpDown.Value > animationPanel.DisplayRectangle.Height / 2)
      {
        e.Cancel = true;
      }
    }

    private void minVelocityNumericUpDown_Validating(object sender, CancelEventArgs e)
    {
      if (minVelocityNumericUpDown.Value > maxVelocityNumericUpDown.Value)
      {
        e.Cancel = true;
      }
    }

    private void maxVelocityNumericUpDown_Validating(object sender, CancelEventArgs e)
    {
      if (maxVelocityNumericUpDown.Value < minVelocityNumericUpDown.Value)
      {
        e.Cancel = true;
      }
    }

    private void customGridSizeCheckBox_CheckedChanged(object sender, EventArgs e)
    {
      boxSizeLabel.Enabled = boxSizeNumericUpDown.Enabled = customBoxSizeCheckBox.Checked;
    }

    private void startButton_Click(object sender, EventArgs e)
    {
      startButton.Enabled = false;
      animationBackgroundWorker.RunWorkerAsync();
    }

    private void stopButton_Click(object sender, EventArgs e)
    {
      stopButton.Enabled = false;
      animationBackgroundWorker.CancelAsync();
    }

    private void animationBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    {
      int boxSize = Math.Max(25, (int)maxRadiusNumericUpDown.Value * 2), fpsCounter = 0, fps = 0;
      long lastUpdate = 0;
      BufferedGraphicsContext graphicsContext = new BufferedGraphicsContext();
      List<Entity> entities = new List<Entity>(), firstEntitityCandidates = null;
      CollisionManager<Entity> collisionManager;
      Random random = new Random();
      Stopwatch stopwatch = new Stopwatch();
      Bitmap collisionBoxes;

      Invoke(new StartDelegate(start));

      for (int i = 0; entities.Count < entitesNumericUpDown.Value; i++)
      {
        int radius = random.Next((int)minRadiusNumericUpDown.Value, (int)maxRadiusNumericUpDown.Value),
          velocity = random.Next((int)minVelocityNumericUpDown.Value, (int)maxVelocityNumericUpDown.Value);
        double angle = 2 * Math.PI * random.NextDouble();

        entities.Add(new Entity(animationPanel.DisplayRectangle,
          new System.Windows.Point(
            random.Next(radius + 1, animationPanel.DisplayRectangle.Width - radius - 1),
            random.Next(radius + 1, animationPanel.DisplayRectangle.Height - radius - 1)),
          new Vector(velocity * Math.Cos(angle), velocity * Math.Sin(angle)),
          radius, (double)lossNumericUpDown.Value, (double)gravityNumericUpDown.Value));
      }

      if (customBoxSizeCheckBox.Checked)
      {
        boxSize = (int)boxSizeNumericUpDown.Value;
      }

      collisionManager = new CollisionManager<Entity>(animationPanel.DisplayRectangle, boxSize);
      collisionBoxes = collisionManager.Boxes;

      stopwatch.Start();

      while (!animationBackgroundWorker.CancellationPending)
      {
        BufferedGraphics graphicsBuffer = graphicsContext.Allocate(animationPanel.CreateGraphics(), animationPanel.DisplayRectangle);

        graphicsBuffer.Graphics.Clear(Color.White);
        graphicsBuffer.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

        if (showCollisionGridCheckBox.Checked)
        {
          graphicsBuffer.Graphics.DrawImage(collisionBoxes, 0, 0);
        }

        collisionManager.Init();

        Parallel.ForEach(entities, entity => collisionManager.Add(entity));

        if (showCollisionCandidatesCheckBox.Checked)
        {
          firstEntitityCandidates = collisionManager.Candidates(entities[0]);
          entities[0].Color = Color.Blue;
        }

        Parallel.ForEach(entities, entity =>
        {
          List<Entity> candidates = collisionManager.Candidates(entity);

          if (showCollisionCandidatesCheckBox.Checked && firstEntitityCandidates.Contains(entity))
          {
            entity.Color = Color.Green;
          }
          else if (entity.Color != Color.Blue)
          {
            entity.Color = Color.Black;
          }

          entity.Update(candidates, stopwatch.ElapsedMilliseconds / 1000.0);
        });

        entities.ForEach(entity => graphicsBuffer.Graphics.FillEllipse(new SolidBrush(entity.Color), entity.BoundingBox));

        if (stopwatch.ElapsedMilliseconds - lastUpdate >= 1000)
        {
          fps = fpsCounter;
          fpsCounter = 0;
          lastUpdate = stopwatch.ElapsedMilliseconds;
        }

        if (showFPSCheckBox.Checked)
        {
          graphicsBuffer.Graphics.DrawString("FPS: " + Convert.ToString(fps),
            new Font(FontFamily.GenericMonospace, 8, FontStyle.Regular),
            new SolidBrush(Color.Black), 0, 0);
        }

        graphicsBuffer.Render();
        graphicsBuffer.Dispose();

        fpsCounter++;
      }
    }

    private void animationBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      startButton.Enabled = true;
      settingsGroupBox.Enabled = true;
      FormBorderStyle = FormBorderStyle.Sizable;
      MinimizeBox = true;
      MaximizeBox = true;

      if (_terminate)
      {
        Close();
      }
    }

    private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (animationBackgroundWorker.IsBusy)
      {
        _terminate = true;
        animationBackgroundWorker.CancelAsync();
        e.Cancel = true;
      }
    }

    private void start()
    {
      stopButton.Enabled = true;
      settingsGroupBox.Enabled = false;
      FormBorderStyle = FormBorderStyle.FixedSingle;
      MinimizeBox = false;
      MaximizeBox = false;
    }
  }
}
