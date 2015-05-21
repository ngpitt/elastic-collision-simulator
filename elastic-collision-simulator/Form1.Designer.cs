namespace elastic_collisions
{
  partial class mainForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.startButton = new System.Windows.Forms.Button();
      this.stopButton = new System.Windows.Forms.Button();
      this.entitesNumericUpDown = new System.Windows.Forms.NumericUpDown();
      this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
      this.lossFactorNumericUpDown = new System.Windows.Forms.NumericUpDown();
      this.minRadiusNumericUpDown = new System.Windows.Forms.NumericUpDown();
      this.maxRadiusNumericUpDown = new System.Windows.Forms.NumericUpDown();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.minVelocityNumericUpDown = new System.Windows.Forms.NumericUpDown();
      this.maxVelocityNumericUpDown = new System.Windows.Forms.NumericUpDown();
      this.label5 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.controlsGroupBox = new System.Windows.Forms.GroupBox();
      this.gravityNumericUpDown = new System.Windows.Forms.NumericUpDown();
      this.label7 = new System.Windows.Forms.Label();
      this.simulationGroupBox = new System.Windows.Forms.GroupBox();
      this.animationPanel = new System.Windows.Forms.Panel();
      ((System.ComponentModel.ISupportInitialize)(this.entitesNumericUpDown)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.lossFactorNumericUpDown)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.minRadiusNumericUpDown)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.maxRadiusNumericUpDown)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.minVelocityNumericUpDown)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.maxVelocityNumericUpDown)).BeginInit();
      this.controlsGroupBox.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.gravityNumericUpDown)).BeginInit();
      this.simulationGroupBox.SuspendLayout();
      this.SuspendLayout();
      // 
      // startButton
      // 
      this.startButton.Location = new System.Drawing.Point(9, 201);
      this.startButton.Name = "startButton";
      this.startButton.Size = new System.Drawing.Size(148, 23);
      this.startButton.TabIndex = 7;
      this.startButton.Text = "Start";
      this.startButton.UseVisualStyleBackColor = true;
      this.startButton.Click += new System.EventHandler(this.startButton_Click);
      // 
      // stopButton
      // 
      this.stopButton.Location = new System.Drawing.Point(9, 230);
      this.stopButton.Name = "stopButton";
      this.stopButton.Size = new System.Drawing.Size(148, 23);
      this.stopButton.TabIndex = 8;
      this.stopButton.Text = "Stop";
      this.stopButton.UseVisualStyleBackColor = true;
      this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
      // 
      // entitesNumericUpDown
      // 
      this.entitesNumericUpDown.Location = new System.Drawing.Point(82, 19);
      this.entitesNumericUpDown.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
      this.entitesNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.entitesNumericUpDown.Name = "entitesNumericUpDown";
      this.entitesNumericUpDown.Size = new System.Drawing.Size(75, 20);
      this.entitesNumericUpDown.TabIndex = 0;
      this.entitesNumericUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
      // 
      // backgroundWorker
      // 
      this.backgroundWorker.WorkerSupportsCancellation = true;
      this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
      this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
      // 
      // lossFactorNumericUpDown
      // 
      this.lossFactorNumericUpDown.DecimalPlaces = 2;
      this.lossFactorNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
      this.lossFactorNumericUpDown.Location = new System.Drawing.Point(82, 149);
      this.lossFactorNumericUpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.lossFactorNumericUpDown.Name = "lossFactorNumericUpDown";
      this.lossFactorNumericUpDown.Size = new System.Drawing.Size(75, 20);
      this.lossFactorNumericUpDown.TabIndex = 5;
      // 
      // minRadiusNumericUpDown
      // 
      this.minRadiusNumericUpDown.Location = new System.Drawing.Point(82, 45);
      this.minRadiusNumericUpDown.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
      this.minRadiusNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.minRadiusNumericUpDown.Name = "minRadiusNumericUpDown";
      this.minRadiusNumericUpDown.Size = new System.Drawing.Size(75, 20);
      this.minRadiusNumericUpDown.TabIndex = 1;
      this.minRadiusNumericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
      // 
      // maxRadiusNumericUpDown
      // 
      this.maxRadiusNumericUpDown.Location = new System.Drawing.Point(82, 71);
      this.maxRadiusNumericUpDown.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
      this.maxRadiusNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.maxRadiusNumericUpDown.Name = "maxRadiusNumericUpDown";
      this.maxRadiusNumericUpDown.Size = new System.Drawing.Size(75, 20);
      this.maxRadiusNumericUpDown.TabIndex = 2;
      this.maxRadiusNumericUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(6, 21);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(44, 13);
      this.label1.TabIndex = 8;
      this.label1.Text = "Entities:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(6, 47);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(63, 13);
      this.label2.TabIndex = 9;
      this.label2.Text = "Min Radius:";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(6, 73);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(66, 13);
      this.label3.TabIndex = 10;
      this.label3.Text = "Max Radius:";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(6, 151);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(65, 13);
      this.label4.TabIndex = 11;
      this.label4.Text = "Loss Factor:";
      // 
      // minVelocityNumericUpDown
      // 
      this.minVelocityNumericUpDown.Location = new System.Drawing.Point(82, 97);
      this.minVelocityNumericUpDown.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
      this.minVelocityNumericUpDown.Minimum = new decimal(new int[] {
            32767,
            0,
            0,
            -2147483648});
      this.minVelocityNumericUpDown.Name = "minVelocityNumericUpDown";
      this.minVelocityNumericUpDown.Size = new System.Drawing.Size(75, 20);
      this.minVelocityNumericUpDown.TabIndex = 3;
      this.minVelocityNumericUpDown.Value = new decimal(new int[] {
            200,
            0,
            0,
            -2147483648});
      // 
      // maxVelocityNumericUpDown
      // 
      this.maxVelocityNumericUpDown.Location = new System.Drawing.Point(82, 123);
      this.maxVelocityNumericUpDown.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
      this.maxVelocityNumericUpDown.Minimum = new decimal(new int[] {
            32767,
            0,
            0,
            -2147483648});
      this.maxVelocityNumericUpDown.Name = "maxVelocityNumericUpDown";
      this.maxVelocityNumericUpDown.Size = new System.Drawing.Size(75, 20);
      this.maxVelocityNumericUpDown.TabIndex = 4;
      this.maxVelocityNumericUpDown.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(6, 125);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(70, 13);
      this.label5.TabIndex = 14;
      this.label5.Text = "Max Velocity:";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(6, 99);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(67, 13);
      this.label6.TabIndex = 15;
      this.label6.Text = "Min Velocity:";
      // 
      // controlsGroupBox
      // 
      this.controlsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
      this.controlsGroupBox.Controls.Add(this.gravityNumericUpDown);
      this.controlsGroupBox.Controls.Add(this.label7);
      this.controlsGroupBox.Controls.Add(this.label4);
      this.controlsGroupBox.Controls.Add(this.stopButton);
      this.controlsGroupBox.Controls.Add(this.maxVelocityNumericUpDown);
      this.controlsGroupBox.Controls.Add(this.startButton);
      this.controlsGroupBox.Controls.Add(this.label1);
      this.controlsGroupBox.Controls.Add(this.lossFactorNumericUpDown);
      this.controlsGroupBox.Controls.Add(this.label6);
      this.controlsGroupBox.Controls.Add(this.minVelocityNumericUpDown);
      this.controlsGroupBox.Controls.Add(this.entitesNumericUpDown);
      this.controlsGroupBox.Controls.Add(this.label5);
      this.controlsGroupBox.Controls.Add(this.label3);
      this.controlsGroupBox.Controls.Add(this.maxRadiusNumericUpDown);
      this.controlsGroupBox.Controls.Add(this.label2);
      this.controlsGroupBox.Controls.Add(this.minRadiusNumericUpDown);
      this.controlsGroupBox.Location = new System.Drawing.Point(12, 12);
      this.controlsGroupBox.Name = "controlsGroupBox";
      this.controlsGroupBox.Size = new System.Drawing.Size(168, 437);
      this.controlsGroupBox.TabIndex = 16;
      this.controlsGroupBox.TabStop = false;
      this.controlsGroupBox.Text = "Controls";
      // 
      // gravityNumericUpDown
      // 
      this.gravityNumericUpDown.Location = new System.Drawing.Point(82, 175);
      this.gravityNumericUpDown.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
      this.gravityNumericUpDown.Name = "gravityNumericUpDown";
      this.gravityNumericUpDown.Size = new System.Drawing.Size(75, 20);
      this.gravityNumericUpDown.TabIndex = 6;
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(6, 177);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(43, 13);
      this.label7.TabIndex = 16;
      this.label7.Text = "Gravity:";
      // 
      // simulationGroupBox
      // 
      this.simulationGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.simulationGroupBox.Controls.Add(this.animationPanel);
      this.simulationGroupBox.Location = new System.Drawing.Point(186, 12);
      this.simulationGroupBox.Name = "simulationGroupBox";
      this.simulationGroupBox.Size = new System.Drawing.Size(486, 437);
      this.simulationGroupBox.TabIndex = 0;
      this.simulationGroupBox.TabStop = false;
      this.simulationGroupBox.Text = "Simulation";
      // 
      // animationPanel
      // 
      this.animationPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.animationPanel.BackColor = System.Drawing.Color.White;
      this.animationPanel.Location = new System.Drawing.Point(6, 19);
      this.animationPanel.Name = "animationPanel";
      this.animationPanel.Size = new System.Drawing.Size(474, 412);
      this.animationPanel.TabIndex = 7;
      // 
      // mainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(684, 461);
      this.Controls.Add(this.simulationGroupBox);
      this.Controls.Add(this.controlsGroupBox);
      this.Name = "mainForm";
      this.Text = "Elastic Collision Silumator";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainForm_FormClosing);
      ((System.ComponentModel.ISupportInitialize)(this.entitesNumericUpDown)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.lossFactorNumericUpDown)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.minRadiusNumericUpDown)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.maxRadiusNumericUpDown)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.minVelocityNumericUpDown)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.maxVelocityNumericUpDown)).EndInit();
      this.controlsGroupBox.ResumeLayout(false);
      this.controlsGroupBox.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.gravityNumericUpDown)).EndInit();
      this.simulationGroupBox.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button startButton;
    private System.Windows.Forms.Button stopButton;
    private System.Windows.Forms.NumericUpDown entitesNumericUpDown;
    private System.ComponentModel.BackgroundWorker backgroundWorker;
    private System.Windows.Forms.NumericUpDown lossFactorNumericUpDown;
    private System.Windows.Forms.NumericUpDown minRadiusNumericUpDown;
    private System.Windows.Forms.NumericUpDown maxRadiusNumericUpDown;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.NumericUpDown minVelocityNumericUpDown;
    private System.Windows.Forms.NumericUpDown maxVelocityNumericUpDown;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.GroupBox controlsGroupBox;
    private System.Windows.Forms.GroupBox simulationGroupBox;
    private System.Windows.Forms.Panel animationPanel;
    private System.Windows.Forms.NumericUpDown gravityNumericUpDown;
    private System.Windows.Forms.Label label7;
  }
}

