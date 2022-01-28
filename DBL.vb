Option Strict On
Imports System.Data, System.Data.SqlClient

' Class: DBL
' Description: Database support classes. The DBL Class was originally designed by Clint
' MacDonald, but has been modified to include support for 3 other tables.
' Additionally, one extra method has been added to allow for retrieving the id of the
' item being added to the database
' Students: Ryan Beckett and Siddharajsinh Chavda
' Durham College Class Name: NETD-2202-04 - NET DEVELOPMENT I
' Date: Mar. 11, 2017
' Version: 1.1
'
Public Class DBL

    Public Class Conn

        Public Shared Function getConnectionString() As String
            Return My.Settings.DBConnection
        End Function

    End Class 'Conn

    Public Class Tables

        Public Class Planet

#Region "           ----- Constructors -----"

            Public Sub New()
                PlanetID = 0
                RegionID = 0
                PlanetName = String.Empty
                SystemName = String.Empty
                LeadersName = String.Empty
                Population = 0
                Diameter = 0
                Allegiance = 0
                ImageName = String.Empty
            End Sub

            Public Sub New(PlanetID As Integer)
                Dim P As New Planet
                P = GetRecordByID(PlanetID)
                PlanetID = P.PlanetID
                RegionID = P.RegionID
                PlanetName = P.PlanetName
                SystemName = P.SystemName
                LeadersName = P.LeadersName
                Population = P.Population
                Diameter = P.Diameter
                Allegiance = P.Allegiance
                ImageName = P.ImageName
            End Sub

#End Region

#Region "           ----- Field Names -----"
            Public Class Fields
                Public Const PLANET_ID As String = "PlanetID"
                Public Const REGION_ID As String = "RegionID"
                Public Const PLANET_NAME As String = "PlanetName"
                Public Const SYSTEM_NAME As String = "SystemName"
                Public Const LEADERS_NAME As String = "LeadersName"
                Public Const POPULATION As String = "Population"
                Public Const DIAMETER As String = "Diameter"
                Public Const ALLEGIANCE_ID As String = "Allegiance"
                Public Const IMAGE_NAME As String = "imageName"
            End Class

#End Region

#Region "           ----- Properties -----"

            Public Property PlanetID As Integer
            Public Property RegionID As Integer
            Public Property PlanetName As String
            Public Property SystemName As String
            Public Property LeadersName As String
            Public Property Population As Integer
            Public Property Diameter As Integer
            Public Property Allegiance As Integer
            Public Property ImageName As String

#End Region

#Region "           ----- SQL Statements -----"

            Private Class SQL_Statements
                Public Const SELECT_1_BY_ID As String = "SELECT 
                                                    PlanetID, RegionID, PlanetName, SystemName, LeadersName, 
                                                    Population, Diameter, Allegiance, ImageName 
                                                    FROM datPlanet 
                                                    WHERE PlanetID = @PlanetID
                                                    ORDER BY PlanetName"
                Public Const SELECT_PLANET_BY_PLANET_NAME As String = "SELECT PlanetID, PlanetName, RegionID, SystemName, LeadersName, Population, Diameter, Allegiance, ImageName From datPlanet WHERE PlanetName = @PlanetName"
                Public Const SELECT_ALL As String = "SELECT 
                                                    PlanetID, RegionID, PlanetName, SystemName, LeadersName, 
                                                    Population, Diameter, Allegiance, ImageName 
                                                    FROM datPlanet
                                                    ORDER BY PlanetName"
                Public Const SELECT_ALL_BY_REGION As String = "Select 
                                                    PlanetID, RegionID, PlanetName, SystemName, LeadersName, 
                                                    Population, Diameter, Allegiance, ImageName 
                                                    FROM datPlanet 
                                                    WHERE RegionID = @RegionID
                                                    ORDER BY PlanetName"
                Public Const INSERT_NEW As String = "INSERT INTO datPlanet (
                                                    RegionID, PlanetName, SystemName, LeadersName, 
                                                    Population, Diameter, Allegiance, ImageName
                                                    ) VALUES (
                                                    @RegionID, @PlanetName, @SystemName, @LeadersName, 
                                                    @Population, @Diameter, @Allegiance, @ImageName
                                                    );SELECT @@Identity;"
                Public Const UPDATE_EXISTING As String = "UPDATE datPlanet SET 
                                                    RegionID = @RegionID, 
                                                    PlanetName = @PlanetName, 
                                                    SystemName = @SystemName, 
                                                    LeadersName = @LeadersName, 
                                                    Population = @Population, 
                                                    Diameter = @Diameter, 
                                                    Allegiance = @Allegiance, 
                                                    ImageName = @ImageName
                                                    WHERE PlanetID = @PlanetID"
                Public Const DELETE_ONE As String = "DELETE FROM datPlanet WHERE PlanetID = @PlanetID"

            End Class

#End Region

