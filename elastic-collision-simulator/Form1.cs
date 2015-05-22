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

      int radius = 10;
      System.Windows.Point position = new System.Windows.Point(
        animationPanel.DisplayRectangle.Width / 2 * 1e9,
        animationPanel.DisplayRectangle.Height / 2 * 1e9);
      Vector velocity = new Vector(0, -15e3);
      Entity newEntity = new Entity(position, velocity, radius, 1.989e30, (int)lossFactorNumericUpDown.Value, null);
      entities.Add(newEntity);

      radius = 10;
      position.X -= 150e9;
      velocity.Y = 15e3;
      newEntity = new Entity(position, velocity, radius, 1.989e30, (int)lossFactorNumericUpDown.Value, entities[0]);
      entities.Add(newEntity);
      entities[0].setOrbiting(entities[1]);

      stopwatch.Start();
      while (!backgroundWorker.CancellationPending)
      {
        BufferedGraphics graphicsBuffer = graphicsContext.Allocate(animationPanel.CreateGraphics(), animationPanel.DisplayRectangle);

        graphicsBuffer.Graphics.Clear(Color.White);
        graphicsBuffer.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        foreach (Entity entity in entities)
        {
          entity.move(animationPanel.DisplayRectangle, entities, stopwatch.ElapsedMilliseconds / 1000.0 * 1e7);
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
