Public Class SqlConnectionConfig

    Public Shadows Event Validated As EventHandler

    Private _builder As New ConnectionStringBuilderWrapper
    Public Property ConnectionStringBuilder() As ConnectionStringBuilderWrapper
        Get
            Return _builder
        End Get
        Set(ByVal value As ConnectionStringBuilderWrapper)
            _builder = value
        End Set
    End Property

    Private Sub SqlConnectionConfig_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        _connStringCache = ConnectionStringBuilder.ConnectionString
        AddHandler ConnectionStringBuilder.ValueChanged, AddressOf ConnectionStringChanged
        Me.ConnectionStringBuilderWrapperBindingSource.DataSource = Me.ConnectionStringBuilder
    End Sub

    Private _connStringCache As String = ""
    Private Sub ConnectionStringChanged(ByVal sender As Object, ByVal e As EventArgs)
        If _connStringCache <> DirectCast(sender, ConnectionStringBuilderWrapper).ConnectionString Then
            RaiseEvent Validated(Me, EventArgs.Empty)
            Me.ConnectionStringBuilderWrapperBindingSource.ResetCurrentItem()
        End If
    End Sub

    Private Sub LoginTextBox_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoginTextBox.Validated
        If LoginTextBox.Text.Length = 0 Then
            PasswordTextBox.Text = ""
            PasswordTextBox.Enabled = False
        Else
            PasswordTextBox.Enabled = True
        End If
    End Sub

    Private Sub ServerComboBox_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ServerComboBox.Validating
        If ServerComboBox.Text <> Me.ConnectionStringBuilder.Server Then
            DatabaseComboBox.Items.Clear()
        End If
    End Sub

    Private Sub DatabaseComboBox_DropDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DatabaseComboBox.DropDown
        With DatabaseComboBox
            If .Items.Count = 0 Then
                Me.Cursor = Cursors.WaitCursor
                Application.DoEvents()
                Try
                    Dim builder As New SqlClient.SqlConnectionStringBuilder(Me.ConnectionStringBuilder.ConnectionString)
                    builder.InitialCatalog = "master"
                    Using sql As New SqlProxy(builder.ConnectionString)
                        Using dr As SqlClient.SqlDataReader = sql.ExecuteReader("select name from sysdatabases where dbid>4 order by name")
                            .BeginUpdate()
                            With .Items
                                .Clear()
                                While dr.Read
                                    .Add(dr("name"))
                                End While
                            End With
                        End Using
                        .EndUpdate()
                    End Using
                Catch ex As SqlClient.SqlException
                    MsgBox(ex.Message, MsgBoxStyle.Exclamation)
                Finally
                    Me.Cursor = Cursors.Default
                End Try
            End If
        End With
    End Sub

    Private Sub ServerComboBox_DropDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ServerComboBox.DropDown
        With ServerComboBox
            If .Items.Count = 0 Then
                Me.Cursor = Cursors.WaitCursor
                Application.DoEvents()
                Try
                    Dim dt As DataTable = Sql.SqlDataSourceEnumerator.Instance.GetDataSources
                    .BeginUpdate()
                    With .Items
                        .Clear()
                        For Each dr As DataRow In dt.Rows
                            If Convert.ToString(dr("InstanceName")).Length = 0 Then
                                .Add(String.Format("{0}", dr("ServerName")))
                            Else
                                .Add(String.Format("{0}\{1}", dr("ServerName"), dr("InstanceName")))
                            End If
                        Next
                    End With
                    .EndUpdate()
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Exclamation)
                Finally
                    Me.Cursor = Cursors.Default
                End Try
            End If
        End With
    End Sub

    Private Sub BtTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtTest.Click
        Me.Cursor = Cursors.WaitCursor
        Application.DoEvents()
        Try
            If SqlProxy.TestConnection(Me.ConnectionStringBuilder.ConnectionString) Then
                MsgBox("Connexion réussie", MsgBoxStyle.Information)
            End If
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
End Class

Public Class ConnectionStringBuilderWrapper
    Private _builder As New SqlClient.SqlConnectionStringBuilder

    Public Event ValueChanged As EventHandler

    Public Property Server() As String
        Get
            Return _builder.DataSource
        End Get
        Set(ByVal value As String)
            If value <> _builder.DataSource Then
                _builder.DataSource = value
                RaiseEvent ValueChanged(Me, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property Database() As String
        Get
            Return _builder.InitialCatalog
        End Get
        Set(ByVal value As String)
            If value <> _builder.InitialCatalog Then
                _builder.InitialCatalog = value
                RaiseEvent ValueChanged(Me, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property Login() As String
        Get
            Return _builder.UserID
        End Get
        Set(ByVal value As String)
            If value <> _builder.UserID Then
                _builder.IntegratedSecurity = (value Is Nothing OrElse value.Length = 0)
                _builder.UserID = value
                RaiseEvent ValueChanged(Me, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property Password() As String
        Get
            Return _builder.Password
        End Get
        Set(ByVal value As String)
            If value <> _builder.Password Then
                _builder.Password = value
                RaiseEvent ValueChanged(Me, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property ConnectionString() As String
        Get
            Return _builder.ConnectionString
        End Get
        Set(ByVal value As String)
            If value <> _builder.ConnectionString Then
                _builder.ConnectionString = value
                RaiseEvent ValueChanged(Me, EventArgs.Empty)
            End If
        End Set
    End Property


End Class