#Region "           ----- Class Methods -----"

            Public Shared Function GetRecordByID(PlanetIDNum As Integer) As Planet
                ' Create local copy of Class Object
                Dim P As New Planet

                'Declare a connection and retrience the connection string from project settings
                Dim MyConn As New SqlConnection
                MyConn.ConnectionString = Conn.getConnectionString

                ' Declare the Command to be executed and set properties
                ' similar to DOS commands, Or Command() Prompt Statements, except SQL
                Dim MyCommand As New System.Data.SqlClient.SqlCommand
                MyCommand.Connection = MyConn
                MyCommand.CommandType = CommandType.Text
                MyCommand.CommandText = SQL_Statements.SELECT_1_BY_ID ' Can type in SQL as string, but Const better

                ' Add parameters to commands (in Command Prompt would be Piped with |, In SQL, uses "@" symbology )
                MyCommand.Parameters.AddWithValue("@PlanetID", PlanetIDNum)

                ' Use Try/Catch block as many errors can occur, including connection failed
                Try
                    ' attempt to connect to database
                    MyConn.Open()

                    ' Declare a data reader, which is "read only" commands (SELECT), and is a resultant "set"
                    Dim DR As IDataReader
                    ' Execute the Command with the Reader Command with CommandText
                    DR = MyCommand.ExecuteReader()


                    ' Because we are only retrieving 1 record, we do not need a loop
                    ' the .read method of datareader, move the pointer to the first record and 
                    ' returns a boolean if it exists or not
                    If DR.Read Then
                        ' Populate the Class Object Properties with each field in the dataReader
                        If Not IsDBNull(DR(Fields.PLANET_ID)) Then P.PlanetID = CInt(DR(Fields.PLANET_ID))
                        If Not IsDBNull(DR(Fields.REGION_ID)) Then P.RegionID = CInt(DR(Fields.REGION_ID))
                        If Not IsDBNull(DR(Fields.PLANET_NAME)) Then P.PlanetName = CStr(DR(Fields.PLANET_NAME))
                        If Not IsDBNull(DR(Fields.SYSTEM_NAME)) Then P.SystemName = CStr(DR(Fields.SYSTEM_NAME))
                        If Not IsDBNull(DR(Fields.LEADERS_NAME)) Then P.LeadersName = CStr(DR(Fields.LEADERS_NAME))
                        If Not IsDBNull(DR(Fields.POPULATION)) Then P.Population = CInt(DR(Fields.POPULATION))
                        If Not IsDBNull(DR(Fields.DIAMETER)) Then P.Diameter = CInt(DR(Fields.DIAMETER))
                        If Not IsDBNull(DR(Fields.ALLEGIANCE_ID)) Then P.Allegiance = CInt(DR(Fields.ALLEGIANCE_ID))
                        If Not IsDBNull(DR(Fields.IMAGE_NAME)) Then P.ImageName = CStr(DR(Fields.IMAGE_NAME))
                    End If

                    ' Close and dispose of the dataaReader to clear memory and close the database connection
                    DR.Close()
                    DR = Nothing
                    MyConn.Close()

                Catch ex As Exception
                    ' Would add error logging information here
                    ' You will learn this later
                    MsgBox("An Error Occured: " & Err.Description, MsgBoxStyle.Critical, "SELECT ONE ERROR")
                End Try

                Return P
            End Function

            Public Shared Function GetRecordByPlanetName(PlanetNameIn As String) As Planet
                ' Create local copy of Class Object
                Dim P As New Planet

                'Declare a connection and retrience the connection string from project settings
                Dim MyConn As New SqlConnection
                MyConn.ConnectionString = Conn.getConnectionString

                ' Declare the Command to be executed and set properties
                ' similar to DOS commands, Or Command() Prompt Statements, except SQL
                Dim MyCommand As New System.Data.SqlClient.SqlCommand
                MyCommand.Connection = MyConn
                MyCommand.CommandType = CommandType.Text
                MyCommand.CommandText = SQL_Statements.SELECT_PLANET_BY_PLANET_NAME ' Can type in SQL as string, but Const better

                ' Add parameters to commands (in Command Prompt would be Piped with |, In SQL, uses "@" symbology )
                MyCommand.Parameters.AddWithValue("@PlanetName", PlanetNameIn)

                ' Use Try/Catch block as many errors can occur, including connection failed
                Try
                    ' attempt to connect to database
                    MyConn.Open()

                    ' Declare a data reader, which is "read only" commands (SELECT), and is a resultant "set"
                    Dim DR As IDataReader
                    ' Execute the Command with the Reader Command with CommandText
                    DR = MyCommand.ExecuteReader()

                    ' Because we are only retrieving 1 record, we do not need a loop
                    ' the .read method of datareader, move the pointer to the first record and 
                    ' returns a boolean if it exists or not
                    If DR.Read Then
                        ' Populate the Class Object Properties with each field in the dataReader
                        If Not IsDBNull(DR(Fields.PLANET_ID)) Then P.PlanetID = CInt(DR(Fields.PLANET_ID))
                        If Not IsDBNull(DR(Fields.REGION_ID)) Then P.RegionID = CInt(DR(Fields.REGION_ID))
                        If Not IsDBNull(DR(Fields.PLANET_NAME)) Then P.PlanetName = CStr(DR(Fields.PLANET_NAME))
                        If Not IsDBNull(DR(Fields.SYSTEM_NAME)) Then P.SystemName = CStr(DR(Fields.SYSTEM_NAME))
                        If Not IsDBNull(DR(Fields.LEADERS_NAME)) Then P.LeadersName = CStr(DR(Fields.LEADERS_NAME))
                        If Not IsDBNull(DR(Fields.POPULATION)) Then P.Population = CInt(DR(Fields.POPULATION))
                        If Not IsDBNull(DR(Fields.DIAMETER)) Then P.Diameter = CInt(DR(Fields.DIAMETER))
                        If Not IsDBNull(DR(Fields.ALLEGIANCE_ID)) Then P.Allegiance = CInt(DR(Fields.ALLEGIANCE_ID))
                        If Not IsDBNull(DR(Fields.IMAGE_NAME)) Then P.ImageName = CStr(DR(Fields.IMAGE_NAME))
                    End If

                    ' Close and dispose of the dataaReader to clear memory and close the database connection
                    DR.Close()
                    DR = Nothing
                    MyConn.Close()

                Catch ex As Exception
                    ' Would add error logging information here
                    ' You will learn this later
                    MsgBox("ERROR: " & Err.Description, MsgBoxStyle.Critical, "select planet by planet name")
                End Try

                Return P
            End Function

            Public Shared Function GetAllRecords() As List(Of Planet)                ' Create local copy of Class Object
                ' We are returning more than one planet here, so we need to place them in 
                ' a collection and return the entire collection full of 1 or more Class Objects
                ' DECLARE a new Generic.List collection
                Dim Planets As New List(Of Planet)

                Dim MyConn As New SqlConnection
                MyConn.ConnectionString = Conn.getConnectionString

                Dim MyCommand As New System.Data.SqlClient.SqlCommand
                MyCommand.Connection = MyConn
                MyCommand.CommandType = CommandType.Text
                MyCommand.CommandText = SQL_Statements.SELECT_ALL ' Can type in SQL as string, but Const better

                ' No parameters in a SELECT ALL query
                Try
                    MyConn.Open()
                    Dim DR As IDataReader
                    DR = MyCommand.ExecuteReader()

                    ' Declare a new local Class Object
                    Dim P As Planet
                    Do While DR.Read
                        ' Instantiate P as New Class Object each time through the loop
                        P = New Planet
                        ' Populate the Class Object Properties with each field in the dataReader
                        If Not IsDBNull(DR(Fields.PLANET_ID)) Then P.PlanetID = CInt(DR(Fields.PLANET_ID))
                        If Not IsDBNull(DR(Fields.REGION_ID)) Then P.RegionID = CInt(DR(Fields.REGION_ID))
                        If Not IsDBNull(DR(Fields.PLANET_NAME)) Then P.PlanetName = CStr(DR(Fields.PLANET_NAME))
                        If Not IsDBNull(DR(Fields.SYSTEM_NAME)) Then P.SystemName = CStr(DR(Fields.SYSTEM_NAME))
                        If Not IsDBNull(DR(Fields.LEADERS_NAME)) Then P.LeadersName = CStr(DR(Fields.LEADERS_NAME))
                        If Not IsDBNull(DR(Fields.POPULATION)) Then P.Population = CInt(DR(Fields.POPULATION))
                        If Not IsDBNull(DR(Fields.DIAMETER)) Then P.Diameter = CInt(DR(Fields.DIAMETER))
                        If Not IsDBNull(DR(Fields.ALLEGIANCE_ID)) Then P.Allegiance = CInt(DR(Fields.ALLEGIANCE_ID))
                        If Not IsDBNull(DR(Fields.IMAGE_NAME)) Then P.ImageName = CStr(DR(Fields.IMAGE_NAME))
                        ' Add the Class Object to the collection (List)
                        Planets.Add(P)
                    Loop

                    DR.Close()
                    DR = Nothing
                    MyConn.Close()

                Catch ex As Exception
                    ' Would add error logging information here
                    ' You will learn this later
                    MsgBox("ERROR: " & Err.Description, MsgBoxStyle.Critical, "select all planets")
                End Try

                ' Returns the entire collection whether there is anything in it or not.
                Return Planets

            End Function

            Public Shared Function GetAllRecordsByFK(RegionID As Integer) As List(Of Planet)                ' Create local copy of Class Object
                ' We are returning more than one planet here, so we need to place them in 
                ' a collection and return the entire collection full of 1 or more Class Objects
                ' DECLARE a new Generic.List collection
                Dim Planets As New List(Of Planet)

                Dim MyConn As New SqlConnection
                MyConn.ConnectionString = Conn.getConnectionString

                Dim MyCommand As New System.Data.SqlClient.SqlCommand
                MyCommand.Connection = MyConn
                MyCommand.CommandType = CommandType.Text
                MyCommand.CommandText = SQL_Statements.SELECT_ALL_BY_REGION ' Can type in SQL as string, but Const better

                ' One query as Foreign Key
                MyCommand.Parameters.AddWithValue("@RegionID", RegionID)

                Try
                    MyConn.Open()
                    Dim DR As IDataReader
                    DR = MyCommand.ExecuteReader()

                    ' Declare a new local Class Object
                    Dim P As Planet
                    Do While DR.Read
                        ' Instantiate P as New Class Object each time through the loop
                        P = New Planet
                        ' Populate the Class Object Properties with each field in the dataReader
                        If Not IsDBNull(DR(Fields.PLANET_ID)) Then P.PlanetID = CInt(DR(Fields.PLANET_ID))
                        If Not IsDBNull(DR(Fields.REGION_ID)) Then P.RegionID = CInt(DR(Fields.REGION_ID))
                        If Not IsDBNull(DR(Fields.PLANET_NAME)) Then P.PlanetName = CStr(DR(Fields.PLANET_NAME))
                        If Not IsDBNull(DR(Fields.SYSTEM_NAME)) Then P.SystemName = CStr(DR(Fields.SYSTEM_NAME))
                        If Not IsDBNull(DR(Fields.LEADERS_NAME)) Then P.LeadersName = CStr(DR(Fields.LEADERS_NAME))
                        If Not IsDBNull(DR(Fields.POPULATION)) Then P.Population = CInt(DR(Fields.POPULATION))
                        If Not IsDBNull(DR(Fields.DIAMETER)) Then P.Diameter = CInt(DR(Fields.DIAMETER))
                        If Not IsDBNull(DR(Fields.ALLEGIANCE_ID)) Then P.Allegiance = CInt(DR(Fields.ALLEGIANCE_ID))
                        If Not IsDBNull(DR(Fields.IMAGE_NAME)) Then P.ImageName = CStr(DR(Fields.IMAGE_NAME))
                        ' Add the Class Object to the collection (List)
                        Planets.Add(P)
                    Loop

                    DR.Close()
                    DR = Nothing
                    MyConn.Close()

                Catch ex As Exception
                    ' Would add error logging information here
                    ' You will learn this later
                    MsgBox("ERROR: " & Err.Description, MsgBoxStyle.Critical, "select all by RegionID")
                End Try

                ' Returns the entire collection whether there is anything in it or not.
                Return Planets

            End Function

            Public Shared Function InsertNewRecord(PlanetObject As Planet) As Integer
                Dim PlanetID As Integer = 0

                Dim MyConn As New SqlConnection
                MyConn.ConnectionString = Conn.getConnectionString

                Dim MyCommand As New System.Data.SqlClient.SqlCommand
                MyCommand.Connection = MyConn
                MyCommand.CommandType = CommandType.Text
                MyCommand.CommandText = SQL_Statements.INSERT_NEW ' Can type in SQL as string, but Const better

                ' Add parameters to commands (in Command Prompt would be Piped with |, In SQL, uses "@" symbology )
                MyCommand.Parameters.AddWithValue("@" & Fields.REGION_ID, PlanetObject.RegionID)
                MyCommand.Parameters.AddWithValue("@" & Fields.PLANET_NAME, PlanetObject.PlanetName)
                MyCommand.Parameters.AddWithValue("@" & Fields.SYSTEM_NAME, PlanetObject.SystemName)
                MyCommand.Parameters.AddWithValue("@" & Fields.LEADERS_NAME, PlanetObject.LeadersName)
                MyCommand.Parameters.AddWithValue("@" & Fields.POPULATION, PlanetObject.Population)
                MyCommand.Parameters.AddWithValue("@" & Fields.DIAMETER, PlanetObject.Diameter)
                MyCommand.Parameters.AddWithValue("@" & Fields.ALLEGIANCE_ID, PlanetObject.Allegiance)
                MyCommand.Parameters.AddWithValue("@" & Fields.IMAGE_NAME, PlanetObject.ImageName)

                ' Use Try/Catch block as many errors can occur, including connection failed
                Try
                    ' attempt to connect to database
                    MyConn.Open()

                    ' -1 indicates error, anything else means success
                    PlanetID = CInt(MyCommand.ExecuteScalar())
                    If -1 = PlanetID Then
                        Throw (New Exception("unable to insert data"))
                    End If

                    ' Close and dispose of the dataaReader to clear memory and close the database connection
                    MyConn.Close()

                Catch ex As Exception
                    ' Would add error logging information here
                    ' You will learn this later
                    MsgBox("ERROR: " & Err.Description, MsgBoxStyle.Critical, "insert new planet")
                End Try

                Return PlanetID

            End Function

            Public Shared Function UpdateExistingRecord(PlanetObject As Planet) As Boolean
                Dim bResult As Boolean = False

                Dim MyConn As New SqlConnection
                MyConn.ConnectionString = Conn.getConnectionString

                Dim MyCommand As New System.Data.SqlClient.SqlCommand
                MyCommand.Connection = MyConn
                MyCommand.CommandType = CommandType.Text
                MyCommand.CommandText = SQL_Statements.UPDATE_EXISTING ' Can type in SQL as string, but Const better

                ' Add parameters to commands (in Command Prompt would be Piped with |, In SQL, uses "@" symbology )
                MyCommand.Parameters.AddWithValue("@" & Fields.PLANET_ID, PlanetObject.PlanetID)
                MyCommand.Parameters.AddWithValue("@" & Fields.REGION_ID, PlanetObject.RegionID)
                MyCommand.Parameters.AddWithValue("@" & Fields.PLANET_NAME, PlanetObject.PlanetName)
                MyCommand.Parameters.AddWithValue("@" & Fields.SYSTEM_NAME, PlanetObject.SystemName)
                MyCommand.Parameters.AddWithValue("@" & Fields.LEADERS_NAME, PlanetObject.LeadersName)
                MyCommand.Parameters.AddWithValue("@" & Fields.POPULATION, PlanetObject.Population)
                MyCommand.Parameters.AddWithValue("@" & Fields.DIAMETER, PlanetObject.Diameter)
                MyCommand.Parameters.AddWithValue("@" & Fields.ALLEGIANCE_ID, PlanetObject.Allegiance)
                MyCommand.Parameters.AddWithValue("@" & Fields.IMAGE_NAME, PlanetObject.ImageName)

                ' Use Try/Catch block as many errors can occur, including connection failed
                Try
                    ' attempt to connect to database
                    MyConn.Open()

                    ' Execute the Command with the NON QUERY as we are Writing and not getting anything back
                    ' ExecuteNonQuery returns an integer representing the number of records effected
                    '               for an UPDATE, this should be 1 for success, and 0 for failure
                    Dim NumRecords As Integer = MyCommand.ExecuteNonQuery()
                    bResult = (NumRecords = 1)

                    ' Close and dispose of the dataaReader to clear memory and close the database connection
                    MyConn.Close()

                Catch ex As Exception
                    ' Would add error logging information here
                    ' You will learn this later
                    MsgBox("ERROR: " & Err.Description, MsgBoxStyle.Critical, "update planet by PlanetID")
                End Try

                Return bResult
            End Function

            Public Shared Function DeleteByID(PlanetIDNum As Integer) As Boolean
                Dim BooResult As Boolean = False

                Dim MyConn As New SqlConnection
                MyConn.ConnectionString = Conn.getConnectionString

                Dim MyCommand As New System.Data.SqlClient.SqlCommand
                MyCommand.Connection = MyConn
                MyCommand.CommandType = CommandType.Text
                MyCommand.CommandText = SQL_Statements.DELETE_ONE ' Can type in SQL as string, but Const better

                ' Add parameters to commands (in Command Prompt would be Piped with |, In SQL, uses "@" symbology )
                MyCommand.Parameters.AddWithValue("@" & Fields.PLANET_ID, PlanetIDNum)

                ' Use Try/Catch block as many errors can occur, including connection failed
                Try
                    ' attempt to connect to database
                    MyConn.Open()

                    ' Execute the Command with the NON QUERY as we are Writing and not getting anything back
                    ' ExecuteNonQuery returns an integer representing the number of records effected
                    '               for an DELETE, this should be 1 for success, and 0 for failure
                    Dim NumRecords As Integer = MyCommand.ExecuteNonQuery()
                    BooResult = (NumRecords = 1)

                    ' Close and dispose of the dataaReader to clear memory and close the database connection
                    MyConn.Close()

                Catch ex As Exception
                    ' Would add error logging information here
                    ' You will learn this later
                    MsgBox("ERROR: " & Err.Description, MsgBoxStyle.Critical, "delete planet by PlanetID")
                End Try

                Return BooResult
            End Function

