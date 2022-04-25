Public Class FrBase
    Inherits Form
    'Public Shared lstFormAffichable As Hashtable

    'Public Shared Utilisateur As String
    'Public Shared Pwd As String
    Public Shared Autorisation As String
    'Public Shared nUtilisateur As Integer = -1
    Public Shared LstAutorisation As New Hashtable

    Public ds As DataSet
    Public id As Object
    Public AjouterEnregistrement As Boolean
    Public FiltreType As String = ""
    Private components As System.ComponentModel.IContainer
    Public FiltrePlus As String = ""
    Public Event SelectObject(ByVal nKey As Object)

    Public Sub OnSelectObject(ByVal nKey As Object)
        RaiseEvent SelectObject(nKey)
    End Sub

    Public Sub SetDataMove(ByRef momDataset As System.Data.DataSet, ByVal nouveau As Boolean)
        ds = momDataset
        AjouterEnregistrement = nouveau
    End Sub

    Public Sub SetDataMove(ByRef momDataset As System.Data.DataSet, ByVal idSouhaite As Object)
        ds = momDataset
        id = idSouhaite
    End Sub

    Public Sub New()
        MyBase.New()
        InitializeComponent()
    End Sub
    Public WithEvents ImageList16 As System.Windows.Forms.ImageList
    Public WithEvents ImageList32 As System.Windows.Forms.ImageList
    Public WithEvents ImageList24 As System.Windows.Forms.ImageList

    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrBase))
        Me.ImageList16 = New System.Windows.Forms.ImageList(Me.components)
        Me.ImageList24 = New System.Windows.Forms.ImageList(Me.components)
        Me.ImageList32 = New System.Windows.Forms.ImageList(Me.components)
        Me.SuspendLayout()
        '
        'ImageList16
        '
        Me.ImageList16.ImageStream = CType(resources.GetObject("ImageList16.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList16.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList16.Images.SetKeyName(0, "")
        '
        'ImageList24
        '
        Me.ImageList24.ImageStream = CType(resources.GetObject("ImageList24.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList24.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList24.Images.SetKeyName(0, "")
        Me.ImageList24.Images.SetKeyName(1, "")
        Me.ImageList24.Images.SetKeyName(2, "")
        Me.ImageList24.Images.SetKeyName(3, "")
        Me.ImageList24.Images.SetKeyName(4, "")
        Me.ImageList24.Images.SetKeyName(5, "")
        Me.ImageList24.Images.SetKeyName(6, "")
        Me.ImageList24.Images.SetKeyName(7, "")
        Me.ImageList24.Images.SetKeyName(8, "")
        Me.ImageList24.Images.SetKeyName(9, "")
        Me.ImageList24.Images.SetKeyName(10, "")
        Me.ImageList24.Images.SetKeyName(11, "")
        Me.ImageList24.Images.SetKeyName(12, "")
        Me.ImageList24.Images.SetKeyName(13, "")
        Me.ImageList24.Images.SetKeyName(14, "")
        '
        'ImageList32
        '
        Me.ImageList32.ImageStream = CType(resources.GetObject("ImageList32.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList32.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList32.Images.SetKeyName(0, "")
        Me.ImageList32.Images.SetKeyName(1, "")
        Me.ImageList32.Images.SetKeyName(2, "")
        Me.ImageList32.Images.SetKeyName(3, "")
        Me.ImageList32.Images.SetKeyName(4, "")
        Me.ImageList32.Images.SetKeyName(5, "")
        Me.ImageList32.Images.SetKeyName(6, "")
        Me.ImageList32.Images.SetKeyName(7, "")
        Me.ImageList32.Images.SetKeyName(8, "")
        Me.ImageList32.Images.SetKeyName(9, "")
        Me.ImageList32.Images.SetKeyName(10, "")
        Me.ImageList32.Images.SetKeyName(11, "")
        '
        'FrBase
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Name = "FrBase"
        Me.ResumeLayout(False)

    End Sub

    Private Sub FrBase_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim fr As New Form
        If fr.Icon.Handle.Equals(Me.Icon.Handle) Then
            Dim frParent As Form = Me.MdiParent
            If frParent Is Nothing Then
                frParent = Me.Owner
            End If
            If Not frParent Is Nothing Then
                Me.Icon = CType(frParent.Icon.Clone, Icon)
            End If
        End If
        
    End Sub
End Class

