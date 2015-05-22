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
      backgroundWorker.RunWorkerAsync();
    }

    private void stopButton_Click(object sender, EventArgs e)
    {
      stopButton.Enabled = false;
      backgroundWorker.CancelAsync();
    }

    private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    {
      int boxSize = Math.Max(25, (int)maxRadiusNumericUpDown.Value * 2), fpsCounter = 0, fps = 0;
      long lastUpdate = 0;
      Random random = new Random();
      BufferedGraphicsContext graphicsContext = new BufferedGraphicsContext();
      List<Entity> entities = new List<Entity>();
      Stopwatch stopwatch = new Stopwatch();

      Invoke(new startDelegate(start));

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

      CollisionManager<Entity> collisionManager = new CollisionManager<Entity>(animationPanel.DisplayRectangle, boxSize);
      Bitmap collisionBoxes = collisionManager.Boxes;

      stopwatch.Start();

      while (!backgroundWorker.CancellationPending)
      {
        bool firstEntity = true;
        BufferedGraphics graphicsBuffer = graphicsContext.Allocate(animationPanel.CreateGraphics(), animationPanel.DisplayRectangle);
        List<Entity> firstEntitityCandidates = null, candidates;

        graphicsBuffer.Graphics.Clear(Color.White);
        graphicsBuffer.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

        if (showCollisionGridCheckBox.Checked)
        {
          graphicsBuffer.Graphics.DrawImage(collisionBoxes, 0, 0);
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
          graphicsBuffer.Graphics.FillEllipse(solidBrush, entity.BoundingBox);

          firstEntity = false;
        }

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

    private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      startButton.Enabled = true;
      settingsGroupBox.Enabled = true;
      FormBorderStyle = FormBorderStyle.Sizable;
      MinimizeBox = true;
      MaximizeBox = true;

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
      settingsGroupBox.Enabled = false;
      FormBorderStyle = FormBorderStyle.FixedSingle;
      MinimizeBox = false;
      MaximizeBox = false;
    }
  }
}
