<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLab5
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.cmbGalaxies = New System.Windows.Forms.ComboBox()
        Me.lblGalaxy = New System.Windows.Forms.Label()
        Me.lblRegions = New System.Windows.Forms.Label()
        Me.lbRegions = New System.Windows.Forms.ListBox()
        Me.dgvPlanets = New System.Windows.Forms.DataGridView()
        Me.lblPlanets = New System.Windows.Forms.Label()
        Me.gbxPlanet = New System.Windows.Forms.GroupBox()
        Me.pbPlanet = New System.Windows.Forms.PictureBox()
        Me.txtImageName = New System.Windows.Forms.TextBox()
        Me.txtSystemName = New System.Windows.Forms.TextBox()
        Me.txtPlanetName = New System.Windows.Forms.TextBox()
        Me.txtLeaderName = New System.Windows.Forms.TextBox()
        Me.nudAllegiance = New System.Windows.Forms.NumericUpDown()
        Me.nudDiameter = New System.Windows.Forms.NumericUpDown()
        Me.nudPopulation = New System.Windows.Forms.NumericUpDown()
        Me.nudRegionID = New System.Windows.Forms.NumericUpDown()
        Me.nudPlanetID = New System.Windows.Forms.NumericUpDown()
        Me.lblImageName = New System.Windows.Forms.Label()
        Me.lblAllegiance = New System.Windows.Forms.Label()
        Me.lblSystemName = New System.Windows.Forms.Label()
        Me.lblDiameter = New System.Windows.Forms.Label()
        Me.lblPopulation = New System.Windows.Forms.Label()
        Me.lblLeaderName = New System.Windows.Forms.Label()
        Me.lblPlanetName = New System.Windows.Forms.Label()
        Me.lblRegionID = New System.Windows.Forms.Label()
        Me.lblPlanetID = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.tmrSelPlanet = New System.Windows.Forms.Timer(Me.components)
        CType(Me.dgvPlanets, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxPlanet.SuspendLayout()
        CType(Me.pbPlanet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudAllegiance, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudDiameter, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudPopulation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudRegionID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudPlanetID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbGalaxies
        '
        Me.cmbGalaxies.BackColor = System.Drawing.SystemColors.Info
        Me.cmbGalaxies.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbGalaxies.FormattingEnabled = True
        Me.cmbGalaxies.Location = New System.Drawing.Point(82, 8)
        Me.cmbGalaxies.Name = "cmbGalaxies"
        Me.cmbGalaxies.Size = New System.Drawing.Size(210, 33)
        Me.cmbGalaxies.TabIndex = 0
        '
        'lblGalaxy
        '
        Me.lblGalaxy.AutoSize = True
        Me.lblGalaxy.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGalaxy.Location = New System.Drawing.Point(9, 9)
        Me.lblGalaxy.Name = "lblGalaxy"
        Me.lblGalaxy.Size = New System.Drawing.Size(72, 25)
        Me.lblGalaxy.TabIndex = 1
        Me.lblGalaxy.Text = "Galaxy:"
        '
        'lblRegions
        '
        Me.lblRegions.AutoSize = True
        Me.lblRegions.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegions.Location = New System.Drawing.Point(10, 41)
        Me.lblRegions.Name = "lblRegions"
        Me.lblRegions.Size = New System.Drawing.Size(82, 25)
        Me.lblRegions.TabIndex = 2
        Me.lblRegions.Text = "Regions:"
        '
        'lbRegions
        '
        Me.lbRegions.BackColor = System.Drawing.SystemColors.Info
        Me.lbRegions.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbRegions.FormattingEnabled = True
        Me.lbRegions.ItemHeight = 25
        Me.lbRegions.Location = New System.Drawing.Point(13, 66)
        Me.lbRegions.Name = "lbRegions"
        Me.lbRegions.Size = New System.Drawing.Size(226, 279)
        Me.lbRegions.TabIndex = 3
        '
        'dgvPlanets
        '
        Me.dgvPlanets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPlanets.Location = New System.Drawing.Point(250, 66)
        Me.dgvPlanets.Name = "dgvPlanets"
        Me.dgvPlanets.Size = New System.Drawing.Size(500, 279)
        Me.dgvPlanets.TabIndex = 4
        '
        'lblPlanets
        '
        Me.lblPlanets.AutoSize = True
        Me.lblPlanets.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlanets.Location = New System.Drawing.Point(245, 41)
        Me.lblPlanets.Name = "lblPlanets"
        Me.lblPlanets.Size = New System.Drawing.Size(77, 25)
        Me.lblPlanets.TabIndex = 5
        Me.lblPlanets.Text = "Planets:"
        '
        'gbxPlanet
        '
        Me.gbxPlanet.Controls.Add(Me.pbPlanet)
        Me.gbxPlanet.Controls.Add(Me.txtImageName)
        Me.gbxPlanet.Controls.Add(Me.txtSystemName)
        Me.gbxPlanet.Controls.Add(Me.txtPlanetName)
        Me.gbxPlanet.Controls.Add(Me.txtLeaderName)
        Me.gbxPlanet.Controls.Add(Me.nudAllegiance)
        Me.gbxPlanet.Controls.Add(Me.nudDiameter)
        Me.gbxPlanet.Controls.Add(Me.nudPopulation)
        Me.gbxPlanet.Controls.Add(Me.nudRegionID)
        Me.gbxPlanet.Controls.Add(Me.nudPlanetID)
        Me.gbxPlanet.Controls.Add(Me.lblImageName)
        Me.gbxPlanet.Controls.Add(Me.lblAllegiance)
        Me.gbxPlanet.Controls.Add(Me.lblSystemName)
        Me.gbxPlanet.Controls.Add(Me.lblDiameter)
        Me.gbxPlanet.Controls.Add(Me.lblPopulation)
        Me.gbxPlanet.Controls.Add(Me.lblLeaderName)
        Me.gbxPlanet.Controls.Add(Me.lblPlanetName)
        Me.gbxPlanet.Controls.Add(Me.lblRegionID)
        Me.gbxPlanet.Controls.Add(Me.lblPlanetID)
        Me.gbxPlanet.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxPlanet.Location = New System.Drawing.Point(15, 345)
        Me.gbxPlanet.Name = "gbxPlanet"
        Me.gbxPlanet.Size = New System.Drawing.Size(640, 218)
        Me.gbxPlanet.TabIndex = 6
        Me.gbxPlanet.TabStop = False
        Me.gbxPlanet.Text = "Planetary Details:"
        '
        'pbPlanet
        '
        Me.pbPlanet.Location = New System.Drawing.Point(470, 23)
        Me.pbPlanet.Name = "pbPlanet"
        Me.pbPlanet.Size = New System.Drawing.Size(157, 132)
        Me.pbPlanet.TabIndex = 18
        Me.pbPlanet.TabStop = False
        '
        'txtImageName
        '
        Me.txtImageName.BackColor = System.Drawing.SystemColors.Info
        Me.txtImageName.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImageName.Location = New System.Drawing.Point(318, 179)
        Me.txtImageName.Name = "txtImageName"
        Me.txtImageName.Size = New System.Drawing.Size(320, 33)
        Me.txtImageName.TabIndex = 17
        '
        'txtSystemName
        '
        Me.txtSystemName.BackColor = System.Drawing.SystemColors.Info
        Me.txtSystemName.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSystemName.Location = New System.Drawing.Point(232, 141)
        Me.txtSystemName.Name = "txtSystemName"
        Me.txtSystemName.Size = New System.Drawing.Size(235, 33)
        Me.txtSystemName.TabIndex = 16
        '
        'txtPlanetName
        '
        Me.txtPlanetName.BackColor = System.Drawing.SystemColors.Info
        Me.txtPlanetName.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPlanetName.Location = New System.Drawing.Point(232, 34)
        Me.txtPlanetName.Name = "txtPlanetName"
        Me.txtPlanetName.Size = New System.Drawing.Size(235, 33)
        Me.txtPlanetName.TabIndex = 15
        '
        'txtLeaderName
        '
        Me.txtLeaderName.BackColor = System.Drawing.SystemColors.Info
        Me.txtLeaderName.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLeaderName.Location = New System.Drawing.Point(232, 87)
        Me.txtLeaderName.Name = "txtLeaderName"
        Me.txtLeaderName.Size = New System.Drawing.Size(235, 33)
        Me.txtLeaderName.TabIndex = 14
        '
        'nudAllegiance
        '
        Me.nudAllegiance.BackColor = System.Drawing.SystemColors.Info
        Me.nudAllegiance.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudAllegiance.Location = New System.Drawing.Point(105, 177)
        Me.nudAllegiance.Maximum = New Decimal(New Integer() {1215752192, 23, 0, 0})
        Me.nudAllegiance.Name = "nudAllegiance"
        Me.nudAllegiance.Size = New System.Drawing.Size(88, 33)
        Me.nudAllegiance.TabIndex = 13
        '
        'nudDiameter
        '
        Me.nudDiameter.BackColor = System.Drawing.SystemColors.Info
        Me.nudDiameter.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudDiameter.Location = New System.Drawing.Point(105, 60)
        Me.nudDiameter.Maximum = New Decimal(New Integer() {1215752192, 23, 0, 0})
        Me.nudDiameter.Name = "nudDiameter"
        Me.nudDiameter.Size = New System.Drawing.Size(120, 33)
        Me.nudDiameter.TabIndex = 12
        '
        'nudPopulation
        '
        Me.nudPopulation.BackColor = System.Drawing.SystemColors.Info
        Me.nudPopulation.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudPopulation.Location = New System.Drawing.Point(105, 23)
        Me.nudPopulation.Maximum = New Decimal(New Integer() {1215752192, 23, 0, 0})
        Me.nudPopulation.Name = "nudPopulation"
        Me.nudPopulation.Size = New System.Drawing.Size(120, 33)
        Me.nudPopulation.TabIndex = 11
        '
        'nudRegionID
        '
        Me.nudRegionID.BackColor = System.Drawing.SystemColors.Info
        Me.nudRegionID.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudRegionID.Location = New System.Drawing.Point(105, 138)
        Me.nudRegionID.Maximum = New Decimal(New Integer() {1215752192, 23, 0, 0})
        Me.nudRegionID.Name = "nudRegionID"
        Me.nudRegionID.Size = New System.Drawing.Size(88, 33)
        Me.nudRegionID.TabIndex = 10
        '
        'nudPlanetID
        '
        Me.nudPlanetID.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudPlanetID.Location = New System.Drawing.Point(105, 99)
        Me.nudPlanetID.Maximum = New Decimal(New Integer() {1215752192, 23, 0, 0})
        Me.nudPlanetID.Name = "nudPlanetID"
        Me.nudPlanetID.ReadOnly = True
        Me.nudPlanetID.Size = New System.Drawing.Size(88, 33)
        Me.nudPlanetID.TabIndex = 9
        '
        'lblImageName
        '
        Me.lblImageName.AutoSize = True
        Me.lblImageName.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImageName.Location = New System.Drawing.Point(199, 182)
        Me.lblImageName.Name = "lblImageName"
        Me.lblImageName.Size = New System.Drawing.Size(123, 25)
        Me.lblImageName.TabIndex = 8
        Me.lblImageName.Text = "Image Name:"
        '
        'lblAllegiance
        '
        Me.lblAllegiance.AutoSize = True
        Me.lblAllegiance.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAllegiance.Location = New System.Drawing.Point(6, 179)
        Me.lblAllegiance.Name = "lblAllegiance"
        Me.lblAllegiance.Size = New System.Drawing.Size(104, 25)
        Me.lblAllegiance.TabIndex = 7
        Me.lblAllegiance.Text = "Allegiance:"
        '
        'lblSystemName
        '
        Me.lblSystemName.AutoSize = True
        Me.lblSystemName.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSystemName.Location = New System.Drawing.Point(229, 117)
        Me.lblSystemName.Name = "lblSystemName"
        Me.lblSystemName.Size = New System.Drawing.Size(129, 25)
        Me.lblSystemName.TabIndex = 3
        Me.lblSystemName.Text = "System Name:"
        '
        'lblDiameter
        '
        Me.lblDiameter.AutoSize = True
        Me.lblDiameter.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDiameter.Location = New System.Drawing.Point(17, 60)
        Me.lblDiameter.Name = "lblDiameter"
        Me.lblDiameter.Size = New System.Drawing.Size(93, 25)
        Me.lblDiameter.TabIndex = 6
        Me.lblDiameter.Text = "Diameter:"
        '
        'lblPopulation
        '
        Me.lblPopulation.AutoSize = True
        Me.lblPopulation.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPopulation.Location = New System.Drawing.Point(3, 23)
        Me.lblPopulation.Name = "lblPopulation"
        Me.lblPopulation.Size = New System.Drawing.Size(107, 25)
        Me.lblPopulation.TabIndex = 5
        Me.lblPopulation.Text = "Population:"
        '
        'lblLeaderName
        '
        Me.lblLeaderName.AutoSize = True
        Me.lblLeaderName.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLeaderName.Location = New System.Drawing.Point(228, 64)
        Me.lblLeaderName.Name = "lblLeaderName"
        Me.lblLeaderName.Size = New System.Drawing.Size(128, 25)
        Me.lblLeaderName.TabIndex = 4
        Me.lblLeaderName.Text = "Leader Name:"
        '
        'lblPlanetName
        '
        Me.lblPlanetName.AutoSize = True
        Me.lblPlanetName.BackColor = System.Drawing.Color.Transparent
        Me.lblPlanetName.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlanetName.Location = New System.Drawing.Point(228, 11)
        Me.lblPlanetName.Name = "lblPlanetName"
        Me.lblPlanetName.Size = New System.Drawing.Size(124, 25)
        Me.lblPlanetName.TabIndex = 2
        Me.lblPlanetName.Text = "Planet Name:"
        '
        'lblRegionID
        '
        Me.lblRegionID.AutoSize = True
        Me.lblRegionID.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegionID.Location = New System.Drawing.Point(18, 140)
        Me.lblRegionID.Name = "lblRegionID"
        Me.lblRegionID.Size = New System.Drawing.Size(92, 25)
        Me.lblRegionID.TabIndex = 1
        Me.lblRegionID.Text = "RegionID:"
        '
        'lblPlanetID
        '
        Me.lblPlanetID.AutoSize = True
        Me.lblPlanetID.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlanetID.Location = New System.Drawing.Point(23, 100)
        Me.lblPlanetID.Name = "lblPlanetID"
        Me.lblPlanetID.Size = New System.Drawing.Size(87, 25)
        Me.lblPlanetID.TabIndex = 0
        Me.lblPlanetID.Text = "PlanetID:"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(661, 412)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(88, 33)
        Me.btnSave.TabIndex = 7
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClear.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.Location = New System.Drawing.Point(661, 467)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(88, 33)
        Me.btnClear.TabIndex = 8
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Location = New System.Drawing.Point(661, 522)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(88, 33)
        Me.btnExit.TabIndex = 9
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Black
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(300, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(482, 37)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Second Order Galactic Map"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnNew
        '
        Me.btnNew.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNew.Location = New System.Drawing.Point(661, 359)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(88, 33)
        Me.btnNew.TabIndex = 11
        Me.btnNew.Text = "New"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'tmrSelPlanet
        '
        Me.tmrSelPlanet.Interval = 500
        '
        'frmLab5
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.gbxPlanet)
        Me.Controls.Add(Me.lblPlanets)
        Me.Controls.Add(Me.dgvPlanets)
        Me.Controls.Add(Me.lbRegions)
        Me.Controls.Add(Me.lblRegions)
        Me.Controls.Add(Me.lblGalaxy)
        Me.Controls.Add(Me.cmbGalaxies)
        Me.Name = "frmLab5"
        Me.Text = "Lab 5"
        CType(Me.dgvPlanets, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxPlanet.ResumeLayout(False)
        Me.gbxPlanet.PerformLayout()
        CType(Me.pbPlanet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudAllegiance, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudDiameter, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudPopulation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudRegionID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudPlanetID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmbGalaxies As ComboBox
    Friend WithEvents lblGalaxy As Label
    Friend WithEvents lblRegions As Label
    Friend WithEvents lbRegions As ListBox
    Friend WithEvents dgvPlanets As DataGridView
    Friend WithEvents lblPlanets As Label
    Friend WithEvents gbxPlanet As GroupBox
    Friend WithEvents btnSave As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents lblImageName As Label
    Friend WithEvents lblAllegiance As Label
    Friend WithEvents lblDiameter As Label
    Friend WithEvents lblPopulation As Label
    Friend WithEvents lblLeaderName As Label
    Friend WithEvents lblSystemName As Label
    Friend WithEvents lblPlanetName As Label
    Friend WithEvents lblRegionID As Label
    Friend WithEvents lblPlanetID As Label
    Friend WithEvents txtImageName As TextBox
    Friend WithEvents txtSystemName As TextBox
    Friend WithEvents txtPlanetName As TextBox
    Friend WithEvents txtLeaderName As TextBox
    Friend WithEvents nudAllegiance As NumericUpDown
    Friend WithEvents nudDiameter As NumericUpDown
    Friend WithEvents nudPopulation As NumericUpDown
    Friend WithEvents nudRegionID As NumericUpDown
    Friend WithEvents nudPlanetID As NumericUpDown
    Friend WithEvents pbPlanet As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnNew As Button
    Friend WithEvents tmrSelPlanet As Timer
End Class
