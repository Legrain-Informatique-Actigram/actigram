Namespace Utilitaires
    Public Class ConnectionStringBuilderWrapper

        Private _builder As New SqlClient.SqlConnectionStringBuilder

        Public Event ValueChanged As EventHandler

#Region "Propriétés"
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
                    If _builder.UserID Is Nothing OrElse _builder.UserID.Length = 0 Then
                        _builder.IntegratedSecurity = True
                    End If
                    RaiseEvent ValueChanged(Me, EventArgs.Empty)
                End If
            End Set
        End Property
#End Region

    End Class
End Namespace
