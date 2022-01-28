' Students: Ryan Beckett and Siddharajsinh Chavda
' Durham College Class Name: NETD-2202-04 - NET DEVELOPMENT I
' Date: Mar. 11, 2017
' Description: A program for displaying and updating information from a database
' Purpose: lab5 assignment for .NET Development 2202
' Version: 1.1

Option Strict On
Public Class frmLab5

    ' class variable declarations
    ' prevents controls from auto-firing events in response to the form initializing
    Dim _initGuard As Boolean = False
    ' prevents the PopulatePlanetDetails subroutine from receiving un-needed
    ' data from the datagridview control received via the DataGridViewCellEventArgs parameter
    Dim _iUpdatePlanetDetailsGuard As Integer = 0

    ''' <summary>
    ''' Method: frmLab5_Load
    ''' 
    ''' Description: Handles the form_load event (when the application opens)
    ''' 
    ''' Handles: frmLab5.Load
    ''' 
    ''' Preconditions: none
    ''' 
    ''' Post-conditions: on success, frmLab5 will be displayed
    ''' </summary>
    ''' <param name="sender">Not Used</param>
    ''' <param name="e">Not Used</param>
    Private Sub frmLab5_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        _initGuard = True
        Call cmbGalaxies_Load()
        Call lbRegions_Load()
        Call dgvPlanets_Load()
        _initGuard = False

    End Sub

    ''' <summary>
    ''' Subroutine: cmbGalaxies_Load
    ''' 
    ''' Description: Utility procedure to populate the cmbGalaxies combo-box
    ''' 
    ''' Preconditions: None
    ''' 
    ''' Post-conditions: on success, a populated combo-box control filled with data from a database
    ''' </summary>
    Private Sub cmbGalaxies_Load()

        Dim dictGalaxies As New Dictionary(Of Integer, String)
        For Each Item In DBL.Tables.Galaxy.GetAllRecords()
            dictGalaxies.Add(Item.GalaxyID, Item.GalaxyName)
        Next
        Me.cmbGalaxies.DataSource = New BindingSource(dictGalaxies, Nothing)
        Me.cmbGalaxies.DisplayMember = "Value"
        Me.cmbGalaxies.ValueMember = "Key"

    End Sub

    ''' <summary>
    ''' Subroutine: lbRegions_Load
    ''' 
    ''' Description: Utility procedure to populate the lbRegions listbox
    ''' 
    ''' Preconditions: An item must be selected in the cmbGalaxies combo-box
    ''' 
    ''' Post-conditions: on success, a populated listbox control filled with data from a database
    ''' </summary>
    Private Sub lbRegions_Load()

        Dim dictRegions As New Dictionary(Of Integer, String)
        Dim selectedGalaxyKey As Integer = DirectCast(cmbGalaxies.SelectedItem, KeyValuePair(Of Integer, String)).Key
        For Each Item In DBL.Tables.Region.GetAllRecordsByFK(selectedGalaxyKey)
            dictRegions.Add(Item.RegionID, Item.RegionName)
        Next
        Me.lbRegions.DataSource = New BindingSource(dictRegions, Nothing)
        Me.lbRegions.DisplayMember = "Value"
        Me.lbRegions.ValueMember = "Key"

    End Sub

    ''' <summary>
    ''' Subroutine: dgvPlanets_Load()
    ''' 
    ''' Description: Utility procedure to populate a datagridview
    ''' 
    ''' Preconditions: An item must be selected in the lbRegions listbox
    ''' 
    ''' Post-conditions: on success, a populated datagridview control filled with data from a database
    ''' </summary>
    Private Sub dgvPlanets_Load()

        Call ResetDataGrid()

        ' setup top row
        Me.dgvPlanets.ColumnCount = 4
        Me.dgvPlanets.RowHeadersVisible = False
        Dim hdrStyle As New DataGridViewCellStyle
        hdrStyle.Font = New Font("Segoe UI", 14)
        hdrStyle.BackColor = SystemColors.Info
        Me.dgvPlanets.Columns(0).Name = CStr(DBL.Tables.Planet.Fields.PLANET_NAME)
        Me.dgvPlanets.Columns(0).HeaderCell.Style = hdrStyle
        Me.dgvPlanets.Columns(0).Width = 119
        Me.dgvPlanets.Columns(1).Name = CStr(DBL.Tables.Planet.Fields.SYSTEM_NAME)
        Me.dgvPlanets.Columns(1).HeaderCell.Style = hdrStyle
        Me.dgvPlanets.Columns(1).Width = 119
        Me.dgvPlanets.Columns(2).Name = CStr(DBL.Tables.Planet.Fields.ALLEGIANCE_ID)
        Me.dgvPlanets.Columns(2).HeaderCell.Style = hdrStyle
        Me.dgvPlanets.Columns(2).Width = 102
        Me.dgvPlanets.Columns(3).Name = CStr(DBL.Tables.Planet.Fields.IMAGE_NAME)
        Me.dgvPlanets.Columns(3).HeaderCell.Style = hdrStyle
        Me.dgvPlanets.Columns(3).Width = 128

        'obtain selected region from lbRegions
        Dim selectedRegionKey As Integer = DirectCast(Me.lbRegions.SelectedItem, KeyValuePair(Of Integer, String)).Key
        Dim listPlanets As New List(Of DBL.Tables.Planet)
        listPlanets = DBL.Tables.Planet.GetAllRecordsByFK(selectedRegionKey)

        ' if there are no planets in the region, we must avoid populating the datagridview
        Dim iCount As Integer = 0
        If 1 < listPlanets.Count Then
            iCount = listPlanets.Count - 1
        Else
            GoTo Cancel
        End If
        Me.dgvPlanets.RowCount = iCount

        ' populate the datagridview
        For rowIterator As Integer = 0 To dgvPlanets.Rows.Count - 1

            Me.dgvPlanets.Rows().Item(rowIterator).Cells().Item(0).Value = listPlanets.Item(rowIterator).PlanetName
            Me.dgvPlanets.Rows().Item(rowIterator).Cells().Item(1).Value = listPlanets.Item(rowIterator).SystemName
            Me.dgvPlanets.Rows().Item(rowIterator).Cells().Item(2).Value = listPlanets.Item(rowIterator).Allegiance
            Me.dgvPlanets.Rows().Item(rowIterator).Cells().Item(3).Value = listPlanets.Item(rowIterator).ImageName

        Next

