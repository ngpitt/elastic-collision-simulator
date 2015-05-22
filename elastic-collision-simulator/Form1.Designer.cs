namespace elastic_collisions
{
  partial class Form1
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
      this.entitiesLabel = new System.Windows.Forms.Label();
      this.minRadiusLabel = new System.Windows.Forms.Label();
      this.maxRadiusLabel = new System.Windows.Forms.Label();
      this.lossFactorLabel = new System.Windows.Forms.Label();
      this.minVelocityNumericUpDown = new System.Windows.Forms.NumericUpDown();
      this.maxVelocityNumericUpDown = new System.Windows.Forms.NumericUpDown();
      this.maxVelocityLabel = new System.Windows.Forms.Label();
      this.minVelocityLabel = new System.Windows.Forms.Label();
      this.settingsGroupBox = new System.Windows.Forms.GroupBox();
      this.showCollisionCandidatesCheckBox = new System.Windows.Forms.CheckBox();
      this.showFPSCheckBox = new System.Windows.Forms.CheckBox();
      this.showCollisionGridCheckBox = new System.Windows.Forms.CheckBox();
      this.fillEntitiesCheckBox = new System.Windows.Forms.CheckBox();
      this.gravityNumericUpDown = new System.Windows.Forms.NumericUpDown();
      this.gravityLabel = new System.Windows.Forms.Label();
      this.simulationGroupBox = new System.Windows.Forms.GroupBox();
      this.animationPanel = new System.Windows.Forms.Panel();
      this.collisionGridSizeNumericUpDown = new System.Windows.Forms.NumericUpDown();
      this.gridSizeLabel = new System.Windows.Forms.Label();
      this.overrideGridSizeCheckBox = new System.Windows.Forms.CheckBox();
      this.controlsGroupBox = new System.Windows.Forms.GroupBox();
      ((System.ComponentModel.ISupportInitialize)(this.entitesNumericUpDown)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.lossFactorNumericUpDown)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.minRadiusNumericUpDown)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.maxRadiusNumericUpDown)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.minVelocityNumericUpDown)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.maxVelocityNumericUpDown)).BeginInit();
      this.settingsGroupBox.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.gravityNumericUpDown)).BeginInit();
      this.simulationGroupBox.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.collisionGridSizeNumericUpDown)).BeginInit();
      this.controlsGroupBox.SuspendLayout();
      this.SuspendLayout();
      // 
      // startButton
      // 
      this.startButton.Location = new System.Drawing.Point(8, 19);
      this.startButton.Name = "startButton";
      this.startButton.Size = new System.Drawing.Size(148, 23);
      this.startButton.TabIndex = 7;
      this.startButton.Text = "Start";
      this.startButton.UseVisualStyleBackColor = true;
      this.startButton.Click += new System.EventHandler(this.startButton_Click);
      // 
      // stopButton
      // 
      this.stopButton.Enabled = false;
      this.stopButton.Location = new System.Drawing.Point(8, 48);
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
            5,
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
            50,
            0,
            0,
            0});
      // 
      // entitiesLabel
      // 
      this.entitiesLabel.AutoSize = true;
      this.entitiesLabel.Location = new System.Drawing.Point(6, 21);
      this.entitiesLabel.Name = "entitiesLabel";
      this.entitiesLabel.Size = new System.Drawing.Size(44, 13);
      this.entitiesLabel.TabIndex = 8;
      this.entitiesLabel.Text = "Entities:";
      // 
      // minRadiusLabel
      // 
      this.minRadiusLabel.AutoSize = true;
      this.minRadiusLabel.Location = new System.Drawing.Point(6, 47);
      this.minRadiusLabel.Name = "minRadiusLabel";
      this.minRadiusLabel.Size = new System.Drawing.Size(63, 13);
      this.minRadiusLabel.TabIndex = 9;
      this.minRadiusLabel.Text = "Min Radius:";
      // 
      // maxRadiusLabel
      // 
      this.maxRadiusLabel.AutoSize = true;
      this.maxRadiusLabel.Location = new System.Drawing.Point(6, 73);
      this.maxRadiusLabel.Name = "maxRadiusLabel";
      this.maxRadiusLabel.Size = new System.Drawing.Size(66, 13);
      this.maxRadiusLabel.TabIndex = 10;
      this.maxRadiusLabel.Text = "Max Radius:";
      // 
      // lossFactorLabel
      // 
      this.lossFactorLabel.AutoSize = true;
      this.lossFactorLabel.Location = new System.Drawing.Point(6, 151);
      this.lossFactorLabel.Name = "lossFactorLabel";
      this.lossFactorLabel.Size = new System.Drawing.Size(65, 13);
      this.lossFactorLabel.TabIndex = 11;
      this.lossFactorLabel.Text = "Loss Factor:";
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
      // maxVelocityLabel
      // 
      this.maxVelocityLabel.AutoSize = true;
      this.maxVelocityLabel.Location = new System.Drawing.Point(6, 125);
      this.maxVelocityLabel.Name = "maxVelocityLabel";
      this.maxVelocityLabel.Size = new System.Drawing.Size(70, 13);
      this.maxVelocityLabel.TabIndex = 14;
      this.maxVelocityLabel.Text = "Max Velocity:";
      // 
      // minVelocityLabel
      // 
      this.minVelocityLabel.AutoSize = true;
      this.minVelocityLabel.Location = new System.Drawing.Point(6, 99);
      this.minVelocityLabel.Name = "minVelocityLabel";
      this.minVelocityLabel.Size = new System.Drawing.Size(67, 13);
      this.minVelocityLabel.TabIndex = 15;
      this.minVelocityLabel.Text = "Min Velocity:";
      // 
      // settingsGroupBox
      // 
      this.settingsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
      this.settingsGroupBox.Controls.Add(this.overrideGridSizeCheckBox);
      this.settingsGroupBox.Controls.Add(this.gridSizeLabel);
      this.settingsGroupBox.Controls.Add(this.collisionGridSizeNumericUpDown);
      this.settingsGroupBox.Controls.Add(this.showCollisionCandidatesCheckBox);
      this.settingsGroupBox.Controls.Add(this.showFPSCheckBox);
      this.settingsGroupBox.Controls.Add(this.showCollisionGridCheckBox);
      this.settingsGroupBox.Controls.Add(this.fillEntitiesCheckBox);
      this.settingsGroupBox.Controls.Add(this.gravityNumericUpDown);
      this.settingsGroupBox.Controls.Add(this.gravityLabel);
      this.settingsGroupBox.Controls.Add(this.lossFactorLabel);
      this.settingsGroupBox.Controls.Add(this.maxVelocityNumericUpDown);
      this.settingsGroupBox.Controls.Add(this.entitiesLabel);
      this.settingsGroupBox.Controls.Add(this.lossFactorNumericUpDown);
      this.settingsGroupBox.Controls.Add(this.minVelocityLabel);
      this.settingsGroupBox.Controls.Add(this.minVelocityNumericUpDown);
      this.settingsGroupBox.Controls.Add(this.entitesNumericUpDown);
      this.settingsGroupBox.Controls.Add(this.maxVelocityLabel);
      this.settingsGroupBox.Controls.Add(this.maxRadiusLabel);
      this.settingsGroupBox.Controls.Add(this.maxRadiusNumericUpDown);
      this.settingsGroupBox.Controls.Add(this.minRadiusLabel);
      this.settingsGroupBox.Controls.Add(this.minRadiusNumericUpDown);
      this.settingsGroupBox.Location = new System.Drawing.Point(12, 12);
      this.settingsGroupBox.Name = "settingsGroupBox";
      this.settingsGroupBox.Size = new System.Drawing.Size(168, 342);
      this.settingsGroupBox.TabIndex = 16;
      this.settingsGroupBox.TabStop = false;
      this.settingsGroupBox.Text = "Settings";
      // 
      // showCollisionCandidatesCheckBox
      // 
      this.showCollisionCandidatesCheckBox.AutoSize = true;
      this.showCollisionCandidatesCheckBox.Location = new System.Drawing.Point(9, 319);
      this.showCollisionCandidatesCheckBox.Name = "showCollisionCandidatesCheckBox";
      this.showCollisionCandidatesCheckBox.Size = new System.Drawing.Size(150, 17);
      this.showCollisionCandidatesCheckBox.TabIndex = 20;
      this.showCollisionCandidatesCheckBox.Text = "Show Collision Candidates";
      this.showCollisionCandidatesCheckBox.UseVisualStyleBackColor = true;
      // 
      // showFPSCheckBox
      // 
      this.showFPSCheckBox.AutoSize = true;
      this.showFPSCheckBox.Location = new System.Drawing.Point(9, 273);
      this.showFPSCheckBox.Name = "showFPSCheckBox";
      this.showFPSCheckBox.Size = new System.Drawing.Size(76, 17);
      this.showFPSCheckBox.TabIndex = 19;
      this.showFPSCheckBox.Text = "Show FPS";
      this.showFPSCheckBox.UseVisualStyleBackColor = true;
      // 
      // showCollisionGridCheckBox
      // 
      this.showCollisionGridCheckBox.AutoSize = true;
      this.showCollisionGridCheckBox.Location = new System.Drawing.Point(9, 296);
      this.showCollisionGridCheckBox.Name = "showCollisionGridCheckBox";
      this.showCollisionGridCheckBox.Size = new System.Drawing.Size(116, 17);
      this.showCollisionGridCheckBox.TabIndex = 18;
      this.showCollisionGridCheckBox.Text = "Show Collision Grid";
      this.showCollisionGridCheckBox.UseVisualStyleBackColor = true;
      // 
      // fillEntitiesCheckBox
      // 
      this.fillEntitiesCheckBox.AutoSize = true;
      this.fillEntitiesCheckBox.Location = new System.Drawing.Point(9, 250);
      this.fillEntitiesCheckBox.Name = "fillEntitiesCheckBox";
      this.fillEntitiesCheckBox.Size = new System.Drawing.Size(95, 17);
      this.fillEntitiesCheckBox.TabIndex = 17;
      this.fillEntitiesCheckBox.Text = "Hollow Entities";
      this.fillEntitiesCheckBox.UseVisualStyleBackColor = true;
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
      // gravityLabel
      // 
      this.gravityLabel.AutoSize = true;
      this.gravityLabel.Location = new System.Drawing.Point(6, 177);
      this.gravityLabel.Name = "gravityLabel";
      this.gravityLabel.Size = new System.Drawing.Size(43, 13);
      this.gravityLabel.TabIndex = 16;
      this.gravityLabel.Text = "Gravity:";
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
      // collisionGridSizeNumericUpDown
      // 
      this.collisionGridSizeNumericUpDown.Enabled = false;
      this.collisionGridSizeNumericUpDown.Location = new System.Drawing.Point(82, 201);
      this.collisionGridSizeNumericUpDown.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
      this.collisionGridSizeNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.collisionGridSizeNumericUpDown.Name = "collisionGridSizeNumericUpDown";
      this.collisionGridSizeNumericUpDown.Size = new System.Drawing.Size(75, 20);
      this.collisionGridSizeNumericUpDown.TabIndex = 21;
      this.collisionGridSizeNumericUpDown.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
      // 
      // gridSizeLabel
      // 
      this.gridSizeLabel.AutoSize = true;
      this.gridSizeLabel.Enabled = false;
      this.gridSizeLabel.Location = new System.Drawing.Point(6, 203);
      this.gridSizeLabel.Name = "gridSizeLabel";
      this.gridSizeLabel.Size = new System.Drawing.Size(52, 13);
      this.gridSizeLabel.TabIndex = 22;
      this.gridSizeLabel.Text = "Grid Size:";
      // 
      // overrideGridSizeCheckBox
      // 
      this.overrideGridSizeCheckBox.AutoSize = true;
      this.overrideGridSizeCheckBox.Location = new System.Drawing.Point(9, 227);
      this.overrideGridSizeCheckBox.Name = "overrideGridSizeCheckBox";
      this.overrideGridSizeCheckBox.Size = new System.Drawing.Size(106, 17);
      this.overrideGridSizeCheckBox.TabIndex = 23;
      this.overrideGridSizeCheckBox.Text = "Custom Grid Size";
      this.overrideGridSizeCheckBox.UseVisualStyleBackColor = true;
      // 
      // controlsGroupBox
      // 
      this.controlsGroupBox.Controls.Add(this.stopButton);
      this.controlsGroupBox.Controls.Add(this.startButton);
      this.controlsGroupBox.Location = new System.Drawing.Point(13, 361);
      this.controlsGroupBox.Name = "controlsGroupBox";
      this.controlsGroupBox.Size = new System.Drawing.Size(167, 88);
      this.controlsGroupBox.TabIndex = 17;
      this.controlsGroupBox.TabStop = false;
      this.controlsGroupBox.Text = "Controls";
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(684, 461);
      this.Controls.Add(this.controlsGroupBox);
      this.Controls.Add(this.simulationGroupBox);
      this.Controls.Add(this.settingsGroupBox);
      this.Name = "Form1";
      this.Text = "Elastic Collision Silumator";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainForm_FormClosing);
      ((System.ComponentModel.ISupportInitialize)(this.entitesNumericUpDown)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.lossFactorNumericUpDown)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.minRadiusNumericUpDown)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.maxRadiusNumericUpDown)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.minVelocityNumericUpDown)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.maxVelocityNumericUpDown)).EndInit();
      this.settingsGroupBox.ResumeLayout(false);
      this.settingsGroupBox.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.gravityNumericUpDown)).EndInit();
      this.simulationGroupBox.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.collisionGridSizeNumericUpDown)).EndInit();
      this.controlsGroupBox.ResumeLayout(false);
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
    private System.Windows.Forms.Label entitiesLabel;
    private System.Windows.Forms.Label minRadiusLabel;
    private System.Windows.Forms.Label maxRadiusLabel;
    private System.Windows.Forms.Label lossFactorLabel;
    private System.Windows.Forms.NumericUpDown minVelocityNumericUpDown;
    private System.Windows.Forms.NumericUpDown maxVelocityNumericUpDown;
    private System.Windows.Forms.Label maxVelocityLabel;
    private System.Windows.Forms.Label minVelocityLabel;
    private System.Windows.Forms.GroupBox settingsGroupBox;
    private System.Windows.Forms.GroupBox simulationGroupBox;
    private System.Windows.Forms.Panel animationPanel;
    private System.Windows.Forms.NumericUpDown gravityNumericUpDown;
    private System.Windows.Forms.Label gravityLabel;
    private System.Windows.Forms.CheckBox showFPSCheckBox;
    private System.Windows.Forms.CheckBox showCollisionGridCheckBox;
    private System.Windows.Forms.CheckBox fillEntitiesCheckBox;
    private System.Windows.Forms.CheckBox showCollisionCandidatesCheckBox;
    private System.Windows.Forms.Label gridSizeLabel;
    private System.Windows.Forms.NumericUpDown collisionGridSizeNumericUpDown;
    private System.Windows.Forms.CheckBox overrideGridSizeCheckBox;
    private System.Windows.Forms.GroupBox controlsGroupBox;
  }
}