#End Region

        End Class 'Planet

        '
        ' The following code is an adaptation of the original code provided to us by Clint MacDonald
        ' Comments have been removed to improve readibility, but otherwise the code is nearly identical
        '

        Public Class Region

            Public Class Fields
                Public Const REGION_ID As String = "RegionID"
                Public Const GALAXY_ID As String = "GalaxyID"
                Public Const REGION_NAME As String = "RegionName"
                Public Const IS_ACTIVE As String = "IsActive"
            End Class

            Public Property RegionID As Integer
            Public Property GalaxyID As Integer
            Public Property RegionName As String
            Public Property IsActive As Integer

            Public Sub New()
                RegionID = 0
                GalaxyID = 0
                RegionName = String.Empty
                IsActive = 0
            End Sub

            Public Sub New(RegionID As Integer)
                Dim R As New Region
                R = GetRecordByID(RegionID)
                RegionID = R.RegionID
                RegionName = R.RegionName
                IsActive = R.IsActive
            End Sub

            Private Class SQL_Statements
                Public Const SELECT_REGION_BY_ID As String = "SELECT RegionID, GalaxyID, RegionName, IsActive FROM datRegions WHERE RegionID = @RegionID"
                Public Const SELECT_ALL As String = "SELECT RegionID, GalaxyID, RegionName, IsActive FROM datRegions ORDER BY RegionName"
                Public Const SELECT_ALL_BY_GALAXY As String = "Select RegionID, GalaxyID, RegionName, IsActive FROM datRegions WHERE GalaxyID = @GalaxyID ORDER BY RegionName"
                Public Const INSERT_NEW As String = "INSERT INTO dbo.datRegions ('RegionName', 'GalaxyID', 'IsActive') VALUES (@RegionName, @GalaxyID, @IsActive);SELECT @@Identity;"
                Public Const UPDATE_EXISTING As String = "UPDATE datRegions SET RegionName = @RegionName, GalaxyID = @GalaxyID, IsActive = @IsActive, WHERE RegionID = @RegionID"
                Public Const DELETE_ONE As String = "DELETE FROM datRegions WHERE RegionID = @RegionID"
            End Class

            Public Shared Function GetRecordByID(RegionIDIn As Integer) As Region
                Dim R As New Region
                Dim MyConn As New SqlConnection
                MyConn.ConnectionString = Conn.getConnectionString
                Dim MyCommand As New System.Data.SqlClient.SqlCommand
                MyCommand.Connection = MyConn
                MyCommand.CommandType = CommandType.Text
                MyCommand.CommandText = SQL_Statements.SELECT_REGION_BY_ID
                MyCommand.Parameters.AddWithValue("@RegionID", RegionIDIn)
                Try
                    MyConn.Open()
                    Dim DR As IDataReader
                    DR = MyCommand.ExecuteReader()
                    If DR.Read Then
                        If Not IsDBNull(DR(Fields.REGION_ID)) Then R.RegionID = CInt(DR(Fields.REGION_ID))
                        If Not IsDBNull(DR(Fields.GALAXY_ID)) Then R.GalaxyID = CInt(DR(Fields.GALAXY_ID))
                        If Not IsDBNull(DR(Fields.REGION_NAME)) Then R.RegionName = CStr(DR(Fields.REGION_NAME))
                        If Not IsDBNull(DR(Fields.IS_ACTIVE)) Then R.IsActive = CInt(DR(Fields.IS_ACTIVE))
                    End If
                    DR.Close()
                    DR = Nothing
                    MyConn.Close()
                Catch ex As Exception
                    MsgBox("ERROR: " & Err.Description, MsgBoxStyle.Critical, "select region by RegionID")
                End Try
                Return R
            End Function 'GetRecordByID

            Public Shared Function GetAllRecords() As List(Of Region)
                Dim Regions As New List(Of Region)
                Dim MyConn As New SqlConnection
                MyConn.ConnectionString = Conn.getConnectionString
                Dim MyCommand As New System.Data.SqlClient.SqlCommand
                MyCommand.Connection = MyConn
                MyCommand.CommandType = CommandType.Text
                MyCommand.CommandText = SQL_Statements.SELECT_ALL
                Try
                    MyConn.Open()
                    Dim DR As IDataReader
                    DR = MyCommand.ExecuteReader()
                    Dim R As Region
                    Do While DR.Read
                        R = New Region
                        If Not IsDBNull(DR(Fields.REGION_ID)) Then R.RegionID = CInt(DR(Fields.REGION_ID))
                        If Not IsDBNull(DR(Fields.GALAXY_ID)) Then R.GalaxyID = CInt(DR(Fields.GALAXY_ID))
                        If Not IsDBNull(DR(Fields.REGION_NAME)) Then R.RegionName = CStr(DR(Fields.REGION_NAME))
                        If Not IsDBNull(DR(Fields.IS_ACTIVE)) Then R.IsActive = CInt(DR(Fields.IS_ACTIVE))
                        Regions.Add(R)
                    Loop
                    DR.Close()
                    DR = Nothing
                    MyConn.Close()
                Catch ex As Exception
                    MsgBox("ERROR: " & Err.Description, MsgBoxStyle.Critical, "select all regions")
                End Try
                Return Regions
            End Function 'GetAllRecords

            Public Shared Function GetAllRecordsByFK(GalaxyIDIn As Integer) As List(Of Region)
                Dim Regions As New List(Of Region)
                Dim MyConn As New SqlConnection
                MyConn.ConnectionString = Conn.getConnectionString
                Dim MyCommand As New System.Data.SqlClient.SqlCommand
                MyCommand.Connection = MyConn
                MyCommand.CommandType = CommandType.Text
                MyCommand.CommandText = SQL_Statements.SELECT_ALL_BY_GALAXY
                MyCommand.Parameters.AddWithValue("@GalaxyID", GalaxyIDIn)
                Try
                    MyConn.Open()
                    Dim DR As IDataReader
                    DR = MyCommand.ExecuteReader()
                    Dim R As Region
                    Do While DR.Read
                        R = New Region
                        If Not IsDBNull(DR(Fields.REGION_ID)) Then R.RegionID = CInt(DR(Fields.REGION_ID))
                        If Not IsDBNull(DR(Fields.GALAXY_ID)) Then R.GalaxyID = CInt(DR(Fields.GALAXY_ID))
                        If Not IsDBNull(DR(Fields.REGION_NAME)) Then R.RegionName = CStr(DR(Fields.REGION_NAME))
                        If Not IsDBNull(DR(Fields.IS_ACTIVE)) Then R.IsActive = CInt(DR(Fields.IS_ACTIVE))
                        Regions.Add(R)
                    Loop
                    DR.Close()
                    DR = Nothing
                    MyConn.Close()
                Catch ex As Exception
                    MsgBox("ERROR: " & Err.Description, MsgBoxStyle.Critical, "select all regions by GalaxyID")
                End Try
                Return Regions
            End Function 'GetAllRecordsByFK

            Public Shared Function InsertNewRecord(RegionObject As Region) As Integer
                Dim RegionID As Integer = 0
                Dim MyConn As New SqlConnection
                MyConn.ConnectionString = Conn.getConnectionString
                Dim MyCommand As New System.Data.SqlClient.SqlCommand
                MyCommand.Connection = MyConn
                MyCommand.CommandType = CommandType.Text
                MyCommand.CommandText = SQL_Statements.INSERT_NEW
                MyCommand.Parameters.AddWithValue("@" & Fields.REGION_NAME, RegionObject.RegionName)
                MyCommand.Parameters.AddWithValue("@" & Fields.GALAXY_ID, RegionObject.GalaxyID)
                MyCommand.Parameters.AddWithValue("@" & Fields.IS_ACTIVE, RegionObject.IsActive)
                Try
                    MyConn.Open()
                    RegionID = CInt(MyCommand.ExecuteScalar())
                    If -1 = RegionID Then
                        Throw (New Exception("unable to insert data"))
                    End If
                    MyConn.Close()
                Catch ex As Exception
                    MsgBox("ERROR: " & Err.Description, MsgBoxStyle.Critical, "insert new region")
                End Try
                Return RegionID
            End Function 'InsertNewRecord

            Public Shared Function UpdateExistingRecord(RegionObject As Region) As Boolean
                Dim bResult As Boolean = False
                Dim MyConn As New SqlConnection
                MyConn.ConnectionString = Conn.getConnectionString
                Dim MyCommand As New System.Data.SqlClient.SqlCommand
                MyCommand.Connection = MyConn
                MyCommand.CommandType = CommandType.Text
                MyCommand.CommandText = SQL_Statements.UPDATE_EXISTING ' Can type in SQL as string, but Const better
                MyCommand.Parameters.AddWithValue("@" & Fields.REGION_ID, RegionObject.RegionID)
                MyCommand.Parameters.AddWithValue("@" & Fields.REGION_NAME, RegionObject.RegionName)
                MyCommand.Parameters.AddWithValue("@" & Fields.GALAXY_ID, RegionObject.GalaxyID)
                MyCommand.Parameters.AddWithValue("@" & Fields.IS_ACTIVE, RegionObject.IsActive)
                Try
                    MyConn.Open()
                    Dim NumRecords As Integer = MyCommand.ExecuteNonQuery()
                    bResult = (NumRecords = 1)
                    MyConn.Close()
                Catch ex As Exception
                    MsgBox("ERROR: " & Err.Description, MsgBoxStyle.Critical, "update region")
                End Try
                Return bResult
            End Function 'UpdateExistingRecord

            Public Shared Function DeleteByID(RegionIDIn As Integer) As Boolean
                Dim bResult As Boolean = False
                Dim MyConn As New SqlConnection
                MyConn.ConnectionString = Conn.getConnectionString
                Dim MyCommand As New System.Data.SqlClient.SqlCommand
                MyCommand.Connection = MyConn
                MyCommand.CommandType = CommandType.Text
                MyCommand.CommandText = SQL_Statements.DELETE_ONE
                MyCommand.Parameters.AddWithValue("@" & Fields.REGION_ID, RegionIDIn)
                Try
                    MyConn.Open()
                    Dim NumRecords As Integer = MyCommand.ExecuteNonQuery()
                    bResult = (NumRecords = 1)
                    MyConn.Close()
                Catch ex As Exception
                    MsgBox("ERROR: " & Err.Description, MsgBoxStyle.Critical, "delete region by id")
                End Try
                Return bResult
            End Function 'DeleteByID
        End Class 'Region

        Public Class Galaxy

            Public Class Fields
                Public Const GALAXY_ID As String = "GalaxyID"
                Public Const GALAXY_NAME As String = "GalaxyName"
                Public Const IS_ACTIVE As String = "IsActive"
                Public Const GALAXY_FORMATION As String = "GalaxyFormation"
                Public Const DISTANCE As String = "Distance"
                Public Const WIDTH As String = "Width"
                Public Const IMAGE_FILE_NAME As String = "ImageFileName"
            End Class

            Public Property GalaxyID As Integer
            Public Property GalaxyName As String
            Public Property IsActive As Integer
            Public Property GalaxyFormation As String
            Public Property Distance As Integer
            Public Property Width As Integer
            Public Property ImageFileName As String

            Public Sub New()
                GalaxyID = 0
                GalaxyName = String.Empty
                IsActive = 0
                GalaxyFormation = String.Empty
                Distance = 0
                Width = 0
                ImageFileName = String.Empty
            End Sub

            Public Sub New(GalaxyID As Integer)
                Dim G As New Galaxy
                G = GetRecordByID(GalaxyID)
                GalaxyID = G.GalaxyID
                GalaxyName = G.GalaxyName
                IsActive = G.IsActive
                GalaxyFormation = G.GalaxyFormation
                Distance = G.Distance
                Width = G.Width
                ImageFileName = G.ImageFileName
            End Sub

            Private Class SQL_Statements
                Public Const SELECT_GALAXY_BY_ID As String = "SELECT GalaxyID, GalaxyName, IsActive, GalaxyFormation, Distance, Width, ImageFileName FROM datGalaxy WHERE GalaxyID = @GalaxyID"
                Public Const SELECT_ALL As String = "SELECT GalaxyID, GalaxyName, IsActive, GalaxyFormation, Distance, Width, ImageFileName FROM datGalaxy ORDER BY GalaxyName"
                Public Const SELECT_ALL_BY_FORMATION As String = "SELECT GalaxyID, GalaxyName, IsActive, GalaxyFormation, Distance, Width, ImageFileName FROM datGalaxy WHERE GalaxyFormation = @GalaxyFormation ORDER BY GalaxyName"
                Public Const INSERT_NEW As String = "INSERT INTO datGalaxy ('GalaxyName', 'IsActive', 'GalaxyFormation', 'Distance', 'Width', 'ImageFileName') VALUES (@GalaxyName, @IsActive, @GalaxyFormation, @Distance, @Width, @ImageFileName);SELECT @@Identity;"
                Public Const UPDATE_EXISTING As String = "UPDATE datGalaxy SET GalaxyName = @GalaxyName, IsActive = @IsActive, GalaxyFormation = @GalaxyFormation, Distance = @Distance, Width = @Width, ImageFileName = @ImageFileName WHERE GalaxyID = @GalaxyID"
                Public Const DELETE_ONE As String = "DELETE FROM datGalaxy WHERE GalaxyID = @GalaxyID"
            End Class

            Public Shared Function GetRecordByID(GalaxyIDIn As Integer) As Galaxy
                Dim G As New Galaxy
                Dim MyConn As New SqlConnection
                MyConn.ConnectionString = Conn.getConnectionString
                Dim MyCommand As New System.Data.SqlClient.SqlCommand
                MyCommand.Connection = MyConn
                MyCommand.CommandType = CommandType.Text
                MyCommand.CommandText = SQL_Statements.SELECT_GALAXY_BY_ID
                MyCommand.Parameters.AddWithValue("@GalaxyID", GalaxyIDIn)
                Try
                    MyConn.Open()
                    Dim DR As IDataReader
                    DR = MyCommand.ExecuteReader()
                    If DR.Read Then
                        If Not IsDBNull(DR(Fields.GALAXY_ID)) Then G.GalaxyID = CInt(DR(Fields.GALAXY_ID))
                        If Not IsDBNull(DR(Fields.GALAXY_NAME)) Then G.GalaxyName = CStr(DR(Fields.GALAXY_NAME))
                        If Not IsDBNull(DR(Fields.IS_ACTIVE)) Then G.IsActive = CInt(DR(Fields.IS_ACTIVE))
                        If Not IsDBNull(DR(Fields.GALAXY_FORMATION)) Then G.GalaxyFormation = CStr(DR(Fields.GALAXY_FORMATION))
                        If Not IsDBNull(DR(Fields.DISTANCE)) Then G.Distance = CInt(DR(Fields.DISTANCE))
                        If Not IsDBNull(DR(Fields.WIDTH)) Then G.Width = CInt(DR(Fields.WIDTH))
                        If Not IsDBNull(DR(Fields.IMAGE_FILE_NAME)) Then G.ImageFileName = CStr(DR(Fields.IMAGE_FILE_NAME))
                    End If
                    DR.Close()
                    DR = Nothing
                    MyConn.Close()
                Catch ex As Exception
                    MsgBox("ERROR: " & Err.Description, MsgBoxStyle.Critical, "select galaxy by GalaxyID")
                End Try
                Return G
            End Function 'GetRecordByID

            Public Shared Function GetAllRecords() As List(Of Galaxy)
                Dim Galaxies As New List(Of Galaxy)
                Dim MyConn As New SqlConnection
                MyConn.ConnectionString = Conn.getConnectionString
                Dim MyCommand As New System.Data.SqlClient.SqlCommand
                MyCommand.Connection = MyConn
                MyCommand.CommandType = CommandType.Text
                MyCommand.CommandText = SQL_Statements.SELECT_ALL
                Try
                    MyConn.Open()
                    Dim DR As IDataReader
                    DR = MyCommand.ExecuteReader()
                    Dim G As Galaxy
                    Do While DR.Read
                        G = New Galaxy
                        If Not IsDBNull(DR(Fields.GALAXY_ID)) Then G.GalaxyID = CInt(DR(Fields.GALAXY_ID))
                        If Not IsDBNull(DR(Fields.GALAXY_NAME)) Then G.GalaxyName = CStr(DR(Fields.GALAXY_NAME))
                        If Not IsDBNull(DR(Fields.IS_ACTIVE)) Then G.IsActive = CInt(DR(Fields.IS_ACTIVE))
                        If Not IsDBNull(DR(Fields.GALAXY_FORMATION)) Then G.GalaxyFormation = CStr(DR(Fields.GALAXY_FORMATION))
                        If Not IsDBNull(DR(Fields.DISTANCE)) Then G.Distance = CInt(DR(Fields.DISTANCE))
                        If Not IsDBNull(DR(Fields.WIDTH)) Then G.Width = CInt(DR(Fields.WIDTH))
                        If Not IsDBNull(DR(Fields.IMAGE_FILE_NAME)) Then G.ImageFileName = CStr(DR(Fields.IMAGE_FILE_NAME))
                        Galaxies.Add(G)
                    Loop
                    DR.Close()
                    DR = Nothing
                    MyConn.Close()
                Catch ex As Exception
                    MsgBox("ERROR: " & Err.Description, MsgBoxStyle.Critical, "select all galaxies")
                End Try
                Return Galaxies
            End Function 'GetAllRecords

            Public Shared Function GetAllRecordsByFormation(Formation As String) As List(Of Galaxy)
                Dim Galaxies As New List(Of Galaxy)
                Dim MyConn As New SqlConnection
                MyConn.ConnectionString = Conn.getConnectionString
                Dim MyCommand As New System.Data.SqlClient.SqlCommand
                MyCommand.Connection = MyConn
                MyCommand.CommandType = CommandType.Text
                MyCommand.CommandText = SQL_Statements.SELECT_ALL_BY_FORMATION
                MyCommand.Parameters.AddWithValue("@GalaxyFormation", Formation)
                Try
                    MyConn.Open()
                    Dim DR As IDataReader
                    DR = MyCommand.ExecuteReader()
                    Dim G As Galaxy
                    Do While DR.Read
                        G = New Galaxy
                        If Not IsDBNull(DR(Fields.GALAXY_ID)) Then G.GalaxyID = CInt(DR(Fields.GALAXY_ID))
                        If Not IsDBNull(DR(Fields.GALAXY_NAME)) Then G.GalaxyName = CStr(DR(Fields.GALAXY_NAME))
                        If Not IsDBNull(DR(Fields.IS_ACTIVE)) Then G.IsActive = CInt(DR(Fields.IS_ACTIVE))
                        If Not IsDBNull(DR(Fields.GALAXY_FORMATION)) Then G.GalaxyFormation = CStr(DR(Fields.GALAXY_FORMATION))
                        If Not IsDBNull(DR(Fields.DISTANCE)) Then G.Distance = CInt(DR(Fields.DISTANCE))
                        If Not IsDBNull(DR(Fields.WIDTH)) Then G.Width = CInt(DR(Fields.WIDTH))
                        If Not IsDBNull(DR(Fields.IMAGE_FILE_NAME)) Then G.ImageFileName = CStr(DR(Fields.IMAGE_FILE_NAME))
                        Galaxies.Add(G)
                    Loop
                    DR.Close()
                    DR = Nothing
                    MyConn.Close()
                Catch ex As Exception
                    MsgBox("ERROR: " & Err.Description, MsgBoxStyle.Critical, "select galaxies by formation")
                End Try
                Return Galaxies
            End Function 'GetAllRecordsByFormation

            Public Shared Function InsertNewRecord(GalaxyObject As Galaxy) As Integer
                Dim GalaxyID As Int32 = 0
                Dim MyConn As New SqlConnection
                MyConn.ConnectionString = Conn.getConnectionString
                Dim MyCommand As New System.Data.SqlClient.SqlCommand
                MyCommand.Connection = MyConn
                MyCommand.CommandType = CommandType.Text
                MyCommand.CommandText = SQL_Statements.INSERT_NEW
                MyCommand.Parameters.AddWithValue("@" & Fields.GALAXY_NAME, GalaxyObject.GalaxyName)
                MyCommand.Parameters.AddWithValue("@" & Fields.IS_ACTIVE, GalaxyObject.IsActive)
                MyCommand.Parameters.AddWithValue("@" & Fields.GALAXY_FORMATION, GalaxyObject.GalaxyFormation)
                MyCommand.Parameters.AddWithValue("@" & Fields.DISTANCE, GalaxyObject.Distance)
                MyCommand.Parameters.AddWithValue("@" & Fields.WIDTH, GalaxyObject.Width)
                MyCommand.Parameters.AddWithValue("@" & Fields.IMAGE_FILE_NAME, GalaxyObject.ImageFileName)
                Try
                    MyConn.Open()
                    GalaxyID = CInt(MyCommand.ExecuteScalar())
                    If -1 = GalaxyID Then
                        Throw (New Exception("unable to insert data"))
                    End If
                    MyConn.Close()
                Catch ex As Exception
                    MsgBox("ERROR: " & Err.Description, MsgBoxStyle.Critical, "insert new galaxy")
                End Try
                Return GalaxyID
            End Function 'InsertNewRecord

            Public Shared Function UpdateExistingRecord(GalaxyObject As Galaxy) As Boolean
                Dim bResult As Boolean = False
                Dim MyConn As New SqlConnection
                MyConn.ConnectionString = Conn.getConnectionString
                Dim MyCommand As New System.Data.SqlClient.SqlCommand
                MyCommand.Connection = MyConn
                MyCommand.CommandType = CommandType.Text
                MyCommand.CommandText = SQL_Statements.UPDATE_EXISTING
                MyCommand.Parameters.AddWithValue("@" & Fields.GALAXY_ID, GalaxyObject.GalaxyID)
                MyCommand.Parameters.AddWithValue("@" & Fields.GALAXY_NAME, GalaxyObject.GalaxyName)
                MyCommand.Parameters.AddWithValue("@" & Fields.IS_ACTIVE, GalaxyObject.IsActive)
                MyCommand.Parameters.AddWithValue("@" & Fields.GALAXY_FORMATION, GalaxyObject.GalaxyFormation)
                MyCommand.Parameters.AddWithValue("@" & Fields.DISTANCE, GalaxyObject.Distance)
                MyCommand.Parameters.AddWithValue("@" & Fields.WIDTH, GalaxyObject.Width)
                MyCommand.Parameters.AddWithValue("@" & Fields.IMAGE_FILE_NAME, GalaxyObject.ImageFileName)
                Try
                    MyConn.Open()
                    Dim NumRecords As Integer = MyCommand.ExecuteNonQuery()
                    bResult = (NumRecords = 1)
                    MyConn.Close()
                Catch ex As Exception
                    MsgBox("ERROR: " & Err.Description, MsgBoxStyle.Critical, "update galaxy")
                End Try
                Return bResult
            End Function 'UpdateExistingRecord

            Public Shared Function DeleteByID(GalaxyIDIn As Integer) As Boolean
                Dim bResult As Boolean = False
                Dim MyConn As New SqlConnection
                MyConn.ConnectionString = Conn.getConnectionString
                Dim MyCommand As New System.Data.SqlClient.SqlCommand
                MyCommand.Connection = MyConn
                MyCommand.CommandType = CommandType.Text
                MyCommand.CommandText = SQL_Statements.DELETE_ONE
                MyCommand.Parameters.AddWithValue("@" & Fields.GALAXY_ID, GalaxyIDIn)
                Try
                    MyConn.Open()
                    Dim NumRecords As Integer = MyCommand.ExecuteNonQuery()
                    bResult = (NumRecords = 1)
                    MyConn.Close()
                Catch ex As Exception
                    MsgBox("ERROR: " & Err.Description, MsgBoxStyle.Critical, "delete galaxy by id")
                End Try
                Return bResult
            End Function 'DeleteByID

        End Class 'Galaxy

        Public Class Alliance
            Public Class Fields
                Public Const ALLIANCE_ID As String = "AllianceID"
                Public Const ALLIANCE_NAME As String = "AllianceName"
                Public Const IS_ACTIVE As String = "IsActive"
                Public Const GALAXY_ID As String = "GalaxyID"
            End Class

            Public Property AllianceID As Integer
            Public Property AllianceName As String
            Public Property IsActive As Integer
            Public Property GalaxyID As Integer

            Public Sub New()
                AllianceID = 0
                AllianceName = String.Empty
                GalaxyID = 0
                IsActive = 0
            End Sub

            Public Sub New(AllianceID As Integer)
                Dim A As New Alliance
                A = GetRecordByID(AllianceID)
                AllianceID = A.AllianceID
                AllianceName = A.AllianceName
                IsActive = A.IsActive
                GalaxyID = A.GalaxyID
            End Sub

            Private Class SQL_Statements
                Public Const SELECT_ALLIANCE_BY_ID As String = "SELECT AllianceID, AllianceName, IsActive, GalaxyID FROM datAlliance WHERE AllianceID = @AllianceID"
                Public Const SELECT_ALL As String = "SELECT AllianceID, AllianceName, IsActive, GalaxyID FROM datAlliance ORDER BY AllianceName"
                Public Const SELECT_ALL_BY_GALAXY As String = "SELECT AllianceID, AllianceName, IsActive, GalaxyID FROM datRegions WHERE GalaxyID = @GalaxyID ORDER BY AllianceName"
                Public Const INSERT_NEW As String = "INSERT INTO datAlliance ('AllianceName', 'IsActive', 'GalaxyID') VALUES (@AllianceName, @IsActive, @GalaxyID);SELECT @@Identity;"
                Public Const UPDATE_EXISTING As String = "UPDATE datAlliance SET AllianceName = @AllianceName, IsActive = @IsActive, GalaxyID = @GalaxyID WHERE AllianceID = @AllianceID"
                Public Const DELETE_ONE As String = "DELETE FROM datAlliance WHERE AllianceID = @AllianceID"
            End Class

            Public Shared Function GetRecordByID(AllianceIDIn As Integer) As Alliance
                Dim A As New Alliance
                Dim MyConn As New SqlConnection
                MyConn.ConnectionString = Conn.getConnectionString
                Dim MyCommand As New System.Data.SqlClient.SqlCommand
                MyCommand.Connection = MyConn
                MyCommand.CommandType = CommandType.Text
                MyCommand.CommandText = SQL_Statements.SELECT_ALLIANCE_BY_ID
                MyCommand.Parameters.AddWithValue("@AllianceID", AllianceIDIn)
                Try
                    MyConn.Open()
                    Dim DR As IDataReader
                    DR = MyCommand.ExecuteReader()
                    If DR.Read Then
                        If Not IsDBNull(DR(Fields.ALLIANCE_ID)) Then A.AllianceID = CInt(DR(Fields.ALLIANCE_ID))
                        If Not IsDBNull(DR(Fields.ALLIANCE_NAME)) Then A.AllianceName = CStr(DR(Fields.ALLIANCE_NAME))
                        If Not IsDBNull(DR(Fields.IS_ACTIVE)) Then A.IsActive = CInt(DR(Fields.IS_ACTIVE))
                        If Not IsDBNull(DR(Fields.GALAXY_ID)) Then A.GalaxyID = CInt(DR(Fields.GALAXY_ID))
                    End If
                    DR.Close()
                    DR = Nothing
                    MyConn.Close()
                Catch ex As Exception
                    MsgBox("ERROR: " & Err.Description, MsgBoxStyle.Critical, "select alliance by AllianceID")
                End Try
                Return A
            End Function 'GetRecordByID

            Public Shared Function GetAllRecords() As List(Of Alliance)
                Dim Alliances As New List(Of Alliance)
                Dim MyConn As New SqlConnection
                MyConn.ConnectionString = Conn.getConnectionString
                Dim MyCommand As New System.Data.SqlClient.SqlCommand
                MyCommand.Connection = MyConn
                MyCommand.CommandType = CommandType.Text
                MyCommand.CommandText = SQL_Statements.SELECT_ALL
                Try
                    MyConn.Open()
                    Dim DR As IDataReader
                    DR = MyCommand.ExecuteReader()
                    Dim A As Alliance
                    Do While DR.Read
                        A = New Alliance
                        If Not IsDBNull(DR(Fields.ALLIANCE_ID)) Then A.AllianceID = CInt(DR(Fields.ALLIANCE_ID))
                        If Not IsDBNull(DR(Fields.ALLIANCE_NAME)) Then A.AllianceName = CStr(DR(Fields.ALLIANCE_NAME))
                        If Not IsDBNull(DR(Fields.IS_ACTIVE)) Then A.IsActive = CInt(DR(Fields.IS_ACTIVE))
                        If Not IsDBNull(DR(Fields.GALAXY_ID)) Then A.GalaxyID = CInt(DR(Fields.GALAXY_ID))
                        Alliances.Add(A)
                    Loop
                    DR.Close()
                    DR = Nothing
                    MyConn.Close()
                Catch ex As Exception
                    MsgBox("ERROR: " & Err.Description, MsgBoxStyle.Critical, "select all alliances")
                End Try
                Return Alliances
            End Function 'GetAllRecords

            Public Shared Function GetAllRecordsByFK(GalaxyIDIn As Integer) As List(Of Alliance)
                Dim Alliances As New List(Of Alliance)
                Dim MyConn As New SqlConnection
                MyConn.ConnectionString = Conn.getConnectionString
                Dim MyCommand As New System.Data.SqlClient.SqlCommand
                MyCommand.Connection = MyConn
                MyCommand.CommandType = CommandType.Text
                MyCommand.CommandText = SQL_Statements.SELECT_ALL_BY_GALAXY
                MyCommand.Parameters.AddWithValue("@GalaxyID", GalaxyIDIn)
                Try
                    MyConn.Open()
                    Dim DR As IDataReader
                    DR = MyCommand.ExecuteReader()
                    Dim A As Alliance
                    Do While DR.Read
                        A = New Alliance
                        If Not IsDBNull(DR(Fields.ALLIANCE_ID)) Then A.AllianceID = CInt(DR(Fields.ALLIANCE_ID))
                        If Not IsDBNull(DR(Fields.ALLIANCE_NAME)) Then A.AllianceName = CStr(DR(Fields.ALLIANCE_NAME))
                        If Not IsDBNull(DR(Fields.IS_ACTIVE)) Then A.IsActive = CInt(DR(Fields.IS_ACTIVE))
                        If Not IsDBNull(DR(Fields.GALAXY_ID)) Then A.GalaxyID = CInt(DR(Fields.GALAXY_ID))
                        Alliances.Add(A)
                    Loop
                    DR.Close()
                    DR = Nothing
                    MyConn.Close()
                Catch ex As Exception
                    MsgBox("ERROR: " & Err.Description, MsgBoxStyle.Critical, "select all alliances by GalaxyID")
                End Try
                Return Alliances
            End Function 'GetAllRecordsByFk

            Public Shared Function InsertNewRecord(AllianceObject As Alliance) As Integer
                Dim AllianceID As Integer = 0
                Dim MyConn As New SqlConnection
                MyConn.ConnectionString = Conn.getConnectionString
                Dim MyCommand As New System.Data.SqlClient.SqlCommand
                MyCommand.Connection = MyConn
                MyCommand.CommandType = CommandType.Text
                MyCommand.CommandText = SQL_Statements.INSERT_NEW
                MyCommand.Parameters.AddWithValue("@" & Fields.ALLIANCE_NAME, AllianceObject.AllianceName)
                MyCommand.Parameters.AddWithValue("@" & Fields.IS_ACTIVE, AllianceObject.IsActive)
                MyCommand.Parameters.AddWithValue("@" & Fields.GALAXY_ID, AllianceObject.GalaxyID)
                Try
                    MyConn.Open()
                    AllianceID = CInt(MyCommand.ExecuteScalar())
                    If -1 = AllianceID Then
                        Throw (New Exception("unable to insert data"))
                    End If
                    MyConn.Close()
                Catch ex As Exception
                    MsgBox("ERROR: " & Err.Description, MsgBoxStyle.Critical, "insert new alliance")
                End Try
                Return AllianceID
            End Function 'InsertNewRecord

            Public Shared Function UpdateExistingRecord(AllianceObject As Alliance) As Boolean
                Dim bResult As Boolean = False
                Dim MyConn As New SqlConnection
                MyConn.ConnectionString = Conn.getConnectionString
                Dim MyCommand As New System.Data.SqlClient.SqlCommand
                MyCommand.Connection = MyConn
                MyCommand.CommandType = CommandType.Text
                MyCommand.CommandText = SQL_Statements.UPDATE_EXISTING
                MyCommand.Parameters.AddWithValue("@" & Fields.ALLIANCE_ID, AllianceObject.AllianceID)
                MyCommand.Parameters.AddWithValue("@" & Fields.ALLIANCE_NAME, AllianceObject.AllianceName)
                MyCommand.Parameters.AddWithValue("@" & Fields.GALAXY_ID, AllianceObject.GalaxyID)
                MyCommand.Parameters.AddWithValue("@" & Fields.IS_ACTIVE, AllianceObject.IsActive)
                Try
                    MyConn.Open()
                    Dim NumRecords As Integer = MyCommand.ExecuteNonQuery()
                    bResult = (NumRecords = 1)
                    MyConn.Close()
                Catch ex As Exception
                    MsgBox("ERROR: " & Err.Description, MsgBoxStyle.Critical, "update alliance")
                End Try
                Return bResult
            End Function 'UpdateExistingRecord

            Public Shared Function DeleteByID(AllianceIDIn As Integer) As Boolean
                Dim bResult As Boolean = False
                Dim MyConn As New SqlConnection
                MyConn.ConnectionString = Conn.getConnectionString
                Dim MyCommand As New System.Data.SqlClient.SqlCommand
                MyCommand.Connection = MyConn
                MyCommand.CommandType = CommandType.Text
                MyCommand.CommandText = SQL_Statements.DELETE_ONE
                MyCommand.Parameters.AddWithValue("@" & Fields.ALLIANCE_ID, AllianceIDIn)
                Try
                    MyConn.Open()
                    Dim NumRecords As Integer = MyCommand.ExecuteNonQuery()
                    bResult = (NumRecords = 1)
                    MyConn.Close()
                Catch ex As Exception
                    MsgBox("ERROR: " & Err.Description, MsgBoxStyle.Critical, "delete alliance by id")
                End Try
                Return bResult
            End Function 'DeleteByID

        End Class

        End Class 'Tables
End Class 'DBL