Cancel:
    End Sub

    ''' <summary>
    ''' Method: cmbGalaxies_SelectedIndexChanged
    ''' 
    ''' Description: handles the SelectedIndexChanged event
    ''' 
    ''' Preconditions: none
    ''' 
    ''' Post-conditions: _initGuard must be false for any meaningful changes to occur
    '''                  if it is, then it calls subroutines to populate controls with data
    ''' </summary>
    ''' <param name="sender">Not Used</param>
    ''' <param name="e">Not Used</param>
    Private Sub cmbGalaxies_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbGalaxies.SelectedIndexChanged

        If Not _initGuard Then
            Call lbRegions_Load()
            Call dgvPlanets_Load()
        End If

    End Sub

    ''' <summary>
    ''' Method: lbRegions_SelectedIndexChanged
    ''' 
    ''' Description: handles the SelectedIndexChanged event
    ''' 
    ''' Preconditions: none
    ''' 
    ''' Post-conditions: _initGuard must be false for any meaningful changes to occur
    '''                  if it is, then it calls a subroutine to populate the datagridview control with data
    ''' </summary>
    ''' <param name="sender">Not Used</param>
    ''' <param name="e">Not Used</param>
    Private Sub lbRegions_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbRegions.SelectedIndexChanged

        If Not _initGuard Then
            Call dgvPlanets_Load()
            Me.tmrSelPlanet.Enabled = True
        End If

    End Sub

    ''' <summary>
    ''' Method: dgvPlanets_CellEnter
    ''' 
    ''' Description: handles the CellEnter event
    ''' 
    ''' Preconditions: none
    ''' 
    ''' Post-conditions: _initGuard must be false for any meaningful changes to occur
    '''                  if it is, then it calls a subroutine to populate various controls in the planetarydetails groupbox with data
    ''' </summary>
    ''' <param name="sender">Not Used</param>
    ''' <param name="e">datagridviewcell</param>
    Private Sub dgvPlanets_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPlanets.CellEnter

        If Not _initGuard Then
            Call PopulatePlanetDetails(e)
        End If

    End Sub


    ''' <summary>
    ''' Subroutine: ResetDataGrid
    ''' 
    ''' Description: Used to erase values from the datagridview control
    ''' 
    ''' Preconditions: none
    ''' 
    ''' Postconditions: _initGuard must be false for any meaningful changes to occur
    '''                 if it is, then it sets all the values in the datagridview to empty strings
    ''' </summary>
    Private Sub ResetDataGrid()

        If Not _initGuard Then

            For rowIterator As Integer = 0 To Me.dgvPlanets.Rows.Count - 1

                For columnIterator As Integer = 0 To Me.dgvPlanets.Columns.Count - 1
                    Me.dgvPlanets.Rows().Item(rowIterator).Cells().Item(columnIterator).Value = ""
                Next

            Next
        End If

    End Sub

    ''' <summary>
    ''' Subroutine: ResetPlanetaryDetails
    ''' 
    ''' Description: Used to clear the contents of the controls in the PlanetaryDetails groupbox
    ''' 
    ''' Preconditions: none
    ''' 
    ''' Post-conditions: resets various controls to their default values
    ''' </summary>
    Private Sub ResetPlanetaryDetails()
        txtPlanetName.Text = ""
        nudRegionID.Value = 0
        txtSystemName.Text = ""
        txtLeaderName.Text = ""
        nudPopulation.Value = 0
        nudDiameter.Value = 0
        nudAllegiance.Value = 0
        txtImageName.Text = ""
    End Sub

    ''' <summary>
    ''' Subroutine: PopulatePlanetDetails
    ''' 
    ''' Description: Based on the datagridviewcelleventargs supplied, looks up a planet in the database
    ''' and populates various controls with the result
    ''' 
    ''' Preconditions: a valid PlanetName, provided by the datagridviewcelleventargs parameter
    ''' 
    ''' Post-conditions: various controls will have data in them
    ''' </summary>
    ''' <param name="e">datagridviewcelleventargs</param>
    Private Sub PopulatePlanetDetails(e As DataGridViewCellEventArgs)

        Me.tmrSelPlanet.Enabled = False
        If _iUpdatePlanetDetailsGuard > 0 Then
            Dim myPlanet As New DBL.Tables.Planet
            Try
                myPlanet = DBL.Tables.Planet.GetRecordByPlanetName(CStr(Me.dgvPlanets.Item(0, e.RowIndex).Value))
                If Not (IsDBNull(myPlanet.PlanetID)) Then Me.nudPlanetID.Value = myPlanet.PlanetID
                If Not (IsDBNull(myPlanet.PlanetName)) Then Me.txtPlanetName.Text = myPlanet.PlanetName
                If Not (IsDBNull(myPlanet.RegionID)) Then Me.nudRegionID.Value = myPlanet.RegionID
                If Not (IsDBNull(myPlanet.SystemName)) Then Me.txtSystemName.Text = myPlanet.SystemName
                If Not (IsDBNull(myPlanet.LeadersName)) Then Me.txtLeaderName.Text = myPlanet.LeadersName
                If Not (IsDBNull(myPlanet.Population)) Then Me.nudPopulation.Value = myPlanet.Population
                If Not (IsDBNull(myPlanet.Diameter)) Then Me.nudDiameter.Value = myPlanet.Diameter
                If Not (IsDBNull(myPlanet.Allegiance)) Then Me.nudAllegiance.Value = myPlanet.Allegiance
                If Not (IsDBNull(myPlanet.ImageName)) Then Me.txtImageName.Text = myPlanet.ImageName
                Me.pbPlanet.Image = Image.FromFile(System.IO.Directory.GetCurrentDirectory() & "\images\planets\" & myPlanet.ImageName)
            Catch ex As Exception
                Me.pbPlanet.Image = Image.FromFile(System.IO.Directory.GetCurrentDirectory() & "\images\planets\" & "NoImage.png")
            End Try
            _iUpdatePlanetDetailsGuard = 0

        End If
        _iUpdatePlanetDetailsGuard += 1

    End Sub

    ''' <summary>
    ''' Method: btnSave_Click
    ''' 
    ''' Description: Handles the btnSave.Click event
    ''' 
    ''' Pre-conditions: none
    ''' 
    ''' Post-conditions: calls the AddOrUpdatePlanet subroutine and reports the result
    ''' </summary>
    ''' <param name="sender">Not Used</param>
    ''' <param name="e">Not Used</param>
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Dim iResult As Integer = 0
        iResult = CInt(AddOrUpdatePlanet())
        If -1 = iResult Then
            MsgBox("Unable to update data")
        ElseIf 0 <> iResult Then
            MsgBox("Successfully added planet")
        Else
            MsgBox("Successfully modified planet")
        End If
        Me.nudPlanetID.Value = iResult

    End Sub

    ''' <summary>
    ''' Method: btnNew_Click
    ''' 
    ''' Description: Handles the btnNew.Click event
    ''' 
    ''' Pre-conditions: none
    ''' 
    ''' Post-conditions: calls the ResetPlanetaryDetails sub-routine, sets nudPlanetID to 0
    ''' </summary>
    ''' <param name="sender">Not Used</param>
    ''' <param name="e">Not Used</param>
    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Me.nudPlanetID.Value = 0
        Call ResetPlanetaryDetails()
    End Sub

    ''' <summary>
    ''' Method: btnClear_click
    ''' 
    ''' Description: Handles the btnClear.Click event
    ''' 
    ''' Pre-confitions: none
    ''' 
    ''' Post-conditions: calls the ResetPlanetaryDetails sub-routine
    ''' </summary>
    ''' <param name="sender">Not Used</param>
    ''' <param name="e">Not Used</param>
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Call ResetPlanetaryDetails()
    End Sub

    ''' <summary>
    ''' Method: btnExit_Click
    ''' 
    ''' Description: Handles the btnExit.Click event
    ''' 
    ''' Pre-conditions: none
    ''' 
    ''' Post-conditions: closes the application
    ''' </summary>
    ''' <param name="sender">Not Used</param>
    ''' <param name="e">Not Used</param>
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    ''' <summary>
    ''' Function: AddOrUpdatePlanet
    ''' 
    ''' Description: Adds or Updates planet in database. The return value is used to populate the new planet's id control
    ''' 
    ''' Pre-conditions: If nudPlanetID has a value other than 0, the updates a planet, else adds a planet
    ''' 
    ''' Post-conditions: an updated planet or a new planet in the database
    ''' </summary>
    ''' <returns>Integer</returns>
    Private Function AddOrUpdatePlanet() As Integer

        Dim returnID As Integer = 0
        Dim myPlanet As New DBL.Tables.Planet
        If "" = Me.txtImageName.Text Then
            Me.txtImageName.Text = "NoImage.png"
        End If
        myPlanet.PlanetID = CInt(Me.nudPlanetID.Value)
        myPlanet.PlanetName = Me.txtPlanetName.Text
        myPlanet.RegionID = CInt(Me.nudRegionID.Value)
        myPlanet.SystemName = Me.txtSystemName.Text
        myPlanet.LeadersName = Me.txtLeaderName.Text
        myPlanet.Population = CInt(Me.nudPopulation.Value)
        myPlanet.Diameter = CInt(Me.nudDiameter.Value)
        myPlanet.Allegiance = CInt(Me.nudAllegiance.Value)
        myPlanet.ImageName = Me.txtImageName.Text
        If 0 <> Me.nudPlanetID.Value Then
            If Not DBL.Tables.Planet.UpdateExistingRecord(myPlanet) Then
                returnID = -1
            End If
        Else
            myPlanet.PlanetName = Me.txtPlanetName.Text
            myPlanet.RegionID = CInt(Me.nudRegionID.Value)
            myPlanet.SystemName = Me.txtSystemName.Text
            myPlanet.LeadersName = Me.txtLeaderName.Text
            myPlanet.Population = CInt(Me.nudPopulation.Value)
            myPlanet.Diameter = CInt(Me.nudDiameter.Value)
            myPlanet.Allegiance = CInt(Me.nudAllegiance.Value)
            myPlanet.ImageName = Me.txtImageName.Text
            returnID = DBL.Tables.Planet.InsertNewRecord(myPlanet)
        End If
        Return returnID

    End Function

    ''' <summary>
    ''' Method: tmrSelPlanet_Tick
    ''' 
    ''' Description: Handles the tmrSelPlanet.Tick event
    ''' 
    ''' Preconditions: User must click an item in the lbRegions listbox
    ''' 
    ''' Post-conditions: Calls method to update planetaryDetails groupbox
    ''' </summary>
    ''' <param name="sender">Not used</param>
    ''' <param name="e">Not used</param>
    Private Sub tmrSelPlanet_Tick(sender As Object, e As EventArgs) Handles tmrSelPlanet.Tick
        If dgvPlanets.Rows.Count <> 0 Then
            Me.dgvPlanets.Rows().Item(0).Cells().Item(0).Selected = True
            Dim dgvCellEventArgs As New DataGridViewCellEventArgs(0, 0)
            dgvPlanets_CellEnter(Nothing, dgvCellEventArgs)
        End If
    End Sub
End Class
