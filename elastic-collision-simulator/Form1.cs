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
        || maxRadiusNumericUpDown.Value > simulationPanel.DisplayRectangle.Width / 2
        || maxRadiusNumericUpDown.Value > simulationPanel.DisplayRectangle.Height / 2)
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
      simulationBackgroundWorker.RunWorkerAsync();
    }

    private void stopButton_Click(object sender, EventArgs e)
    {
      stopButton.Enabled = false;
      simulationBackgroundWorker.CancelAsync();
    }

    private void simulationBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    {
      int boxSize = Math.Max(25, (int)maxRadiusNumericUpDown.Value * 2),
        fpsCounter = 0,
        fps = 0;
      long lastUpdate = 0;
      List<Entity> entities = new List<Entity>(), firstEntitityCandidates = null;
      Random random = new Random();
      Stopwatch stopwatch = new Stopwatch();

      Invoke(new StartDelegate(start));

      for (int i = 0; entities.Count < entitesNumericUpDown.Value; i++)
      {
        int radius = random.Next(
          (int)minRadiusNumericUpDown.Value,
          (int)maxRadiusNumericUpDown.Value),
          velocity = random.Next(
          (int)minVelocityNumericUpDown.Value,
          (int)maxVelocityNumericUpDown.Value);
        double angle = 2 * Math.PI * random.NextDouble();

        entities.Add(new Entity(simulationPanel.DisplayRectangle,
          new System.Windows.Point(
            random.Next(radius + 1, simulationPanel.DisplayRectangle.Width - radius - 1),
            random.Next(radius + 1, simulationPanel.DisplayRectangle.Height - radius - 1)),
          new Vector(velocity * Math.Cos(angle), velocity * Math.Sin(angle)),
          radius,
          (double)lossNumericUpDown.Value,
          (double)gravityNumericUpDown.Value));
      }

      if (customBoxSizeCheckBox.Checked)
      {
        boxSize = (int)boxSizeNumericUpDown.Value;
      }

      CollisionManager<Entity> collisionManager = new CollisionManager<Entity>(
        simulationPanel.DisplayRectangle, boxSize);

      stopwatch.Start();

      using (BufferedGraphicsContext graphicsContext = new BufferedGraphicsContext())
      {
        while (!simulationBackgroundWorker.CancellationPending)
        {
          using (BufferedGraphics graphicsBuffer = graphicsContext.Allocate(
            simulationPanel.CreateGraphics(), simulationPanel.DisplayRectangle))
          {
            graphicsBuffer.Graphics.Clear(Color.White);
            graphicsBuffer.Graphics.SmoothingMode =
              System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            collisionManager.Init();

            Parallel.ForEach(entities, entity => collisionManager.Add(entity));

            if (showBoxesCheckBox.Checked)
            {
              firstEntitityCandidates = collisionManager.Candidates(entities[0]);
              entities[0].Color = Color.Blue;
            }

            Parallel.ForEach(entities, entity =>
            {
              if (showBoxesCheckBox.Checked && firstEntitityCandidates.Contains(entity))
              {
                entity.Color = Color.Green;
              }
              else if (entity.Color != Color.Blue)
              {
                entity.Color = Color.Black;
              }

              entity.Update(
                collisionManager.Candidates(entity),
                stopwatch.ElapsedMilliseconds / 1000.0);
            });

            if (showBoxesCheckBox.Checked)
            {
              Bitmap bitmap = collisionManager.Boxes(entities[0]);

              graphicsBuffer.Graphics.DrawImage(bitmap, 0, 0);
              bitmap.Dispose();
            }

            entities.ForEach(entity => graphicsBuffer.Graphics.FillEllipse(
              new SolidBrush(entity.Color), entity.BoundingBox));

            if (stopwatch.ElapsedMilliseconds - lastUpdate >= 1000)
            {
              fps = fpsCounter;
              fpsCounter = 0;
              lastUpdate = stopwatch.ElapsedMilliseconds;
            }

            if (showFPSCheckBox.Checked)
            {
              graphicsBuffer.Graphics.DrawString(
                "FPS: " + Convert.ToString(fps),
                new Font(FontFamily.GenericMonospace, 8, FontStyle.Regular),
                new SolidBrush(Color.Black), 0, 0);
            }

            graphicsBuffer.Render();

            fpsCounter++;
          }
        }
      }
    }

    private void simulationBackgroundWorker_RunWorkerCompleted(
      object sender, RunWorkerCompletedEventArgs e)
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
      if (simulationBackgroundWorker.IsBusy)
      {
        _terminate = true;
        simulationBackgroundWorker.CancelAsync();
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
