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
  public partial class mainForm : Form
  {
    public mainForm()
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
      BufferedGraphicsContext graphicsContext = new BufferedGraphicsContext();
      Random random = new Random();
      List<Entity> entities = new List<Entity>();
      Stopwatch stopwatch = new Stopwatch();

      Invoke(new startDelegate(start));
      for (int i = 0; entities.Count < entitesNumericUpDown.Value && i < entitesNumericUpDown.Value * 10; i++)
      {
        int radius = random.Next((int)minRadiusNumericUpDown.Value, (int)maxRadiusNumericUpDown.Value);
        System.Windows.Point location = new System.Windows.Point(
          random.Next(radius, animationPanel.DisplayRectangle.Width - radius),
          random.Next(radius, animationPanel.DisplayRectangle.Height - radius));
        Vector velocity = new Vector(
          random.Next((int)minVelocityNumericUpDown.Value, (int)maxVelocityNumericUpDown.Value),
          random.Next((int)minVelocityNumericUpDown.Value, (int)maxVelocityNumericUpDown.Value));
        Entity newEntity = new Entity(location, velocity, radius, (double)lossFactorNumericUpDown.Value);

        if (newEntity.collidesWith(entities).Count == 0)
        {
          entities.Add(newEntity);
        }
      }

      stopwatch.Start();
      while (!backgroundWorker.CancellationPending)
      {
        BufferedGraphics graphicsBuffer = graphicsContext.Allocate(animationPanel.CreateGraphics(), animationPanel.DisplayRectangle);

        graphicsBuffer.Graphics.Clear(Color.White);
        graphicsBuffer.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        foreach (Entity entity in entities)
        {
          entity.move(animationPanel.DisplayRectangle, entities, stopwatch.ElapsedMilliseconds / 1000.0, (double)gravityNumericUpDown.Value);
          entity.render(graphicsBuffer.Graphics);
        }
        graphicsBuffer.Render();
        graphicsBuffer.Dispose();
      }
    }

    private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      startButton.Enabled = true;
      enableNumericUpDowns(true);
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
      enableNumericUpDowns(false);
      stopButton.Enabled = true;
    }

    private void enableNumericUpDowns(bool value)
    {
      entitesNumericUpDown.Enabled = value;
      minRadiusNumericUpDown.Enabled = value;
      maxRadiusNumericUpDown.Enabled = value;
      minVelocityNumericUpDown.Enabled = value;
      maxVelocityNumericUpDown.Enabled = value;
      lossFactorNumericUpDown.Enabled = value;
      gravityNumericUpDown.Enabled = value;
    }
  }
}
